using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour {
    
    public  Animator anim;

    private EnemyBehaviour enemyParent;
    private bool inRange;

    private void Awake() {
        enemyParent = GetComponentInParent<EnemyBehaviour>();
    }

    private void Update() {
        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            enemyParent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            inRange = true;
        }
    }

    private void OnCollisionEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
        }
    }
}
