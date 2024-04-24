using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CapsuleCollider CapsuleCol;
    private Animator anim;
    private string currAnim;
    private string attk;
    private bool isAttacking;
    private bool isHurt;
    private bool isBlocking;
    public bool isGrounded = false; // is true after an attack strikes
    public bool isRecovering = false; // repairing shield
    public bool isFainting; // fake attack
    public bool isCharging; // charge attack
    public bool chargeRelease; // after charge attack
    [Space]
    public LayerMask groundLayers;
    [Space]
    private float xAxis;
    public float movementSpeed = 3f;
    public float jumpForce = 2f;
    [Space]
    [SerializeField]
    private float attackDelay;
    
    const string PLAYER_IDLE = "knightIdle";
    const string PLAYER_WALK = "knightWalk";
    const string PLAYER_RUN = "knightRun";
    const string PLAYER_DEAD = "knightDead";
    const string PLAYER_HURT = "knightHurt";
    const string PLAYER_BLOCK = "knightBlock";
    const string PLAYER_FEINT = "knightFeint";
    const string PLAYER_ATTACK1 = "knight1Attk"; 
    const string PLAYER_ATTACK2 = "knight2Attk";
    const string PLAYER_ATTACK3 = "knight3Attk";

    #region Private_Variables

    private new Rigidbody rigidbody;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        CapsuleCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.MovePosition(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0) * movementSpeed * Time.deltaTime);
        CheckInGround();
        Movesets();
    }

    void CheckInGround()
    {
        isGrounded = Physics.CheckSphere(transform.position + new Vector3(0, 0f), 0.1f, groundLayers, QueryTriggerInteraction.Ignore);
    }

    public void Movesets()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        //consumables
        //wind orb
        if (Input.GetKeyDown(Keycode.U))
        {

        }

        //healing tincture
        if (Input.GetKeyDown(Keycode.I))
        {

        }

        //smoke bomb
        if (Input.GetKeyDown(Keycode.O))
        {

        }

        //attacks
        //1strike
        if (Input.GetKeyDown(Keycode.J))
        {

        }

        //2strike
        if (Input.GetKeyDown(Keycode.K))
        {

        }

        //3strike
        if (Input.GetKeyDown(Keycode.L))
        {

        }

        //blocking or parry
        if (Input.GetKeyDown(Keycode.Space))
        {

        }

        //feint

    }


    /*    private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0f), 1f);
        }*/
}
