using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_sc : MonoBehaviour
{
    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R) && isGameOver == true){
            SceneManager.LoadScene("Yeni Sahne");
        }
    }

    public void GameOver(){
        isGameOver = true;
    }
}
