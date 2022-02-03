using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class resignManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void resign(string enemyEmail);

    public void yes()
    {
        ChessGameController chess = GameObject.Find("GameController").GetComponent<ChessGameController>();
        resign(chess.EnemyEmail);
    }

    public void no()
    {
        this.gameObject.SetActive(false);
    }
}
