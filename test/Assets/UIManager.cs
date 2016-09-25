using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public UIInput inputId;
    public UIInput inputPwd;

    public void btnLogin()
    {
        Debug.Log("btn login");

        GameObject netManager = GameObject.Find("NetworkManager");

        netManager.SendMessage("ConnectServer");
        

    }

    public void btnJoin()
    {

        GameObject netManager = GameObject.Find("NetworkManager");

        netManager.SendMessage("testLim");

        Debug.Log("btn join");       
    }
}