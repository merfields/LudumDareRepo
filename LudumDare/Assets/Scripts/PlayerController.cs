using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private AudioManager audioManager;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jetpackPower = 10f;
    private float groundCheckLength = 0.5f;

    [SerializeField]
    private LayerMask groundMask;

    private BoxCollider2D playerCollider;
    private bool isFacingRight = true;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if (Input.GetButton("Jump"))
        {
            animator.SetBool("AnimIsFlying", true);
            rigidbody2D.velocity = new Vector2(0, jetpackPower);
        }

        if(Input.GetButtonDown("Jump")){
            audioManager.PlayClip("Jetpack");
        }

        if (Input.GetButtonUp("Jump"))
        {   
            audioManager.StopClip("Jetpack");
            animator.SetBool("AnimIsFlying", false);
        }

        if (input.x != 0)
        {
            animator.SetBool("AnimIsRunning", true);
        }
        else
        {
            animator.SetBool("AnimIsRunning", false);
        }

        if (input.x < 0 && isFacingRight)
            Flip();
        else if (input.x > 0 && !isFacingRight)
            Flip();


        transform.position += new Vector3(input.x * moveSpeed * Time.deltaTime, 0);
    }

/*
    public bool checkIfGrounded()
    {

        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size,
        0, Vector2.down, groundCheckLength, groundMask);

        Debug.Log(raycastHit2D.collider != null);

        return raycastHit2D.collider != null;
    }
*/
    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
