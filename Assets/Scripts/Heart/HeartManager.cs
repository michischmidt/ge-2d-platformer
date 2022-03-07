using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour {

    [SerializeField] GameObject heartPrefab;
    [SerializeField] GameObject emptyHeartPrefab;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void DrawHearts (int hearts, int maxHearts) {
        foreach (Transform child in transform) {
            // need to the destroy so right amount of hearts is always there
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHearts; i++) {
            if (i + 1 <= hearts) {
                GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
                heart.transform.localScale = new Vector3(1, 1, 1);
            } else {
                GameObject heart = Instantiate(emptyHeartPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
                heart.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
