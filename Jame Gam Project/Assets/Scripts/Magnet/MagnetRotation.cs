using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetRotation : MonoBehaviour
{
    GameObject Player;



    private void Start()
    {
        Player = transform.parent.gameObject;
    }

    private void Update()
    {
        // Getting Mouse Position
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Getting Vector from Player to Mouse
        Vector2 LookVector = MousePos - new Vector2(Player.transform.position.x, Player.transform.position.y);
        // normalizing vector
        LookVector = LookVector.normalized;
        // Calculates Degree
        float angle = Mathf.Atan2(LookVector.y, LookVector.x) * Mathf.Rad2Deg;
        // Rotates with certain degree
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        transform.localPosition = new Vector2(LookVector.x / 3, LookVector.y /2);
    }
}
