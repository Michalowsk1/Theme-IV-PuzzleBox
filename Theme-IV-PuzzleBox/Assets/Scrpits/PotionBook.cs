using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PotionBook : MonoBehaviour
{
    [SerializeField] Symptomdictionary DictionaryScript;

    [SerializeField] GameObject closedBook;
    [SerializeField] GameObject openBook;
    [SerializeField] TextMeshProUGUI symptomText;

    int count;
    // Start is called before the first frame update
    void Start()
    {
        DictionaryScript = GetComponent<Symptomdictionary>();
        closedBook.SetActive(true);
        openBook.SetActive(false);
        symptomText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        OpenPotionbook();
        UpdateSymptoms();
    }


    void OpenPotionbook()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            count++;
        }

        if (count % 2 == 1)
        {
            closedBook.SetActive(false);
            openBook.SetActive(true);
        }
        else
        {
            closedBook.SetActive(true);
            openBook.SetActive(false);
        }
    }

    void UpdateSymptoms()
    {
        symptomText.text = Inspecting.Symptoms;
    }
}
