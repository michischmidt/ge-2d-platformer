using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

    public float speed = 15f;
    public Rigidbody2D rb; 
    public int arrowDamage = 10;

    // Start is called before the first frame update
    void Start() {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(arrowDamage);
        }

        Destroy(gameObject);
    }
}
