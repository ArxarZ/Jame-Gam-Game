using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject Player;
    public float Speed;

    private float distance;
    private Rigidbody2D rb;
    private int health;
    private int maxHealth = 10;
    public int damage = 5;

    public Player playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Sets values
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Finds distance between player and slime and makes the slime move towards the player 
        distance = Vector2.Distance(transform.position, Player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);


        // Dash mechanic for if the slime if too far
        if (distance > 8)
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision != null)
            {
                playerHealth.TakeDamage(damage);
            }
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
