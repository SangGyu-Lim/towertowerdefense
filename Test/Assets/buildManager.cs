using UnityEngine;
using System.Collections;

public class buildManager : MonoBehaviour {

<<<<<<< HEAD
    public Ray ray;
    public RaycastHit hitInfo;

	// Use this for initialization
	void Start () {

        Debug.Log("test");
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
=======
    Ray ray;
    RaycastHit hitInfo;

    public GameObject goTowerPanel;

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

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

>>>>>>> dev
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
<<<<<<< HEAD
                Debug.Log(hitInfo.transform.gameObject.name); //gameObject name
=======
                Debug.Log(hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.name == "box")
                    goTowerPanel.SetActive(true);
                
                
                //Debug.Log();
>>>>>>> dev
            }
        }
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
}
