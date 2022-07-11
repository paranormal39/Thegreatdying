using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatTreeHealth : MonoBehaviour
{
    public float treehealth;
    // Start is called before the first frame update
    void Start()
    {
        treehealth = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.tag == "Enemy"){
        treehealth -= .01f;
        }
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        
        treehealth -= .015f;
    }

    public void restarttree(){
        treehealth = 200;
    }
   
}
