using UnityEngine;
using System.Collections;

public class MonsterGenManager : MonoBehaviour {

    //points는 배열로 담을 수 있도록 한다. 
    public Transform[] points;
    public GameObject monster;
    // 3초마다 몬스터를 만든다.
    public float createTime = 1.0f;

	// Use this for initialization
	void Start () {
        // points를 게임시작과 함께 배열에 담기
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        StartCoroutine(this.CreateMonster());
	}

    IEnumerator CreateMonster()
    {
        // 계속해서 createTime동안 monster생성
        while (true)
        {
            int idx = Random.Range(1, points.Length);
            Instantiate(monster, points[idx-1].position, Quaternion.identity);

            yield return new WaitForSeconds(createTime);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
