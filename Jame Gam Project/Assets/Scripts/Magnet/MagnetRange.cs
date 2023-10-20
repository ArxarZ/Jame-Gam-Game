using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MagnetRange : MonoBehaviour
{
    GameObject MagnetRangeObject;
    Collider2D Magnetrange;
    public bool Pulling;
    public bool Locked;
    [SerializeField]
    private GameObject TargetOject;

    public List<GameObject> MagneticObjectsInRange;
    

    public void Start()
    {
        StartCoroutine(PullObject());
        MagnetRangeObject = transform.GetChild(0).gameObject;
        Magnetrange = MagnetRangeObject.GetComponent<Collider2D>();
        MagnetRangeObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            MagnetRangeObject.SetActive(true);
            Pulling = true;
            GameObject[] FoundMagneticObjects = GameObject.FindGameObjectsWithTag("Magnetic");
            foreach(GameObject obj in FoundMagneticObjects)
            {
                if(obj.GetComponent<Collider2D>().IsTouching(Magnetrange))
                {
                    if (!MagneticObjectsInRange.Contains(obj))
                    {
                        MagneticObjectsInRange.Add(obj);
                    }
                }
            }

            foreach (GameObject MagneticObject in MagneticObjectsInRange)
            {
                if (MagneticObject.GetComponent<Collider2D>().IsTouching(Magnetrange) == false)
                {
                    MagneticObjectsInRange = null;
                    MagneticObjectsInRange = new List<GameObject>();
                }
            }
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            MagnetRangeObject.SetActive(false);
            MagneticObjectsInRange = null;
            MagneticObjectsInRange = new List<GameObject>();
            TargetOject = null;
            Locked = false;
        }
    }

    public IEnumerator PullObject()
    {
        while (true) {
            if (!Locked)
            {
                List<float> floats = new List<float>();
                foreach (GameObject obj in MagneticObjectsInRange)
                {
                    floats.Add(Vector2.Distance(transform.position, obj.transform.position));
                    int Count = floats.IndexOf(floats.Min());
                    TargetOject = MagneticObjectsInRange[Count];
                    Locked = true;
                }

            }
            yield return null;
        }
            
    }
}
