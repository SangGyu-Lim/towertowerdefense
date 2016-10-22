using UnityEngine;
using System.Collections;

public class tower : MonoBehaviour
{

    public string name;
    public int atk;
    public float range;
    public float speed = 3.0f;

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
        if (fTickTime >= speed)
        {
            fTickTime = 0.0f;

            if (!isAtk)
            {
                if (checkRange())
                {
                    isAtk = true;
                }
            }
            else
            {
                checkOutRange();
                atkMonster();
            }
        }

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

    public bool checkRange()
    {
        for (targetNum = 0; targetNum < targetMonster.GetComponent<MonsterGenManager>().currentMonsterNum; ++targetNum)
        {
            Debug.Log(Vector3.Distance(this.transform.position, targetMonster.GetComponent<MonsterGenManager>().allMonster[targetNum].transform.position));
            if (Vector3.Distance(this.transform.position, targetMonster.GetComponent<MonsterGenManager>().allMonster[targetNum].transform.position) < range)
            {
                return true;
            }
        }

        return false;
    }

    public void checkOutRange()
    {
        if (Vector3.Distance(this.transform.position, targetMonster.GetComponent<MonsterGenManager>().allMonster[targetNum].transform.position) > range)
        {
            isAtk = false;
        }
    }

    public void atkMonster()
    {
        targetMonster.GetComponent<MonsterGenManager>().allMonster[targetNum].GetComponent<Monster>().monsterHp -= atk;
        atkEffect();
    }

    IEnumerator atkEffect()
    {
        Instantiate(Resources.Load("AttackEffect/ArcaneSlash"), targetMonster.GetComponent<MonsterGenManager>().allMonster[targetNum].transform.position, Quaternion.identity);

        yield return new WaitForSeconds(2.0f);
    }
}
