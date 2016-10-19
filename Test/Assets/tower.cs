using UnityEngine;
using System.Collections;

public class tower : MonoBehaviour {

    public string name;
    public int atk;
    public float range;
    



    void Awake()
    {
        Debug.Log("tower awake");

        //fileLoad();

        //towerInfo = new sTower[5];



    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setTower(string towerName, int towerAtk, float towerAtkRange)
    {
        name = towerName;
        atk = towerAtk;
        range = towerAtkRange;
    }

    public void resetTower()
    {
        name = "";
        atk = -1;
        range = -1.0f;
    }

    
}
