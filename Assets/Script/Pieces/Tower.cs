using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public bool moving = false;

    void up()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        for (int i = 1; i <= 8; i++)
        {
            if ((this.transform.parent.GetSiblingIndex() + (8 * i)) >= 0 &&
                (this.transform.parent.GetSiblingIndex() + (8 * i)) <= 63)
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).childCount > 1 &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name != chessManager.square)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name);
                        }
                    }
                    else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(1).tag == this.tag &&
                                this.GetComponent<Piece>().moving == false)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(1).GetComponent<Piece>().supported = true;
                    }
                    break;
                }
                else if (!this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).tag.Contains("SideTileUp") ||
                          this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name == chessManager.square)
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name);
                    }
                }
                else
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).childCount > 1)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(1).tag != this.tag)
                        {
                            if (this.GetComponent<Piece>().moving == true)
                            {
                                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(0).gameObject.SetActive(true);
                                this.transform.localPosition = new Vector3(0, 6, 0);
                                onMoved();
                                break;
                            }
                            else
                            {
                                if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name))
                                    this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name);
                                break;
                            }
                        }
                        else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(1).tag == this.tag &&
                                this.GetComponent<Piece>().moving == false)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(1).GetComponent<Piece>().supported = true;
                        }
                    }
                    else
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                            break;
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i)).name);
                            break;
                        }
                    }
                }
        }
    }

    void down()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        for (int i = 1; i <= 8; i++)
        {
            if ((this.transform.parent.GetSiblingIndex() - (8 * i)) >= 0 &&
                (this.transform.parent.GetSiblingIndex() - (8 * i)) <= 63)
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).childCount > 1 &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name != chessManager.square)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name);
                        }
                    }
                    else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).GetChild(1).tag == this.tag &&
                                this.GetComponent<Piece>().moving == false)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).GetChild(1).GetComponent<Piece>().supported = true;
                    }
                    break;
                }
                else if (!this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).tag.Contains("SideTileDown") ||
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name == chessManager.square)
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + -(8 * i)).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name);
                    }
                }
                else
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).childCount > 1)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).GetChild(1).tag != this.tag)
                        {
                            if (this.GetComponent<Piece>().moving == true)
                            {
                                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() -(8 * i)).GetChild(0).gameObject.SetActive(true);
                                this.transform.localPosition = new Vector3(0, 6, 0);
                                onMoved();
                                break;
                            }
                            else
                            {
                                if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name))
                                    this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name);
                                break;
                            }
                        }
                        else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).GetChild(1).tag == this.tag &&
                                this.GetComponent<Piece>().moving == false)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).GetChild(1).GetComponent<Piece>().supported = true;
                        }
                    }
                    else
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex()  - (8 * i)).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                            break;
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i)).name);
                            break;
                        }
                    }
                }
        }
    }

    void left()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        for (int i = 1; i <= 8; i++)
        {
            if ((this.transform.parent.GetSiblingIndex() - (i)) >= 0 &&
                (this.transform.parent.GetSiblingIndex() - (i)) <= 63)
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).childCount > 1 &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).name != chessManager.square)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - ( i)).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).name);
                        }
                    }
                    else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(1).tag == this.tag &&
                                this.GetComponent<Piece>().moving == false)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(1).GetComponent<Piece>().supported = true;
                    }
                    break;
                }
                else if (!this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).tag.Contains("SideTileLeft") ||
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).name == chessManager.square)
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).name);
                    }
                }
                else
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).childCount > 1)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(1).tag != this.tag)
                        {
                            if (this.GetComponent<Piece>().moving == true)
                            {
                                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(0).gameObject.SetActive(true);
                                this.transform.localPosition = new Vector3(0, 6, 0);
                                onMoved();
                                break;
                            }
                            else
                            {
                                if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).name))
                                    this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).name);
                                break;
                            }
                        }
                        else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(1).tag == this.tag &&
                                this.GetComponent<Piece>().moving == false)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(1).GetComponent<Piece>().supported = true;
                        }
                    }
                    else
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                            break;
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (i)).name);
                            break;
                        }
                    }
                }
        }
    }

    void right()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        for (int i = 1; i <= 8; i++)
        {
            if ((this.transform.parent.GetSiblingIndex() + (i)) >= 0 &&
                (this.transform.parent.GetSiblingIndex() + (i)) <= 63)
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).childCount > 1 &&
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name != chessManager.square)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name);
                        }
                    }
                    else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(1).tag == this.tag &&
                                this.GetComponent<Piece>().moving == false)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(1).GetComponent<Piece>().supported = true;
                    }
                    break;
                }
                else if (!this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).tag.Contains("SideTileRight") ||
                    this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name == chessManager.square)
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name);
                    }
                }
                else
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).childCount > 1)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(1).tag != this.tag)
                        {
                            if (this.GetComponent<Piece>().moving == true)
                            {
                                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(0).gameObject.SetActive(true);
                                this.transform.localPosition = new Vector3(0, 6, 0);
                                onMoved();
                            }
                            else
                            {
                                if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name))
                                    this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name);
                            }
                        }
                        else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(1).tag == this.tag &&
                                this.GetComponent<Piece>().moving == false)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(1).GetComponent<Piece>().supported = true;
                        }
                    }
                    else
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (i)).name);
                        }
                    }
                    break;
                }
        }
    }

    public void showMoves()
    {
        if (this.transform.parent.tag == "SideTileLeftDown")
        {
            up();
            right();
        }
        else if (this.transform.parent.tag == "SideTileLeftUp")
        {
            down();
            right();

        }
        else if (this.transform.parent.tag== "SideTileRightUp")
        {
            down();
            left();
        }
        else if (this.transform.parent.tag=="SideTileRightDown")
        {
            up();
            left();
        }
        else if(this.transform.parent.tag == "SideTileLeft") 
        {
            up();
            down();
            right();
        }
        else if (this.transform.parent.tag == "SideTileRight")
        {
            up();
            down();
            left();
        }
        else if (this.transform.parent.tag == "SideTileUp")
        {
            right();
            down();
            left();
        }
        else if (this.transform.parent.tag == "SideTileDown")
        {
            up();
            right();
            left();
        }
        else
        {
            up();
            down();
            right();
            left();
        }

        canBeEaten();
    }

    void onMoved()
    {
        this.GetComponent<Piece>().selected = true;

        var Canvas = GameObject.Find("Canvas");

        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

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
}
