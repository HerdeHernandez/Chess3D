using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class ChessGameController : MonoBehaviour
{
    [HideInInspector]
    public Transform tilesParent;

    public Texture2D white, black;

    public Material whiteShade, blackShade;

    public string Player, Piece, move, square, Me;

    public bool onMoved = false;
    public bool gameStart = false;
    public bool promotion = false;

    public bool myBoard = false;
    public bool otherBoard = false;

    public string PlayerEmail = "";
    public string EnemyEmail = "";

    public List<string> White = new List<string>();

    public List<string> Black = new List<string>();

    public List<string> whiteMoves = new List<string>();

    public List<string> blackMoves = new List<string>();

    [DllImport("__Internal")]
    private static extern void UnityGetMyColor();

    [DllImport("__Internal")]
    private static extern void checkmate(string email, string color);

    [DllImport("__Internal")]
    private static extern void scoring(int score);


    private void Start()
    {
        Starting();
    }
    public void Starting()
    {
        startGame();
        Player = "White";
        myBoard = true;
#if UNITY_WEBGL && !UNITY_EDITOR
        UnityGetMyColor();
#endif
    }

    //checking for move repetition
    void Update()
    {
        if (myBoard ==  true && otherBoard == true)
        {
            gameStart = true;
        }

        if (Player == "White" && onMoved == false)
        {
            foreach (Transform child in tilesParent)
            {
                if (child.childCount > 1 && child.GetChild(1).tag == "Black")
                {
                    child.GetComponent<TileClick>().enabled = false;
                }
                else
                {
                    child.GetComponent<TileClick>().enabled = true;
                }
            }
        }
        else if (Player == "Black" && onMoved == false)
        {
            foreach (Transform child in tilesParent)
            {
                if (child.childCount > 1 && child.GetChild(1).tag == "White")
                {
                    child.GetComponent<TileClick>().enabled = false;
                }
                else
                {
                    child.GetComponent<TileClick>().enabled = true;
                }
            }
        }

        /* if (whiteMoves.Count > 4)
         {
             if (whiteMoves[whiteMoves.Count - 4] == whiteMoves[whiteMoves.Count - 4] && whiteMoves[whiteMoves.Count - 4] == whiteMoves[whiteMoves.Count - 2] && whiteMoves[whiteMoves.Count - 4] == whiteMoves[whiteMoves.Count - 1])
             {
                 StartCoroutine(Draw());
             }
         }

         if (blackMoves.Count > 4)
         {
             if (blackMoves[blackMoves.Count - 4] == blackMoves[blackMoves.Count - 4] && blackMoves[blackMoves.Count - 4] == blackMoves[blackMoves.Count - 2] && blackMoves[blackMoves.Count - 4] == blackMoves[blackMoves.Count - 1])
             {
                 StartCoroutine(Draw());
             }
         }*/

        if (whiteMoves.Count > 3 && blackMoves.Count > 3)
        {
            if (whiteMoves[whiteMoves.Count - 4] == whiteMoves[whiteMoves.Count - 2] &&
                whiteMoves[whiteMoves.Count - 3] == whiteMoves[whiteMoves.Count - 1] &&
                blackMoves[blackMoves.Count - 4] == blackMoves[blackMoves.Count - 2] &&
                blackMoves[blackMoves.Count - 3] == blackMoves[blackMoves.Count - 1])
            {
                StartCoroutine(Draw());
            }
        }
    }


    //WEB FUNCTION set my color
    public void MyColor(string data)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        otherBoard = true;
        PlayerData playerData  = JsonUtility.FromJson<PlayerData>(data);

        PlayerEmail = playerData.PlayerEmail;
        Me = playerData.PlayerColor;

        if (playerData.PlayerColor.ToLower() == "white")
        {
            tilesParent.parent.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }
        else
        {
            tilesParent.parent.rotation = Quaternion.Euler(new Vector3(0, 450, 0));
        }
#endif

    }


    //piece details
    void pieceDetails(GameObject piece, int rotation, Material material, string tag)
    {
        piece.GetComponent<RectTransform>().localScale = new Vector3(1576.05f, 13572, 1576.05f);
        piece.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        piece.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, rotation, 0));

        piece.GetComponent<Renderer>().material = material;
        piece.gameObject.tag = tag;
    }

    //game start spawn pieces
    public void startGame()
    {
        foreach (Transform child in tilesParent)
        {
            if (child.GetSiblingIndex() == 0 || child.GetSiblingIndex() == 7)
            {
                var Piece = Resources.Load("Rook") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
            }
            else if (child.GetSiblingIndex() == 1 || child.GetSiblingIndex() == 6)
            {
                var Piece = Resources.Load("Knight") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
            }
            else if (child.GetSiblingIndex() == 2 || child.GetSiblingIndex() == 5)
            {
                var Piece = Resources.Load("Bishop") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
            }
            else if (child.GetSiblingIndex() == 4)
            {
                var Piece = Resources.Load("King") as GameObject;
                var PieceDetails = Instantiate(Piece, child);
                PieceDetails.name = "KingWhite";
                pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
            }
            else if (child.GetSiblingIndex() == 3)
            {
                var Piece = Resources.Load("Queen") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
            }
            else if (child.GetSiblingIndex() == 8 || child.GetSiblingIndex() == 9 || child.GetSiblingIndex() == 10 || child.GetSiblingIndex() == 11 || child.GetSiblingIndex() == 12 
                || child.GetSiblingIndex() == 13 || child.GetSiblingIndex() == 14 || child.GetSiblingIndex() == 15)
            {
                var Piece = Resources.Load("Pawn") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 0, whiteShade, "White");
            }
            else if (child.GetSiblingIndex() == 56 || child.GetSiblingIndex() == 63)
            {
                var Piece = Resources.Load("Rook") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
            }
            else if (child.GetSiblingIndex() == 57 || child.GetSiblingIndex() == 62)
            {
                var Piece = Resources.Load("Knight") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
            }
            else if (child.GetSiblingIndex() == 58 || child.GetSiblingIndex() == 61)
            {
                var Piece = Resources.Load("Bishop") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
            }
            else if (child.GetSiblingIndex() == 60)
            {
                var Piece = Resources.Load("King") as GameObject;
                var PieceDetails = Instantiate(Piece, child);
                PieceDetails.name = "KingBlack";
                pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
            }
            else if (child.GetSiblingIndex() == 59)
            {
                var Piece = Resources.Load("Queen") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
            }
            else if (child.GetSiblingIndex() == 55 || child.GetSiblingIndex() == 54 || child.GetSiblingIndex() == 53 || child.GetSiblingIndex() == 52 || child.GetSiblingIndex() == 51
                || child.GetSiblingIndex() == 50 || child.GetSiblingIndex() == 49 || child.GetSiblingIndex() == 48)
            {
                var Piece = Resources.Load("Pawn") as GameObject;
                var PieceDetails = Instantiate(Piece, child);

                pieceDetails(PieceDetails.gameObject, 180, blackShade, "Black");
            }
        }

#if UNITY_WEBGL && !UNITY_EDITOR
        GameObject chessBoard = GameObject.Find("ChessBoard");
        chessBoard.transform.GetChild(0).gameObject.SetActive(false);
#endif
    }

    //reset everything on the game
    public void Reset()
    {
        White.Clear();
        Black.Clear();
        whiteMoves.Clear();
        blackMoves.Clear();

        Player = "";  Piece = ""; move = ""; square = ""; Me = ""; ;        

        onMoved = false;
        gameStart = false;
        promotion = false;

        myBoard = false;
        otherBoard = false;

        PlayerEmail = "";
        EnemyEmail = "";

        foreach (Transform child in tilesParent)
        {
            if (child.childCount > 1)
            {
                Destroy(child.GetChild(1).gameObject);
            }
        }

        Starting();
    }

    public void webCheckMate(string checkmateColor)
    {
        StartCoroutine(checkMate(checkmateColor));
    }

    //checkmate
    public IEnumerator checkMate(string checkmateColor)
    {
        yield return new WaitForSeconds(.05f);
        Transform endPanel = GameObject.Find("Chess Canvas").transform.GetChild(3);        
        endPanel.gameObject.SetActive(true);

        if (Me == checkmateColor)
        {
            endPanel.GetComponent<EndGame>().Standing.text = "You Lose (Checkmate)";
        }
        else
        {
            endPanel.GetComponent<EndGame>().Standing.text = "You Win (Checkmate)";
        }
#if UNITY_WEBGL && !UNITY_EDITOR
        checkmate(EnemyEmail, checkmateColor);
#endif

        //email ng kalaban
        //kulay ng nanalo
    }

    //draw by stalemate
    public IEnumerator stalemate()
    {
        yield return new WaitForSeconds(.05f);
        Transform endPanel = GameObject.Find("Chess Canvas").transform.GetChild(3);
        endPanel.gameObject.SetActive(true);

        endPanel.GetComponent<EndGame>().Standing.text = "Draw (Stalemate)";
    }

    //draw by move repetition
    public IEnumerator Draw()
    {
        yield return new WaitForSeconds(.05f);
        Transform endPanel = GameObject.Find("Chess Canvas").transform.GetChild(3);
        endPanel.gameObject.SetActive(true);

        endPanel.GetComponent<EndGame>().Standing.text = "Draw (Move Repetition)";
    }


    //timeout
    public IEnumerator timeOut(string player)
    {
        yield return new WaitForSeconds(.05f);
       /* Transform endPanel = GameObject.Find("Chess Canvas").transform.GetChild(3);
        endPanel.gameObject.SetActive(true);

        if (Me == player)
        {
            endPanel.GetComponent<EndGame>().Standing.text = "You Lose (TimeOut)";
        }
        else
        {
            endPanel.GetComponent<EndGame>().Standing.text = "You Win (TimeOut)";
        }*/
    }

    //resign
    public IEnumerator resign(string email)
    {
        yield return new WaitForSeconds(.05f);
        Transform endPanel = GameObject.Find("Chess Canvas").transform.GetChild(3);
        endPanel.gameObject.SetActive(true);

        if (PlayerEmail == email)
        {
            endPanel.GetComponent<EndGame>().Standing.text = "You Win (Resign)";
        }
        else
        {
            endPanel.GetComponent<EndGame>().Standing.text = "You Lose (Resign)";
        }
    }

    void sendScore(int score)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        scoring(score);
#endif
    }
}

[System.Serializable]
public class PlayerData {

    public string PlayerColor;
    public string PlayerEmail;

}