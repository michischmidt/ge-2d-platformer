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

    
    // Start is called before the first frame update
    void Start() {
        player = GetComponent<PlayerManager>();
        anim = GetComponent<Animator>();
        heartManager.DrawHearts(hearts, maxHearts);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void DamagePlayer (int dmg) {
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
