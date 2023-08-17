using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float speed;
    public float rotationspeed;
    public float jumpSpeed;

    private float ySpeed;
    private Animator animator;
    private CharacterController CharacterController;
    public Transform cam;

    public float turnSmoothTime = 0.1f;
    float  turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float input_horizontal = Input.GetAxis("Horizontal");
        float input_vertical = Input.GetAxis("Vertical");

        Vector3 direcao_movimento = new Vector3(input_horizontal, 0, input_vertical);

        float magnitude = Mathf.Clamp01(direcao_movimento.magnitude) * speed;
        direcao_movimento.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;
        
        Vector3 velocity = direcao_movimento * magnitude;
        velocity.y = ySpeed;

        if(CharacterController.isGrounded)
        {
            ySpeed = -0.5f;
        
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
                CharacterController.Move(velocity * Time.deltaTime);
            }

        }

        if(direcao_movimento != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            float targetAngle = Mathf.Atan2(direcao_movimento.x, direcao_movimento.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            CharacterController.Move(moveDir.normalized* speed * Time.deltaTime);
        } 
        else 
        {
            animator.SetBool("isWalking", false);
        }

    }
}
