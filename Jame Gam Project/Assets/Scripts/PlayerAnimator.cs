using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playeranimatior;

    private void Start()
    {
        playeranimatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Key Recognition
        // Setting Animations True and False
        if (Input.GetKey(KeyCode.W))
        {
            playeranimatior.SetBool("WalkingUp", true);
        }
        else
            playeranimatior.SetBool("WalkingUp", false);

        if (Input.GetKey(KeyCode.A))
        {
            playeranimatior.SetBool("WalkingLeft", true);
        }
        else
            playeranimatior.SetBool("WalkingLeft", false);

        if (Input.GetKey(KeyCode.D))
        {
            playeranimatior.SetBool("WalkingRight", true);
        }
        else
            playeranimatior.SetBool("WalkingRight", false);

        if (Input.GetKey(KeyCode.S))
        {
            playeranimatior.SetBool("WalkingDown", true);
        }
        else
            playeranimatior.SetBool("WalkingDown", false);
       
        if (Input.GetKeyUp(KeyCode.W))
        {
            CheckIfIdle();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            CheckIfIdle();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            CheckIfIdle();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            CheckIfIdle();
        }
    }

    private void CheckIfIdle()
    {
        //Detect if W,A,S or D are pressed and player not idle
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            playeranimatior.SetTrigger("Idle");
        }
    }
    
}
