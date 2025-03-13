using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickingUpItems : MonoBehaviour
{
    [SerializeField] GameObject PlayerCam;
    [SerializeField] GameObject EquipText;
    int distance = 3;
    bool hand = false;
    public Transform Arm;
    string PetriName;

    // Start is called before the first frame update
    void Start()
    {
        EquipText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PickingUpItem();
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
               hitInfo.collider.tag == "PurplePetri" || hitInfo.collider.tag == "GreenPetri")
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

    private bool leftMouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            return true;
        }
        else return false;
    }
}