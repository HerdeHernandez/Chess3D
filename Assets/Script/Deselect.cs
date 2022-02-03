using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deselect : MonoBehaviour
{
    
    public void deselect()
    {
        Transform chessBoard = GameObject.Find("Tiles").transform;

        foreach (Transform child in chessBoard)
        {
            child.GetChild(0).gameObject.SetActive(false);

            if (child.childCount > 1)
            {
                if (child.GetChild(1).GetComponent<Piece>().selected == true)
                {
                    child.GetChild(1).GetComponent<Piece>().selected = false;
                    child.GetChild(1).GetComponent<Piece>().moving = false;

                    child.GetChild(1).localPosition = new Vector3(0, 0, 0);

                    var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
                    chessManager.onMoved = false;
                    chessManager.square = "";
                }
            }
        }       
    }
}
