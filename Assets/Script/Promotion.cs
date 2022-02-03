using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Promotion : MonoBehaviour
{
    public Transform chessBoard;

    public Material whiteShade, blackShade;

    public List<Sprite> white = new List<Sprite>();
    public List<Sprite> black = new List<Sprite>();

    public Image Queen, Rook, Bishop, Knight;
    public Text QueenText, RookText, BishopText, KnightText;

    public string notation, childName;

    [DllImport("__Internal")]
    private static extern void promotion(string PiecenNotation, string square);

    private void Start()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        whiteShade = chessManager.whiteShade;
        blackShade = chessManager.blackShade;       

        setColor(chessManager);
    }

    void setColor(ChessGameController chessManager)
    {
        if (chessManager.Me == "White")
        {
            Queen.sprite = white[0];
            Rook.sprite = white[1];
            Bishop.sprite = white[2];
            Knight.sprite = white[3];

            QueenText.color = Color.white;
            RookText.color = Color.white;
            BishopText.color = Color.white;
            KnightText.color = Color.white;

            QueenText.transform.parent.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            RookText.transform.parent.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            BishopText.transform.parent.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            KnightText.transform.parent.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
        else
        {
            Queen.sprite = black[0];
            Rook.sprite = black[1];
            Bishop.sprite = black[2];
            Knight.sprite = black[3];

            QueenText.color = Color.black;
            RookText.color = Color.black;
            BishopText.color = Color.black;
            KnightText.color = Color.black;

            QueenText.transform.parent.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            RookText.transform.parent.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            BishopText.transform.parent.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            KnightText.transform.parent.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void queen()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        foreach (Transform child in chessBoard)
        {
            if (child.childCount > 1)
            {
                if (child.GetChild(1).name.Contains("Pawn"))
                {
                    if (child.GetChild(1).GetComponent<Pawn>().promotion == true)
                    {
                        var Piece = Resources.Load("Queen") as GameObject;
                        var PieceDetails = Instantiate(Piece, child);

                        if (chessManager.Me == "White")
                        {
                            pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
                        }
                        else
                        {
                            pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
                        }

                        editNotation("Queen", "=Q", child.name);

                        Destroy(child.GetChild(1).gameObject);
                        
                        StartCoroutine(checking(PieceDetails.transform));
                        
                        break;
                    }
                }
            }
        }
    }

    public void bishop()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        foreach (Transform child in chessBoard)
        {
            if (child.childCount > 1)
            {
                if (child.GetChild(1).name.Contains("Pawn"))
                {
                    if (child.GetChild(1).GetComponent<Pawn>().promotion == true)
                    {
                        var Piece = Resources.Load("Bishop") as GameObject;
                        var PieceDetails = Instantiate(Piece, child);

                        if (chessManager.Me == "White")
                        {
                            pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
                        }
                        else
                        {
                            pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
                        }
                        editNotation("Bishop", "=B", child.name);

                        Destroy(child.GetChild(1).gameObject);

                        StartCoroutine(checking(PieceDetails.transform));
                        break;
                    }
                }
            }
        }
    }

    public void rook()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        foreach (Transform child in chessBoard)
        {
            if (child.childCount > 1)
            {
                if (child.GetChild(1).name.Contains("Pawn"))
                {
                    if (child.GetChild(1).GetComponent<Pawn>().promotion == true)
                    {
                        var Piece = Resources.Load("Rook") as GameObject;
                        var PieceDetails = Instantiate(Piece, child);

                        if (chessManager.Me == "White")
                        {
                            pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
                        }
                        else
                        {
                            pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
                        }

                        editNotation("Rook", "=R", child.name);

                        Destroy(child.GetChild(1).gameObject);

                        StartCoroutine(checking(PieceDetails.transform));
                        break;
                    }
                }
            }
        }        
    }

    public void knight()
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        foreach (Transform child in chessBoard)
        {
            if (child.childCount > 1)
            {
                if (child.GetChild(1).name.Contains("Pawn"))
                {
                    if (child.GetChild(1).GetComponent<Pawn>().promotion == true)
                    {
                        var Piece = Resources.Load("Knight") as GameObject;
                        var PieceDetails = Instantiate(Piece, child);

                        if (chessManager.Me == "White")
                        {
                            pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
                        }
                        else
                        {
                            pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
                        }

                        editNotation("Knight", "=N", child.name);

                        Destroy(child.GetChild(1).gameObject);

                        StartCoroutine(checking(PieceDetails.transform));
                        break;
                    }
                }
            }
        }
    }

    IEnumerator checking(Transform PieceDetails)
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        yield return new WaitForSeconds(.01f);
        PieceDetails.transform.parent.GetComponent<TileClick>().checking();

        if (chessManager.Me == "White")
        {
            chessManager.Player = "Black";
        }
        else
        {
            chessManager.Player = "White";
        }
        chessManager.promotion = false;
        this.gameObject.SetActive(false);
    }

    void pieceDetails(GameObject piece, int rotation, Material material, string tag)
    {
        piece.GetComponent<RectTransform>().localScale = new Vector3(1576.05f, 13572, 1576.05f);
        piece.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        piece.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, rotation, 0));

        piece.GetComponent<Renderer>().material = material;
        piece.gameObject.tag = tag;       
    }

    void editNotation(string piece, string newNotation, string squareName)
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();
        Transform Notation = GameObject.Find("Chess Canvas").transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0);

#if UNITY_WEBGL && !UNITY_EDITOR
        promotion(piece + "-"+ notation + newNotation, squareName);
#endif

        if (chessManager.onMoved == false)
        {
            if (chessManager.Me == "White")
            {
                chessManager.whiteMoves[chessManager.whiteMoves.Count - 1] = notation + newNotation ;
                Notation.GetChild(0).GetChild(Notation.GetChild(0).childCount - 1).GetComponent<Text>().text = notation + newNotation;
            }
            else if (chessManager.Me == "Black")
            {
                chessManager.blackMoves[chessManager.blackMoves.Count - 1] = notation + newNotation;
                Notation.GetChild(1).GetChild(Notation.GetChild(0).childCount - 1).GetComponent<Text>().text = notation + newNotation;
            }
        }
    }
}
