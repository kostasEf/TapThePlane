using UnityEngine;
using System.Collections;
using System;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    private GooglePlay GooglePlay;
    private float flapSpeed = 170;
    private float forwardSpeed = 1.5f;
    private bool didFlap = false;
    public GameObject explosion;

    //Sound
    private SoundManager SoundManager;
    private AudioSource EngineSound;

    // Use this for initialization
    void Start()
    {
        EngineSound = GameObject.Find("EngineSound").GetComponent<AudioSource>();
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        GooglePlay = GameObject.FindGameObjectWithTag("GooglePlay").GetComponent<GooglePlay>();
        EngineSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * forwardSpeed);

        if (didFlap)
        {
            rb.AddForce(Vector2.up * flapSpeed);
            didFlap = false;
        }

        
        float angle = Mathf.Lerp(0, -90, (-rb.velocity.y / 3f));
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }

    public void Continue()
    {
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(transform.position.x, 0);
        forwardSpeed = 1.5f;
        flapSpeed = 170;
        GameObject.Find("GameManager").GetComponent<GameManager>().DisableDeathButtons();
        StartCoroutine(DisableTrigger());
    }

    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GooglePlay.ReportLeaderBoardScore((int)transform.position.x);
        forwardSpeed = 0;
        flapSpeed = 0;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        Instantiate(explosion, transform.position, Quaternion.identity);
        SoundManager.ExplosionSound();
        EngineSound.Stop();
        GameObject.Find("GameManager").GetComponent<GameManager>().EnableDeathButtons();
    }

    IEnumerator DisableTrigger()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        rb.gravityScale = 0.4f;
    }
}
