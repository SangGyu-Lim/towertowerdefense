using UnityEngine;
using System.Collections;

public class tower : MonoBehaviour
{

	public int num;
    public string name;
    public int atk;
    public float range;
    public float speed = 0.5f;
	public string skill;

    public bool isAtk;

    public GameObject targetMonster;
    public int targetNum;

    private float fTickTime = 0.0f;

    void Awake()
    {
        Debug.Log("tower awake");

        //fileLoad();

        //towerInfo = new sTower[5];



    }


    // Use this for initialization
    void Start()
    {
        //targetMonster = MonsterGenManager;
        targetMonster = GameObject.Find("MonsterGenManager");
        isAtk = false;
    }

    // Update is called once per frame
    void Update()
    {
        fTickTime += Time.deltaTime;
        checkRange();
        
        if (fTickTime >= speed)
        {
            fTickTime = 0.0f;
            
            if (!isAtk)
            {
                
               // if ()
                //{
                    isAtk = true;
					atkMonster ();
                //}
            }
            else
            {
                checkOutRange();
                
            }
        }
        watchTarget();
		

    }

	public void setTower(int towerNum, string towerName, int towerAtk, float towerAtkRange, float towerAtkSpeed, string towerSkill)
    {
		num = towerNum;;
        name = towerName;
        atk = towerAtk;
        range = towerAtkRange;
		speed = towerAtkSpeed;
		skill = towerSkill;
    }

    public void resetTower()
    {
		num = -1;
        name = "";
        atk = -1;
        range = -1.0f;
		speed = -1;
		skill = "";
    }

    public void checkRange()
    {
        //for (targetNum = 0; targetNum < targetMonster.GetComponent<MonsterGenManager>().currentMonsterNum; ++targetNum)
		for (int i = 0; i < targetMonster.GetComponent<MonsterGenManager>().maxMonsterCount; ++i)
        {
            //Debug.Log(Vector3.Distance(this.transform.position, targetMonster.GetComponent<MonsterGenManager>().allMonster[targetNum].transform.position));
			if (targetMonster.GetComponent<MonsterGenManager> ().allMonster [i] == null)
				continue;

			if (targetMonster.GetComponent<MonsterGenManager> ().allMonster [i].GetComponent<Monster> ().monsterHp <= 0)
				continue;

            if (Vector3.Distance(this.transform.position, targetMonster.GetComponent<MonsterGenManager>().allMonster[i].transform.position) > range)
                continue;
			
            if (Vector3.Distance(this.transform.position, targetMonster.GetComponent<MonsterGenManager>().allMonster[i].transform.position) <= range)
            {
				targetNum = i;
                break;
            }
        }

    }

    public void checkOutRange()
    {
		if (Vector3.Distance (this.transform.position, targetMonster.GetComponent<MonsterGenManager> ().allMonster [targetNum].transform.position) > range) {
			isAtk = false;
		} else if (targetMonster.GetComponent<MonsterGenManager> ().allMonster [targetNum].GetComponent<Monster> ().monsterHp <= 0) {
			isAtk = false;
		}
		else
		{
			atkMonster();
		}
    }

    public void atkMonster()
    {

        targetMonster.GetComponent<MonsterGenManager>().allMonster[targetNum].GetComponent<Monster>().monsterHp -= atk;

		if (targetMonster.GetComponent<MonsterGenManager> ().allMonster [targetNum].GetComponent<Monster> ().monsterHp <= 0) {
			targetMonster.GetComponent<MonsterGenManager> ().allMonster [targetNum].GetComponent<Monster> ().monsterLife = Monster.eMonsterLiveState.eDIE;
			isAtk = false;
		}

        StartCoroutine(atkEffect());




        
    }

	IEnumerator atkEffect()
    {
		GameObject objTemp;
		Vector3 vectorTemp;
		vectorTemp.x = targetMonster.GetComponent<MonsterGenManager> ().allMonster [targetNum].transform.position.x;
		vectorTemp.y = targetMonster.GetComponent<MonsterGenManager> ().allMonster [targetNum].transform.position.y + 2.5f;
		vectorTemp.z = targetMonster.GetComponent<MonsterGenManager> ().allMonster [targetNum].transform.position.z;
		objTemp = Instantiate(Resources.Load("AttackEffect/" + skill), vectorTemp, Quaternion.identity) as GameObject;

        yield return new WaitForSeconds(1.5f);

		Destroy (objTemp);
    }

	void watchTarget()
	{
		this.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(targetMonster.GetComponent<MonsterGenManager> ().allMonster [targetNum].transform.position);
	}
}
