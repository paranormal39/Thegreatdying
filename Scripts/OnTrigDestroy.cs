using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player"){
            Destroy(this.gameObject,.01f);
        }
    }
}
