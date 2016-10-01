using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    enum eState
    {
        eNONE = 0,
        eJOIN = 1,
        eLOGIN = 2
    }

    GameObject netManager;

    public UIInput inputId;
    public UIInput inputPwd;
    public UIInput inputEmail;

    eState currentState;



    public void btnLogin()
    {
        Debug.Log("btn login");

        currentState = eState.eLOGIN;

        connectNetwork();

    }

    public void btnJoin()
    {
        changeActiveGameObject("ButtonJoin", false);
        changeActiveGameObject("ButtonLogin", false);

        inputEmail.gameObject.SetActive(true);
        changeActiveGameObject("ButtonJoinMember", true);
        changeActiveGameObject("ButtonBack", true);

        Debug.Log("btn join");
    }

    public void btnJoinMember()
    {
        currentState = eState.eJOIN;        

        connectNetwork();

        btnBack();
        Debug.Log("btn join member");
    }

    public void btnBack()
    {
        changeActiveGameObject("ButtonJoin", true);
        changeActiveGameObject("ButtonLogin", true);

        inputEmail.gameObject.SetActive(false);
        changeActiveGameObject("ButtonJoinMember", false);
        changeActiveGameObject("ButtonBack", false);

        Debug.Log("btn back");
    }

    void connectNetwork()
    {
        netManager = GameObject.Find("Network");
        
        netManager.gameObject.GetComponent<Network>().id = inputId.value.ToString();
        netManager.gameObject.GetComponent<Network>().passWord = inputPwd.value.ToString();

        if (currentState == eState.eJOIN)
            netManager.gameObject.GetComponent<Network>().eMail = inputEmail.value.ToString();

        netManager.SendMessage("ConnectServer", (int)currentState);
    }

    void changeActiveGameObject(string str, bool state)
    {
        Debug.Log(str + state);

		if (state)
        {
			//GameObject goTemp = GameObject.Find ("Btn").transform.FindChild (str).gameObject.SetActive (state);
            GameObject goTemp = GameObject.Find("Btn");
            goTemp.transform.FindChild(str).gameObject.SetActive(state);
		}
		else
		{
			//GameObject goTemp = GameObject.Find (str).gameObject.SetActive (state);
            GameObject goTemp = GameObject.Find(str);
            goTemp.gameObject.SetActive(state);
		}

        Debug.Log(str + " completion");
    }
}