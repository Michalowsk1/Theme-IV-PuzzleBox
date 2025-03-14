using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickingUpItems : MonoBehaviour
{
    [SerializeField] GameObject PlayerCam;
    [SerializeField] GameObject EquipText;
    [SerializeField] GameObject DrinkPotionText;
    int distance = 3;
    public static bool hand = false;
    public Transform Arm;
    string PetriName;

    // Start is called before the first frame update
    void Start()
    {
        DrinkPotionText.SetActive(false);
        EquipText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PickingUpItem();
        BodyChanger();
    }


    void PickingUpItem()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(PlayerCam.transform.position, PlayerCam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider.tag == "RedPetri" || hitInfo.collider.tag == "OrangePetri" ||
               hitInfo.collider.tag == "BluePetri" || hitInfo.collider.tag == "BrownPetri" ||
               hitInfo.collider.tag == "PurplePetri" || hitInfo.collider.tag == "GreenPetri" || hitInfo.collider.tag == "Fake")
            {
                EquipText.SetActive(true);
                if (hand == false && leftMouseInput())
                {
                    EquipText.SetActive(false);
                    hand = true;
                }

                else if (hand == true && leftMouseInput())
                {
                    hand = false;
                    heldItem.beingHeld = false;
                }

                if (hand)
                {
                    heldItem.beingHeld = true;
                    hitInfo.collider.gameObject.transform.position = Arm.position;
                }
                else { hand = false; heldItem.beingHeld = false; }
            }
            else { EquipText.SetActive(false); }
        }
    }

    void BodyChanger()
    {

        RaycastHit hitInfo;
        Ray ray = new Ray(PlayerCam.transform.position, PlayerCam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider.tag == "YellowPotion") //CHANGE PLAYER TO SPIDER
            {
                DrinkPotionText.SetActive(true);
                if (pickingUpItems.hand == false && Input.GetKey(KeyCode.Mouse0))
                {
                    BodyChange.Spider = true;
                    DrinkPotionText.SetActive(false);
                }
            }



            if (hitInfo.collider.tag == "CyanPotion") //CHANGE PLAYER TO BIRD
            {
                DrinkPotionText.SetActive(true);
                if (pickingUpItems.hand == false && Input.GetKey(KeyCode.Mouse0))
                {
                    BodyChange.Bird = true;
                    DrinkPotionText.SetActive(false);
                }
            }



            if (hitInfo.collider.tag == "PinkPotion") //CHANGE PLAYER TO RAT
            {
                DrinkPotionText.SetActive(true);
                if (pickingUpItems.hand == false && Input.GetKey(KeyCode.Mouse0))
                {
                    BodyChange.Rat = true;
                    DrinkPotionText.SetActive(false);
                }
            }
            DrinkPotionText.SetActive(false);
        }
    }


    private bool leftMouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            return true;
        }
        else return false;
    }
}