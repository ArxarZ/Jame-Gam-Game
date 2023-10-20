using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject Player;
    public float Speed;

    private float distance;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Finds distance between player and slime and makes the slime move towards the player 
        distance = Vector2.Distance(transform.position, Player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);

        if(distance > 8)
        {
            Dash();
        }
        else if (distance < 5)
        {
            Walk();
        }
        else
        {
            Dash();
        }
    } 

    void Dash()
    {
        Speed = 6f;
    }
    void Walk()
    {
        Speed = 4f;
    }
}
