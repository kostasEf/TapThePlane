using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public Transform plane;
    private float offset;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position.x - plane.position.x ;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (plane != null)
        {
            transform.position = new Vector3(plane.position.x + offset, 0, -10);
        }
        
	}
}
