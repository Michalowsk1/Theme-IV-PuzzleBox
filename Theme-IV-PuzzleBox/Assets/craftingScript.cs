using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craftingScript : MonoBehaviour
{
    List<GameObject> craftableItems;


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Craftable")
        {
            craftableItems.Add(collision.gameObject);
        }
        
        foreach (var item in craftableItems)
        {
            Debug.Log(item);
        }
    }
}
