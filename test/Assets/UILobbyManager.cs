using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UILobbyManager : MonoBehaviour {

    public void btnBackLoginScene()
    {
        SceneManager.LoadScene(0);

        Debug.Log("btn back");
    }
}
