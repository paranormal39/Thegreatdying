using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;
public class WebSocketcon : MonoBehaviour
{
     WebSocket ws;

     public GameManager gm;

    public RewardData rewardData;

    public Userwalletdata userwalldata;

    public InputField inputtext;

    public string input;

    public Button loginbutton;
    // Start is called before the first frame update
   public void Start()
    {
        //ws = new WebSocket("ws://localhost:3030");
       ws = new WebSocket("wss://gentle-thicket-83243.herokuapp.com/");
       
        
        ws.Connect();
        //ws.Send("589challenge client v:"+clientvers);
        ws.OnMessage += (sender, e) =>
        {
            string datastring = e.Data;
            Debug.Log(e.Data);
            if(e.Data == "Banned"){
                Application.Quit();
            }
            if(e.Data =="payload"){
                Debug.Log("payload found !");
            }
            Debug.Log("Message Received from "+((WebSocket)sender).Url+", Data : "+e.Data);
            if (e.IsPing ) {
             // Do something to notify that a ping has been received
             Debug.Log("ping recieved" + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
              return;
            }
            //Invoke("moonboistatus",5f);
        };
        
         ws.OnClose += (sender, e) =>
        {
            ws.Send("client xrdoge disconnected");
            Application.Quit();
        }; 
        ws.OnError += (sender, e) => {
            //gm.offlinemode();
            Debug.Log(e.Exception +"in event");
            //Debug.Log(e.Message);
            
        };
    }

    

public void loginbuttonshown(){
    
    if(inputtext.text.Length >15){
        loginbutton.interactable = true;
    }
}

public void ReadStringInput(string s){
    if(s == "" || s.Length <=25 || s.Length >36){
        Debug.Log("error");
        gm.offlinemode();
    }
    Userwalletdata walletdata = new Userwalletdata();
    walletdata.userwallet = s;
    string jsonsign = JsonUtility.ToJson(walletdata,true);
    input = s;
    Debug.Log(jsonsign);
    PlayerPrefs.SetString("wallet",input);
   
    ws.Send(jsonsign);
}

public void rewardcoins(int score){
    RewardData newticket = new RewardData();
    newticket.userwall = input;
    newticket.reward =  score.ToString();
    string json = JsonUtility.ToJson(newticket,true);
    Debug.Log(json);
    //ws.Send("reward");
    ws.Send(json);

    //ws.Send(gm.seassionscore.ToString());
    //ws.Send("reward");
}
    
}
