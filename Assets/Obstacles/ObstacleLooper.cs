using UnityEngine;
using System.Collections;

public class ObstacleLooper : MonoBehaviour {

    private float distance = 15;
    private Vector3 nextSpawnPosition;
    public GameObject[] rockObstacle;

    // Use this for initialization
    void Start ()
    {
	
	}
	

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            nextSpawnPosition = new Vector3(collision.transform.position.x + distance, Random.Range(-0.63f, 0.77f), 0);

            //Instantiate(obstacle, nextSpawnPosition, Quaternion.identity);

            //collision.transform.position = nextSpawnPosition;
        }
    }
}
