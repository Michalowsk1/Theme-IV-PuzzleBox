using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Mouse : MonoBehaviour
{
    Vector3 destination;
    float distance;

    [SerializeField] NavMeshAgent agent;

    [SerializeField] GameObject player;
    int X;
    int Z;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Rat");
    }

    // Update is called once per frame
    void Update()
    {
        X = Random.Range(0, -9);
        Z = Random.Range(0, -7);

        agent.SetDestination(destination);

        destination = new Vector3(X, gameObject.transform.position.y, Z);

        distance = Vector3.Distance(agent.transform.position, destination);

        if(distance < 2)
        {
            X = Random.Range(-2, 5);
            Z = Random.Range(-5, 0);
        }
    }
}
