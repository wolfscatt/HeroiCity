using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;

    public TextMeshProUGUI pointText;
    int point = 0;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;

    bool facingRight = true;
    bool isJumping;
    bool isRight;
    bool isLeft;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMove();

        //playerAnimator.SetFloat("characterSpeed", Mathf.Abs(playerRB.velocity.x));

        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetKey(KeyCode.W) && isJumping == false)
        {
            Jump();
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpSpeed);
            isJumping = true;
        }
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Diamond")
        {
            point++;
            pointText.text = "Puan: " + point;
            Destroy(collision.gameObject);
        }
    }
}
