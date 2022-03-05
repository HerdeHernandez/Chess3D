using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notation : MonoBehaviour
{

    //notation identifier
    public void notation(string childName, string tileName)
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if (childName.Contains("Pawn"))
        {
            if (this.transform.childCount > 2)
            {
                addingNotation(chessManager.square + tileName + this.name);
            }
            else
            {
                addingNotation(tileName + this.name);
            }
            
            this.transform.GetChild(1).GetComponent<Pawn>().lastMove = this.name;
        }
        else if (childName.Contains("Rook"))
        {
            addingNotation("R" + tileName + this.name);
        }
        else if (childName.Contains("Bishop"))
        {
            addingNotation("B" + tileName + this.name);
        }
        else if (childName.Contains("Knight"))
        {
            addingNotation("N" + tileName + this.name);
        }
        else if (childName.Contains("Queen"))
        {
            addingNotation("Q" + tileName + this.name);
        }
        else if (childName.Contains("King"))
        {
            addingNotation("K" + tileName + this.name);
        }
    }

    //add notation
    public void addingNotation(string notation)
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        Transform Notation = GameObject.Find("Chess Canvas").transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0);

        if (chessManager.Player == "White")
        {
            chessManager.whiteMoves.Add(notation);
            showNotation(notation, Notation.GetChild(0));
        }
        else
        {
            chessManager.blackMoves.Add(notation);
            showNotation(notation, Notation.GetChild(1));
        }
    }

    //show notation on canvas
    public void showNotation(string Notation, Transform color)
    {
        var text = Resources.Load("Text") as GameObject;
        var textDetails = Instantiate(text, color);

        textDetails.GetComponent<Text>().text = Notation;
    }


    //fix vertical layout group not updating every new notation
    private void Update()
    {
        Transform Notation = GameObject.Find("Chess Canvas").transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0);

        Notation.GetChild(0).GetComponent<VerticalLayoutGroup>().enabled = false;
        Notation.GetChild(1).GetComponent<VerticalLayoutGroup>().enabled = false;

        if (Notation.GetChild(0).GetComponent<VerticalLayoutGroup>().enabled == false)
        {
            Notation.GetChild(0).GetComponent<VerticalLayoutGroup>().enabled = true;
        }

        if (Notation.GetChild(1).GetComponent<VerticalLayoutGroup>().enabled == false)
        {
            Notation.GetChild(1).GetComponent<VerticalLayoutGroup>().enabled = true;
        }
    }
}
