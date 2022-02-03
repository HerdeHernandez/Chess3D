using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public bool selected = false;
    public bool hasMoved = false;
    public bool canBeEaten = false;
    public bool supported = false;

    public List<string> availableMoves = new List<string>();
    public bool moving = false;

    private void Start()
    {
        
    }

    public void pieceClick()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if (this.name.Contains("Pawn"))
        {
            moving = true;
            this.GetComponent<Deselect>().deselect();
            this.GetComponent<Pawn>().showMoves();
        }
        else if (this.name.Contains("Rook"))
        {
            moving = true;
            this.GetComponent<Deselect>().deselect();
            this.GetComponent<Tower>().showMoves();
        }
        else if (this.name.Contains("Knight"))
        {
            moving = true;
            this.GetComponent<Deselect>().deselect();
            this.GetComponent<Knight>().showMoves();
        }
        else if (this.name.Contains("Bishop"))
        {
            moving = true;
            this.GetComponent<Deselect>().deselect();
            this.GetComponent<Bishop>().showMoves();
        }
        else if (this.name.Contains("Queen"))
        {
            moving = true;
            this.GetComponent<Deselect>().deselect();
            this.GetComponent<Tower>().showMoves();
            this.GetComponent<Bishop>().showMoves();
        }
        else if (this.name.Contains("King"))
        {
            moving = true;
            this.GetComponent<Deselect>().deselect();
            this.GetComponent<King>().showMoves();            
        }
    }

    public void showMoves()
    {      
        if (this.name.Contains("Pawn"))
        {
            moving = false;
            this.GetComponent<Pawn>().showMoves();
        }
        else if (this.name.Contains("Rook"))
        {
            moving = false;
            this.GetComponent<Tower>().showMoves();
        }
        else if (this.name.Contains("Knight"))
        {
            moving = false;
            this.GetComponent<Knight>().showMoves();
        }
        else if (this.name.Contains("Bishop"))
        {
            moving = false;
            this.GetComponent<Bishop>().showMoves();
        }
        else if (this.name.Contains("Queen"))
        {
            moving = false;
            this.GetComponent<Tower>().showMoves();
            this.GetComponent<Bishop>().showMoves();
        }
        else if (this.name.Contains("King"))
        {
            moving = false;
            this.GetComponent<King>().showMoves();
        }
    }    
}
