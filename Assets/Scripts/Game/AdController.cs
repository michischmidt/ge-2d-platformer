using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdController : MonoBehaviour {

    public GameObject lvlCompleteOverlay;

    public static bool gameIsPaused = false;

    public GameObject adPanel;

    public Slider timerSlider;
    public GameObject closeButton;
    public float gameTime;

    private bool stopTimer;
    float timer = 0f;

    void Start() {
        Setup();
    }

    // Update is called once per frame
    void Update() {

        if (gameIsPaused) {
            timer += Time.deltaTime;
            // handling slider down
            float time = gameTime - timer;

            if (time <= 0) {
                stopTimer = true;
                Resume();
            }

            if (!stopTimer) {
                timerSlider.value = time;
            }
            
            // Enable close button
            if (timerSlider.value <= 7.5f) {
                closeButton.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        SoundManager.instance.UnMuteAllSound();
        adPanel.SetActive(false); 
        // freezes game
        // Time.timeScale = 1f;
        gameIsPaused = false;
        closeButton.SetActive(false);
    }

    public void Pause() {
        SoundManager.instance.MuteAllSound();
        lvlCompleteOverlay.SetActive(false);
        Setup();
        adPanel.SetActive(true);
        // freezes game
        // Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void Setup() {
        timer = 0f;
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }
}
