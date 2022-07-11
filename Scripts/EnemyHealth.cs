using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   
    public float health = 150;

    public GameManager gm;

    public SFXManager sfxm;
    // Update is called once per frame
    public void Start(){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        sfxm = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }
    void Update()
    {
        if(health<=0){
            Destroy(this.gameObject,.01f);
            //gm.addscore();
            gm.enemyslain.Invoke();
        }
        if(gm.currently == GameManager.state.gameover){
            Destroy(this.gameObject,.01f);
        }
    }

    public void TakeDmg(){

            health -=50f;
            
    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.tag == "AoeMele"){
            health -= 75f;
        }
    }
}