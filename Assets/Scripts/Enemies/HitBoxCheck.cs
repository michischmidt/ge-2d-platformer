using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCheck : MonoBehaviour {

    [SerializeField] PlayerHealth ph;
    public int dmg = 1;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            ph.DamagePlayer(dmg);
        }
    }
}
