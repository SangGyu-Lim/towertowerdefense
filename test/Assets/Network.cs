using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Network : MonoBehaviour {

    enum eNetworkState
    {
        eNONE = 0,
        eJOIN = 1,
        eLOGIN = 2,

        eSUCCESS_JOIN = 11,
        eSUCCESS_LOGIN = 12,

        eERROR_JOIN = 1001,
        eERROR_LOGIN = 1002
    }

    // 필요에 따라 url을 수정한다.
    string url = "http://192.168.0.116/connect.php";

	public int currentState { get; set; }
    public string id { get; set; }
    public string passWord { get; set; }
    public string eMail { get; set; }
        
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

        
        if((eNetworkState)currentState == eNetworkState.eJOIN)
            sendData.AddField("eMail", eMail);

        Debug.LogError((int)currentState + " / " + id + " / " + passWord + " / " + eMail);
        
        // 데이터 송신
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForRequest(www));
    }

    // coroutine 및 출력
    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
               

        if (www.error == null)
        {
            Debug.LogError("www success\n");
            Debug.LogError(www.text);

            changeState(int.Parse(www.text));
			Debug.LogError(currentState);
            
            //string[] dataTexts = www.text.Split(',');

            
            //foreach (string dataText in dataTexts)
            //    //Debug.Log(dataText);
            //    Debug.LogError(dataText);
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
				    currentState = (int)eNetworkState.eNONE;
                } break;
            case eNetworkState.eJOIN:
                {
                    currentState = (int)eNetworkState.eJOIN;
                } break;
            case eNetworkState.eLOGIN:
                {
                    currentState = (int)eNetworkState.eLOGIN;
                } break;
            case eNetworkState.eSUCCESS_JOIN:
                {
                    currentState = (int)eNetworkState.eSUCCESS_JOIN;
                } break;
            case eNetworkState.eSUCCESS_LOGIN:
                {
                    currentState = (int)eNetworkState.eSUCCESS_LOGIN;
                } break;
            case eNetworkState.eERROR_JOIN:
                {
                    currentState = (int)eNetworkState.eERROR_JOIN;
                } break;
            case eNetworkState.eERROR_LOGIN:
                {
                    currentState = (int)eNetworkState.eERROR_LOGIN;
                } break;
        }
    }
}

