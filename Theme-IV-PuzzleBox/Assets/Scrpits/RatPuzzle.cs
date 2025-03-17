using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RatPuzzle : MonoBehaviour
{
    [Header("Digging")]
    [SerializeField] GameObject Dirt;
    [SerializeField] GameObject Particles;
    [SerializeField] GameObject RatCam;
    [SerializeField] GameObject DigText;

    [Header("Stamina")]
    [SerializeField] GameObject staminaBar;
    [SerializeField] GameObject BackstaminaBar;
    [SerializeField] Rigidbody rat;
    public bool staminaDrain;

    int distance = 2;
    public int timer;

    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        staminaBar = rectTransform.gameObject;
        staminaBar.SetActive(false);
        BackstaminaBar.SetActive(false);
        DigText.SetActive(false);
        Particles.SetActive(false);
        BackstaminaBar.SetActive(false);
        staminaDrain = false;
        timer = 0;

        rat = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BodyChange.Rat)
        {
            BackstaminaBar.SetActive(true);
            staminaBar.SetActive(true);
        }
        Digging();
        RatStamina();

        if (timer >= 1140)
        {
            timer = 0;
        }

        
    }

    void RatStamina()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
        {
            staminaDrain = true;
        }
        else if ((!Input.GetKey(KeyCode.W)) || (!Input.GetKey(KeyCode.A)) || (!Input.GetKey(KeyCode.S)) || (!Input.GetKey(KeyCode.D)))
        {
            staminaDrain = false;
        }

        if (staminaDrain)
        {
            staminaBar.transform.localScale = new Vector3(staminaBar.transform.localScale.x - 0.003f, staminaBar.transform.localScale.y); //DECREASES STAMINA
        }

        else if (!staminaDrain)
        {
            staminaBar.transform.localScale = new Vector3(staminaBar.transform.localScale.x + 0.01f, staminaBar.transform.localScale.y); //INCREASES STAMINA
        }

        if (staminaBar.transform.localScale.x > 4.5) //PREVENTS BAR GOING OVER MAX LIMIT
        {
            staminaBar.transform.localScale = new Vector3(4.5f, staminaBar.transform.localScale.y);
        }

        else if (staminaBar.transform.localScale.x <= 0) //PREVENTS BAR GOING BELOW MINIMUM LIMIT
        {
            staminaBar.transform.localScale = new Vector3(0.0f, staminaBar.transform.localScale.y);
        }

        if (staminaBar.transform.localScale.x == 0)
        {
            rat.constraints = RigidbodyConstraints.FreezeAll;
        }

        else if (staminaBar.transform.localScale.x != 0)
        {
            rat.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void Digging()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(RatCam.transform.position, RatCam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider.tag == "Dirt")
            {
                Debug.Log("HIT");
                DigText.SetActive(true);
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    DigText.SetActive(false);
                    Particles.SetActive(true);
                    timer++;

                    if (timer % 380 == 0)
                    {
                        Dirt.transform.position = new Vector2(Dirt.transform.position.x, Dirt.transform.position.y - 0.05f);
                        DirtGround.digCount++;
                    }
                }
            }
            DigText.SetActive(false);

        }

    }
}