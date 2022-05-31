using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public int score;

    private int highScore;

    private float currentTime;

    [SerializeField] private float startTimer;

    [HideInInspector] public bool gameStarted;

    private UIController uiController;

    private SpawnController spawnController;

    [SerializeField] private Transform player;
    private Vector2 playerPosition;
    private void Awake(){
         DeleteHighScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
        spawnController = FindObjectOfType<SpawnController>();
        highScore = GetScore();
        uiController.txtTime.text = currentTime.ToString();
        playerPosition = player.position;
    }

    public void DestroyAllBalls(){
        foreach (Transform child in spawnController.allBallsParent) {
            Destroy(child.gameObject);
        }
    }

    public void SaveScore(){

        if(score > highScore){
            highScore = score;
            PlayerPrefs.SetInt("@highscore", highScore);
        } else {
            return;
        }
        
    }

    public int GetScore(){
        int highScore = PlayerPrefs.GetInt("@highscore");
        return highScore;
    }

    public void DeleteHighScore(){
        PlayerPrefs.DeleteKey("@highscore");
    }

    public void StartGame(){
        score = 0;
        currentTime = startTimer;
        gameStarted = true;
        InvokeCountDownTime();
        player.position = playerPosition;
    }

    public void BackMainMenu(){
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        CancelInvoke("CountdownTime");
        player.position = playerPosition;
    }

    public void InvokeCountDownTime(){
        InvokeRepeating("CountdownTime", 1f, 1f);
    }
    public void CountdownTime(){
        uiController.txtTime.text = currentTime.ToString();

        if(currentTime > 0f && gameStarted){
            currentTime -= 1f;
        } else {
            uiController.panelGameOver.gameObject.SetActive(true);
            uiController.panelGame.gameObject.SetActive(false);
            gameStarted = false;
            SaveScore();
            currentTime = 0f;
            CancelInvoke("CountdownTime");
            return;
        }
    }
}
