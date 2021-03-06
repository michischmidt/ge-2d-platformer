using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Animator anim;
    public int maxHealth = 20;
    int currentHealth;
    EnemyBehaviour enemyBehaviour;

    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator> ();
        enemyBehaviour = GetComponent<EnemyBehaviour> ();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void TakeDamage(int damage) {
        enemyBehaviour.hurt = true;
        currentHealth -= damage;
        if (currentHealth <= 0) {
            StartCoroutine(Die());
        }

        SoundManager.instance.PlaySound(hurtSound);

        if (!enemyBehaviour.attackMode) {
            anim.SetTrigger("Hurt");
            StartCoroutine(waitForHurtFinish());
        } else {
            enemyBehaviour.hurt = false;
        }
    }

    IEnumerator Die() {
        enemyBehaviour.dying = true;
        anim.SetTrigger("Died");

        // Disabling that player run into dead body
        // SINGLE DISABLE IS OLD
        // GetComponent<Collider2D>().enabled = false;
        Collider2D[] colliders = gameObject.GetComponentsInChildren<Collider2D>();
        foreach(Collider2D c in colliders) {
            c.enabled = false;
        }
        this.enabled = false;

        //Wait for seconds so animation can play
        SoundManager.instance.PlaySound(deathSound);
        yield return new WaitForSecondsRealtime(1.5f);

        Destroy(gameObject);
    }

    public IEnumerator waitForHurtFinish() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(0.5f);
        enemyBehaviour.hurt = false;
    }
}
