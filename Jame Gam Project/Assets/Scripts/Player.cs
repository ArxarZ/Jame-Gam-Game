using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth;
    public int maxPlayerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxPlayerHealth;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
    }
    

    public void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;

        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
