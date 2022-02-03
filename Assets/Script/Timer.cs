using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text white, black;

    public float whiteTime;
    public float blackTime;

    public Transform chessBoard;

    // Update is called once per frame
    void Update()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if (chessManager.Player == "White" && chessManager.gameStart ==true)
        {
            if (whiteTime > 0)
            {
                whiteTime -= Time.deltaTime;
            }
            else
            {
                whiteTime = 0;
            }
        }
        else if (chessManager.Player == "Black" && chessManager.gameStart == true)
        {
            if (blackTime > 0)
            {
                blackTime -= Time.deltaTime;
            }
            else
            {
                blackTime = 0;
            }
        }

        displayTime(whiteTime, blackTime);
    }

    void displayTime(float whiteTimeDisplay, float blackTimeDisplay)
    {
        float whiteMinutes = Mathf.FloorToInt(whiteTimeDisplay / 60);
        float whiteSeconds = Mathf.FloorToInt(whiteTimeDisplay % 60);

        float blackMinutes = Mathf.FloorToInt(blackTimeDisplay / 60);
        float blackSeconds = Mathf.FloorToInt(blackTimeDisplay % 60);

        white.text = string.Format("{0:00}:{1:00}", whiteMinutes, whiteSeconds);
        black.text = string.Format("{0:00}:{1:00}", blackMinutes, blackSeconds);
    }
}
