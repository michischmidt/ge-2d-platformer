using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Animator anim;
    public int maxHealth = 20;
    int currentHealth;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator> ();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if (currentHealth <= 0) {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {
        anim.SetBool("Died", true);

        // Disabling that player run into dead body
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(gameObject);
    }
}
