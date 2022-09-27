using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    public PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    private float walkSpeed = 5f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    public float jump = 5.0f;
    
    //Jump
    Rigidbody rb;
    private float distanceToGround;
    private bool isGrounded = true;

    Animator playerAnimator;
    private bool isRunning = false;


    //Projectile Bullets
    public GameObject bullet;
    public Transform projectilePos;

    

    // Start is called before the first frame update
    void Awake()
    {

        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntex => move = cntex.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntex => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntex =>Jump();
        inputAction.Player.Shoot.performed += cntex => Shoot();

        inputAction.Player.Run.performed += cntex => isRunning = true;
        inputAction.Player.Run.canceled += cntex => isRunning = false;

        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        inputAction.Player.Move.performed += cntex => playerAnimator.SetBool("IsWalking", true);
        inputAction.Player.Move.canceled += cntex => playerAnimator.SetBool("IsWalking", false);

        distanceToGround = 0.3f;
    }

    private void OnEnable()
    {
        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    private void Jump()
    {
      
        if (isGrounded)
        {
            playerAnimator.ResetTrigger("Jumped");
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
            playerAnimator.SetTrigger("Jumped");
        }
    }

    public void Shoot()
    {
        playerAnimator.ResetTrigger("Shooting");
        Rigidbody bulletRB = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRB.AddForce(transform.forward * 37f, ForceMode.Impulse);
        //bulletRB.AddForce(transform.up * 5f, ForceMode.Impulse);
        playerAnimator.SetTrigger("Shooting");
    }

    

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            walkSpeed = 9.5f;
            playerAnimator.SetBool("IsRunning", true);
        }
        else
        {
            walkSpeed = 5f;
            playerAnimator.SetBool("IsRunning", false);
        }

        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);

        Debug.DrawRay(transform.position, Vector3.down * distanceToGround);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToGround);
        playerAnimator.SetBool("IsGrounded", isGrounded);

        if (move.x < 0) //Left Direction
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            transform.Translate(Vector3.forward * -move.x * Time.deltaTime * walkSpeed, Space.Self);
        }
        else if (move.x > 0) //Right Direction
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.Translate(Vector3.forward * move.x * Time.deltaTime * walkSpeed, Space.Self);
        }

    }
}
