using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPuzzle : MonoBehaviour
{
    [SerializeField] Rigidbody spiderBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (BodyChange.Spider)
        {
            //if (collision.gameObject.tag == "Vent") //WALL CAWLING FAILED
            //{
            //    spiderBody.useGravity = false;
            //}
            //if (collision.gameObject.tag == "Untagged")
            //{
            //    spiderBody.useGravity = true;
            //}

            if(collision.gameObject.tag == "Finish")
            {
                finalCount.PuzzleSolved++;
                BodyChange.Human = true;
                BodyChange.Spider = false;

            }
        }
    }
}
