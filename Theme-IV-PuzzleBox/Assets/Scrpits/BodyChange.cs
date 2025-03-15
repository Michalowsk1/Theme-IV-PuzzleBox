using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodyChange : MonoBehaviour
{
    [SerializeField] GameObject human;
    [SerializeField] GameObject spider;
    [SerializeField] GameObject bird;
    [SerializeField] GameObject rat;
    public static bool Human;
    public static bool Spider;
    public static bool Bird;
    public static bool Rat;
    // Start is called before the first frame update
    void Start()
    {
        human.SetActive(true);
        spider.SetActive(false);
        bird.SetActive(false);
        rat.SetActive(false);

        Human = true;
        Spider = false;
        Bird = false;
        Rat = false;
    }

    // Update is called once per frame
    void Update()
    {
        BodyChanger();
    }


    void BodyChanger()
    {
        if (Spider)
        {
            human.SetActive(false);
            spider.SetActive(true);
            Human = false;
        }

        if (Human)
        {
            human.SetActive(true);
            spider.SetActive(false);
            bird.SetActive(false);
            rat.SetActive (false);
            
        }

        if (Bird)
        {
            human.SetActive(false);
            bird.SetActive(true);
            Human=false;
        }

        if (Rat)
        {
            human.SetActive(false);
            rat.SetActive(true);
            Human=false;
        }
    }
}

