using UnityEngine;
using System.Collections;

public class UIStageManager : MonoBehaviour {

    public GameObject goTowerPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void exitBtn()
    {
        goTowerPanel.SetActive(false);
    }
}
