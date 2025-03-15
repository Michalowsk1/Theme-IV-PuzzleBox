using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormRemove : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bird")
        {
            Destroy(gameObject);
        }
    }
}

