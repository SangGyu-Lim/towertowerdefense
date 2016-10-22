using UnityEngine;
using System.Collections;

public class MonsterGenManager : MonoBehaviour
{

    //points는 배열로 담을 수 있도록 한다. 
    public Transform[] points;
    public GameObject[] monster;
    //public GameObject[] monster2;
    //WAVE ENUM
    private enum EWave
    {
        eNONE = 0,
        eWAVE1 = 1,
        eWAVE2,
        eWAVE3,
        eWAVE4,
        eWAVE5,
        eWAVE6,
        eWAVE7,
        eWAVE8,
        eWAVE9,
        eWAVE10,
        eEND = 11
    }
    // 3초마다 몬스터를 만든다.
    private float createTime = 0.5f;
    public const int maxMonsterNum = 200;   // 누적 최대 몬스터수
    public const int maxWaveMonsterNum = 5;   //  웨이브 최대 몬스터수
    private int currentWaveMonsterNum = 0;  // 현재 웨이브 몬스터 생성수
    private int currentMonsterNum = 0;  //  누적 몬스터 생성수
    private EWave currentWave = EWave.eNONE;
    private float fDestroyTime = 1.0f;
    private float fTickTime = 1.0f;
    public int maxMonsterCount { get; set; }

    public GameObject[] allMonster;



    // Use this for initialization
    void Start()
    {
        currentWave = EWave.eWAVE1;
        // points를 게임시작과 함께 배열에 담기
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        //StartCoroutine(this.CreateMonster());

        allMonster = new GameObject[maxMonsterNum];
        maxMonsterCount = maxMonsterNum;

    }

    // Update is called once per frame
    void Update()
    {
        fTickTime += Time.deltaTime;
        if (fTickTime >= fDestroyTime)
        {
            fTickTime = 0.0f;

            if (currentMonsterNum < maxMonsterNum)
            {
                if (currentWaveMonsterNum == maxWaveMonsterNum)
                {
                    currentWaveMonsterNum = 0;
                    changeState();
                }

                generateMonster();
            }
            else
                Debug.Log("GameOver");
        }
    }

    IEnumerator CreateMonster(EWave state, int hp)
    {
        // 계속해서 createTime동안 monster생성
        int idx = Random.Range(1, points.Length);
        int index = (int)state;
        for (int i = 0; i < maxMonsterNum; ++i)
        {
            Debug.Log(allMonster[i]);
            if (allMonster[i] == null)
            {
                allMonster[i] = Instantiate(monster[index - 1], points[idx - 1].position, Quaternion.identity) as GameObject;
                break;
            }
        }

        monster[index - 1].GetComponent<Monster>().monsterHp = hp;
        yield return new WaitForSeconds(createTime);
        //Debug.Log (currentMonsterNum);	
    }

    void generateMonster()
    {
        switch (currentWave)
        {
            case EWave.eWAVE1:
                StartCoroutine(CreateMonster(EWave.eWAVE1, 50));
                changeMonseterCount(true, 1);
                changeMonseterCount(false, 1);
                break;
            case EWave.eWAVE2:
                StartCoroutine(CreateMonster(EWave.eWAVE2, 100));
                changeMonseterCount(true, 1);
                changeMonseterCount(false, 1);
                break;
            case EWave.eWAVE3:
                StartCoroutine(CreateMonster(EWave.eWAVE3, 150));
                changeMonseterCount(true, 1);
                changeMonseterCount(false, 1);
                break;
            case EWave.eWAVE4:
                StartCoroutine(CreateMonster(EWave.eWAVE4, 200));
                changeMonseterCount(true, 1);
                changeMonseterCount(false, 1);
                break;
            case EWave.eWAVE5:
                StartCoroutine(CreateMonster(EWave.eWAVE5, 250));
                changeMonseterCount(true, 1);
                changeMonseterCount(false, 1);
                break;
            case EWave.eWAVE6:
                StartCoroutine(CreateMonster(EWave.eWAVE6, 300));
                changeMonseterCount(true, 1);
                changeMonseterCount(false, 1);
                break;
            case EWave.eWAVE7:
                StartCoroutine(CreateMonster(EWave.eWAVE7, 350));
                changeMonseterCount(true, 1);
                changeMonseterCount(false, 1);
                break;
            case EWave.eWAVE8:
                StartCoroutine(CreateMonster(EWave.eWAVE8, 400));
                changeMonseterCount(true, 1);
                changeMonseterCount(false, 1);
                break;
            case EWave.eWAVE9:
                StartCoroutine(CreateMonster(EWave.eWAVE9, 450));
                changeMonseterCount(true, 1);
                changeMonseterCount(false, 1);
                break;
            //case EWave.eWAVE10:
            //	StartCoroutine (CreateMonster ( EWave.eWAVE10 ));
            //	changeMonseterCount(true, 1);
            //	changeMonseterCount(false, 1);
            //	break;
        }
    }

    void changeMonseterCount(bool isWave, int changeValue)
    {
        //Debug.Log(currentWaveMonsterNum + " / " + currentMonsterNum);

        if (isWave)
            currentWaveMonsterNum += changeValue;
        else
            currentMonsterNum += changeValue;

        //Debug.Log(currentWaveMonsterNum + " / " + currentMonsterNum);
    }

    void changeState()
    {
        switch (currentWave)
        {
            case EWave.eWAVE1:
                currentWave = EWave.eWAVE2;
                break;
            case EWave.eWAVE2:
                currentWave = EWave.eWAVE3;
                break;
            case EWave.eWAVE3:
                currentWave = EWave.eWAVE4;
                break;
            case EWave.eWAVE4:
                currentWave = EWave.eWAVE5;
                break;
            case EWave.eWAVE5:
                currentWave = EWave.eWAVE6;
                break;
            case EWave.eWAVE6:
                currentWave = EWave.eWAVE7;
                break;
            case EWave.eWAVE7:
                currentWave = EWave.eWAVE8;
                break;
            case EWave.eWAVE9:
                currentWave = EWave.eWAVE9;
                break;
            //case EWave.eWAVE9:
            //	currentWave = EWave.eWAVE10;
            //	break;            
        }

        fTickTime = -3.0f;
    }
}
