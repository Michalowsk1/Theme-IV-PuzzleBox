using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickedUp : MonoBehaviour
{
    public static bool Holding = false;
    [SerializeField] Rigidbody Dish;
    public Transform position;
    Vector3 spawnLocation;

    void Start()
    {
        Dish = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Holding)
        {
            Dish.GetComponent<Rigidbody>().useGravity = false;
        }
        else if (!Holding)
        {
            Dish.GetComponent<Rigidbody>().useGravity = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Kill")
        {
            gameObject.transform.position = position.transform.position;
        }
    }
}
