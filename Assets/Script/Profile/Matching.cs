using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Matching : MonoBehaviour
{
    public Image profile;
    public Text Name, rating, win, draw, loses;

    public Transform playerList;

    public Text type;

    public int minutes;
    public string gameType;

    private void Start()
    {
        ProfileManager profileManager = GameObject.Find("MainProfile").GetComponent<ProfileManager>();

        profile.sprite = profileManager.profile.sprite;
        Name.text = profileManager.playerName.text;
    }

    public void hideMatching()
    {
        this.transform.parent.GetChild(4).gameObject.SetActive(true);
        StartCoroutine(back());
    }

    IEnumerator back()
    {
        yield return new WaitForSeconds(.5f);
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;        

        yield return new WaitForSeconds(.6f);
        this.transform.parent.GetChild(4).gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void setPlayerImage(string image)
    {
        byte[] imageBytes = Convert.FromBase64String(image);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageBytes);
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        profile.sprite = sprite;
    }

    public void reply(string data)
    {
        string[] datas = data.Split('|');
        string response = datas[0];
        string name = datas[1];
        string email = datas[2];  

        ProfileManager main = GameObject.Find("MainProfile").GetComponent<ProfileManager>();
        ChessGameController chess = GameObject.Find("GameController").GetComponent<ChessGameController>();

        main.replyPanel.SetActive(true);

        foreach (Transform child in playerList)
        {
            if (child.GetComponent<playersData>().email == email)
            {
                child.GetChild(3).GetChild(1).gameObject.SetActive(true);
            }
        }

        if (response == "true")
        {
            main.replyPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = name +" accepted your invitation";
            main.load();

            chess.EnemyEmail = email;
        }
        else
        {
            main.replyPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = name + " declined your invitation";
            main.replyPanel.SetActive(true);
            StartCoroutine(loading(main.replyPanel));
        }

        
    }
    public IEnumerator loading(GameObject replyPanel)
    {
        yield return new WaitForSeconds(1f);
        replyPanel.SetActive(false);
    }
}
