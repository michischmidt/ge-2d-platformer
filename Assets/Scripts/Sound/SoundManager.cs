using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance {get; private set;}
    private AudioSource source;

    // Start is called before the first frame update
    void Awake() {
        instance = this;
        source = GetComponent<AudioSource>();
        
        // Keep this obj even when we got to new scene
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != null && instance != this) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void PlaySound(AudioClip _sound) {
        source.PlayOneShot(_sound);
    }

    public void MuteAllSound() {
        AudioListener.volume = 0;
    }

    public void UnMuteAllSound() {
        AudioListener.volume = 1;
    }
}
