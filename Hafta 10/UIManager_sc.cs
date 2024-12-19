using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_sc : MonoBehaviour
{
    GameManager_sc gameManager_sc;
    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI gameOverTMP;
    [SerializeField] TextMeshProUGUI restartTMP;
    [SerializeField] private Sprite[] livesSprites;
    [SerializeField] private Image lives_img;
    // Start is called before the first frame update
    void Start()
    {
        gameManager_sc = GameObject.Find("Game_Manager").GetComponent<GameManager_sc>();
        scoreTMP.text = "Score: " + 0;
        lives_img.sprite = livesSprites[3];
        gameOverTMP.gameObject.SetActive(false);
        restartTMP.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreTMP(int score){
        scoreTMP.text = "Score: " + score;
    }

    public void UpdateLivesIMG(int lives){
        lives_img.sprite = livesSprites[lives];
        if(lives == 0){
            GameOverSequence();
        }
    }
    void GameOverSequence(){
        if(gameManager_sc != null){
            gameManager_sc. GameOver();
        }
        gameOverTMP.gameObject.SetActive(true);
        restartTMP.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }
    IEnumerator GameOverFlickerRoutine(){
        while(true){
            gameOverTMP.text = "GAME_OVER";
            yield return new WaitForSeconds(0.5f);
            gameOverTMP.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

}
