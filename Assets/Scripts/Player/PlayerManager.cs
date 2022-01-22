using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public float speedX;
    public float jumpSpeedY;

    bool facingRight, jumping;
    float speed;

    Animator anim;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody2D> ();
        facingRight = true;
    }

    // Update is called once per frame
    void Update() {
        MovePlayer(speed);
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
        if (Input.GetKeyDown(KeyCode.W)) {
            jumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            anim.SetInteger("State", 2);
        }
    }

    void MovePlayer(float playerSpeed) {
        if (playerSpeed < 0 && !jumping || playerSpeed > 0 && !jumping) {
            anim.SetInteger("State", 1); // running
        }

        if (playerSpeed == 0 && !jumping) {
            anim.SetInteger("State", 0); // idle
        }

        rb.velocity = new Vector3(speed, rb.velocity.y, 0);

    }

    void FlipCharacter() {
        if (speed > 0 && !facingRight || speed < 0 && facingRight) {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;

            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "GROUND") {
            jumping = false; 
            anim.SetInteger("State", 0);
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

    public void Jump() {
        jumping = true;
        rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
        anim.SetInteger("State", 2);
    }
}
