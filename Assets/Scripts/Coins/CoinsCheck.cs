using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCheck : MonoBehaviour {
    public Text coinsText;
    [SerializeField] private AudioClip coinSound;
    static int coinsCount = 0;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            SoundManager.instance.PlaySound(coinSound);
            coinsCount += 1;
            coinsText.text = coinsCount.ToString();
            Destroy(gameObject);
        }
    }
}
