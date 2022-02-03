using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalemate : MonoBehaviour
{
    public void stalemate()
    {
      /*  var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if (this.GetComponent<Piece>().availableMoves.Count > 0)
        {
            print(2);
            foreach (Transform child in this.transform.parent.parent)
            {
                if (child.childCount > 1)
                {
                    if (child.GetChild(1).tag !=  this.tag && child.GetChild(1).GetComponent<Piece>().canBeEaten == false)
                    {
                        foreach (string move in child.GetChild(1).GetComponent<Piece>().availableMoves)
                        {
                            if (this.GetComponent<Piece>().availableMoves.Contains(move))
                            {
                                this.GetComponent<Piece>().availableMoves.Remove(move);
                            }
                        }
                    }
                }
            }
            print(this.GetComponent<Piece>().availableMoves.Count);
            print(this.GetComponent<King>().check);


            if (this.GetComponent<Piece>().availableMoves.Count == 0 && this.GetComponent<King>().check == false)
            {
                print(1);
                StartCoroutine(chessManager.stalemate());
            }
        }*/
    }
}
