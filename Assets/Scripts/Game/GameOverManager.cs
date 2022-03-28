using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    [SerializeField] private GemCheck gemCheck;

    public void Setup() {
        gameObject.SetActive(true);
    }

    public void RestartButton() {
        SceneManager.LoadScene("SampleSceneNegative");
        gemCheck.IncrementDeathCounter();
    }
}
