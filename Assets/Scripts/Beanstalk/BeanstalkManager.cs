using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanstalkManager : MonoBehaviour {
    static int triggerCounter = 0;
    [SerializeField] GameObject beanstalks; 
    public GameOverManager gameOverManager;
    public AdController adController;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            if (triggerCounter < 3) {
                gameObject.active = false;
                triggerCounter += 1;
                beanstalks.SetActive(true);
            }
        }
    }

    public int getTriggerCounter() {
        return triggerCounter;
    }
}
