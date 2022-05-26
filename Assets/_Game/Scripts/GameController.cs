using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score;

    public float currentTime;
    [SerializeField] private float startTimer;

    public bool gameStarted;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        currentTime = startTimer;
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTime();
    }

    public void CountdownTime(){
        if(currentTime > 0f && gameStarted){
            currentTime -= Time.deltaTime;
            float currentTimeToInt = Mathf.RoundToInt(currentTime);
            Debug.Log(currentTimeToInt);
        } else {
            gameStarted = false;
            currentTime = 0f;
            return;
        }

        
        
    }
}
