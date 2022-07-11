using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PesantAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject player,gt;
    // Start is called before the first frame update
    void Start()
    {
        gt = GameObject.FindWithTag("FinalPoint");
        agent.SetDestination(gt.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
