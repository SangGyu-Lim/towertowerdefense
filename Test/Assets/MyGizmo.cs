using UnityEngine;
using System.Collections;

public class MyGizmo : MonoBehaviour {

    public Color color = Color.blue;
    public float radius = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
