using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GemCheck : MonoBehaviour {
    [SerializeField] private AudioClip lvlCompleteSound;
    public GameObject lvlCompleteOverlay;
    public AdController adController;
    public Text deathText;
    public Text playTimeText;

    static int deathCounter = 0;
    static float timer = 0.0f;
    static int playTimeSeconds = 0;

    Scene scene;

    void Start() {
        scene = SceneManager.GetActiveScene();
    }

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

            // Only show ad in positve case
            if (scene.name == "SampleScenePositive") {
                StartCoroutine(waitForBanner());
            }
        }
    }

    public IEnumerator waitForBanner() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(3f);
        lvlCompleteOverlay.SetActive(false);
        adController.Pause();
        yield return new WaitForSecondsRealtime(10f);
        lvlCompleteOverlay.SetActive(true);
    }

    public void IncrementDeathCounter() {
        deathCounter += 1;
    }
}
