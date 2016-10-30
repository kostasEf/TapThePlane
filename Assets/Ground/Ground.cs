using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

    public Transform[] obstaclePositions;

    public GameObject[] rockObstacles;
    public GameObject[] grassObstacles;
    public GameObject[] iceObstacles;
    public GameObject[] snowObstacles;
    private int randomIndex;
    private Vector3 nextSpawnPosition;

    public enum ObstacleType
    {
        Rock, Grass, Ice, Snow
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnObstacles(int type)
    {
        for (int i = 0; i < 3; i++)
        {
            randomIndex = Random.Range(0, 3);

            if (randomIndex == 2)
            {
                nextSpawnPosition = new Vector3(obstaclePositions[i].transform.position.x, Random.Range(-0.63f, 0.77f), 0);
            }
            else
            {
                nextSpawnPosition = new Vector3(obstaclePositions[i].transform.position.x, 0, 0);
            }
            
            TypeantiateAppropriate(type);

        }
    }

    private void TypeantiateAppropriate(int type)
    {
        if (type == 0)
        {
            Instantiate(rockObstacles[randomIndex], nextSpawnPosition, Quaternion.identity);
        }
        else if (type == 1)
        {
            Instantiate(grassObstacles[randomIndex], nextSpawnPosition, Quaternion.identity);
        }
        else if (type == 2)
        {
            Instantiate(iceObstacles[randomIndex], nextSpawnPosition, Quaternion.identity);
        }
        else if (type == 3)
        {
            Instantiate(rockObstacles[randomIndex], nextSpawnPosition, Quaternion.identity);
        }
        else if (type == 4)
        {
            Instantiate(snowObstacles[randomIndex], nextSpawnPosition, Quaternion.identity);
        }
    }
}
