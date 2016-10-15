using UnityEngine;
using System.Collections;

public class MonsterGenManager : MonoBehaviour {

    //points는 배열로 담을 수 있도록 한다. 
    public Transform[] points;
	public GameObject[] monster;
	//public GameObject[] monster2;
	//WAVE ENUM
	private enum EWave{
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
	private float createTime = 3.0f;
	const int maxMonsterNum = 80;   // 누적 최대 몬스터수
	const int maxWaveMonsterNum = 10;   //  웨이브 최대 몬스터수
	private int currentWaveMonsterNum = 0;  // 현재 웨이브 몬스터 생성수
	private int currentMonsterNum = 0;  //  누적 몬스터 생성수
	private EWave currentWave = EWave.eNONE;


	// Use this for initialization
	void Start () {
		currentWave = EWave.eWAVE1;
        // points를 게임시작과 함께 배열에 담기
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        //StartCoroutine(this.CreateMonster());
	}

	// Update is called once per frame
	void Update () {
        if(true /* delta time 돌릴것*/)
        {
		    if (currentMonsterNum < maxMonsterNum) 
		    {
                if (currentWaveMonsterNum == maxWaveMonsterNum)
                {
                    currentWaveMonsterNum = 0;
                    changeState();
                }

			    generateMonster ();
		    }
		    else
			    Debug.Log ("GameOver");
        }
	}

	IEnumerator CreateMonster( EWave state)
	{
		// 계속해서 createTime동안 monster생성
        int idx = Random.Range(1, points.Length);
        int index = (int)state;
        Instantiate(monster[index - 1], points[idx - 1].position, Quaternion.identity);
        //currentWaveMonsterNum++;
        yield return new WaitForSeconds(createTime);
		Debug.Log (currentMonsterNum);	
	}

	void generateMonster()
	{
		switch(currentWave)
		{
		case EWave.eWAVE1:
			StartCoroutine (CreateMonster (EWave.eWAVE1));
            changeMonseterCount(true, 1);
            changeMonseterCount(false, 1);
           
				break;
			case EWave.eWAVE2:
			StartCoroutine (CreateMonster ( EWave.eWAVE2 ));
			changeMonseterCount(true, 1);
            changeMonseterCount(false, 1);
           
				break;
			case EWave.eWAVE3:
			StartCoroutine (CreateMonster ( EWave.eWAVE3 ));
			changeMonseterCount(true, 1);
            changeMonseterCount(false, 1);
				break;
			case EWave.eWAVE4:
			StartCoroutine (CreateMonster ( EWave.eWAVE4 ));
			changeMonseterCount(true, 1);
            changeMonseterCount(false, 1);
				break;
			//case EWave.eWAVE5:
			//StartCoroutine (this.CreateMonster ( EWave.eWAVE5 ));
			//currentMonsterNum += currentWaveMonsterNum;
			//currentWaveMonsterNum = 0;
			//currentWave = EWave.eWAVE6;
			//	break;
			//case EWave.eWAVE6:
			//StartCoroutine (this.CreateMonster ( EWave.eWAVE6 ));
			//currentMonsterNum += currentWaveMonsterNum;
			//currentWaveMonsterNum = 0;
			//currentWave = EWave.eWAVE7;
			//	break;
			//case EWave.eWAVE7:
			//StartCoroutine (this.CreateMonster ( EWave.eWAVE7 ));
			//currentMonsterNum += currentWaveMonsterNum;
			//currentWaveMonsterNum = 0;
			//currentWave = EWave.eWAVE8;
			//	break;
			//case EWave.eWAVE8:
			//StartCoroutine (this.CreateMonster ( EWave.eWAVE8 ));
			//currentMonsterNum += currentWaveMonsterNum;
			//currentWaveMonsterNum = 0;
			//currentWave = EWave.eWAVE9;
			//	break;
			//case EWave.eWAVE9:
			//StartCoroutine (this.CreateMonster ( EWave.eWAVE9 ));
			//currentMonsterNum += currentWaveMonsterNum;
			//currentWaveMonsterNum = 0;
			//currentWave = EWave.eWAVE10;
			//	break;
			//case EWave.eWAVE10:
			//StartCoroutine (this.CreateMonster ( EWave.eWAVE10 ));
			//currentMonsterNum += currentWaveMonsterNum;
			//currentWaveMonsterNum = 0;
			//currentWave = EWave.eEND;
			//	break;
		}
	}

    void changeMonseterCount(bool isWave, int changeValue)
    {
        Debug.Log(currentWaveMonsterNum + " / " + currentMonsterNum);

        if (isWave)
            currentWaveMonsterNum += changeValue;
        else
            currentMonsterNum += changeValue;

        Debug.Log(currentWaveMonsterNum + " / " + currentMonsterNum);
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
            
        }
    }
}
