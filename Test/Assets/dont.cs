using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class dont : MonoBehaviour {

	public bool isSave = false;
	public bool isLoad = false;
    public int trickScore = 100;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {

        SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
