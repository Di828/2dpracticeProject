using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] AudioClip jumpClip;
    private float jumpForce = 15f;
    Rigidbody2D playerRigidbody;    
    private bool isGrounded;    
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
    }
    private void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        ReverseJumpForce();
        ChangeGravity();
        FlipPlayerSprite();
        PlayJumpSound();
    }
    private void ReverseJumpForce()
    {
        jumpForce *= -1;        
    }
    private void ChangeGravity()
    {
        playerRigidbody.gravityScale *= -1;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void FlipPlayerSprite()
    {
        GetComponent<SpriteRenderer>().flipY = !GetComponent<SpriteRenderer>().flipY;
    }
    private void PlayJumpSound()
    {
        GetComponent<AudioSource>().PlayOneShot(jumpClip);
    }
}
