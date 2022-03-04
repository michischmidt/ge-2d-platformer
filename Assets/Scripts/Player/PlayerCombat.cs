using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerCombat : MonoBehaviour {

    public Animator anim;
    public Transform swordAttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    public void Attack() {
        // Play attack animation
        int randInt = new Random().Next(1, 4);
        anim.SetTrigger("SwordAttack" + randInt.ToString());

        // Detect enemy in range
        // Creates cirlce and collects all objects that are hit by it
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordAttackPoint.position, attackRange, enemyLayers);


        // Deal DMG to enemy
        foreach(Collider2D enemy in hitEnemies) {
            Debug.Log("Hit " + enemy.name);
        }
    }

    // Development function
    void OnDrawGizmosSelected() {
        if (swordAttackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(swordAttackPoint.position, attackRange);
    }
}

