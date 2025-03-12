using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Inspecting : MonoBehaviour
{
    [SerializeField] Symptomdictionary DictionaryScript;

    [Header("GameObjects")]
    [SerializeField] GameObject magnifyingGlass;
    [SerializeField] GameObject TablemagnifyingGlass;

    [Header("Inspecting")]
    [SerializeField] GameObject InspectHead;
    [SerializeField] GameObject InspectTail;
    [SerializeField] GameObject InspectBody;
    [SerializeField] GameObject InspectLegs;
    [SerializeField] GameObject equipMagGlass;
    [SerializeField] GameObject equipPetriDish;

    [Header("HitBoxes")]
    [SerializeField] GameObject legs;
    [SerializeField] GameObject head;
    [SerializeField] GameObject body;
    [SerializeField] GameObject tail;
    public bool inspect;

    [Header("RayCast")]
    public Camera playerCamera;
    public float distance;

    [Header("Injuries")]
    string HeadInjury;
    string BodyInjury;
    string TailInjury;
    string LegsInjury;

    public static string Symptoms;
    private bool hand;
    int count;
    public Transform Arm;
    // Start is called before the first frame update
    void Start()
    {
        DictionaryScript = GetComponent<Symptomdictionary>();
        inspect = false;  hand = false;
        InspectBody.SetActive(false);   InspectHead.SetActive(false);   InspectLegs.SetActive(false);   InspectTail.SetActive(false); equipMagGlass.SetActive(false); equipPetriDish.SetActive(false);
        legs.SetActive(true);   head.SetActive(true);   body.SetActive(true); tail.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        EquipMagnifyingGlass();
        SymptomList();
        PickingUpItem();

        if (inspect)
        {
            InspectSymptoms();
        }
        else
        { }
    }


    void InspectSymptoms()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        if (Physics.Raycast(ray, out hitInfo, distance))
        {

            if (hitInfo.collider.tag == "Body")
            {
                InspectBody.SetActive(true);
                if (leftMouseInput())
                {
                    BodyInjury = DictionaryScript.BodySymptom();
                    InspectBody.SetActive(false);
                    body.SetActive(false);
                }
            }
            else { InspectBody.SetActive(false); }


            if (hitInfo.collider.tag == "Head")
            {
                InspectHead.SetActive(true);
                if (leftMouseInput())
                {
                    HeadInjury = DictionaryScript.HeadSymptom();
                    InspectHead.SetActive(false);
                    head.SetActive(false);
                }
            }
            else { InspectHead.SetActive(false); }


            if (hitInfo.collider.tag == "Tail")
            {
                InspectTail.SetActive(true);
                if (leftMouseInput())
                {
                    TailInjury = DictionaryScript.TailSymptom();
                    InspectTail.SetActive(false);
                    tail.SetActive(false);
                }
            }
            else { InspectTail.SetActive(false); }


            if (hitInfo.collider.tag == "Legs")
            { 
                InspectLegs.SetActive(true);
                if (leftMouseInput())
                {
                    LegsInjury = DictionaryScript.LegsSymptom();
                    InspectLegs.SetActive(false);
                    legs.SetActive(false);
                }
            }
            else { InspectLegs.SetActive(false); }


        }
        
    }

    void EquipMagnifyingGlass()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out hitInfo, 2))
        {
            if (hitInfo.collider.tag == "MagGlass")
            {
                equipMagGlass.SetActive(true);
                if (leftMouseInput() && hand == false)
                {
                    TablemagnifyingGlass.SetActive(false);
                    magnifyingGlass.SetActive(true);
                    inspect = true;
                    hand = true;
                }
            }
            else { equipMagGlass.SetActive(false); }

            if(hitInfo.collider.tag == "TableTop" && leftMouseInput())
            {
                magnifyingGlass.SetActive(false);
                TablemagnifyingGlass.SetActive(true);
                inspect = false;
                hand = false;
            }
        }
    }

    void PickingUpItem()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if(hitInfo.collider.tag == "Craftable")
            {
                equipPetriDish.SetActive(true);
                if (Input.GetKey(KeyCode.Mouse0) && hand == false)
                {
                    equipPetriDish.SetActive(false);
                    hand = true;
                    pickedUp.Holding = true;
                    if (hand)
                    {
                        hitInfo.collider.gameObject.transform.position = Arm.position;
                    }
                }
                pickedUp.Holding = false;
                hand = false;
            }
            else if(hitInfo.collider.tag != "Craftable")
            {
                equipPetriDish.SetActive(false);
            }
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

    public string SymptomList()
    {
        Symptoms = HeadInjury + "\n"
                 + BodyInjury + "\n"
                 + TailInjury + "\n"
                 + LegsInjury + "\n";
        return Symptoms;
    }
        


}