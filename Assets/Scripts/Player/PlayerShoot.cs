using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Animator anim;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerManager player;

    public float attackRate = 1f; 
    float nextAttackTime = 0f;

    [SerializeField] private AudioClip arrowShootSound;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update() {
        // BUGGY on mobile so commented out
        // if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Fire2")) {
        //     Shoot();
        // }
    }

    public void Shoot() {
        if (Time.time < nextAttackTime) {
            return;
        }

        player.isShooting = true;
        anim.SetTrigger("BowAttack");
        StartCoroutine(waitForShootingFinish());
        nextAttackTime = Time.time + 1f / attackRate;
    }   

    public IEnumerator waitForShootingFinish() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(0.7f);
        SoundManager.instance.PlaySound(arrowShootSound);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        player.isShooting = false;
        
    }
}
