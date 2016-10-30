using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

    private AudioSource AudioSource;

    // Use this for initialization
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    public void Mute()
    {
        AudioSource.volume = 0;
    }

    public void UnMute()
    {
        AudioSource.volume = 0.8f;
    }
}
