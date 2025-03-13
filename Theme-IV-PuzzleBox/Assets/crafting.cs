using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crafting : MonoBehaviour
{
    bool Orange;
    // Start is called before the first frame update
    void Start()
    {
        Orange = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Orange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "OrangePetri")
        {
            Orange = true;
        }

        if (collision.gameObject.tag != "OrangePetri")
        {
            Orange = false;
        }

        if (collision.gameObject.tag == "GreenPetri")
        {
            Debug.Log("Green");
        }

        if (collision.gameObject.tag == "BrownPetri")
        {
            Debug.Log("Brown");
        }

        if (collision.gameObject.tag == "RedPetri")
        {
            Debug.Log("Red");
        }

        if (collision.gameObject.tag == "PurplePetri")
        {
            Debug.Log("Purple");
        }

        if (collision.gameObject.tag == "GreenPetri")
        {
            Debug.Log("Green");
        }
    }
}
