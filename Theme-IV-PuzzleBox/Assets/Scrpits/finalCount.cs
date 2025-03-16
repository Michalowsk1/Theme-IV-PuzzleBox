using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalCount : MonoBehaviour
{
    public static int PuzzleSolved;
    public static bool FinalDoor;
    [SerializeField] GameObject BottomDoor;
    [SerializeField] GameObject LeftDoor;
    [SerializeField] GameObject RightDoor;
    // Start is called before the first frame update
    void Start()
    {
        FinalDoor = false;
        PuzzleSolved = 0;
        BottomDoor.SetActive(false);
        LeftDoor.SetActive(false);
        RightDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PuzzleSolved >= 1)
        {
            BottomDoor.SetActive(true);
        }

        if (PuzzleSolved >= 2)
        {
            LeftDoor.SetActive(true);
        }

        if (PuzzleSolved >= 3)
        {
            RightDoor.SetActive(true);
            FinalDoor = true;
        }

    }
}
