using UnityEngine;
using System.Collections;
using System.IO;

public class buildManager : MonoBehaviour {

    Ray ray;
    RaycastHit hitInfo;

    public bool[] isBuild;
    public bool isTowerPanel;
    public bool isDestroyPanel;

    public GameObject goStageManager;
    GameObject goTargetObject;

    const int towerSize = 1;
    const int boxCount = 46;

    struct sTowerFile
    {
        public string name;
        public int atk;
        public float range;
		public float speed;
		public string skill;
    }

    sTowerFile[] allTowerInfo;

    tower cTower;

	public Vector2 nowPos, prePos;
	public Vector3 movePos;


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
        
		fileWrite();
        fileLoad();

        //towerInfo = new sTower[5];

        isTowerPanel = false;
        isDestroyPanel = false;

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

                    if (!isTowerPanel && !isDestroyPanel)
                    {
						if (dataText == "box" && !isBuild[int.Parse(dataTexts[1])])
                        {
                            isTowerPanel = true;

                            isBuild[int.Parse(dataTexts[1])] = true;
                            goStageManager.GetComponent<UIStageManager>().goTowerPanel.SetActive(true);
                            goTargetObject = GameObject.Find(hitInfo.transform.gameObject.name);
                            break;
                        }
						else if (dataText == "clone" && isBuild[int.Parse(dataTexts[2])])
                        {
                            isDestroyPanel = true;

							isBuild [int.Parse (dataTexts [2])] = false;

                            goStageManager.GetComponent<UIStageManager>().goDestroyPanel.SetActive(true);
                            goTargetObject = GameObject.Find(hitInfo.transform.gameObject.name);
                            break;
                        }
                    }
                }           
                
                //Debug.Log();
            }


        }
        
        // 상태 체크
        if (goStageManager.GetComponent<UIStageManager>().state != UIStageManager.eStageState.eNONE)
            checkState();
         
	}

	/* test
	void OnMouseEnter()
	{
		Debug.LogError ("mouse enter");
	}

	void OnMouseExit()
	{
		Debug.LogError ("mouse exit");
	}

	void OnMouseUp()
	{
		Debug.LogError ("mouse up");
	}

	void OnMouseDown()
	{
		Debug.LogError ("mouse down");
	}

    void OnDestroy()
    {
        Debug.Log("buildManager ondestroy");
    }
	test */

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
    test */

    void checkState()
    {
        switch (goStageManager.GetComponent<UIStageManager>().state)
        {
            case UIStageManager.eStageState.eBUILD_TOWER0:
                {
                    
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER1:
                {
                    buildTower(0);
                    
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER2:
                {
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER3:
                {
                    buildTower(1);
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER4:
                {
                } break;

            case UIStageManager.eStageState.eBUILD_TOWER5:
                {
                    buildTower(2);
                    
                } break;

            case UIStageManager.eStageState.eDESTROY_TOWER:
                {
                    destroyTower();
                    
                } break;

			case UIStageManager.eStageState.eSETTING:
				{
					
			
				} break;
			
			case UIStageManager.eStageState.eSAVE:
				{
					
			
				} break;
			
			case UIStageManager.eStageState.eSTAGE_EXIT:
				{
					
			
				} break;
		
        }

        isTowerPanel = false;
        isDestroyPanel = false;
        goStageManager.GetComponent<UIStageManager>().goDestroyPanel.SetActive(false);
        goStageManager.GetComponent<UIStageManager>().goTowerPanel.SetActive(false);
        goStageManager.GetComponent<UIStageManager>().state = UIStageManager.eStageState.eNONE;
    }

    void buildTower(int towerNum)
    {
        GameObject temp, parentTemp;
        parentTemp = goTargetObject.transform.FindChild("tower").gameObject;
        
        //temp = Instantiate(Resources.Load("SD_Project/Prefab/Hero/king"), Vector3.zero, Quaternion.identity) as GameObject;
        //this.transform.FindChild("tower").gameObject = Instantiate(Resources.Load("SD_Project/Prefab/Hero/king"), Vector3.zero, Quaternion.identity);
        //Instantiate(Resources.Load("Assets/SD_Project/Prefab/Hero/king"), Vector3.zero, Quaternion.identity);

        // build tower
        temp = Instantiate(Resources.Load("Hero/" + allTowerInfo[towerNum].name), Vector3.zero, Quaternion.identity) as GameObject;
        temp.transform.parent = parentTemp.transform/*cTower.transform*/;
        temp.transform.localScale = new Vector3(towerSize, towerSize, towerSize);
        temp.transform.position = Vector3.zero;
        temp.transform.localPosition = Vector3.zero;
		temp.name = "clone_" + goTargetObject.name;

		parentTemp.GetComponent<tower>().setTower(
			towerNum,
			allTowerInfo[towerNum].name,
			allTowerInfo[towerNum].atk,
			allTowerInfo[towerNum].range,
			allTowerInfo[towerNum].speed,
			allTowerInfo[towerNum].skill 
		);
    }

    void destroyTower()
    {
        GameObject temp;
        temp = goTargetObject;

        temp.transform.parent.GetComponent<tower>().resetTower();
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
        StreamReader sr = new StreamReader("testFileInputOutput.dat");
        string str;

        str = sr.ReadLine();
        int towerCount = int.Parse(str);
        allTowerInfo = new sTowerFile[towerCount];

        for (int i = 0; i < towerCount; ++i)
        {
            str = sr.ReadLine();
            if (str == null) break;
            else
            {
                string[] dataTexts = str.Split('\t');

                allTowerInfo[i].name = dataTexts[0];
                allTowerInfo[i].atk = int.Parse(dataTexts[1]);
                allTowerInfo[i].range = float.Parse(dataTexts[2]);
				allTowerInfo[i].speed = float.Parse(dataTexts[3]);
				allTowerInfo[i].skill = dataTexts[4];
            }
        }
    }

    void fileWrite()
    {
        StreamWriter sw = new StreamWriter("testFileInputOutput.dat");
		sw.WriteLine("3");
		sw.WriteLine("king\t123\t50\t3\tArcaneSlash");
		sw.WriteLine("knight\t456\t70\t2\tFireSphereBlast");
		sw.WriteLine("nurse\t9874\t100\t0.5\tArcaneWallCircle");
        sw.Flush();
        sw.Close();
    }

	void buildTowerSave()
	{
		string saveStr = "";

		for (int i = 0; i < boxCount; ++i)
		{
			if (isBuild [i])
			{
				GameObject temp;
				temp = GameObject.Find ("box_" + i).transform.FindChild ("tower").gameObject;

				saveStr += (i + "," + temp.GetComponent<tower> ().name + ";");

			}
		}
		
	}

    
}
