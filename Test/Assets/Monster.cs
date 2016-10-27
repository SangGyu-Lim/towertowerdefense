using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{

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

	public enum eMonsterLiveState
	{
		eALIVE = 0,
		eDIE = 1,
		eDESTROY = 2
	}

    public STATE currentMonsterMoveState;
	public eMonsterLiveState monsterLife = eMonsterLiveState.eALIVE;

    public GameObject[] arrayObject = new GameObject[16];
    float speed = 3.0f;
    float rotSpeed = 350.0f;
    public int monsterHp = 1;
    public int monsterGold;
    Animator anim;

	public GameObject goStageManager;

    // Use this for initialization
    void Start()
    {
        currentMonsterMoveState = STATE.POINT1;
        anim = this.gameObject.GetComponent<Animator>();

		anim.SetInteger ("animation", 13);
    }

    // Update is called once per frame
    void Update()
    {
        //checkIsDead();
		if (monsterLife == eMonsterLiveState.eALIVE) {
			Vector3 moveDir = new Vector3(arrayObject[(int)currentMonsterMoveState].transform.position.x, arrayObject[(int)currentMonsterMoveState].transform.position.y);
			transform.position = Vector3.MoveTowards(transform.position, arrayObject[(int)currentMonsterMoveState].transform.position, speed * Time.deltaTime);

			if (currentMonsterMoveState > STATE.POINT1)
			{
				Vector3 dir = arrayObject[(int)currentMonsterMoveState].transform.position - transform.position;
				Vector3 dirXZ = new Vector3(dir.x, 0.0f, dir.y);
				Quaternion targetRot = Quaternion.LookRotation(dirXZ);
				Quaternion monsterRot = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
				transform.rotation = monsterRot;
			}

			UpdateState();
			Debug.LogError(monsterHp);
		}
		else if(monsterLife == eMonsterLiveState.eDIE)
		{
			GameObject temp;
			temp = GameObject.Find ("MonsterGenManager");
			temp.GetComponent<MonsterGenManager>().changeMonseterCount(false, -1);
				
			goStageManager.GetComponent<UIStageManager>().gold += monsterGold;
			goStageManager.GetComponent<UIStageManager>().score += 10;
			//goStageManager.GetComponent<UIStageManager>().changeMainPanel();
			monsterLife = eMonsterLiveState.eDESTROY;
			die ();
		}
        
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
	public void die()
	{
	//	StartCoroutine (dieAnimation());
		Destroy(this.gameObject);
	}

	public IEnumerator dieAnimation()
    {
		//anim.SetInteger ("animation", 12);
		anim.Play("animation", 12);

        yield return new WaitForSeconds(0.5f);
    }



	public void setMonsterLife(eMonsterLiveState state)
	{
		monsterLife = state;
	}


   /*
	void checkDieMonster()
	{
		for (int i = 0; i < currentMonsterNum; ++i)
		{
			if (allMonster [i] == null)
				continue;
			else if (allMonster [i].GetComponent<Monster> ().monsterHp <= 0)
			{

				allMonster [i].GetComponent<Monster> ().setMonsterLife (Monster.eMonsterLiveState.eDIE);
				StartCoroutine (allMonster [i].GetComponent<Monster> ().dieAnimation ());

				goStageManager.GetComponent<UIStageManager>().gold += allMonster[i].GetComponent<Monster>().monsterGold;
				goStageManager.GetComponent<UIStageManager>().score += 10;
				//goStageManager.GetComponent<UIStageManager>().changeMainPanel();

				allMonster [i].GetComponent<Monster> ().setMonsterLife (Monster.eMonsterLiveState.eDESTROY);
				Destroy (allMonster [i]);
				changeMonseterCount(false, -1);
				//break;
			}

		}
	}*/
}
