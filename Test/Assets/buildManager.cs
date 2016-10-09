using UnityEngine;
using System.Collections;

public class buildManager : MonoBehaviour {

    Ray ray;
    RaycastHit hitInfo;

	// Use this for initialization
	void Start () {
        Debug.Log("buildManager start");
	}
	
	// Update is called once per frame
	void Update () {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.transform.gameObject.name);
            }
        }
	}
}
