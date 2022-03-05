using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class invite : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void inviPlayer(string email, string type);

    //invite player
    public void invitePlayer()
    {
        string email = this.transform.parent.parent.GetComponent<playersData>().email;
        Matching matching = GameObject.Find("Matching").GetComponent<Matching>();

#if UNITY_WEBGL && !UNITY_EDITOR
        inviPlayer(email, matching.gameType);
#endif
        this.gameObject.SetActive(false);
    }
}
