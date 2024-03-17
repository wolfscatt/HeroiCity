using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float jumpForce = 7;
    public float speed ;
    public float horizontalInput;
    public float verticalInput;

    private bool jump;
    private bool grounded = true;

    private Vector3 charPos;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Camera camera;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        camera = Camera.main;
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpForce = 8;
    }

    private void FixedUpdate()
    {
        
        rigidbody2D.velocity = new Vector2(speed * horizontalInput, rigidbody2D.velocity.y);
        if (jump)
        {
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
            grounded = false;
            animator.SetTrigger("jump");
        }
        charPos = transform.position;
    }


    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Debug.Log(grounded);
        // Sa�a ve sola hareketler
        if (grounded && horizontalInput != 0)
        {
            if(horizontalInput > 0) 
            { 
                spriteRenderer.flipX = false;
            }else if(horizontalInput < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        // Z�plama hareketi
        if(grounded && verticalInput > 0)
        {
            jump = true;
        }
        // animasyon g�ncellemeleri
        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        animator.SetBool("grounded", grounded);
        //animator.SetBool("jump", jump);

    }
    private void LateUpdate()
    {
        if (camera != null)
            camera.transform.position = new Vector3(charPos.x, charPos.y, -10);
        else 
            Debug.Log("Kamera Tan�ml� De�il.");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
