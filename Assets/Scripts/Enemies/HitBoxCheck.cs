using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCheck : MonoBehaviour {

    [SerializeField] PlayerHealth ph;
    public int dmgOrHealth = 0;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            if (dmgOrHealth > 0) {
                ph.HealPlayer(dmgOrHealth);
                Destroy(gameObject);
            } else {
                ph.DamagePlayer(dmgOrHealth);
            }
        }
    }
}
