using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerCombat : MonoBehaviour {

    public Animator anim;
    public Transform swordAttackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;

    public float attackRate = 2f; 
    float nextAtttackTime = 0f;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    public void Attack() {
        // Timeout so player can't spam attack
        if (Time.time < nextAtttackTime) {
            return;
        }

        // Play attack animation
        int randInt = new Random().Next(1, 4);
        anim.SetTrigger("SwordAttack" + randInt.ToString());

        // Detect enemy in range
        // Creates cirlce and collects all objects that are hit by it
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordAttackPoint.position, attackRange, enemyLayers);


        // Deal DMG to any enemy
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        nextAtttackTime = Time.time + 1f / attackRate;
    }

    // Development function
    void OnDrawGizmosSelected() {
        if (swordAttackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(swordAttackPoint.position, attackRange);
    }
}

