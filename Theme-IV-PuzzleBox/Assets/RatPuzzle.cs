using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RatPuzzle : MonoBehaviour
{
    [SerializeField] GameObject staminaBar;
    [SerializeField] GameObject BackstaminaBar;
    [SerializeField] Rigidbody rat;
    public bool staminaDrain;

    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        staminaBar = rectTransform.gameObject;
        staminaBar.SetActive(false);
        BackstaminaBar.SetActive(false);
        staminaDrain = false;

        rat = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BackstaminaBar.SetActive(true);
        staminaBar.SetActive(true);
        RatStamina();
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
            staminaBar.transform.localScale = new Vector3(staminaBar.transform.localScale.x - 0.01f, staminaBar.transform.localScale.y); //DECREASES STAMINA
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

        if(staminaBar.transform.localScale.x == 0)
        {
            rat.constraints = RigidbodyConstraints.FreezeAll;
        }

        else if(staminaBar.transform.localScale.x != 0)
        {
            rat.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

}
