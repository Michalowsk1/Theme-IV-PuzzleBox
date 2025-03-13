using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heldItem : MonoBehaviour
{
    [SerializeField] Rigidbody item;
    [SerializeField] GameObject Item;
    public static bool beingHeld;
    public Transform Spawn;
    // Start is called before the first frame update
    void Start()
    {
        item.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(beingHeld)
        {
            item.useGravity = false;
        }

        if(!beingHeld)
        {
            item.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Kill")
        {
            Item.transform.position = Spawn.position;
        }

        if(collision.gameObject.tag == "Craft")
        {
            Destroy(gameObject);
        }
    }
}
