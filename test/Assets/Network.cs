﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Network : MonoBehaviour {

    enum eNetworkState
    {
        eNONE = 0,
        eJOIN = 1,
        eLOGIN = 2,
        eLOBBY_INFORMATION = 3,

        eSUCCESS_JOIN = 11,
        eSUCCESS_LOGIN = 12,
        eSUCCESS_LOBBY_INFORMATION = 13,

        eERROR_JOIN = 1001,
        eERROR_LOGIN = 1002,
        eERROR_LOBBY_INFORMATION = 1003
    }

    // 필요에 따라 url을 수정한다.
    string url = "http://192.168.0.116/connect.php";

    eNetworkState eCurrentState = eNetworkState.eNONE;
    public int currentState { get { return (int)eCurrentState; } }
    public string id { get; set; }
    public string passWord { get; set; }
    public string eMail { get; set; }
    public int bestScore { get; set; }
    public int currentStage { get; set; }

    void Awake()
    {
        Debug.Log("network awake");
        DontDestroyOnLoad(this);
    }

    void ConnectServer(int state)
    {
        // 송신할 데이터 셋팅
        WWWForm sendData = new WWWForm();

        Debug.LogError(state);

        changeState(state);
        Debug.LogError(currentState);
        // addfield에서 비교할 키값, 데이터 값 순서.
        sendData.AddField("functionName", currentState);
        sendData.AddField("ID", id);
        sendData.AddField("passWord", passWord);


        if (eCurrentState == eNetworkState.eJOIN)
            sendData.AddField("eMail", eMail);

        Debug.LogError((int)currentState + " / " + id + " / " + passWord + " / " + eMail);
        
        // 데이터 송신
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForRequest(www));
    }
    
    void getLobbyInformation(int state)
    {
        // 송신할 데이터 셋팅
        WWWForm sendData = new WWWForm();

        Debug.LogError(state);

        changeState(state);
        Debug.LogError(currentState);
        // addfield에서 비교할 키값, 데이터 값 순서.
        sendData.AddField("functionName", currentState);
        sendData.AddField("ID", id);

        Debug.LogError((int)currentState + " / " + id);

        // 데이터 송신
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForLobby(www));
    }

    // coroutine 및 출력, 로그인, 회원가입.
    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
               

        if (www.error == null)
        {
            Debug.LogError("www success\n");
            Debug.LogError(www.text);

            changeState(int.Parse(www.text.ToString()));
			Debug.LogError(currentState);
            
        }
        else
        {
            Debug.LogError("www error : " + www.error);
        }
    }

    // coroutine 및 출력, 로비 정보.
    private IEnumerator WaitForLobby(WWW www)
    {
        yield return www;


        if (www.error == null)
        {
            Debug.LogError("www success\n");
            Debug.LogError(www.text);

            string[] dataTexts = www.text.Split('/');


            changeState(int.Parse(dataTexts[0]));
            bestScore = int.Parse(dataTexts[1]);
            currentStage = int.Parse(dataTexts[2]);


            Debug.LogError(currentState);


            //foreach (string dataText in dataTexts)
            //{
            //    Debug.LogError(dataText);
            //}

            
        }
        else
        {
            Debug.LogError("www error : " + www.error);
        }
    }

    void changeState(int state)
    {
        switch((eNetworkState)state)
        {
            case eNetworkState.eNONE:
                {
                    eCurrentState = eNetworkState.eNONE;
                } break;


            case eNetworkState.eJOIN:
                {
                    eCurrentState = eNetworkState.eJOIN;
                } break;
            case eNetworkState.eLOGIN:
                {
                    eCurrentState = eNetworkState.eLOGIN;
                } break;
            case eNetworkState.eLOBBY_INFORMATION:
                {
                    eCurrentState = eNetworkState.eLOBBY_INFORMATION;
                } break;


            case eNetworkState.eSUCCESS_JOIN:
                {
                    eCurrentState = eNetworkState.eSUCCESS_JOIN;
                } break;
            case eNetworkState.eSUCCESS_LOGIN:
                {
                    eCurrentState = eNetworkState.eSUCCESS_LOGIN;
                } break;
            case eNetworkState.eSUCCESS_LOBBY_INFORMATION:
                {
                    eCurrentState = eNetworkState.eSUCCESS_LOBBY_INFORMATION;
                } break;


            case eNetworkState.eERROR_JOIN:
                {
                    eCurrentState = eNetworkState.eERROR_JOIN;
                } break;
            case eNetworkState.eERROR_LOGIN:
                {
                    eCurrentState = eNetworkState.eERROR_LOGIN;
                } break;
            case eNetworkState.eERROR_LOBBY_INFORMATION:
                {
                    eCurrentState = eNetworkState.eERROR_LOBBY_INFORMATION;
                } break;
        }
    }
}

