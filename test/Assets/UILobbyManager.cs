using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UILobbyManager : MonoBehaviour {

    GameObject netManager;

    public UILabel labelId;
    public UILabel labelBestScore;

    void Start()
    {
        Debug.Log("lobby start");
        netManager = GameObject.Find("Network");

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
}
