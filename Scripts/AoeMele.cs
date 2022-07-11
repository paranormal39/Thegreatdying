using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeMele : MonoBehaviour
{

    public float mana;

    public PlayerStats ps;

    
    public GameObject meleaoe;

    public GameObject AOESpell;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PlayerStats>();
        mana = ps.mana;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && mana >75f){
            StartCoroutine("activatemele");
            
        }
    }

    public IEnumerator activatemele(){
        meleaoe.SetActive(true);
        Instantiate(AOESpell,this.gameObject.transform.position,this.gameObject.transform.rotation);
        yield return new WaitForSeconds(2f);
        meleaoe.SetActive(false);
    }

}
