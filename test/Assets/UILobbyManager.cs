using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UILobbyManager : MonoBehaviour {

    enum eLobbyState
    {
        eNONE = 0,
        eLOBBY_INFORMATION = 3,

        eSUCCESS_LOBBY_INFORMATION = 13,

        eERROR_LOBBY_INFORMATION = 1003
    }

    enum eCurrentStage
    {
        eEASY = 0,
        eNORMAL = 1,
        eHARD = 2
    }

    GameObject netManager;

    public UILabel labelId;
    public UILabel labelBestScore;

    eLobbyState currentState = eLobbyState.eLOBBY_INFORMATION;
    eLobbyState state = eLobbyState.eLOBBY_INFORMATION;

    eCurrentStage stage = eCurrentStage.eEASY;

    void Start()
    {
        Debug.Log("lobby start");

        getValue();
    }

    void Update()
    {
        Debug.Log("update");

        state = (eLobbyState)netManager.gameObject.GetComponent<Network>().currentState;
        if (currentState != state)
        {
            currentState = state;
            confirm();
        }
    }

    public void btnBackLoginScene()
    {
        SceneManager.LoadScene(0);

        Debug.Log("btn back");
    }

	public void btnEnterStage()
	{
		SceneManager.LoadScene(2);

		Debug.Log("btn enter stage");
	}

    public void btnEnterEasyStage()
    {
        Debug.Log("enter easy stage");
    }

    public void btnEnterNormalStage()
    {
        Debug.Log("enter normal stage");
    }

    public void btnEnterHardStage()
    {
        Debug.Log("enter hard stage");
    }

    void getValue()
    {
        netManager = GameObject.Find("Network");

        netManager.SendMessage("getLobbyInformation", (int)state);

    }

    void setLabel()
    {
        labelId.text = "id : " + netManager.GetComponent<Network>().id;
        labelBestScore.text = "best score\n" + netManager.GetComponent<Network>().bestScore.ToString();
    }

    void setStage()
    {
        stage = (eCurrentStage)netManager.gameObject.GetComponent<Network>().currentStage;

        switch (stage)
        {
            case eCurrentStage.eEASY:
                {
                    GameObject.Find("Normal").SetActive(false);
                    GameObject.Find("Hard").SetActive(false);
                } break;
            case eCurrentStage.eNORMAL:
                {
                    GameObject.Find("Hard").SetActive(false);
                } break;
            case eCurrentStage.eHARD:
                {
                } break;
        }
    }

    void confirm()
    {
        switch (currentState)
        {
            case eLobbyState.eNONE:
                {
                    Debug.Log("eNONE");
                } break;
            case eLobbyState.eLOBBY_INFORMATION:
                {
                    Debug.Log("eLOBBY_INFORMATION");
                } break;
            case eLobbyState.eSUCCESS_LOBBY_INFORMATION:
                {
                    setLabel();
                    setStage();
                    Debug.Log("eSUCCESS_LOBBY_INFORMATION");
                } break;
            case eLobbyState.eERROR_LOBBY_INFORMATION:
                {
                    Debug.LogError("eERROR_LOBBY_INFORMATION");
                } break;
            
        }
    }
}
