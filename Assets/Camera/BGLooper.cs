using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour
{
    private GooglePlay GooglePlay;
    private Vector3 bgComponentSizeX = new Vector3(24, 0, 0);
    private Vector3 groundComponentSizeX = new Vector3(24.24f, 0, 0);
    public Transform plane;
    public Sprite[] grounds;
    public int switchCounter = 0;
    private int groundCounter = 0;

    // Use this for initialization
    void Start()
    {
        GooglePlay = GameObject.FindGameObjectWithTag("GooglePlay").GetComponent<GooglePlay>();
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        string name = collision.gameObject.name;

        if (tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
        else if(tag == "Ground")
        {
            if (groundCounter > 0)
            {
                groundCounter--;
                collision.GetComponent<SpriteRenderer>().sprite = grounds[switchCounter % grounds.Length];
            }
            collision.transform.position += groundComponentSizeX;
            collision.GetComponent<Ground>().SpawnObstacles(switchCounter % grounds.Length);
        }
        else if (tag == "Background")
        {
            collision.transform.position += bgComponentSizeX;
        }
        else if(tag == "Switch")
        {
            collision.transform.position += new Vector3(50, 0, 0);
            switchCounter++;
            groundCounter = 3;
        }
        else if (tag == "Achievement")
        {
            if (name == "Meters50")
            {
                GooglePlay.CompleteAchievement(GooglePlay.Achievements[GooglePlay.Achievement.Meters50]);
            }
            else if (name == "Meters100")
            {
                GooglePlay.CompleteAchievement(GooglePlay.Achievements[GooglePlay.Achievement.Meters100]);
            }
            else if (name == "Meters150")
            {
                GooglePlay.CompleteAchievement(GooglePlay.Achievements[GooglePlay.Achievement.Meters150]);
            }
            else if (name == "Meters200")
            {
                GooglePlay.CompleteAchievement(GooglePlay.Achievements[GooglePlay.Achievement.Meters200]);
            }
            else if (name == "Meters250")
            {
                GooglePlay.CompleteAchievement(GooglePlay.Achievements[GooglePlay.Achievement.Meters250]);
            }

        }
        
    }
}
