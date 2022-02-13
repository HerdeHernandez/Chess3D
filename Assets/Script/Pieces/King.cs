using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    public string castling;
    public bool check, checkmate;

    List<bool> canBeEaten = new List<bool>();

    void Move(int childIndex)
    {
        if (this.transform.parent.parent.GetChild(childIndex).childCount > 1)
        {
            if (this.transform.parent.parent.GetChild(childIndex).GetChild(1).tag != this.tag)
            {
                if (this.GetComponent<Piece>().moving == true)
                {
                    if (this.transform.parent.parent.GetChild(childIndex).GetChild(1).GetComponent<Piece>().supported == true)
                    {
                        this.transform.parent.parent.GetChild(childIndex).GetChild(0).gameObject.SetActive(false);
                        this.transform.localPosition = new Vector3(0, 0, 0);
                        this.GetComponent<Piece>().availableMoves.Remove(this.transform.parent.parent.GetChild(childIndex).name);
                        //print(this.tag + " 1");
                    }
                    else
                    {
                        this.transform.parent.parent.GetChild(childIndex).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved("", childIndex);
                        //print(this.tag + " 2");
                    }
                }
                else
                {
                    if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(childIndex).name))
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(childIndex).name);
                        //print(this.tag + " 3");
                    }
                }
            }
        }
        else
        {
            if (this.GetComponent<Piece>().moving == true)
            {
                foreach (Transform child in this.transform.parent.parent)
                {
                    if (child.childCount > 1)
                    {
                        if (child.GetChild(1).tag != this.tag)
                        {
                            if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(childIndex).name))
                            {
                                this.transform.parent.parent.GetChild(childIndex).GetChild(0).gameObject.SetActive(false);
                                this.transform.localPosition = new Vector3(0, 0, 0);
                                this.GetComponent<Piece>().availableMoves.Remove(this.transform.parent.parent.GetChild(childIndex).name);
                                //print(this.tag + " 4");
                                break;
                            }
                            else
                            {
                                this.transform.parent.parent.GetChild(childIndex).GetChild(0).gameObject.SetActive(true);
                                this.transform.localPosition = new Vector3(0, 6, 0);
                                onMoved("", childIndex);
                                //print(this.tag + " 5");
                            }
                        }
                    }
                }
            }
            else
            {
                if (!this.GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(childIndex).name))
                {
                    this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild(childIndex).name);
                    //print(this.tag + " 6");
                }
            }
        }       
    }

    void castlingMove()
    {

    }
   

    public void showMoves()
    {
        if (this.GetComponent<Piece>().moving == true)
        {
            if (this.tag == "White")
            {
                if (this.transform.parent.parent.GetChild(7).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild(7).GetChild(1).GetComponent<Piece>().hasMoved == false &&
                         check == false && checkmate == false && this.GetComponent<Piece>().hasMoved == false)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).childCount < 2 &&
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 2).childCount < 2)
                        {
                            foreach (Transform child in this.transform.parent.parent)
                            {
                                if (child.childCount > 1)
                                {
                                    if (child.GetChild(1).tag != this.tag)
                                    {
                                        if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).name))
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).GetChild(0).gameObject.SetActive(false);
                                            break;
                                        }
                                        else
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).GetChild(0).gameObject.SetActive(true);
                                            this.transform.localPosition = new Vector3(0, 6, 0);
                                            castling = "whiteKing";
                                            onMoved("whiteKing", this.transform.parent.GetSiblingIndex() + 1);
                                        }

                                        if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 2).name))
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 2).GetChild(0).gameObject.SetActive(false);
                                            break;
                                        }
                                        else
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 2).GetChild(0).gameObject.SetActive(true);
                                            this.transform.localPosition = new Vector3(0, 6, 0);
                                            castling = "whiteKing";
                                            onMoved("whiteKing", this.transform.parent.GetSiblingIndex() + 2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (this.transform.parent.parent.GetChild(0).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild(0).GetChild(1).GetComponent<Piece>().hasMoved == false &&
                    check == false && checkmate == false && this.GetComponent<Piece>().hasMoved == false)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).childCount < 2 &&
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 2).childCount < 2)
                        {
                            foreach (Transform child in this.transform.parent.parent)
                            {
                                if (child.childCount > 1)
                                {
                                    if (child.GetChild(1).tag != this.tag)
                                    {
                                        if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).name))
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(0).gameObject.SetActive(false);
                                            break;
                                        }
                                        else
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(0).gameObject.SetActive(true);
                                            this.transform.localPosition = new Vector3(0, 6, 0);
                                            castling = "whiteQueen";
                                            onMoved("whiteQueen", this.transform.parent.GetSiblingIndex() - 1);
                                        }

                                        if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 2).name))
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 2).GetChild(0).gameObject.SetActive(false);
                                            break;
                                        }
                                        else
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 2).GetChild(0).gameObject.SetActive(true);
                                            this.transform.localPosition = new Vector3(0, 6, 0);
                                            castling = "whiteQueen";
                                            onMoved("whiteQueen", this.transform.parent.GetSiblingIndex() - 2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (this.tag == "Black")
            {
                if (this.transform.parent.parent.GetChild(63).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild(63).GetChild(1).GetComponent<Piece>().hasMoved == false &&
                        check == false && checkmate == false && this.GetComponent<Piece>().hasMoved == false)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).childCount < 2 &&
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 2).childCount < 2)
                        {
                            foreach (Transform child in this.transform.parent.parent)
                            {
                                if (child.childCount > 1)
                                {
                                    if (child.GetChild(1).tag != this.tag)
                                    {
                                        if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).name))
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).GetChild(0).gameObject.SetActive(false);
                                            break;
                                        }
                                        else
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 1).GetChild(0).gameObject.SetActive(true);
                                            this.transform.localPosition = new Vector3(0, 6, 0);
                                            castling = "blackKing";
                                            onMoved("blackKing", this.transform.parent.GetSiblingIndex() + 1);
                                        }

                                        if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 2).name))
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 2).GetChild(0).gameObject.SetActive(false);
                                            break;
                                        }
                                        else
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() + 2).GetChild(0).gameObject.SetActive(true);
                                            this.transform.localPosition = new Vector3(0, 6, 0);
                                            castling = "blackKing";
                                            onMoved("blackKing", this.transform.parent.GetSiblingIndex() + 2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (this.transform.parent.parent.GetChild(56).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild(56).GetChild(1).GetComponent<Piece>().hasMoved == false &&
                    check == false && checkmate == false && this.GetComponent<Piece>().hasMoved == false)
                    {
                        if (this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).childCount < 2 &&
                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 2).childCount < 2)
                        {
                            foreach (Transform child in this.transform.parent.parent)
                            {
                                if (child.childCount > 1)
                                {
                                    if (child.GetChild(1).tag != this.tag)
                                    {
                                        if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).name))
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(0).gameObject.SetActive(false);
                                            break;
                                        }
                                        else
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 1).GetChild(0).gameObject.SetActive(true);
                                            this.transform.localPosition = new Vector3(0, 6, 0);
                                            castling = "blackQueen";
                                            onMoved("blackQueen", this.transform.parent.GetSiblingIndex() - 1);
                                        }

                                        if (child.GetChild(1).GetComponent<Piece>().availableMoves.Contains(this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 2).name))
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 2).GetChild(0).gameObject.SetActive(false);
                                            break;
                                        }
                                        else
                                        {
                                            this.transform.parent.parent.GetChild(this.transform.parent.GetSiblingIndex() - 2).GetChild(0).gameObject.SetActive(true);
                                            this.transform.localPosition = new Vector3(0, 6, 0);
                                            castling = "blackQueen";
                                            onMoved("blackQueen", this.transform.parent.GetSiblingIndex() - 2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Moves();
        }
        else
        {
            Moves();
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

    void Moves()
    {
        if (this.transform.parent.tag == "SideTileLeftDown")
        {
            Move(this.transform.parent.GetSiblingIndex() + 8);
            Move(this.transform.parent.GetSiblingIndex() + 1);
            Move(this.transform.parent.GetSiblingIndex() + 9);
        }
        else if (this.transform.parent.tag == "SideTileLeftUp")
        {
            Move(this.transform.parent.GetSiblingIndex() + 1);
            Move(this.transform.parent.GetSiblingIndex() - 8);
            Move(this.transform.parent.GetSiblingIndex() - 7);
        }
        else if (this.transform.parent.tag == "SideTileRightUp")
        {
            Move(this.transform.parent.GetSiblingIndex() - 8);
            Move(this.transform.parent.GetSiblingIndex() - 1);
            Move(this.transform.parent.GetSiblingIndex() - 9);
        }
        else if (this.transform.parent.tag == "SideTileRightDown")
        {
            Move(this.transform.parent.GetSiblingIndex() + 8);
            Move(this.transform.parent.GetSiblingIndex() - 1);
            Move(this.transform.parent.GetSiblingIndex() + 7);
        }
        else if (this.transform.parent.tag == "SideTileLeft")
        {
            Move(this.transform.parent.GetSiblingIndex() + 8);
            Move(this.transform.parent.GetSiblingIndex() + 1);
            Move(this.transform.parent.GetSiblingIndex() - 8);
            Move(this.transform.parent.GetSiblingIndex() + 9);
            Move(this.transform.parent.GetSiblingIndex() - 7);
        }
        else if (this.transform.parent.tag == "SideTileRight")
        {
            Move(this.transform.parent.GetSiblingIndex() + 8);
            Move(this.transform.parent.GetSiblingIndex() - 8);
            Move(this.transform.parent.GetSiblingIndex() - 1);
            Move(this.transform.parent.GetSiblingIndex() + 7);
            Move(this.transform.parent.GetSiblingIndex() - 9);
        }
        else if (this.transform.parent.tag == "SideTileUp")
        {
            Move(this.transform.parent.GetSiblingIndex() + 1);
            Move(this.transform.parent.GetSiblingIndex() - 8);
            Move(this.transform.parent.GetSiblingIndex() - 1);
            Move(this.transform.parent.GetSiblingIndex() - 9);
            Move(this.transform.parent.GetSiblingIndex() - 7);
        }
        else if (this.transform.parent.tag == "SideTileDown")
        {
            Move(this.transform.parent.GetSiblingIndex() + 8);
            Move(this.transform.parent.GetSiblingIndex() + 1);
            Move(this.transform.parent.GetSiblingIndex() - 1);
            Move(this.transform.parent.GetSiblingIndex() + 9);
            Move(this.transform.parent.GetSiblingIndex() + 7);
        }
        else
        {
            Move(this.transform.parent.GetSiblingIndex() + 8);
            Move(this.transform.parent.GetSiblingIndex() + 1);
            Move(this.transform.parent.GetSiblingIndex() - 8);
            Move(this.transform.parent.GetSiblingIndex() - 1);
            Move(this.transform.parent.GetSiblingIndex() + 9);
            Move(this.transform.parent.GetSiblingIndex() + 7);
            Move(this.transform.parent.GetSiblingIndex() - 9);
            Move(this.transform.parent.GetSiblingIndex() - 7);
        }
        removeMoves();
    }

    public void removeMoves()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();        

        if (this.GetComponent<Piece>().availableMoves.Count > 0)
        {
            foreach (Transform child in this.transform.parent.parent)
            {
                if (child.childCount > 1)
                {
                    if (child.GetChild(1).tag != this.tag && child.GetChild(1).GetComponent<Piece>().canBeEaten == false)
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

            foreach (string str in this.GetComponent<Piece>().availableMoves)
            {
                StartCoroutine(remove(str));  
            }

            if (this.GetComponent<Piece>().availableMoves.Count == 0 && this.GetComponent<King>().check == false)
            {
                StartCoroutine(chessManager.stalemate());
            }
        }

       
    }

   IEnumerator remove(string str)
    {
        yield return new WaitForSeconds(.1f);

        Transform move = GameObject.Find(str).transform;

        if (move.childCount > 1)
        {
            if (move.GetChild(1).GetComponent<Piece>().supported == true)
            {
                this.GetComponent<Piece>().availableMoves.Remove(str);
            }
        }
    }

    private void Update()
    {
        this.GetComponent<Piece>().supported = false;
    }
}
