using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score;

    public float currentTime;
    [SerializeField] private float startTimer;

    public bool gameStarted;

    private UIController uiController;
    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
    }

    public void StartGame(){
        score = 0;
        currentTime = startTimer;
        gameStarted = true;
        InvokeCountDownTime();
    }

    public void BackMainMenu(){
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        CancelInvoke("CountdownTime");
    }

    public void InvokeCountDownTime(){
        InvokeRepeating("CountdownTime", 1f, 1f);
    }
    public void CountdownTime(){
        if(currentTime > 0f && gameStarted){
            currentTime -= 1f;
        } else {
            uiController.panelGameOver.gameObject.SetActive(true);
            uiController.panelGame.gameObject.SetActive(false);
            gameStarted = false;
            currentTime = 0f;
            CancelInvoke("CountdownTime");
            return;
        }
    }
}
