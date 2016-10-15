using UnityEngine;
using System.Collections;

public class buildManager : MonoBehaviour {

    Ray ray;
    RaycastHit hitInfo;

    public bool isTouch = false;
    public GameObject goStageManager;

    /* test
    public int count;
    public GameObject[] towerList;
    public GameObject goTower;
    public GameObject goParent;
    int temp = 0;

    const float RANGE_MIN = -10.0F;
    const float RANGE_MAX = 10.0F;

    int posX = 100;
    int posZ = 100;
    */
    
	// Use this for initialization
	void Start () {
        Debug.Log("buildManager start");


        /* test
        towerList = new GameObject[count];
        towerInit();
        */
    }
	
	// Update is called once per frame
	void Update () {
        
        // 터치 입력
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.name == "box")
                {
                    isTouch = true;
                    goStageManager.GetComponent<UIStageManager>().goTowerPanel.SetActive(true);
                }
                
                
                //Debug.Log();
            }
        }
        
        // 상태 체크
        checkState();
         
	}


    /* test
    void towerInit()
    {
        for (int i = 0; i < towerList.Length; ++i)
        {

            towerList[i] = GameObject.Instantiate(goTower) as GameObject;
            towerList[i].transform.parent = goParent.transform;

            towerList[i].name = temp.ToString();

            towerList[i].transform.localScale = new Vector3(356, 356, 356);

            float x = Random.Range(RANGE_MIN, RANGE_MAX);
            float z = Random.Range(RANGE_MIN, RANGE_MAX);

            towerList[i].transform.position = Vector3.zero;

            towerList[i].transform.localPosition = new Vector3((posX + 50 * temp), (posZ + 50 * temp), 0f);
            towerList[i].SetActive(true);

            temp++;
        }
    }
    */

    void checkState()
    {
        switch (goStageManager.GetComponent<UIStageManager>().state)
        {
            case UIStageManager.eStageState.eNONE:
                {
                } break;

            case UIStageManager.eStageState.eTOWERPANEL_FALSE:
                {
                    goStageManager.GetComponent<UIStageManager>().goTowerPanel.SetActive(false);
                    
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER0:
                {
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER1:
                {
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER2:
                {
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER3:
                {
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER4:
                {
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER5:
                {
                } break;
        }

        goStageManager.GetComponent<UIStageManager>().state = UIStageManager.eStageState.eNONE;
    }
}
