using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private CapsuleCollider CapsuleCol;
    public bool isGrounded = false; // is true after an attack strikes
    public bool isRecovering = false; // repairing shield
    [Space]
    public LayerMask groundLayers;
    [Space]
    public float movementSpeed = 3f;
    public float jumpForce = 2f;

    #region Private_Variables

    private new Rigidbody rigidbody;
    private ComboCombat comboCombat;
    private Animator anim;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        comboCombat = GetComponent<ComboCombat>();
        //CapsuleCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (comboCombat.onAttack || comboCombat.onBlock)
            return;

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        rigidbody.MovePosition(transform.position + move * movementSpeed * Time.deltaTime);
        CheckInGround();
        anim.SetBool("Walk", move != Vector3.zero);
    }

    void CheckInGround()
    {
        isGrounded = Physics.CheckSphere(transform.position + new Vector3(0, 0f), 0.1f, groundLayers, QueryTriggerInteraction.Ignore);
    }
}
