using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Mouse : MonoBehaviour
{
    Vector3 destination;
    Vector3 Newdestination;
    Vector3 MoveAway;
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

        agent.SetDestination(MoveAway);

        MoveAway = agent.transform.position - player.transform.position;

        transform.Translate(MoveAway.normalized * 1.5f * Time.deltaTime);

    }
}
