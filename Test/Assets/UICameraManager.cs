using UnityEngine;
using System.Collections;

public class UICameraManager : MonoBehaviour {

	public float speed = 1.0f;
	public Vector2 nowPos, prePos;
	public Vector3 movePos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("camera manager update");

		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began)
			{
				prePos = touch.position - touch.deltaPosition;
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				nowPos = touch.position - touch.deltaPosition;
				movePos = (Vector3)(prePos - nowPos) * speed;
				GetComponent<Camera>().transform.Translate (movePos);
				prePos = touch.position - touch.deltaPosition;
			}
			else if (touch.phase == TouchPhase.Ended)
			{
			}
		}

	}
}
