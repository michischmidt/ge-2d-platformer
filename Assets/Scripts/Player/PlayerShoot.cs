using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Animator anim;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerManager player;

    public float attackRate = 1f; 
    float nextAtttackTime = 0f;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    // TODO: move in func that gets called with btn click
    void Update() {
        if (Time.time >= nextAtttackTime) {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Fire2")) {
                Shoot();
                nextAtttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void Shoot() {
        player.isShooting = true;
        anim.SetTrigger("BowAttack");
        StartCoroutine(waitForShootingFinish());
    }

    public IEnumerator waitForShootingFinish() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(0.7f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        player.isShooting = false;
    }
}
