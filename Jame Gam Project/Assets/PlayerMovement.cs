using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
       

    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
