using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtGround : MonoBehaviour
{
    [SerializeField] GameObject mousePrefab;
    public static int digCount;

    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        digCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(digCount == 3)
        {
            Destroy(gameObject);
            Instantiate(mousePrefab, gameObject.transform.position, Quaternion.identity);
        }
    }
}
