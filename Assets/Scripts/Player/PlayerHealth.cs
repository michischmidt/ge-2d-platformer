using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    
    public int hearts = 3;
    public int maxHearts = 3;

    [SerializeField] HeartManager hm;
    private Animator anim; 
    private PlayerManager player;
    
    // Start is called before the first frame update
    void Start() {
        player = GetComponent<PlayerManager>();
        anim = GetComponent<Animator>();
        hm.DrawHearts(hearts, maxHearts);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void DamagePlayer (int dmg) {
        if (hearts > 1) {
            anim.SetTrigger("Hurt");
        } else if (hearts == 1) {
            player.isDying = true;
            anim.SetTrigger("Died");
        }

        if (hearts > 0) {
            hearts -= dmg;
            hm.DrawHearts(hearts, maxHearts);
        }
    }

    public void HealPlayer (int heal) {
        if (hearts < maxHearts) {
            hearts += heal;
            hm.DrawHearts(hearts, maxHearts);
        }
    }
}
