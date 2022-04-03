using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeAdController : MonoBehaviour {
    public AdController adController;
    [SerializeField] private GameObject deathOverlay;
    static int shroomDeathCounter = 0;


    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            StartCoroutine(waitForBanner());
        }
    }

    public IEnumerator waitForBanner() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(1f);
        deathOverlay.SetActive(false);
        adController.Pause();
        yield return new WaitForSecondsRealtime(10f);
        deathOverlay.SetActive(true);
    }
}
