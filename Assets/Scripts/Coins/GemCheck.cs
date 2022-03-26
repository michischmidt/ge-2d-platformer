using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCheck : MonoBehaviour {
    [SerializeField] private AudioClip lvlCompleteSound;
    public GameObject lvlCompleteOverlay;
    public AdController adController;
    public Text deathText;
    public Text playTimeText;

    static int deathCounter = 0;
    static float timer = 0.0f;
    static int playTimeSeconds = 0;

    void Update() {
        timer += Time.deltaTime;
        playTimeSeconds = (int) timer % 60;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            SoundManager.instance.PlaySound(lvlCompleteSound);
            deathText.text = "Deaths: " + deathCounter.ToString();

            playTimeText.text = "Playtime: " + TimeSpan.FromSeconds(playTimeSeconds).Minutes + ":" + TimeSpan.FromSeconds(playTimeSeconds).Seconds;
            lvlCompleteOverlay.SetActive(true);
            StartCoroutine(waitForBanner());
        }
    }

    public IEnumerator waitForBanner() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(3f);
        lvlCompleteOverlay.SetActive(false);
        adController.Pause();
        // Destroy(gameObject);
        yield return new WaitForSecondsRealtime(15f);
        lvlCompleteOverlay.SetActive(true);
    }

    public void IncrementDeathCounter() {
        deathCounter += 1;
    }
}
