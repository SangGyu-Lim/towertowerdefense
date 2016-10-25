using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIStageManager : MonoBehaviour {

    public enum eStageState
    {
        eNONE = 0,
        eTOWERPANEL_FALSE = 1,

        eSAVE_BUILD_TOWER = 5,
        eSAVE_MONSTER = 6,

        eSUCCESS_SAVE_TOWER = 15,
        eSUCCESS_SAVE_MONSTER = 16,

        eBUILD_TOWER0 = 21,
        eBUILD_TOWER1 = 22,
        eBUILD_TOWER2 = 23,
        eBUILD_TOWER3 = 24,
        eBUILD_TOWER4 = 25,
        eBUILD_TOWER5 = 26,

        eDESTROY_TOWER = 101,

		eSETTING = 201,
		eSAVE = 202,
		eSTAGE_EXIT = 203,

        eERROR_SAVE_TOWER = 1005,
        eERROR_SAVE_MONSTER = 1006,

    }

    public GameObject goTowerPanel;
    public GameObject goDestroyPanel;
    public GameObject goSettingPanel;
    public UILabel scoreLabel;
    public UILabel goldLabel;

    public eStageState state = eStageState.eNONE;

	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    public void exitBtn()
    {
        state = eStageState.eTOWERPANEL_FALSE;
    }

    public void towerBtn0()
    {
        state = eStageState.eBUILD_TOWER0;
        Debug.Log("tower0");
    }

    public void towerBtn1()
    {
        state = eStageState.eBUILD_TOWER1;
        Debug.Log("tower1");
    }

    public void towerBtn2()
    {
        state = eStageState.eBUILD_TOWER2;
        Debug.Log("tower2");
    }

    public void towerBtn3()
    {
        state = eStageState.eBUILD_TOWER3;
        Debug.Log("tower3");
    }

    public void towerBtn4()
    {
        state = eStageState.eBUILD_TOWER4;
        Debug.Log("tower4");
    }

    public void towerBtn5()
    {
        state = eStageState.eBUILD_TOWER5;
        Debug.Log("tower5");
    }

    public void destroyBtn()
    {
        state = eStageState.eDESTROY_TOWER;
        Debug.Log("destroyBtn");
    }

	public void settingBtn()
	{
        goSettingPanel.SetActive(true);

	}

    public void settingExitBtn()
    {
        goSettingPanel.SetActive(false);
    }

	public void saveBtn()
	{
        state = eStageState.eSAVE_BUILD_TOWER;
	}

    public void stageExitBtn()
    {
        SceneManager.LoadScene(1);
    }
}
