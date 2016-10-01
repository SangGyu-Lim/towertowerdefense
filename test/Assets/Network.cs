using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Network : MonoBehaviour {

    enum eNetworkState
    {
        eNONE = 0,
        eJOIN = 1,
        eLOGIN = 2
    }

    // 필요에 따라 url을 수정한다.
    string url = "http://localhost/ll.php";

    eNetworkState currentState { get; set; }
    public string id { get; set; }
    public string passWord { get; set; }
    public string eMail { get; set; }
        
    void ConnectServer(int state)
    {
        // 송신할 데이터 셋팅
        WWWForm sendData = new WWWForm();

        Debug.LogError(state);

        currentState = (eNetworkState)state;
        Debug.LogError((int)currentState);
        // addfield에서 비교할 키값, 데이터 값 순서.
        sendData.AddField("functionName", (int)currentState );
        sendData.AddField("ID", id);
        sendData.AddField("passWord", passWord);

        
        if(currentState == eNetworkState.eJOIN)
            sendData.AddField("eMail", eMail);

        Debug.LogError((int)currentState + " / " + id + " / " + passWord + " / " + eMail);
        
        // 데이터 송신
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForRequest(www));
    }


    // 테스트 코드
    void DisConnectServer()
    {
        Debug.Log("call disconnect server");
    }


    // coroutine 및 출력
    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;



        if (www.error == null)
        {
            Debug.LogError("www success\n");
            Debug.LogError(www.text);
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
}

