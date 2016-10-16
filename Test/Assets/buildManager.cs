﻿using UnityEngine;
using System.Collections;
using System.IO;

public class buildManager : MonoBehaviour {

    Ray ray;
    RaycastHit hitInfo;

    public bool[] isBuild;

    public GameObject goStageManager;
    GameObject goTargetObject;

    const int towerSize = 2;
    const int boxCount = 3;

    struct sTower
    {
        public string name;
        public int atk;
        public float range;
    }

    sTower[] towerInfo;

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

    void Awake()
    {
        Debug.Log("buildManager awake");

        initValue();
        //fileWrite();
        fileLoad();

        //towerInfo = new sTower[5];

        

    }
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

                string[] dataTexts = hitInfo.transform.gameObject.name.Split('_');

                foreach (string dataText in dataTexts)
                {
                    Debug.Log(dataText);

                    if (dataText == "box")
                    {
                        isBuild[int.Parse(dataTexts[1])] = true;
                        goStageManager.GetComponent<UIStageManager>().goTowerPanel.SetActive(true);
                        goTargetObject = GameObject.Find(hitInfo.transform.gameObject.name);
                        break;
                    }
                    else if (dataText == "clone")
                    {
                        goStageManager.GetComponent<UIStageManager>().goDestroyPanel.SetActive(true);
                        goTargetObject = GameObject.Find(hitInfo.transform.gameObject.name);
                        break;
                    }
                }           
                
                //Debug.Log();
            }
        }
        
        // 상태 체크
        if (goStageManager.GetComponent<UIStageManager>().state != UIStageManager.eStageState.eNONE)
            checkState();
         
	}

    void OnDestroy()
    {
        Debug.Log("buildManager ondestroy");
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
            case UIStageManager.eStageState.eBUILD_TOWER0:
                {
                    
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER1:
                {
                    buildTower("knight");
                    
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER2:
                {
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER3:
                {
                    buildTower("king");
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER4:
                {
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER5:
                {
                    buildTower("nurse");
                    
                } break;

            case UIStageManager.eStageState.eDESTROY_TOWER:
                {
                    destroyTower();
                    
                } break;
        }

        goStageManager.GetComponent<UIStageManager>().goDestroyPanel.SetActive(false);
        goStageManager.GetComponent<UIStageManager>().goTowerPanel.SetActive(false);
        goStageManager.GetComponent<UIStageManager>().state = UIStageManager.eStageState.eNONE;
    }

    void buildTower(string towerName)
    {
        GameObject temp;
        temp = goTargetObject.transform.FindChild("tower").gameObject;
        //temp = Instantiate(Resources.Load("SD_Project/Prefab/Hero/king"), Vector3.zero, Quaternion.identity) as GameObject;
        //this.transform.FindChild("tower").gameObject = Instantiate(Resources.Load("SD_Project/Prefab/Hero/king"), Vector3.zero, Quaternion.identity);
        //Instantiate(Resources.Load("Assets/SD_Project/Prefab/Hero/king"), Vector3.zero, Quaternion.identity);

        temp = Instantiate(Resources.Load("Hero/" + towerName), Vector3.zero, Quaternion.identity) as GameObject;
        temp.transform.parent = goTargetObject.transform;
        temp.transform.localScale = new Vector3(towerSize, towerSize, towerSize);
        temp.transform.position = Vector3.zero;
        temp.transform.localPosition = Vector3.zero;
        temp.name = "clone_" + towerName;
    }

    void destroyTower()
    {
        GameObject temp;
        temp = goTargetObject;
        Destroy(temp);
    }

    void initValue()
    {
        isBuild = new bool[boxCount];

        for (int i = 0; i < boxCount; ++i)
            isBuild[i] = false;

    }

    void fileLoad()
    {
        StreamReader sr = new StreamReader("testFileInputOutput.txt");
        string str;

        str = sr.ReadLine();
        int towerCount = int.Parse(str);
        towerInfo = new sTower[towerCount];

        for (int i = 0; i < towerCount; ++i )
        {
            str = sr.ReadLine();
            if (str == null) break;
            else
            {
                string[] dataTexts = str.Split('\t');
                
                towerInfo[i].name = dataTexts[0];
                towerInfo[i].atk = int.Parse(dataTexts[1]);
                towerInfo[i].range = float.Parse(dataTexts[2]);
            }
        }
    }

    void fileWrite()
    {
        StreamWriter sw = new StreamWriter("testFileInputOutput.txt");
        sw.WriteLine("line write");
        sw.Write("write");
        sw.WriteLine("line write");
        sw.Flush();
        sw.Close();
    }

    
}
