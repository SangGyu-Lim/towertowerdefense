using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Network : MonoBehaviour {

    enum eNetworkState
    {
        eNONE = 0,
        eJOIN = 1,
        eLOGIN = 2,
        eLOBBY_INFORMATION = 3,
        eFIND_MEMBER = 4,
        eSAVE_TOWER = 5,
        eSAVE_MONSTER = 6,
        eLOAD_TOWER = 7,
        eLOAD_MONSTER = 8,
        eSAVE_SCORE_STAGE = 9,

        eSUCCESS_JOIN = 11,
        eSUCCESS_LOGIN = 12,
        eSUCCESS_LOBBY_INFORMATION = 13,
        eSUCCESS_FIND_MEMBER = 14,
        eSUCCESS_SAVE_TOWER = 15,
        eSUCCESS_SAVE_MONSTER = 16,
        eSUCCESS_LOAD_TOWER = 17,
        eSUCCESS_LOAD_MONSTER = 18,
        eSUCCESS_SAVE_SCORE_STAGE = 19,

        eERROR_JOIN = 1001,
        eERROR_LOGIN = 1002,
        eERROR_LOBBY_INFORMATION = 1003,
        eERROR_FIND_MEMBER = 1004,
        eERROR_SAVE_TOWER = 1005,
        eERROR_SAVE_MONSTER = 1006,
        eERROR_LOAD_TOWER = 1007,
        eERROR_LOAD_MONSTER = 1008,
        eERROR_SAVE_SCORE_STAGE = 1009,
    }

    // 필요에 따라 url을 수정한다.
	string url = "http://210.107.231.38/connect.php";

    eNetworkState eCurrentState = eNetworkState.eNONE;
    public int currentState { get { return (int)eCurrentState; } set { eCurrentState = eNetworkState.eNONE; } }
    public string id { get; set; }
    public string passWord { get; set; }
    public string eMail { get; set; }
    public int bestScore { get; set; }
    public int currentStage { get; set; }
    public string tower { get; set; }
    public string[] monster;


    void Awake()
    {
        Debug.Log("network awake");
        DontDestroyOnLoad(this);

        monster = new string[10];
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

    void getMemberInformation(int state)
    {
        // 송신할 데이터 셋팅
        WWWForm sendData = new WWWForm();

        Debug.LogError(state);

        changeState(state);
        Debug.LogError(currentState);
        // addfield에서 비교할 키값, 데이터 값 순서.
        sendData.AddField("functionName", currentState);
        sendData.AddField("eMail", eMail);

        Debug.LogError((int)currentState + " / " + id);

        // 데이터 송신
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForFindMember(www));
    }

    void saveBuildTower(int state)
    {
        // 송신할 데이터 셋팅
        WWWForm sendData = new WWWForm();

        Debug.LogError(state);

        changeState(state);
        Debug.LogError(currentState);
        // addfield에서 비교할 키값, 데이터 값 순서.
        sendData.AddField("functionName", currentState);
        sendData.AddField("ID", id);
		if(tower == "")
			sendData.AddField("towerDataString", "-1");
		else
			sendData.AddField("towerDataString", tower);

        // 데이터 송신
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForSaveTower(www));
    }

    void saveMonster(int state)
    {
        // 송신할 데이터 셋팅
        WWWForm sendData = new WWWForm();

        Debug.LogError(state);

        changeState(state);
        Debug.LogError(currentState);
        // addfield에서 비교할 키값, 데이터 값 순서.
        sendData.AddField("functionName", currentState);
        sendData.AddField("ID", id);

        for (int i = 0; i < 10; ++i)
        {
			if(monster[i] == null)
				sendData.AddField("monsterDataString" + (i + 1), "-1");   
			else
				sendData.AddField("monsterDataString" + (i + 1), monster[i]);
        }
            

        // 데이터 송신
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForSaveMonster(www));
    }

    void saveScoreStage(int state)
    {
        // 송신할 데이터 셋팅
        WWWForm sendData = new WWWForm();

        Debug.LogError(state);

        changeState(state);
        Debug.LogError(currentState);
        // addfield에서 비교할 키값, 데이터 값 순서.
        sendData.AddField("functionName", currentState);
        sendData.AddField("ID", id);
        sendData.AddField("score", bestScore);
        sendData.AddField("stage", currentStage);
        
         
            

        // 데이터 송신
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForSaveScoreStage(www));
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

    // 아이디, 비밀번호 찾기
    private IEnumerator WaitForFindMember(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            string[] dataTexts = www.text.Split('/');

            changeState(int.Parse(dataTexts[0]));
            id = dataTexts[1];
            passWord = dataTexts[2];

        }
        else
        {
            Debug.LogError("www error : " + www.error);
        }
    }

    private IEnumerator WaitForSaveTower(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            changeState(int.Parse(www.text));
        }
        else
        {
            Debug.LogError("www error : " + www.error);
        }

        
    }

    private IEnumerator WaitForSaveMonster(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            changeState(int.Parse(www.text));
        }
        else
        {
            Debug.LogError("www error : " + www.error);
        }

        
    }

    private IEnumerator WaitForSaveScoreStage(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            changeState(int.Parse(www.text));
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
            case eNetworkState.eFIND_MEMBER:
                {
                    eCurrentState = eNetworkState.eFIND_MEMBER;
                } break;
            case eNetworkState.eSAVE_TOWER:
                {
                    eCurrentState = eNetworkState.eSAVE_TOWER;
                } break;
            case eNetworkState.eSAVE_MONSTER:
                {
                    eCurrentState = eNetworkState.eSAVE_MONSTER;
                } break;
            case eNetworkState.eLOAD_MONSTER:
                {
                    eCurrentState = eNetworkState.eLOAD_MONSTER;
                } break;
            case eNetworkState.eLOAD_TOWER:
                {
                    eCurrentState = eNetworkState.eLOAD_TOWER;
                } break;
            case eNetworkState.eSAVE_SCORE_STAGE:
                {
                    eCurrentState = eNetworkState.eSAVE_SCORE_STAGE;
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
            case eNetworkState.eSUCCESS_FIND_MEMBER:
                {
                    eCurrentState = eNetworkState.eSUCCESS_FIND_MEMBER;
                } break;
            case eNetworkState.eSUCCESS_SAVE_TOWER:
                {
                    eCurrentState = eNetworkState.eSUCCESS_SAVE_TOWER;
                } break;
            case eNetworkState.eSUCCESS_SAVE_MONSTER:
                {
                    eCurrentState = eNetworkState.eSUCCESS_SAVE_MONSTER;
                } break;
            case eNetworkState.eSUCCESS_LOAD_MONSTER:
                {
                    eCurrentState = eNetworkState.eSUCCESS_LOAD_MONSTER;
                } break;
            case eNetworkState.eSUCCESS_LOAD_TOWER:
                {
                    eCurrentState = eNetworkState.eSUCCESS_LOAD_TOWER;
                } break;
            case eNetworkState.eSUCCESS_SAVE_SCORE_STAGE:
                {
                    eCurrentState = eNetworkState.eSUCCESS_SAVE_SCORE_STAGE;
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
            case eNetworkState.eERROR_FIND_MEMBER:
                {
                    eCurrentState = eNetworkState.eERROR_FIND_MEMBER;
                } break;
            case eNetworkState.eERROR_SAVE_TOWER:
                {
                    eCurrentState = eNetworkState.eERROR_SAVE_TOWER;
                } break;
            case eNetworkState.eERROR_SAVE_MONSTER:
                {
                    eCurrentState = eNetworkState.eERROR_SAVE_MONSTER;
                } break;                
            case eNetworkState.eERROR_LOAD_MONSTER:
                {
                    eCurrentState = eNetworkState.eERROR_LOAD_MONSTER;
                } break;
            case eNetworkState.eERROR_LOAD_TOWER:
                {
                    eCurrentState = eNetworkState.eERROR_LOAD_TOWER;
                } break;
            case eNetworkState.eERROR_SAVE_SCORE_STAGE:
                {
                    eCurrentState = eNetworkState.eERROR_SAVE_SCORE_STAGE;
                } break;
        }
    }
}

