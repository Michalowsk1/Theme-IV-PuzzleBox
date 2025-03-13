using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crafting : MonoBehaviour
{
    bool Orange;
    bool Green;
    bool Blue;
    bool Red;
    bool Brown;
    bool Purple;
    [SerializeField] GameObject PinkPotion;
    [SerializeField] GameObject CyanPotion;
    [SerializeField] GameObject YellowPotion;
    public Transform PotionSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Orange = false;
        Green = false;
        Blue = false;
        Red = false;
        Brown = false;
        Purple = false;
    }

    // Update is called once per frame
    void Update()
    {
        CraftingRecipies();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "OrangePetri")
        {
            Orange = true;
        }

        if (collision.gameObject.tag == "GreenPetri")
        {
            Green = true;
        }

        if (collision.gameObject.tag == "BrownPetri")
        {
            Brown = true;
        }

        if (collision.gameObject.tag == "RedPetri")
        {
            Red = true;
        }

        if (collision.gameObject.tag == "PurplePetri")
        {
            Purple = true;
        }

        if (collision.gameObject.tag == "BluePetri")
        {
            Blue = true;
        }
    }

    void CraftingRecipies()
    {
        if(Red && Blue)
        {
            Instantiate(YellowPotion, PotionSpawn.position, Quaternion.identity);
            Red = false;
            Blue = false;
        }

        if(Orange && Green)
        {
            Instantiate(PinkPotion, PotionSpawn.position, Quaternion.identity);
            Orange = false;
            Green = false;
        }

        if(Purple && Brown)
        {
            Instantiate(CyanPotion, PotionSpawn.position, Quaternion.identity);
            Purple = false;
            Brown = false;
        }
    }
}
