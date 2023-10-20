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

    public Animator animator;

    

    // Update is called once per frame
    void Update()
    {
        Animations();

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

    void Animations()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("Right", true);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("Left", true);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("Up", true);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("Down", true);
        }
        if (Input.GetAxis("Horizontal") !> 0)
        {
            animator.SetBool("Right", false);
        }
        if (Input.GetAxis("Horizontal") !< 0)
        {
            animator.SetBool("Left", false);
        }
        if (Input.GetAxis("Vertical") !> 0)
        {
            animator.SetBool("Up", false);
        }
        if (Input.GetAxis("Vertical") !> 0)
        {
            animator.SetBool("Down", false);
        }
    }
}
