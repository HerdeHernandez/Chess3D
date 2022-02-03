using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class inivtationManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Reply(string reply, string email);

    public Text playerName, gameType, win, draw, lose;

    string type, pName, image, email;

    public Image profile;
    
    public void setInviterData(string InviterData)
    {
        string[] data = InviterData.Split('|');
        type = data[0];
        pName = data[1];
        image = data[2];
        email = data[3];

        byte[] imageBytes = Convert.FromBase64String(image);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageBytes);
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        // Set Data
        gameType.text = type;
        playerName.text = pName;
        profile.sprite = sprite;
    }

    public void accept()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Reply("true", email);
#endif
        ProfileManager main = GameObject.Find("MainProfile").GetComponent<ProfileManager>();

        main.replyPanel.SetActive(true);
        main.replyPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Arranging Chess Pieces ...";

        main.load();
        this.gameObject.SetActive(false);
    }

    public void decline()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
         Reply("false", email);
#endif

        this.gameObject.SetActive(false);
    }

}
