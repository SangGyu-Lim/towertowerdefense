using UnityEngine;
using System.Collections;

public class UIStageManager : MonoBehaviour {

    public enum eStageState
    {
        eNONE = 0,
        eTOWERPANEL_FALSE = 1,

        eBUILD_TOWER0 = 11,
        eBUILD_TOWER1 = 12,
        eBUILD_TOWER2 = 13,
        eBUILD_TOWER3 = 14,
        eBUILD_TOWER4 = 15,
        eBUILD_TOWER5 = 16,

        eDESTROY_TOWER = 101
    }

    public GameObject goTowerPanel;
    public GameObject goDestroyPanel;

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
}
