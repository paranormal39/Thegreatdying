using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigAi : MonoBehaviour
{
    public Ai ai;
    public void Start(){
        ai = GetComponentInParent<Ai>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player"){
        ai.StartCoroutine("attackingplayer");

        }
    }
}
