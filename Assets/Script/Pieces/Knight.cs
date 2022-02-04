using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public void showMoves()
    {
        if (this.transform.parent.tag == "SideTileLeftDown")
        {
            upright();
            rightup();
        }
        else if (this.transform.parent.tag == "SideTileLeftUp")
        {
            downright();
            rightdown();
        }
        else if (this.transform.parent.tag == "SideTileRightUp")
        {
            downleft();
            leftdown();
        }
        else if (this.transform.parent.tag == "SideTileRightDown")
        {
            upleft();
            leftup();
        }
        else if (this.transform.parent.tag == "SideTileLeft")
        {
            upright();
            rightup();
            rightdown();
            downright();
        }
        else if (this.transform.parent.tag == "SideTileRight")
        {
            upleft();
            leftup();
            leftdown();
            downleft();
        }
        else if (this.transform.parent.tag == "SideTileUp")
        {
            downright();
            leftdown();
            downleft();
            rightdown();
        }
        else if (this.transform.parent.tag == "SideTileDown")
        {
            upright();
            leftup();
            upleft();
            rightup();
        }
        else
        {
            upleft();
            upright();
            downleft();
            downright();
            rightup();
            rightdown();
            leftup();
            leftdown();
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

    void upleft()
    {
        int index = this.transform.parent.GetSiblingIndex() + (8 * 2) - 1;
        if (index >= 0 && index <= 63)
        {
            if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).tag.Contains("SideTile"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).name);
                    }
                }
            }
            else if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).tag.Contains("Right"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) - 1).name);
                    }
                }
            }
        }
    }

    void upright()
    {
        int index = this.transform.parent.GetSiblingIndex() + (8 * 2) + 1;
        if (index >= 0 && index <= 63)
        {
            if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).tag.Contains("SideTile"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).name);
                    }
                }
            }
            else if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).tag.Contains("Left"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + (8 * 2)) + 1).name);
                    }
                }
            }
        }
    }

    void rightup()
    {
        int index = (this.transform.parent.GetSiblingIndex() + 8) + 2;
        if (index >= 0 && index <= 63)
        {
            if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) + 1).tag.Contains("SideTileRight"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) + 2).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) + 2).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) + 2).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) + 2).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) + 2).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) + 2).name);
                    }
                }
            }
        }
    }

    void rightdown()
    {

        int index = (this.transform.parent.GetSiblingIndex() - 8) + 2;
        if (index >= 0 && index <= 63)
        {
            if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) + 1).tag.Contains("SideTileRight"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) + 2).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) + 2).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) + 2).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) + 2).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) + 2).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) + 2).name);
                    }
                }
            }
        }
    }

    void leftup()
    {
        int index = (this.transform.parent.GetSiblingIndex() + 8) - 2;
        if (index >= 0 && index <= 63)
        {
            if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) - 1).tag.Contains("SideTileLeft"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) - 2).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) - 2).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) - 2).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) - 2).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) - 2).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() + 8) - 2).name);
                    }
                }
            }
        }
    }

    void leftdown()
    {
        int index = (this.transform.parent.GetSiblingIndex() - 8) -2;
        if (index >= 0 && index <= 63)
        {
            if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) - 1).tag.Contains("SideTileLeft"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) - 2).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) - 2).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) - 2).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) - 2).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) - 2).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - 8) - 2).name);
                    }
                }
            }
        }
    }


    void downleft()
    {
        int index = this.transform.parent.GetSiblingIndex() - (8 * 2) - 1;
        if (index >= 0 && index <= 63)
        {
            if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2))-1).tag.Contains("SideTile"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).name);
                    }
                }
            }
            else if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).tag.Contains("Right"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) - 1).name);
                    }
                }
            }
        }
    }

    void downright()
    {
        int index = this.transform.parent.GetSiblingIndex() - (8 * 2) + 1;
        if (index >= 0 && index <= 63)
        {
            if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).tag.Contains("SideTile"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).name);
                    }
                }
            }
            else if (!this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).tag.Contains("Left"))
            {
                if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).childCount > 1)
                {
                    if (this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).GetChild(1).tag != this.tag)
                    {
                        if (this.GetComponent<Piece>().moving == true)
                        {
                            this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).GetChild(0).gameObject.SetActive(true);
                            this.transform.localPosition = new Vector3(0, 6, 0);
                            onMoved();
                        }
                        else
                        {
                            this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).name);
                        }
                    }
                }
                else
                {
                    if (this.GetComponent<Piece>().moving == true)
                    {
                        this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).GetChild(0).gameObject.SetActive(true);
                        this.transform.localPosition = new Vector3(0, 6, 0);
                        onMoved();
                    }
                    else
                    {
                        this.GetComponent<Piece>().availableMoves.Add(this.transform.parent.parent.GetChild((this.transform.parent.GetSiblingIndex() - (8 * 2)) + 1).name);
                    }
                }
            }
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
