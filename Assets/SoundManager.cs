using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public AudioClip clickSound;
    public AudioClip achievement;
    public AudioClip switchPlanes;
    public AudioClip explosion;

    public AudioSource AudioSource;

    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ClickSound()
    {
        AudioSource.PlayOneShot(this.clickSound);
    }

    public void SwitchSound()
    {
        AudioSource.PlayOneShot(this.switchPlanes);
    }

    public void AchievementSound()
    {
        AudioSource.PlayOneShot(this.achievement);
    }

    public void ExplosionSound()
    {
        AudioSource.PlayOneShot(this.explosion);
    }

    public void Mute()
    {
        AudioSource.volume = 0;
    }

    public void UnMute()
    {
        AudioSource.volume = 1;
    }

    public bool IsOff()
    {
        if (AudioSource.volume == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
