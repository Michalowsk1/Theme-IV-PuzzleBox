using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdPuzzleScript : MonoBehaviour
{
    [SerializeField] GameObject Worm;
    public Transform BirdCam;
    int distance = 1;
    public int wormCount;
    public static bool completed;
    // Start is called before the first frame update
    void Start()
    {
        wormCount = 0;
        completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //WormDestroyer();

        if(wormCount == 5)
        {
            completed = true;
            BodyChange.Human = true;
            BodyChange.Bird = false;
        }
        if(completed)
        {
            finalCount.PuzzleSolved++;
            wormCount = 0;
            completed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Worm")
        {
            wormCount++;
        }
    }

    void WormDestroyer()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(BirdCam.transform.position, BirdCam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider.tag == "Worm" && Input.GetKey(KeyCode.Mouse0))
            {
                Destroy(hitInfo.collider.gameObject);
                wormCount++;
            }
        }
    }
}
