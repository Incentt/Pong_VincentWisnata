using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float Speed = 10f;
    public float Yboundary = 3.7f;
    private int Score;
    private ContactPoint2D lastContactPoint;
    private Rigidbody2D Player1;
    private Rigidbody2D Player2;

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Racket_Left").GetComponent<Rigidbody2D>();
        Player2 = GameObject.Find("Racket_Right").GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        Player1.velocity = new Vector2(Player1.velocity.x, Speed * Time.deltaTime * move);
        float move2 = Input.GetAxis("Vertical2");
        Player2.velocity = new Vector2(Player2.velocity.x, Speed * Time.deltaTime * move2);
    }
    void Update()
    {
        if (transform.position.y > Yboundary)
        {
            gameObject.transform.position = new Vector2(transform.position.x, Yboundary);
        }
        else if (transform.position.y < -Yboundary)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -Yboundary);
        }
    }

}

