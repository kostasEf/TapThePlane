using UnityEngine;
using System.Collections;

public class PlaneColor : MonoBehaviour
{
    public int animatorNumber;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
