using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class selectPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool selected = false;

    [DllImport("__Internal")]
    private static extern void GetImage(string email);

    //player selection
    public void select()
    {
        foreach (Transform children in this.transform.parent)
        {
            children.GetComponent<Image>().color = new Color32(174, 171, 163, 255);
            children.GetComponent<selectPlayer>().selected = false;
            children.GetChild(0).GetComponent<Text>().color = new Color32(58, 23, 12, 255);
            children.GetChild(1).GetComponent<Text>().color = new Color32(58, 23, 12, 255);
            children.GetChild(2).GetComponent<Text>().color = new Color32(58, 23, 12, 255);
        }

        this.GetComponent<selectPlayer>().selected = true;
        this.GetComponent<Image>().color = new Color32(210, 127, 35, 255);
        this.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 255, 255, 255); //name
        this.transform.GetChild(1).GetComponent<Text>().color = new Color32(255, 255, 255, 255); //rating
        this.transform.GetChild(2).GetComponent<Text>().color = new Color32(255, 255, 255, 255); //standing

        playerData(this.transform.GetChild(0).GetComponent<Text>().text,
                   this.transform.GetChild(1).GetComponent<Text>().text,
                   "","","");
    }

    //animtations
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selected == false)
        {
            this.GetComponent<Image>().color = new Color32(255, 175, 86, 255);
        }

    }

    //animtations
    public void OnPointerExit(PointerEventData eventData)
    {
        if (selected == false)
        {
            this.GetComponent<Image>().color = new Color32(174, 171, 163, 255);
        }
    }

    //invite player
    void playerData(string playersName, string rating, string win, string draw, string lose)
    {
        Matching matching = GameObject.Find("Matching").GetComponent<Matching>();

        matching.Name.text = playersName;
        matching.rating.text = rating + " Points";

#if UNITY_WEBGL && !UNITY_EDITOR
        GetImage(this.GetComponent<playersData>().email);
#endif
    }
}
