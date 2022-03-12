using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    
    public int hearts = 3;
    public int maxHearts = 3;

    [SerializeField] private HeartManager hm;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;

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
        SoundManager.instance.PlaySound(hurtSound);
        if (hearts > 1) {
            anim.SetTrigger("Hurt");
        } else if (hearts == 1) {
            SoundManager.instance.PlaySound(deathSound);
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
