using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private GameController gameController;
    public GameObject panelMainMenu, panelGame, panelPause, panelGameOver;
    public TMP_Text txtHighScore;
    public TMP_Text txtTime;
    public TMP_Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        txtHighScore.text = "Highscore: " + gameController.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BottonExit(){
        //Forma generica
        /*if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }*/

        //Forma Android
        AndroidJavaObject activity = new AndroidJavaObject("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

    public void BottonStart(){
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.StartGame();
    }

    public void ButtonPause(){
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ButtonResume(){
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ButtonBackMainMenu(){
        panelPause.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        panelGameOver.gameObject.SetActive(false);
        gameController.BackMainMenu();
        txtHighScore.text = "Highscore: " + gameController.GetScore().ToString();
        gameController.DestroyAllBalls();
        txtScore.text = gameController.score.ToString();
        Time.timeScale = 1f;
    }

    public void ButtonRestart(){
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        gameController.StartGame();
        gameController.DestroyAllBalls();
        txtScore.text = gameController.score.ToString();
    }
}
