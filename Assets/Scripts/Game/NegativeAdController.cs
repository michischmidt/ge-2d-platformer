using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeAdController : MonoBehaviour {
    public AdController adController;
    static int shroomDeathCounter = 0;


    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            if (shroomDeathCounter < 2) {
                StartCoroutine(waitForBanner());
            }
            shroomDeathCounter += 1;
        }
    }

    public IEnumerator waitForBanner() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(1.5f);
        adController.Pause();
    }
}
