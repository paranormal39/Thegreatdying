using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
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

    public bool attackingtree;

    public GameObject attacktrig;
    // Start is called before the first frame update
    void Start()
    {
        //FindNewLocation();
        attackingtree = true;
        agent = GetComponent<NavMeshAgent>();
        //.current = state.patroling;
        finalspot = GameObject.FindGameObjectsWithTag("FinalPoint");
        player = GameObject.FindWithTag("Player");
       
        //agent.destination = finalspot.transform.position;

        anim = GetComponent<Animator>();
        StartCoroutine("FindNewLocation");
        //waypoints = GameObject.FindGameObjectsWithTag("FinalPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {

        
        playerpos = player.transform.position;
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }

        if(attackingtree){

        //agent.destination = finalspot.transform.position;

        }

        if(agent.remainingDistance <3){
            AttackAnim();
           // Debug.Log("close enough to attack");
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

    public void gotofinalspot(){
        //agent.SetDestination(finalspot.transform.position);
        //agent.destination = finalspot.transform.position;
        Debug.Log(agent.isPathStale);

    }

    public void AttackAnim(){
        //here is wehre we will call attack animation
        anim.Play("attack");
        StartCoroutine("attacking");
    }

    public IEnumerator attackingplayer(){
        attackingtree = false;
        agent.SetDestination(player.transform.position);

        yield return new WaitForSeconds(2f);
    }

    public IEnumerator attacking(){
        attacktrig.SetActive(true);

        yield return new WaitForSeconds(2f);
    }
}