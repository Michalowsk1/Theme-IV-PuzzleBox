using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class DirtGround : MonoBehaviour
{
    [SerializeField] GameObject mousePrefab;
    [SerializeField] GameObject DirtPos;
    public static int digCount;
    public static bool Digging;

    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        digCount = 0;
        Digging = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.position.y <= -0.1f)
        {
            Destroy(gameObject);
            Instantiate(mousePrefab, gameObject.transform.position, Quaternion.identity);
        }
    }
}
