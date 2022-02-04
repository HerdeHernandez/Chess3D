using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public bool promotion, twoSteps;

    public string lastMove;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void toRightUp()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if ((this.transform.parent.GetSiblingIndex() + 8) >= 0 && (this.transform.parent.GetSiblingIndex() + 8) <= 63)
        {
            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).childCount < 2)
            {
                if (this.GetComponent<Piece>().moving == true)
                {
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).GetChild(0).gameObject.SetActive(true);
                    this.transform.localPosition = new Vector3(0, 6, 0);
                    onMoved("", this.transform.parent.GetSiblingIndex() + 8);
                }
                else
                {
                    if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).name))
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).name);
                }

                if ((this.transform.parent.GetSiblingIndex() + 16) >= 0 && (this.transform.parent.GetSiblingIndex() + 16) <= 63)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 16).childCount < 2 &&
                    this.transform.parent.GetSiblingIndex() < 24 && (this.transform.parent.GetSiblingIndex() + 16) <= 31)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 16).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved("twoSteps", this.transform.parent.GetSiblingIndex() + 16);
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 16).name);
                        }
                    }
                }
            }
        }

        if ((this.transform.parent.GetSiblingIndex() + 9) >= 0 && (this.transform.parent.GetSiblingIndex() + 9) <= 63)
        {
            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 9).childCount > 1)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 9).GetChild(1).tag == "Black")
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 9).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved("", this.transform.parent.GetSiblingIndex() + 9);
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 9).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 9).name);
                    }
                }
            }

            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).childCount > 1 &&
                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).childCount > 1)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).GetChild(1).tag == "Black" &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).GetChild(1).name.Contains("Pawn") &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).GetChild(1).name.Contains("Pawn") &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).GetChild(1).tag == "Black")
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 9).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved("enPassUR", this.transform.parent.GetSiblingIndex() + 9);
                    }

                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 9).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 9).name);
                    }
                }
            }
        }
    }
    
    void toLeftUp()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if ((this.transform.parent.GetSiblingIndex() + 8) >= 0 && (this.transform.parent.GetSiblingIndex() + 8) <= 63)
        {
            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).childCount < 2)
            {
                if (this.GetComponent<Piece>().moving == true)
                {
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).GetChild(0).gameObject.SetActive(true);
                    this.transform.localPosition = new Vector3(0, 6, 0);
                    onMoved("", this.transform.parent.GetSiblingIndex() + 8);
                }
                else
                {
                    if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).name))
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).name);
                }

                if ((this.transform.parent.GetSiblingIndex() + 16) >= 0 && (this.transform.parent.GetSiblingIndex() + 16) <= 63)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 16).childCount < 2 &&
                    this.transform.parent.GetSiblingIndex() < 24 && (this.transform.parent.GetSiblingIndex() + 16) <= 31)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 16).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved("twoSteps", this.transform.parent.GetSiblingIndex() + 16);
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 16).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 16).name);
                        }
                    }
                }
            }
        }

        if ((this.transform.parent.GetSiblingIndex() + 7) >= 0 && (this.transform.parent.GetSiblingIndex() + 7) <= 63)
        {
            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).childCount > 1)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).GetChild(1).tag == "Black")
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved("", this.transform.parent.GetSiblingIndex() + 7);
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).name);
                    }
                }
            }

            /*if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).childCount > 1)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(1).tag == "Black" &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(1).name.Contains("Pawn") &&
                    this.transform.parent.GetSiblingIndex() >= 32 && this.transform.parent.GetSiblingIndex() <= 39)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(1).GetComponent<Pawn>().twoSteps == true)
                    {
                        if (this.GetComponent<Piece>().moving == true &&
                            lastMove == chessManager.whiteMoves[chessManager.whiteMoves.Count - 1] &&
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(1).GetComponent<Pawn>().lastMove == chessManager.blackMoves[chessManager.blackMoves.Count - 1])
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved("enPassUL", this.transform.parent.GetSiblingIndex() + 7);
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).name);
                        }
                    }                    
                }
            }*/
            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).childCount > 1 &&
                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).childCount > 1)
            {
               
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(1).tag == "Black" &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(1).name.Contains("Pawn") &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).GetChild(1).name.Contains("Pawn") &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 8).GetChild(1).tag == "Black")
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved("enPassUL", this.transform.parent.GetSiblingIndex() + 7);
                    }
                    
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 7).name);
                    }
                }
            }
        }
    }

    void toLeftDown()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if ((this.transform.parent.GetSiblingIndex() - 8) >= 0 && (this.transform.parent.GetSiblingIndex() - 8) <= 63)
        {
            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).childCount < 2)
            {
                if (this.GetComponent<Piece>().moving == true)
                {
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).GetChild(0).gameObject.SetActive(true);
                    this.transform.localPosition = new Vector3(0, 6, 0);
                    onMoved("", this.transform.parent.GetSiblingIndex() - 8);
                }
                else
                {
                    if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).name))
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).name);
                }

                if ((this.transform.parent.GetSiblingIndex() - 16) >= 0 && (this.transform.parent.GetSiblingIndex() - 16) <= 63)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 16).childCount < 2 &&
                    this.transform.parent.GetSiblingIndex() > 24 && (this.transform.parent.GetSiblingIndex() - 16) >= 32)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 16).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved("twoSteps", this.transform.parent.GetSiblingIndex() - 16);
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 16).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 16).name);
                        }
                    }
                }
            }
        }

        if ((this.transform.parent.GetSiblingIndex() - 9) >= 0 && (this.transform.parent.GetSiblingIndex() - 9) <= 63)
        {
            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 9).childCount > 1)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 9).GetChild(1).tag == "White")
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 9).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved("", this.transform.parent.GetSiblingIndex() - 9);
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 9).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 9).name);
                    }
                }

            }

            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).childCount > 1 &&
               this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).childCount > 1)
            {

                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(1).tag == "White" &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(1).name.Contains("Pawn") &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).GetChild(1).name.Contains("Pawn") &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).GetChild(1).tag == "White")
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 9).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved("enPassDL", this.transform.parent.GetSiblingIndex() - 9);
                    }

                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 9).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 9 ).name);
                    }
                }
            }

        }
    }

    void toRightDown()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if ((this.transform.parent.GetSiblingIndex() - 8) >= 0 && (this.transform.parent.GetSiblingIndex() - 8) <= 63)
        {
            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).childCount < 2)
            {
                if (this.GetComponent<Piece>().moving == true)
                {
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).GetChild(0).gameObject.SetActive(true);
                    this.transform.localPosition = new Vector3(0, 6, 0);
                    onMoved("", this.transform.parent.GetSiblingIndex() - 8);
                }
                else
                {
                    if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).name))
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).name);
                }

                if ((this.transform.parent.GetSiblingIndex() - 16) >= 0 && (this.transform.parent.GetSiblingIndex() - 16) <= 63)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 16).childCount < 2 &&
                    this.transform.parent.GetSiblingIndex() > 24 && (this.transform.parent.GetSiblingIndex() - 16) >= 32)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 16).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved("twoSteps", this.transform.parent.GetSiblingIndex() - 16);
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 16).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 16).name);
                        }
                    }
                }
            }
        }

        if ((this.transform.parent.GetSiblingIndex() - 7) >= 0 && (this.transform.parent.GetSiblingIndex() - 7) <= 63)
        {
            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 7).childCount > 1)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 7).GetChild(1).tag == "White")
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 7).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved("", this.transform.parent.GetSiblingIndex() - 7);
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 7).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 7).name);
                    }
                }
            }

            if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).childCount > 1 &&
                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).childCount > 1)
            {

                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).GetChild(1).tag == "White" &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).GetChild(1).name.Contains("Pawn") &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).GetChild(1).name.Contains("Pawn") &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 8).GetChild(1).tag == "White")
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 7).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved("enPassDR", this.transform.parent.GetSiblingIndex() - 7);
                    }

                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 7).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 7).name);
                    }
                }
            }
        }
    }

    public void showMoves()
    {
        GameObject chess = GameObject.Find("GameController");

        if (this.tag == "White")
        {
            if (this.transform.parent.tag.Contains("SideTileLeft"))
            {
                toRightUp();
            }
            else if (this.transform.parent.tag.Contains("SideTileRight"))
            {
                toLeftUp();
            }
            else
            {
                toRightUp();
                toLeftUp();
            }
        }
        else
        {
            if (this.transform.parent.tag.Contains("SideTileLeft"))
            {
                toRightDown();
            }
            else if (this.transform.parent.tag.Contains("SideTileRight"))
            {
                toLeftDown();
            }
            else
            {
                toRightDown();
                toLeftDown();
            }
        }

        canBeEaten();
    }

    void canBeEaten()
    {
        foreach (string str in this.GetComponent<Piece>().availableMoves)
        {
            Transform move = GameObject.Find(str).transform;

            if (move.childCount > 1)
            {
                move.GetChild(1).GetComponent<Piece>().canBeEaten = true;
            }
        }
    }

    void onMoved(string move, int index)
    {
        this.GetComponent<Piece>().selected = true;

        var Canvas = GameObject.Find("Canvas");

        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        this.transform.parent.parent.GetChild(index).GetComponent<TileClick>().enabled = true;
        this.transform.parent.parent.GetChild(index).GetComponent<TileClick>().Move = move;
        this.transform.parent.parent.GetChild(index).GetComponent<TileClick>().childIndex = index;
        chessManager.onMoved = true;

        foreach (Transform child in this.transform.parent.parent)
        {
            if (!child.GetChild(0).gameObject.activeSelf)
            {
                if (child.childCount > 1)
                {
                    if (child.GetChild(1).tag != this.tag)
                    {
                        child.GetComponent<TileClick>().enabled = false;
                        chessManager.onMoved = true;
                    }                   
                }               
            }
        }
    }
}