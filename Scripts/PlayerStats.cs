using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health, mana;

    public float tick = 3;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        mana =250;
    }

    // Update is called once per frame
    void Update()
    {
        tick -= Time.deltaTime;

        if(tick <=0){
            tick = 3;
            addmana();
        }

        if(mana >=250){
            mana = 250;
        }
        
    }
    public void manashot(){
        mana -=5;
    }

    public void manapotion(){
        mana +=75f;
    }

    public void healthpot(){
        health +=35f;
    }

    public void newgame(){
        health = 100f;
        mana = 250;
    }

    public void addmana(){
        mana +=7;
    }

    public void melemanaattack(){
        mana -= 50f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag =="enemymele"){
            health -=15;
        }

        if(other.gameObject.transform.tag =="ManaPot"){
            manapotion();
        }

        if(other.gameObject.transform.tag == "HealthPot"){
            healthpot();
        }
    }
}
