using UnityEngine;
using System.Collections;
using System.IO;

public class tower : MonoBehaviour {

    public string name;
    public int atk;
    public float range;
    



    void Awake()
    {
        Debug.Log("tower awake");

        //fileLoad();

        //towerInfo = new sTower[5];



    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    

    void fileLoad()
    {
        StreamReader sr = new StreamReader("testFileInputOutput.txt");
        string str;

        str = sr.ReadLine();
        int towerCount = int.Parse(str);
        towerInfo = new sTower[towerCount];

        for (int i = 0; i < towerCount; ++i)
        {
            str = sr.ReadLine();
            if (str == null) break;
            else
            {
                string[] dataTexts = str.Split('\t');

                towerInfo[i].name = dataTexts[0];
                towerInfo[i].atk = int.Parse(dataTexts[1]);
                towerInfo[i].range = float.Parse(dataTexts[2]);
            }
        }
    }

    void fileWrite()
    {
        StreamWriter sw = new StreamWriter("testFileInputOutput.txt");
        sw.WriteLine("line write");
        sw.Write("write");
        sw.WriteLine("line write");
        sw.Flush();
        sw.Close();
    }
}
