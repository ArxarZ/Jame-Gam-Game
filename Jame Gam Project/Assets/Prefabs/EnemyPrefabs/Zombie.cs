using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Player playerHealth;
    public int damage = 10;
    private float distance;
    public float speed = 5f;
    public GameObject Player;
    public int maxHealth = 20;
    public int health;

    public Animator zombieAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Checks difference in distance and moves the zombie towards the player
        distance = Vector2.Distance(transform.position, Player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    
}
