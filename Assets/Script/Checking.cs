using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Checking : MonoBehaviour
{
    //check every piece available moves if there's a king
    public void checking()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        List<string> availableMoves = this.GetComponent<Piece>().availableMoves;
        bool canbeEaten = this.GetComponent<Piece>().canBeEaten;
        bool supported = this.GetComponent<Piece>().supported;

        foreach (string str in availableMoves)
        {
            Transform tileName = GameObject.Find(str).transform;            

            if (tileName.childCount > 1)
            {               
                if (tileName.GetChild(1).name.Contains("King") && tileName.GetChild(1).tag != this.tag)
                {
                    //print(tileName.GetChild(1).GetComponent<Piece>().availableMoves.Count);
                    //print(canbeEaten);
                    if (tileName.GetChild(1).GetComponent<Piece>().availableMoves.Count > 0 && canbeEaten == false)
                    {                        
                        tileName.GetChild(1).GetComponent<King>().checkmate = false;
                        tileName.GetChild(1).GetComponent<King>().check = true;
                        editNotation("+");
                    }
                    else if (canbeEaten == true)
                    {
                        tileName.GetChild(1).GetComponent<King>().checkmate = false;
                        tileName.GetChild(1).GetComponent<King>().check = true;

                        editNotation("+");
                    }
                    else if (tileName.GetChild(1).GetComponent<Piece>().availableMoves.Count < 1 &&
                             tileName.GetChild(1).GetComponent<Piece>().canBeEaten == true)
                    {
                        checkMate(tileName);
                    }
                    break;
                }
            }
        }
    }

    //edit notation for check & checkmate
    void editNotation(string notation)
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        Transform Notation = GameObject.Find("Chess Canvas").transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0);

        if (chessManager.onMoved == false)
        {
            if (chessManager.Player == "Black" &&
                !chessManager.whiteMoves[chessManager.whiteMoves.Count - 1].Contains("+") &&
                !chessManager.whiteMoves[chessManager.whiteMoves.Count - 1].Contains("#"))
            {
                chessManager.whiteMoves[chessManager.whiteMoves.Count - 1] = chessManager.whiteMoves[chessManager.whiteMoves.Count - 1] + notation;
                string newNotation = Notation.GetChild(0).GetChild(Notation.GetChild(0).childCount - 1).GetComponent<Text>().text + notation;
                Notation.GetChild(0).GetChild(Notation.GetChild(0).childCount - 1).GetComponent<Text>().text = newNotation;
            }
            else if (chessManager.Player == "White" &&
                     !chessManager.blackMoves[chessManager.blackMoves.Count - 1].Contains("+") &&
                     !chessManager.blackMoves[chessManager.blackMoves.Count - 1].Contains("#"))
            {
                
                chessManager.blackMoves[chessManager.blackMoves.Count - 1] = chessManager.blackMoves[chessManager.blackMoves.Count - 1] + notation;
                string newNotation = Notation.GetChild(1).GetChild(Notation.GetChild(1).childCount - 1).GetComponent<Text>().text + notation;
                Notation.GetChild(1).GetChild(Notation.GetChild(1).childCount - 1).GetComponent<Text>().text = newNotation;
            }
        }        
    }

    //check every piece available moves of the same color of the checked king, if the available moves can blocked the piece that checked the king
    public void checkMate(Transform tileName)
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        //i = same piece color count minus the king (for reference)
        //j = same piece color count minus the king (for real count)
       
        //k = move count of j 

        int i = 0, j = 0, k = 0;

        foreach (Transform child in this.transform.parent.parent)
        {
            if (child.childCount > 1)
            {
                if (child.GetChild(1).tag == tileName.GetChild(1).tag && child.GetChild(1).name != tileName.GetChild(1).name)
                {
                    i++;
                }
            }
        }

        if (i > 0)
        {
            foreach (Transform child in this.transform.parent.parent)
            {
                if (child.childCount > 1)
                {
                    if (child.GetChild(1).tag == tileName.GetChild(1).tag && child.GetChild(1).name != tileName.GetChild(1).name)
                    {
                        j++;
                       
                        foreach (string move in child.GetChild(1).GetComponent<Piece>().availableMoves)
                        {
                            k++;                           
                           
                            if (this.GetComponent<Piece>().availableMoves.Contains(move))
                            {
                                Transform square = GameObject.Find(move).transform;

                                child.GetChild(1).parent = square.transform;

                                tileName.GetChild(1).GetComponent<King>().check = false;

                                this.GetComponent<Piece>().availableMoves.Clear();
                                this.GetComponent<Piece>().showMoves();

                                tileName.GetChild(1).GetComponent<Piece>().showMoves();

                                square.GetChild(1).parent = child.transform;

                                if (!this.GetComponent<Piece>().availableMoves.Contains(tileName.name))
                                {
                                    //print(1);
                                    tileName.GetChild(1).GetComponent<King>().checkmate = false;
                                    tileName.GetChild(1).GetComponent<King>().check = true;

                                    tileName.GetChild(1).GetComponent<Piece>().availableMoves.Clear();
                                    tileName.GetChild(1).GetComponent<Piece>().showMoves();

                                    editNotation("+");
                                  
                                    return;
                                }

                                tileName.GetChild(1).GetComponent<Piece>().availableMoves.Clear();
                                tileName.GetChild(1).GetComponent<Piece>().showMoves();
                            }

                           
                            if (i == j && child.GetChild(1).GetComponent<Piece>().availableMoves.Count == k)
                            {
                                //print(2);
                                StartCoroutine(chessManager.checkMate(tileName.GetChild(1).tag));
                                editNotation("#");
                                return;

                            }                            
                        }

                        k = 0;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(chessManager.checkMate(tileName.GetChild(1).tag));
            editNotation("#");
        }
    }

    //if the king can be eaten
    public void canBeEaten()
    {
        //  var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

       
        Transform kingWhite = GameObject.Find("KingWhite").transform;
        Transform kingBlack = GameObject.Find("KingBlack").transform;

        foreach (Transform child in this.transform.parent.parent)
        {
            if (child.childCount > 1)
            {
                if (child.GetChild(1).tag == "White")
                {                    
                    if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(kingBlack.parent.name))
                    {
                        kingBlack.GetComponent<Piece>().canBeEaten = true;
                        
                    }
                }
                else
                {                  
                    if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(kingWhite.parent.name))
                    {
                        kingWhite.GetComponent<Piece>().canBeEaten = true;                  
                    }
                }
            }
        }
    }
}
