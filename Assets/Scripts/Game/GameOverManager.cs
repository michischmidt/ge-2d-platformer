using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    [SerializeField] private GemCheck gemCheck;
    [SerializeField] private GameObject deathOverlay;
    [SerializeField] AdController adController;
    [SerializeField] BeanstalkManager beanstalkManager;

    Scene scene; 

    void Start () {
        scene = SceneManager.GetActiveScene();
    }

    public void Setup() {
        deathOverlay.SetActive(true);
        if (beanstalkManager.getTriggerCounter() == 1) {
            StartCoroutine(waitForBanner());
        }
    }

    public void RestartButton() {
        SceneManager.LoadScene(scene.name);
        gemCheck.IncrementDeathCounter();
    }

    IEnumerator waitForBanner() {
        //Wait for seconds so animation can play
        yield return new WaitForSecondsRealtime(1f);
        deathOverlay.SetActive(false);
        adController.Pause();
        yield return new WaitForSecondsRealtime(10f);
        deathOverlay.SetActive(true);
    }
}
