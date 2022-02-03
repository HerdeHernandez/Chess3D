using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
{    
    void toRightUp()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        for (int i = 1; i <= 8; i++)
        {
            if ((this.transform.parent.GetSiblingIndex() + (8 * i) + i) >= 0 &&
                (this.transform.parent.GetSiblingIndex() + (8 * i) + i) <= 63)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).childCount > 1 &&
                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name != chessManager.square)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name);
                        }
                    }
                    else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(1).tag == this.tag &&
                                 this.GetComponent<Piece>().moving == false)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(1).GetComponent<Piece>().supported = true;
                    }
                    break;
                }
                else if (!this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).tag.Contains("SideTile") ||
                          this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name == chessManager.square)
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name);
                    }
                }
                else
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).childCount > 1)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(1).tag != this.tag)
                        {
                            if (this.GetComponent<Piece>().moving == true)
                            {
                                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(0).gameObject.SetActive(true);
                                this.transform.localPosition = new Vector3(0, 6, 0);
                                onMoved();
                            }
                            else
                            {
                                if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name))
                                    this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name);
                            }
                        }
                        else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(1).tag == this.tag &&
                                 this.GetComponent<Piece>().moving == false)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(1).GetComponent<Piece>().supported = true;
                        }
                    }
                    else
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) + i).name);
                        }
                    }
                    break;
                }
            }
        }
    }

    void toRightDown()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        for (int i = 1; i <= 8; i++)
        {
            if ((this.transform.parent.GetSiblingIndex() - (8 * i) + i) >= 0 &&
                (this.transform.parent.GetSiblingIndex() - (8 * i) + i) <= 63)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).childCount > 1 &&
                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name != chessManager.square)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name);
                        }
                    }
                    else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(1).tag == this.tag &&
                                 this.GetComponent<Piece>().moving == false)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(1).GetComponent<Piece>().supported = true;
                    }
                    break;
                }
                else if (!this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).tag.Contains("SideTile") ||
                          this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name == chessManager.square)
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name);
                    }
                }
                else
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).childCount > 1)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(1).tag != this.tag)
                        {
                            if (this.GetComponent<Piece>().moving == true)
                            {
                                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(0).gameObject.SetActive(true);
                                this.transform.localPosition = new Vector3(0, 6, 0);
                                onMoved();
                            }
                            else
                            {
                                if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name))
                                    this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name);
                            }
                        }
                        else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(1).tag == this.tag &&
                                 this.GetComponent<Piece>().moving == false)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(1).GetComponent<Piece>().supported = true;
                        }
                    }
                    else
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) + i).name);
                        }
                    }
                    break;
                }
            }
        }
    }

    void toLeftUp()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        for (int i = 1; i <= 8; i++)
        {
            if ((this.transform.parent.GetSiblingIndex() + (8 * i) - i) >= 0 &&
                (this.transform.parent.GetSiblingIndex() + (8 * i) - i) <= 63)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).childCount > 1 &&
                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name != chessManager.square)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name);
                        }
                    }
                    else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(1).tag == this.tag &&
                                 this.GetComponent<Piece>().moving == false)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(1).GetComponent<Piece>().supported = true;
                    }
                    break;
                }
                else if (!this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).tag.Contains("SideTile") ||
                          this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name == chessManager.square)
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name);
                    }
                }
                else
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).childCount > 1)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(1).tag != this.tag)
                        {
                            if (this.GetComponent<Piece>().moving == true)
                            {
                                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(0).gameObject.SetActive(true);
                                this.transform.localPosition = new Vector3(0, 6, 0);
                                onMoved();
                            }
                            else
                            {
                                if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name))
                                    this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name);
                            }
                        }
                        else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(1).tag == this.tag &&
                                 this.GetComponent<Piece>().moving == false)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(1).GetComponent<Piece>().supported = true;
                        }
                    }
                    else
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + (8 * i) - i).name);
                        }
                    }
                    break;
                }
            }
        }
    }

    void toLeftDown()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        for (int i = 1; i <= 8; i++)
        {
            if ((this.transform.parent.GetSiblingIndex() - (8 * i) - i) >= 0 &&
                (this.transform.parent.GetSiblingIndex() - (8 * i) - i) <= 63)
            {
                if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).childCount > 1 &&
                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name != chessManager.square)
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name);
                        }
                    }
                    else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(1).tag == this.tag &&
                                 this.GetComponent<Piece>().moving == false)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(1).GetComponent<Piece>().supported = true;
                    }
                    break;
                }
                else if (!this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).tag.Contains("SideTile") ||
                          this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name == chessManager.square)
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name))
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name);
                    }
                }
                else
                {
                    if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).childCount > 1)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(1).tag != this.tag)
                        {
                            if (this.GetComponent<Piece>().moving == true)
                            {
                                this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(0).gameObject.SetActive(true);
                                this.transform.localPosition = new Vector3(0, 6, 0);
                                onMoved();
                            }
                            else
                            {
                                if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name))
                                    this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name);
                            }
                        }
                        else if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(1).tag == this.tag &&
                                 this.GetComponent<Piece>().moving == false)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(1).GetComponent<Piece>().supported = true;
                        }
                    }
                    else
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name))
                                this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - (8 * i) - i).name);
                        }
                    }
                    break;
                }
            }
        }
    }

    public void showMoves()
    {
        if (this.transform.parent.tag == "SideTileLeftDown")
        {
            toRightUp();
        }
        else if (this.transform.parent.tag == "SideTileLeftUp")
        {
            toRightDown();

        }
        else if (this.transform.parent.tag == "SideTileRightUp")
        {
            toLeftDown();
        }
        else if (this.transform.parent.tag == "SideTileRightDown")
        {
            toLeftUp();
        }
        else if (this.transform.parent.tag == "SideTileLeft")
        {
            toRightDown();
            toRightUp();
        }
        else if (this.transform.parent.tag == "SideTileRight")
        {
            toLeftDown();
            toLeftUp();
        }
        else if (this.transform.parent.tag == "SideTileUp")
        {
            toLeftDown();
            toRightDown();
        }
        else if (this.transform.parent.tag == "SideTileDown")
        {
            toRightUp();
            toLeftUp();
        }
        else
        {
            toLeftUp();
            toRightUp();
            toLeftDown();
            toRightDown();
        }
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
}
