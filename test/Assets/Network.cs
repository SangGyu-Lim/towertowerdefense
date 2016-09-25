using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Network : MonoBehaviour {

    // 필요에 따라 url을 수정한다.
    string url = "http://localhost/connect.php";

    public void testLim(int a)
    {
        Debug.Log(a);
    }

    public void ConnectServer()
    {
        // 송신할 데이터 셋팅
        WWWForm sendData = new WWWForm();
        // addfield에서 비교할 키값, 데이터 값 순서.
        sendData.AddField("characterKey", "1");
        // 데이터 송신
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForRequest(www));
    }


    // 테스트 코드
    public void DisConnectServer()
    {
        Debug.Log("call disconnect server");
    }


    // coroutine 및 출력
    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            Debug.Log("www success\n");

            string[] dataTexts = www.text.Split(',');

            foreach (string dataText in dataTexts)
                Debug.Log(dataText);
        }
        else
        {
            Debug.Log("www error : " + www.error);
        }
    }
}
