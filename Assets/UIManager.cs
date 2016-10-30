using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class UIManager : MonoBehaviour
{

    public bool SoundsEnabled = true;
    private GooglePlay GooglePlay;
    public Animator plane;
    public Button volume;
    private int currentColor;

    public Sprite soundOff;
    public Sprite soundOn;

    public PlaneColor planeColor;

    //Sound
    private SoundManager SoundManager;
    private BackgroundMusic BackgroundMusic;
    private EngineSound EngineSound;

    // Use this for initialization
    void Start()
    {
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        BackgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<BackgroundMusic>();
        EngineSound = GameObject.Find("EngineSound").GetComponent<EngineSound>();
        GooglePlay = GameObject.FindGameObjectWithTag("GooglePlay").GetComponent<GooglePlay>();

        if (SoundManager.IsOff())
        {
            volume.GetComponent<Image>().sprite = soundOff;
            SoundsEnabled = false;
        }
    }


    public void OnOffSound(GameObject buttonPressed)
    {
        if (buttonPressed.name == "Sounds")
        {
            if (SoundsEnabled == true)
            {
                SoundsEnabled = false;
                buttonPressed.GetComponent<Image>().sprite = soundOff;
                SoundManager.Mute();
                BackgroundMusic.Mute();
                EngineSound.Mute();
            }
            else
            {
                buttonPressed.GetComponent<Image>().sprite = soundOn;
                SoundsEnabled = true;
                SoundManager.UnMute();
                BackgroundMusic.UnMute();
                EngineSound.UnMute();
            }
        }
    }

    public void StartGame()
    {
        SoundManager.ClickSound();
        SceneManager.LoadScene("GameScene");
    }

    public void ChangePlanesPlus()
    {
        currentColor++;
        if (currentColor > 3)
        {
            currentColor = 0;
        }
        plane.SetInteger("Color", currentColor);
        planeColor.animatorNumber = currentColor;
        SoundManager.SwitchSound();
    }

    public void ChangePlanesMinus()
    {
        currentColor--;
        if (currentColor < 0)
        {
            currentColor = 3;
        }
        plane.SetInteger("Color", currentColor);
        planeColor.animatorNumber = currentColor;
        SoundManager.SwitchSound();
    }

    public void Leaderboard()
    {
        SoundManager.ClickSound();
        GooglePlay.ShowSpecificLeaderBoard();
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
