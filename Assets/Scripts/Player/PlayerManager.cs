using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public float speedX;
    public float jumpSpeedY;
    public bool isShooting;

    bool facingRight, jumping, isGrounded;
    float speed;

    Animator anim;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        isShooting = false;
    }

    // Update is called once per frame
    void Update() {
        MovePlayer(speed);
        HandleJumpAndFall();
        FlipCharacter();

        if (Input.GetKeyDown(KeyCode.A)) {
            speed = -speedX;
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            speed = speedX;
        }

        if (Input.GetKeyUp(KeyCode.D)) {
            speed = 0;
        }

        // First jumping action, speed in direction = velocity
        if (Input.GetKeyDown(KeyCode.W) && isGrounded) {
            Jump();
        }
    }

    void MovePlayer(float playerSpeed) {
        if (playerSpeed < 0 && !jumping || playerSpeed > 0 && !jumping) {
            anim.SetBool("Run", true); // running
        }

        if (playerSpeed == 0 && !jumping) {
            anim.SetBool("Run", false); // stop running
        }

        // handling no horizontal movement while shooting
        if (!jumping && isShooting) {
            speed = 0;
        }

        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    void HandleJumpAndFall() {
        if (jumping) {
            // Handling Jump when velocity is postiv -> 
            // jumps up, if negativ he starts falling
            if (rb.velocity.y > 0) {
                anim.SetBool("Jump", true);
                anim.SetBool("Fall", false);
            } else {
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", true);
            }
        } else {
            // TODO: Fix Handling freefalling without a jump
            if (!isGrounded && rb.velocity.y < 0) {
                anim.SetBool("Fall", true);
            }
        }
    }

    public void Jump() {
        // handles single jump
        if (isGrounded && !isShooting) {
            jumping = true;
            isGrounded = false;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            anim.SetBool("Run", false);
            anim.SetBool("Jump", true);
        }
    }

    void FlipCharacter() {
        if (speed > 0 && !facingRight || speed < 0 && facingRight) {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);

            // OLD char flipping
            // Vector3 temp = transform.localScale;
            // temp.x *= -1;
            // transform.localScale = temp;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "GROUND") {
            isGrounded = true;
            jumping = false; 
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
    }

    public void WalkLeft() {
        speed = -speedX;
    }

    public void WalkRight() {
        speed = speedX;
    }

    public void StopMoving() {
        speed = 0;
    }
}
