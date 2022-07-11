using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai2 : MonoBehaviour
{

    public Transform[] waypoints;
    public NavMeshAgent agent;

    public enum state{patroling,Attack};
    public state current;

    public bool reachedposition;

    public int random;
    public GameObject[] finalspot;

    public GameObject player;

    public Vector3 playerpos;

    public Animator anim;

    public bool performingattack;

   
    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        //.current = state.patroling;
        
        player = GameObject.FindWithTag("Player");
       
        //agent.destination = finalspot.transform.position;

        anim = GetComponent<Animator>();

        performingattack = false;
        
        //waypoints = GameObject.FindGameObjectsWithTag("FinalPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        playerpos = player.transform.position;
        agent.destination = playerpos;
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }


        if(agent.remainingDistance <3 && performingattack == false){
            StartCoroutine("attacking");
        }
      
    }

    public IEnumerator FindNewLocation(){
        random = Random.Range(0,3);

        switch(random){
            case 0:
            agent.SetDestination(finalspot[0].transform.position);
            agent.destination = finalspot[0].transform.position;
            break;

            case 1:
            agent.SetDestination(finalspot[1].transform.position);

            break;

            case 2:
            agent.SetDestination(finalspot[2].transform.position);
            break;

            case 3:
            agent.SetDestination(finalspot[3].transform.position);
            break;

            yield return new WaitForSeconds(30f);
        }

    }

   

    public void AttackAnim(){
        //here is wehre we will call attack animation
        anim.Play("Attack");
        StartCoroutine("attacking");
    }

    public IEnumerator attackingplayer(){
        agent.SetDestination(player.transform.position);

        yield return new WaitForSeconds(2f);
    }

    public IEnumerator attacking(){
       anim.Play("Attack");
        performingattack = true;

        yield return new WaitForSeconds(3f);
        performingattack = false;
    }
}