using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private float OriginalSpeed;
    private float SlowedSpeed;

    public Vector3 MovementVector;
    
    // Start is called before the first frame update
    void Start()
    {
        OriginalSpeed = speed;
        SlowedSpeed = speed / 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Horrible Input code
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.down);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }
       
        //Even more horrible Input code
        // Speed Management
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            speed = SlowedSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            speed = SlowedSpeed;
        }
        else
        {
            speed = OriginalSpeed;
        }

    }

    private void MovePlayer(Vector3 direction)
    {
        //Movement Calculation
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
