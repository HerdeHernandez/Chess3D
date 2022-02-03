using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class selectPromotion : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color32(255, 171, 35, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var chessManager = GameObject.Find("GameController").GetComponent<ChessGameController>();

        if (chessManager.Me == "White")
        {
            this.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
        else
        {
            this.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
