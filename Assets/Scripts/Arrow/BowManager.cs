using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowManager : MonoBehaviour {
    private static bool bowFound = false;
    [SerializeField] private AudioClip bowFoundSound;
    public GameObject bow;
    public GameObject bowFoundOverlay;
    public AdController adController;

    void Start() {
        if (bowFound) {
            bow.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            bow.SetActive(true);
            bowFound = true;
            SoundManager.instance.PlaySound(bowFoundSound);
            bowFoundOverlay.SetActive(true);
            StartCoroutine(waitForBanner());
        }
    }

    public IEnumerator waitForBanner() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(3f);
        bowFoundOverlay.SetActive(false);
        adController.Pause();
        Destroy(gameObject);
    }
}
