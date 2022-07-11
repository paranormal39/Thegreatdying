using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour {
    
    public enum state
    {
        InMenu,
        playing,
        pause,
        gameover
           }

    public state currently;

    public float gamertimer;
    public float spawntimer;
    public GameObject zombie;
    public GameObject[] zombies;
    public GameObject[] orcs;
    public GameObject[] spawnpoints;

    public float TreeHealth;
    public Slider treeslide;

    public int score;
    public TMP_Text scoretext;

    //ui gameObjects
    public GameObject StartPanel,GameOverPanel,PlayPanel;

    public GameObject playerObject;
    public MageMovement playermovement;
    public PlayerStats playerstats;
    public float ph;
    public TMP_Text playerhealth, playermana;

    public int enemyskilled;

    public float mot;  ///manaovertime or the amount regain

    public UnityEvent enemyslain;

    public GameObject maincamera;

    public sendERC20Token senderctoken;
     
    public WebSocketcon wsc;

    public GameObject websocketobject;

    private void Awake()
    {
        currently = state.InMenu;
        spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        playermovement = playerObject.GetComponent<MageMovement>();

    }
    public void Start(){
        //enemyslain.AddListener(addscore);
        
    }

	// Update is called once per frame
	void Update () {
        zombies = GameObject.FindGameObjectsWithTag("Enemy");
        scoretext.text = score.ToString();
        TreeHealth = GameObject.Find("GreatTree").GetComponent<GreatTreeHealth>().treehealth;
        playerhealth.text = playerstats.health.ToString();
        playermana.text = playerstats.mana.ToString();
        treeslide.value = TreeHealth;
            switch(currently){
                case state.playing:
                 Cursor.visible = false;
                 Cursor.lockState = CursorLockMode.Locked;
                maincamera.SetActive(false);
                playerObject = GameObject.Find("Player");
                playerstats = GameObject.Find("Player").GetComponent<PlayerStats>();
                ph = playerstats.health;
                scoretext.text = score.ToString();
                gamertimer += Time.deltaTime;
                spawntimer -= Time.deltaTime;
                if(TreeHealth < 0 || ph < 0 ){
                    Debug.Log("TreeHealth is 0");
                    //cashout(score);
                    wsc.rewardcoins(score);
                    currently = state.gameover;
                }
                if(spawntimer <=0){
                    StartCoroutine("respawnNewEnemys");
                }



                break;

                case state.InMenu:

                break;

                case state.pause:

                break;

                case state.gameover:
              
                maincamera.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                GameOverPanel.SetActive(true);
                playerObject.SetActive(false);
                PlayPanel.SetActive(false);
                score = 0;


                break;
            }

	}
    public void Play()
    {
        currently = state.playing;
        StartCoroutine("respawnNewEnemys");
        playerstats.newgame();
        playermovement.restartgame();
       playermovement.enablecontroller();
       
        
    }

    public void SetGameOver(){
        currently = state.gameover;
        
    }

    public void cashout(int cashscore){
        senderctoken.CashOut(cashscore);
    }

    public IEnumerator respawnNewEnemys(){

        if(zombies.Length < 25){
            int random = Random.Range(0,spawnpoints.Length);
            int zombiespawn = Random.Range(0,3);
            Instantiate(orcs  [zombiespawn],spawnpoints[random].transform.position,spawnpoints[random].transform.rotation);
        }
        spawntimer = 2f;
        yield return new WaitForSeconds(2);
    }

    public void addscore(){
        score +=1;
    }

    public void doublescore(){
        score +=2;
    }

    public void retrygame(){
        StartCoroutine("RestarGame");
    }

    public IEnumerator RestarGame(){
        
        
        playerstats.newgame();
        playermovement.restartgame();
        

        yield return new WaitForSeconds(1f);
        currently = state.playing;
    }

    public void offlinemode(){
        websocketobject.SetActive(false);
    }
    public void setTrustLine(){
        Application.OpenURL("https://xrpl.services?issuer=rMczrvMki7DuXsuMf3zGUrqAmWvLKZNnt2&currency=GamerXGold&limit=10000000000");
    }
}