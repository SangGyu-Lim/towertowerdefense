using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    public enum STATE
    {
        POINT1 = 0,
        POINT2,
        POINT3,
        POINT4,
        POINT5,
        POINT6,
        POINT7,
        POINT8,
        POINT9,
        POINT10,
        POINT11,
        POINT12,
        POINT13,
        POINT14,
        POINT15,
        POINT16,
    }
    private STATE currentMonsterMoveState;
    public GameObject[] arrayObject = new GameObject[16];
    float speed = 5.0f;
    
	// Use this for initialization
	void Start () {
        currentMonsterMoveState = STATE.POINT1;
	}
	
	// Update is called once per frame
	void Update () 
    {
       transform.position = Vector3.MoveTowards(transform.position, arrayObject[(int)currentMonsterMoveState].transform.position, speed * Time.deltaTime);
       UpdateState();
	}

    void UpdateState()
    {
        if (transform.position.x == arrayObject[0].transform.position.x && transform.position.z == arrayObject[0].transform.position.z)
            currentMonsterMoveState = STATE.POINT2;
        if (transform.position.x == arrayObject[1].transform.position.x && transform.position.z == arrayObject[1].transform.position.z)
            currentMonsterMoveState = STATE.POINT3;
        if (transform.position.x == arrayObject[2].transform.position.x && transform.position.z == arrayObject[2].transform.position.z)
            currentMonsterMoveState = STATE.POINT4;
        if (transform.position.x == arrayObject[3].transform.position.x && transform.position.z == arrayObject[3].transform.position.z)
            currentMonsterMoveState = STATE.POINT5;
        if (transform.position.x == arrayObject[4].transform.position.x && transform.position.z == arrayObject[4].transform.position.z)
            currentMonsterMoveState = STATE.POINT6;
        if (transform.position.x == arrayObject[5].transform.position.x && transform.position.z == arrayObject[5].transform.position.z)
            currentMonsterMoveState = STATE.POINT7;
        if (transform.position.x == arrayObject[6].transform.position.x && transform.position.z == arrayObject[6].transform.position.z)
            currentMonsterMoveState = STATE.POINT8;
        if (transform.position.x == arrayObject[7].transform.position.x && transform.position.z == arrayObject[7].transform.position.z)
            currentMonsterMoveState = STATE.POINT9;
        if (transform.position.x == arrayObject[8].transform.position.x && transform.position.z == arrayObject[8].transform.position.z)
            currentMonsterMoveState = STATE.POINT10;
        if (transform.position.x == arrayObject[9].transform.position.x && transform.position.z == arrayObject[9].transform.position.z)
            currentMonsterMoveState = STATE.POINT11;
        if (transform.position.x == arrayObject[10].transform.position.x && transform.position.z == arrayObject[10].transform.position.z)
            currentMonsterMoveState = STATE.POINT12;
        if (transform.position.x == arrayObject[11].transform.position.x && transform.position.z == arrayObject[11].transform.position.z)
            currentMonsterMoveState = STATE.POINT13;
        if (transform.position.x == arrayObject[12].transform.position.x && transform.position.z == arrayObject[12].transform.position.z)
            currentMonsterMoveState = STATE.POINT14;
        if (transform.position.x == arrayObject[13].transform.position.x && transform.position.z == arrayObject[13].transform.position.z)
            currentMonsterMoveState = STATE.POINT15;
        if (transform.position.x == arrayObject[14].transform.position.x && transform.position.z == arrayObject[14].transform.position.z)
            currentMonsterMoveState = STATE.POINT16;
        if (transform.position.x == arrayObject[15].transform.position.x && transform.position.z == arrayObject[15].transform.position.z)
            currentMonsterMoveState = STATE.POINT1;
    }
}
