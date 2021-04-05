using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{
    public float Xforce;
    public float Yforce;
    private Rigidbody2D Ball;
    public Vector2 currentvelocity;
    //
    private Vector2 trajectoryOrigin;

    public Game_Manager GM;
    public AudioSource BounceSound;
    public AudioSource ScoredSound;


    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    void Start()
    {
        Ball = GetComponent<Rigidbody2D>();
        Invoke("GameStart", 2.1f);
        trajectoryOrigin = transform.position;
    }

    void GameStart()
    {
        float rand = Random.Range(0, 2);
        if(rand == 1)
        {
            Yforce *= -1;
        }
        else
        {
            Yforce *= 1;
        }
        float rand2 = Random.Range(0, 2);
        if (rand2 == 1)
        {
            Xforce *= -1;
        }
        else
        {
            Xforce *= 1;
        }
        Ball.AddForce(new Vector2(Xforce, Yforce));
        Invoke("checkvelocity", 1f);

    }
    void checkvelocity()
    {
        currentvelocity.x = Ball.velocity.x;
        currentvelocity.y = Ball.velocity.y;
    }

    void ResetGame()
    {
        transform.position = new Vector2(0, 0);
        Ball.velocity = new Vector2(0, 0);
        Invoke("GameStart", 1);
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.collider.tag == "Racket")
        {
            BounceSound.Play();

        }
        if (coll.collider.tag == "Roof")
        {
            BounceSound.Play();
        }
        

    }
    private void OnCollisionExit(Collision collision)
    {
        trajectoryOrigin = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LeftWall")
        {
            GM.AddScoreRight();
            Invoke("ResetGame", 0.5f);
        }
        if (collision.gameObject.name == "RightWall")
        {
            GM.AddScoreLeft();
            Invoke("ResetGame", 0.5f);
        }
        if (collision.gameObject.tag == "Wall")
        {
            ScoredSound.Play();
        }

    }
}
