using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIIntroManager : MonoBehaviour {

	enum eState
	{
		eNONE = 0,
		eJOIN = 1,
		eLOGIN = 2,

		eSUCCESS_JOIN = 11,
		eSUCCESS_LOGIN = 12,

		eERROR_JOIN = 1001,
		eERROR_LOGIN = 1002
	}

	GameObject netManager;

	public UIInput inputId;
	public UIInput inputPwd;
	public UIInput inputEmail;

	eState currentState = eState.eNONE;
	eState state = eState.eNONE;

	// Use this for initialization
	void Start () {
		Debug.Log("start");
        netManager = GameObject.Find("Network");        
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("updata");

        state = (eState)netManager.gameObject.GetComponent<Network>().currentState;
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

        state = eState.eLOGIN;

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

		Debug.Log("btn join");
	}

	// 회원가입
	public void btnJoinMember()
	{
        state = eState.eJOIN;        

		connectNetwork();

		Debug.Log("btn join member");
	}

	// 회원가입 화면에서 뒤로가기
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
		netManager.gameObject.GetComponent<Network>().id = inputId.value.ToString();
		netManager.gameObject.GetComponent<Network>().passWord = inputPwd.value.ToString();

        if (state == eState.eJOIN)
			netManager.gameObject.GetComponent<Network>().eMail = inputEmail.value.ToString();

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
            case eState.eNONE:
                {
                    Debug.Log("eNONE");
                } break;
            case eState.eJOIN:
                {
                    Debug.Log("eJOIN");
                } break;
            case eState.eLOGIN:
                {
                    Debug.Log("eLOGIN");
                } break;
		    case eState.eSUCCESS_LOGIN:
		    	{
		    		SceneManager.LoadScene(1);
		    	} break;
		    case eState.eERROR_LOGIN:
		    	{
		    		Debug.LogError("eERROR_LOGIN");
		    	} break;
		    case eState.eSUCCESS_JOIN:
		    	{
		    		btnBack();
		    	} break;
		    case eState.eERROR_JOIN:
		    	{
		    		Debug.LogError("eERROR_JOIN");
		    	} break;
		}
	}
}
