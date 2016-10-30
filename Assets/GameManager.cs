using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public Text distance;
    public GameObject[] deathButtons;
    public GameObject plane;
    public bool tapToStart = true;
    public GameObject tapTick;
    public Animator planeAnim;

    //Sound
    private SoundManager SoundManager;

    // Use this for initialization
    void Start()
    {
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        plane.GetComponent<Rigidbody2D>().isKinematic = true;
        int x = GameObject.Find("PlaneColor").GetComponent<PlaneColor>().animatorNumber;
        planeAnim.SetInteger("Color", GameObject.Find("PlaneColor").GetComponent<PlaneColor>().animatorNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tapToStart == true)
        {
            tapToStart = false;
            plane.GetComponent<Rigidbody2D>().isKinematic = false;
            Destroy(tapTick);
        }
    }

    void FixedUpdate()
    {
        distance.text = "DISTANCE \n" + plane.transform.position.x.ToString("0");
    }

    public void RestartGame()
    {
        SoundManager.ClickSound();
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMainMenu()
    {
        SoundManager.ClickSound();
        Destroy(GameObject.Find("PlaneColor"));
        Destroy(GameObject.Find("GooglePlay"));
        SceneManager.LoadScene("Menu");
        if (true)
        {

        }
    }

    public void EnableDeathButtons()
    {
        foreach (GameObject button in deathButtons)
        {
            button.SetActive(true);
        }
    }

    public void DisableDeathButtons()
    {
        foreach (GameObject button in deathButtons)
        {
            button.SetActive(false);
        }
    }

    public void ShowAd()
    {
        SoundManager.ClickSound();
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public void ShowRewardedAd()
    {
        SoundManager.ClickSound();
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                plane.GetComponent<Movement>().Continue();
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
