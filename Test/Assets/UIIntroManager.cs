using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIIntroManager : MonoBehaviour {

	enum eIntroState
	{
		eNONE = 0,
		eJOIN = 1,
		eLOGIN = 2,
        eFIND_MEMBER = 4,

		eSUCCESS_JOIN = 11,
		eSUCCESS_LOGIN = 12,
        eSUCCESS_FIND_MEMBER = 14,

		eERROR_JOIN = 1001,
		eERROR_LOGIN = 1002,
        eERROR_FIND_MEMBER = 1004
	}

	GameObject netManager;

	public UIInput inputId;
	public UIInput inputPwd;
	public UIInput inputEmail;

    public UILabel labelId;
    public UILabel labelPassword;

    eIntroState currentState = eIntroState.eNONE;
    eIntroState state = eIntroState.eNONE;

    const string notFind = "not exist or information incorrect";

	// Use this for initialization
	void Start () {
		Debug.Log("intro start");
        netManager = GameObject.Find("Network");      
        
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("updata");

        state = (eIntroState)netManager.gameObject.GetComponent<Network>().currentState;
        if (currentState != state)
        {
            currentState = state;
            confirm();
        }
	}

	// 로그인
	public void btnLogin()
	{
		Debug.Log("btn login");

        state = eIntroState.eLOGIN;
        currentState = eIntroState.eLOGIN;

		connectNetwork();
	}

	// 회원가입 화면 이동
	public void btnJoin()
	{
		changeActiveGameObject("ButtonJoin", false);
		changeActiveGameObject("ButtonLogin", false);

		inputEmail.gameObject.SetActive(true);
		changeActiveGameObject("ButtonJoinMember", true);
		changeActiveGameObject("ButtonBack", true);

        inputUIReset();

		Debug.Log("btn join");
	}

	// 회원가입
	public void btnJoinMember()
	{
        state = eIntroState.eJOIN;
        currentState = eIntroState.eJOIN;    

		connectNetwork();

		Debug.Log("btn join member");
	}

	// 회원가입 화면에서 뒤로가기
	public void btnBack()
	{
		changeActiveGameObject("ButtonJoin", true);
		changeActiveGameObject("ButtonLogin", true);

        inputUIReset();

		inputEmail.gameObject.SetActive(false);
		changeActiveGameObject("ButtonJoinMember", false);
		changeActiveGameObject("ButtonBack", false);

		Debug.Log("btn back");
	}

    public void btnFind()
    {
        changeActiveGameObject("ButtonJoin", false);
        changeActiveGameObject("ButtonLogin", false);

        inputUIReset();

        inputId.gameObject.SetActive(false);
        inputPwd.gameObject.SetActive(false);
        inputEmail.gameObject.SetActive(true);
        changeActiveGameObject("ButtonFindBack", true);
        changeActiveGameObject("ButtonFindMember", true);

        changeActiveGameObject("ButtonFind", false);
    }

    public void btnFindBack()
    {
        changeActiveGameObject("ButtonJoin", true);
        changeActiveGameObject("ButtonLogin", true);
        changeActiveGameObject("ButtonFind", true);

        inputUIReset();

        inputId.gameObject.SetActive(true);
        inputPwd.gameObject.SetActive(true);
        inputEmail.gameObject.SetActive(false);
        labelId.gameObject.SetActive(false);
        labelPassword.gameObject.SetActive(false);
        changeActiveGameObject("ButtonFindBack", false);
        changeActiveGameObject("ButtonFindMember", false);
    }

    public void btnFindMember()
    {
        state = eIntroState.eFIND_MEMBER;
        currentState = eIntroState.eFIND_MEMBER;

        netManager.gameObject.GetComponent<Network>().eMail = inputEmail.value.ToString();

        inputUIReset();
        netManager.SendMessage("getMemberInformation", (int)state);
    }

    void setMemberInformation(string id, string pwd)
    {
        labelId.gameObject.SetActive(true);
        labelPassword.gameObject.SetActive(true);

        labelId.text = "find id is " + id;
        labelPassword.text = "find password is " + pwd;
    }

	void connectNetwork()
	{
		netManager.gameObject.GetComponent<Network>().id = inputId.value.ToString();
		netManager.gameObject.GetComponent<Network>().passWord = inputPwd.value.ToString();

        if (state == eIntroState.eJOIN)
			netManager.gameObject.GetComponent<Network>().eMail = inputEmail.value.ToString();

        inputUIReset();
        netManager.SendMessage("ConnectServer", (int)state);
		
	}

	// 회원가입 화면으로 변경 및 로그인 화면으로 복귀
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

	// 로그인 및 회원가입 확인
	void confirm()
	{
		switch (currentState)
		{
            case eIntroState.eNONE:
                {
                    Debug.Log("eNONE");
                } break;
            case eIntroState.eJOIN:
                {
                    Debug.Log("eJOIN");
                } break;
            case eIntroState.eLOGIN:
                {
                    Debug.Log("eLOGIN");
                } break;
            case eIntroState.eFIND_MEMBER:
                {
                    Debug.Log("eFIND_MEMBER");
                } break;


            case eIntroState.eSUCCESS_LOGIN:
		    	{
		    		SceneManager.LoadScene(1);
		    	} break;
            case eIntroState.eSUCCESS_JOIN:
                {
                    btnBack();
                } break;
            case eIntroState.eSUCCESS_FIND_MEMBER:
                {
                    inputEmail.gameObject.SetActive(false);
                    changeActiveGameObject("ButtonFindMember", false);
                    setMemberInformation(netManager.gameObject.GetComponent<Network>().id, netManager.gameObject.GetComponent<Network>().passWord);
                } break;


            case eIntroState.eERROR_LOGIN:
		    	{
		    		Debug.LogError("eERROR_LOGIN");
		    	} break;            
            case eIntroState.eERROR_JOIN:
		    	{
		    		Debug.LogError("eERROR_JOIN");
		    	} break;
            case eIntroState.eERROR_FIND_MEMBER:
                {
                    inputEmail.gameObject.SetActive(false);
                    changeActiveGameObject("ButtonFindMember", false);
                    setMemberInformation(notFind, notFind);
                } break;
		}
	}

    void inputUIReset()
    {
        inputId.value = "";
        inputPwd.value = "";
        inputEmail.value = "";
    }
}
