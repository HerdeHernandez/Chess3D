using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void newGame()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        chessManager.Reset();
        this.gameObject.SetActive(false);
    }
}
