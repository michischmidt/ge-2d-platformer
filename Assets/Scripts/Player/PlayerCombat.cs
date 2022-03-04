using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    void Attack() {
        // Play attack animation
        anim.SetTrigger("SwordAttack");

        // Detect enemy in range

        // Deal DMG to enemy
    }
}
