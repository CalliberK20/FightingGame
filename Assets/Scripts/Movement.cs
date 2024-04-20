using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isGrounded = false;
    public bool isCrouching = false;
    public LayerMask groundLayers;
    [Space]
    public float movementSpeed = 3f;
    public float jumpForce = 2f;

    #region Private_Variables

    private new Rigidbody rigidbody;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.MovePosition(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0) * movementSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigidbody.AddForce(transform.up * jumpForce);
        }

        isCrouching = Input.GetKey(KeyCode.S) && isGrounded;

        if(isCrouching)
        {
            //For Crouching
        }

        CheckInGround();
    }

    void CheckInGround()
    {
        isGrounded = Physics.CheckSphere(transform.position + new Vector3(0, 0f), 0.1f, groundLayers, QueryTriggerInteraction.Ignore);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0f), 0.1f);
    }
}
