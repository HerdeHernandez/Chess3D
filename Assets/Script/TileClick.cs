using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class TileClick : MonoBehaviour
{
    public int childIndex = 0;
    public string Move, notation;
    Transform notationTextParent;

    [DllImport("__Internal")]
    private static extern void squareClick(string tileName, string thisName, string notation);

    public void OnMouseDown()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if (this.GetComponent<TileClick>().enabled == true && this.transform.childCount > 1)
        {
            if (this.transform.GetChild(1).tag == chessManager.Player
#if UNITY_WEBGL && !UNITY_EDITOR
                && this.transform.GetChild(1).tag == chessManager.Me 
#endif
                )
            {                   
                this.transform.GetChild(1).GetComponent<Piece>().availableMoves.Clear();
                this.transform.GetChild(1).GetComponent<Piece>().supported = false;                

                chessManager.square = this.name;
                this.transform.GetChild(1).GetComponent<Piece>().pieceClick();
                reset();
                showMoves();
            }
            else
            {
                showMoves();
                StartCoroutine(moving());
            }

        }
        else if (this.transform.GetChild(0).gameObject.activeSelf)
        {
            showMoves();
            StartCoroutine(moving());
        }
    }

    IEnumerator moving()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        foreach (Transform child in this.transform.parent)
        {
            if (child.childCount > 1)
            {
                if (child.GetChild(1).GetComponent<Piece>().selected == true)
                {
                    chessManager.move = Move;

                    yield return new WaitForSeconds(.001f);
                    child.GetChild(1).parent = this.transform;

                    if (this.transform.childCount > 2)
                    {
                        this.transform.GetChild(2).SetSiblingIndex(1);
                    }

                    reset();
                    showMoves();

                    Transform kingWhite = GameObject.Find("KingWhite").transform;
                    Transform kingBlack = GameObject.Find("KingBlack").transform;

                    kingWhite.GetComponent<King>().check = false;
                    kingWhite.GetComponent<King>().checkmate = false;

                    kingBlack.GetComponent<King>().check = false;
                    kingBlack.GetComponent<King>().checkmate = false;

                    moveChecking();

                    if (chessManager.Player == "White")
                    {
                        if (kingWhite.GetComponent<King>().check == true && this.transform.GetChild(1).name != "KingWhite" || kingWhite.GetComponent<King>().checkmate == true)
                        {
                            yield return new WaitForSeconds(.001f);
                            this.transform.GetChild(1).parent = child;
                            child.GetChild(1).localPosition = new Vector3(0, 0, 0);

                            child.GetChild(1).GetComponent<Piece>().selected = false;
                            chessManager.square = "";
                            reset();
                            showMoves();

                            kingWhite.GetComponent<King>().check = false;
                            kingWhite.GetComponent<King>().checkmate = false;

                            moveChecking();
                        }
                        else
                        {
                            yield return new WaitForSeconds(.001f);

                            this.transform.GetChild(1).localPosition = new Vector3(0, 0, 0);
                            this.transform.GetChild(1).GetComponent<Piece>().selected = false;
                            this.transform.GetChild(1).GetComponent<Piece>().hasMoved = true;

                           /* while (this.transform.GetChild(1).localPosition.x > 0)
                            {
                                print(this.transform.GetChild(1).localPosition.x);
                            }*/

                            chessManager.onMoved = false;
                            
                            eatPiece();
                            promotion();

                            if (this.transform.GetChild(1).tag == "White" && chessManager.promotion == false)
                            {
                                chessManager.Player = "Black";
                                notation = chessManager.whiteMoves[chessManager.whiteMoves.Count - 1];
                            }
                            else if (this.transform.GetChild(1).tag == "Black" && chessManager.promotion == false)
                            {
                                chessManager.Player = "White";
                                notation = chessManager.blackMoves[chessManager.blackMoves.Count - 1];
                            }

                            kingWhite.GetComponent<King>().check = false;
                            kingWhite.GetComponent<King>().checkmate = false;



#if UNITY_WEBGL && !UNITY_EDITOR
                            squareClick(child.name, this.name, Move);
#endif
                        }

                        /*  if (chessManager.promotion == false)
                          {
                              squareClick(child.name, this.name, notation);
                          }
                          else
                          {
                              squareClick(child.name, this.name, notation + "-true");
                          }*/
                    }
                    else
                    {
                        /*print(kingBlack.GetComponent<King>().check);
                        print(this.transform.GetChild(1).name);
                        print(kingBlack.GetComponent<King>().checkmate);*/
                        
                        if (kingBlack.GetComponent<King>().check == true && this.transform.GetChild(1).name != "KingBlack" || kingBlack.GetComponent<King>().checkmate == true)
                        {
                            yield return new WaitForSeconds(.001f);
                            this.transform.GetChild(1).parent = child;
                            child.GetChild(1).localPosition = new Vector3(0, 0, 0);

                            child.GetChild(1).GetComponent<Piece>().selected = false;
                            chessManager.square = "";
                            reset();
                            showMoves();
                            kingBlack.GetComponent<King>().check = false;
                            kingBlack.GetComponent<King>().checkmate = false;

                            moveChecking();
                        }
                        else
                        {

                            yield return new WaitForSeconds(.001f);
                            this.transform.GetChild(1).localPosition = new Vector3(0, 0, 0);
                            this.transform.GetChild(1).GetComponent<Piece>().selected = false;
                            this.transform.GetChild(1).GetComponent<Piece>().hasMoved = true;

                            chessManager.onMoved = false;
                            
                            eatPiece();
                            promotion();

                            if (this.transform.GetChild(1).tag == "White" && chessManager.promotion == false)
                            {
                                chessManager.Player = "Black";
                                notation = chessManager.whiteMoves[chessManager.whiteMoves.Count - 1];
                            }
                            else if (this.transform.GetChild(1).tag == "Black" && chessManager.promotion == false)
                            {
                                chessManager.Player = "White";
                                notation = chessManager.blackMoves[chessManager.blackMoves.Count - 1];
                            }

                            kingBlack.GetComponent<King>().check = false;
                            kingBlack.GetComponent<King>().checkmate = false;


#if UNITY_WEBGL && !UNITY_EDITOR
                             squareClick(child.name, this.name, Move);
#endif
                        }

                        /*if (chessManager.promotion == false)
                        {
                            squareClick(child.name, this.name, notation);
                        }
                        else
                        {
                            squareClick(child.name, this.name, notation + "-true");
                        }*/
                    }

                    foreach (Transform children in this.transform.parent)
                    {
                        children.GetChild(0).gameObject.SetActive(false);
                    }

                    childIndex = 0;
                    break;
                }
            }
        }
    }    

    void promotion()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        Transform Promotion = GameObject.Find("Chess Canvas").transform.GetChild(2);
        Transform Notation = GameObject.Find("Chess Canvas").transform.GetChild(1);

        notationTextParent = Notation.GetChild(2).GetChild(0).GetChild(0);

        if (this.transform.childCount > 1 && this.name.Contains("8"))
        {
            if (this.transform.GetChild(1).tag == "White" && this.transform.GetChild(1).name.Contains("Pawn"))
            {
                chessManager.promotion = true;
                Promotion.gameObject.SetActive(true);
                this.transform.GetChild(1).GetComponent<Pawn>().promotion = true;

                chessManager.whiteMoves[chessManager.whiteMoves.Count - 1] = "";
                string newNotation = notationTextParent.GetChild(0).GetChild(notationTextParent.GetChild(0).childCount - 1).GetComponent<Text>().text;
                notationTextParent.GetChild(0).GetChild(notationTextParent.GetChild(0).childCount - 1).GetComponent<Text>().text = "";

                Promotion.GetComponent<Promotion>().notation = newNotation;
            }
        }

        if (this.transform.childCount > 1 && this.name.Contains("1"))
        {
            if (this.transform.GetChild(1).tag == "Black" && this.transform.GetChild(1).name.Contains("Pawn"))
            {
                chessManager.promotion = true;
                Promotion.gameObject.SetActive(true);
                this.transform.GetChild(1).GetComponent<Pawn>().promotion = true;

                chessManager.whiteMoves[chessManager.whiteMoves.Count - 1] = "";
                string newNotation = Notation.GetChild(1).GetChild(Notation.GetChild(1).childCount - 1).GetComponent<Text>().text;
                Notation.GetChild(1).GetChild(Notation.GetChild(1).childCount - 1).GetComponent<Text>().text = "";

                Promotion.GetComponent<Promotion>().notation = newNotation;
            }
        }
    }    

    public void eatPiece()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        var notation = this.GetComponent<Notation>();

        if (Move == "enPassUR")
        {
            Destroy(chessManager.tilesParent.GetChild(childIndex - 8).GetChild(1).gameObject);
            this.GetComponent<Notation>().addingNotation(chessManager.square + "x" + chessManager.tilesParent.GetChild(childIndex - 8).name);
        }
        else if (Move == "enPassUL")
        {
            Destroy(chessManager.tilesParent.GetChild(childIndex - 8).GetChild(1).gameObject);
            this.GetComponent<Notation>().addingNotation(chessManager.square + "x" + chessManager.tilesParent.GetChild(childIndex - 8).name);
        }
        else if (Move == "enPassDL")
        {
            Destroy(chessManager.tilesParent.GetChild(childIndex + 8).GetChild(1).gameObject);
            this.GetComponent<Notation>().addingNotation(chessManager.square + "x" + chessManager.tilesParent.GetChild(childIndex + 8).name);
        }
        else if (Move == "enPassDR")
        {
            Destroy(chessManager.tilesParent.GetChild(childIndex + 8).GetChild(1).gameObject);
            this.GetComponent<Notation>().addingNotation(chessManager.square + "x" + chessManager.tilesParent.GetChild(childIndex + 8).name);
        }
        else if (Move == "whiteKing")
        {
            chessManager.tilesParent.GetChild(childIndex + 1).GetChild(1).parent = chessManager.tilesParent.GetChild(childIndex - 1).transform;
            chessManager.tilesParent.GetChild(childIndex - 1).GetChild(1).localPosition = new Vector3(0, 0, 0);
            this.GetComponent<Notation>().addingNotation("0-0");
        }
        else if (Move == "whiteQueen")
        {
            chessManager.tilesParent.GetChild(childIndex - 2).GetChild(1).parent = chessManager.tilesParent.GetChild(childIndex + 1).transform;
            chessManager.tilesParent.GetChild(childIndex + 1).GetChild(1).localPosition = new Vector3(0, 0, 0);
            this.GetComponent<Notation>().addingNotation("0-0-0");
        }
        else if (Move == "blackKing")
        {
            chessManager.tilesParent.GetChild(childIndex + 1).GetChild(1).parent = chessManager.tilesParent.GetChild(childIndex - 1).transform;
            chessManager.tilesParent.GetChild(childIndex - 1).GetChild(1).localPosition = new Vector3(0, 0, 0);
            this.GetComponent<Notation>().addingNotation("0-0");
        }
        else if (Move == "blackQueen")
        {
            chessManager.tilesParent.GetChild(childIndex - 2).GetChild(1).parent = chessManager.tilesParent.GetChild(childIndex + 1).transform;
            chessManager.tilesParent.GetChild(childIndex + 1).GetChild(1).localPosition = new Vector3(0, 0, 0);
            this.GetComponent<Notation>().addingNotation("0-0-0");
        }
        else if (Move == "twoSteps")
        {
            this.transform.GetChild(1).GetComponent<Pawn>().twoSteps = true;            
            notation.notation(this.transform.GetChild(1).name, "");
        }

        if (this.transform.childCount > 2 && Move == "")
        {     
            if (this.transform.GetChild(2).name.Contains("Pawn"))
            {
                notation.notation(this.transform.GetChild(1).name, "x");
            }
            else if (this.transform.GetChild(2).name.Contains("Rook"))
            {
                notation.notation(this.transform.GetChild(1).name, "xR");
            }
            else if (this.transform.GetChild(2).name.Contains("Knight"))
            {
                notation.notation(this.transform.GetChild(1).name, "xN");
            }
            else if (this.transform.GetChild(2).name.Contains("Bishop"))
            {
                notation.notation(this.transform.GetChild(1).name, "xB");
            }
            else if (this.transform.GetChild(2).name.Contains("Queen"))
            {
                notation.notation(this.transform.GetChild(1).name, "xQ");
            }

            Destroy(this.transform.GetChild(2).gameObject);
        }
        else if (this.transform.childCount < 3 && Move == "")
        {
            notation.notation(this.transform.GetChild(1).name, "");        
        }

        Move = "";
        chessManager.square = "";
        stalemate();
        reset();
        showMoves();
        StartCoroutine(checking());
    }

    public void reset()
    {
        foreach (Transform child in this.transform.parent)
        {
            if (child.childCount > 1)
            {
                child.GetChild(1).GetComponent<Piece>().moving = false;
                child.GetChild(1).GetComponent<Piece>().canBeEaten = false;
                child.GetChild(1).GetComponent<Piece>().availableMoves.Clear();
            }
        }

        showMoves();

    }

    public void showMoves()
    {
        foreach (Transform child in this.transform.parent)
        {
            if (child.childCount > 1)
            {
                child.GetChild(1).GetComponent<Piece>().showMoves();
 
            }
        }
    }

    public IEnumerator checking()
    {    
        yield return new WaitForSeconds(.1f);
        moveChecking();
       
    }

    public void moveChecking()
    {
        foreach (Transform child in this.transform.parent)
        {
            if (child.childCount > 1)
            {
                child.GetChild(1).GetComponent<Checking>().canBeEaten();
            }
        }

        foreach (Transform child in this.transform.parent)
        {
            if (child.childCount > 1)
            {
                child.GetChild(1).GetComponent<Checking>().checking();

            }
        }
    }

    public void stalemate()
    {
        foreach (Transform child in this.transform.parent)
        {
            if (child.childCount > 1)
            {
                if (child.GetChild(1).name.Contains("King"))
                {
                    child.GetChild(1).GetComponent<Stalemate>().stalemate();
                }
            }
        }
    }

    public void moveOtherBoard(string parentNotation)
    {
        movePiece(parentNotation);
    }

    void movePiece(string parentNotation)
    {
        string[] pn = parentNotation.Split('|');
        string newParent = pn[0];
        string notation = pn[1];
     
        Transform newTile = GameObject.Find(newParent).transform;
        this.transform.GetChild(1).parent = newTile;

        newTile.GetComponent<TileClick>().Move = notation;
        newTile.GetComponent<TileClick>().eatPiece();

        /*if (newTile.transform.childCount > 2)
        {
            newTile.transform.GetChild(2).SetSiblingIndex(1);
            Destroy(newTile.transform.GetChild(2).gameObject);
        }
        newTile.GetChild(1).localPosition = new Vector3(0, 0, 0);

        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        Transform Notation = GameObject.Find("Chess Canvas").transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0);

        if (!notation.Contains("true"))
        {
            notation.Replace("-true","");
            if (newTile.GetChild(1).tag == "White")
            {
                chessManager.Player = "Black";
                chessManager.whiteMoves.Add(notation);
                this.GetComponent<Notation>().showNotation(notation, Notation.GetChild(0));
            }
            
            else if (newTile.GetChild(1).tag == "Black")
            {
                chessManager.Player = "White";
                chessManager.blackMoves.Add(notation);
                this.GetComponent<Notation>().showNotation(notation, Notation.GetChild(1));
            }

        }

        stalemate();
        reset();
        showMoves();
        StartCoroutine(checking());*/
    }

    public void piecePromotion(string parameter)
    {
        Destroy(this.transform.GetChild(1).gameObject);

        string[] para = parameter.Split('-');
        string piece = para[0];
        string notation = para[1];

        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        Transform Notation = GameObject.Find("Chess Canvas").transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0);

        var Piece = Resources.Load(piece) as GameObject;
        var PieceDetails = Instantiate(Piece, this.transform);

        if (chessManager.Me == "White")
        {
            pieceDetails(PieceDetails.gameObject, 180, chessManager.blackShade, "Black");
            chessManager.Player = "White";
            chessManager.whiteMoves[chessManager.whiteMoves.Count - 1] = notation;
            Notation.GetChild(0).GetChild(Notation.GetChild(0).childCount - 1).GetComponent<Text>().text = notation;
        }

        else
        {
            pieceDetails(PieceDetails.gameObject, 0, chessManager.whiteShade, "White");
            chessManager.Player = "Black";
            chessManager.blackMoves[chessManager.blackMoves.Count - 1] = notation;
            Notation.GetChild(1).GetChild(Notation.GetChild(0).childCount - 1).GetComponent<Text>().text = notation;
        }

        chessManager.promotion = false;

        stalemate();
        reset();
        showMoves();
        StartCoroutine(checking());
    }

    void pieceDetails(GameObject piece, int rotation, Material material, string tag)
    {
        piece.GetComponent<RectTransform>().localScale = new Vector3(1576.05f, 13572, 1576.05f);
        piece.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        piece.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, rotation, 0));

        piece.GetComponent<Renderer>().material = material;
        piece.gameObject.tag = tag;
    }
}
