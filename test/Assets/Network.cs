using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Network : MonoBehaviour {

    string url = "http://localhost/connect.php";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ConnectServer()
    {
        WWWForm sendData = new WWWForm();
        sendData.AddField("characterKey", "1");
        WWW www = new WWW(url, sendData);
        StartCoroutine(WaitForRequest(www));
    }


    //public WWW GET()
    //{
    //    WWW www = new WWW(url);
    //    StartCoroutine(WaitForRequest(www));
    //}

    public void DisConnectServer()
    {
        Debug.Log("call disconnect server");
    }

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
