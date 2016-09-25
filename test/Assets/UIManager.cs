using UnityEngine;
using System.Collections;

public class UIButtonManager : MonoBehaviour {

    GameObject netManager = GameObject.Find("NetworkManager");

    public void btnLogin()
    {
        Debug.Log("btn login");
        netManager.SendMessage("testLim", 5);
    }

    public void btnJoin()
    {
        Debug.Log("btn join");
    }
}
