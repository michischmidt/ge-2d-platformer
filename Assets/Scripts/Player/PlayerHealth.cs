using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    
    public int hearts = 3;
    public int maxHearts = 3;

    [SerializeField] private HeartManager heartManager;
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip deathSound;

    private Animator anim; 
    private PlayerManager player;
    private bool dead;
    
    // Start is called before the first frame update
    void Start() {
        player = GetComponent<PlayerManager>();
        anim = GetComponent<Animator>();
        heartManager.DrawHearts(hearts, maxHearts);
        dead = false;
    }

    public void DamagePlayer (int dmg) {
        if (dead) {
            return;
        }

        // Plus dmg because dmg is negative, heal is positiv
        hearts += dmg;

        if (hearts > 1) {
            SoundManager.instance.PlaySound(hurtSound);
            anim.SetTrigger("Hurt");
        } else if (hearts <= 0) {
            SoundManager.instance.PlaySound(deathSound);
            player.isDying = true;
            anim.SetTrigger("Died");
            gameOverManager.Setup();
            dead = true;
        }

        heartManager.DrawHearts(hearts, maxHearts);
    }

    public void HealPlayer (int heal) {
        SoundManager.instance.PlaySound(healSound);
        if (hearts < maxHearts) {
            hearts += heal;
            heartManager.DrawHearts(hearts, maxHearts);
        }
    }
}
