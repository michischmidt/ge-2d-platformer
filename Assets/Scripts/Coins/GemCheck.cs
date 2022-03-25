using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCheck : MonoBehaviour {
    [SerializeField] private AudioClip lvlCompleteSound;
    public GameObject lvlCompleteOverlay;
    public AdController adController;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            SoundManager.instance.PlaySound(lvlCompleteSound);
            lvlCompleteOverlay.SetActive(true);
            StartCoroutine(waitForBanner());
        }
    }

    public IEnumerator waitForBanner() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(3f);
        adController.Pause();
        Destroy(gameObject);
    }
}
