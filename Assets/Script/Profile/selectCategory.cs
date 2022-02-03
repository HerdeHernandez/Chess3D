using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class selectCategory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool selected = false;

    [DllImport("__Internal")]
    private static extern void GetPlayerInfo();

    public void select()
    {
        foreach (Transform child in this.transform.parent.parent)
        {
            foreach (Transform children in child)
            {
                if (children.childCount > 0)
                {
                    children.GetComponent<Image>().color = new Color32(210, 127, 35, 0);
                    children.GetComponent<selectCategory>().selected = false;
                    children.GetChild(0).GetComponent<Text>().color = new Color32(58, 23, 12, 255);
                }
            }
        }

        this.GetComponent<selectCategory>().selected = true;
        this.GetComponent<Image>().color = new Color32(210, 127, 35, 255);
        this.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 255, 255, 255);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selected == false)
        {
            this.GetComponent<Image>().color = new Color32(210, 127, 35, 180);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selected == false)
        {
            this.GetComponent<Image>().color = new Color32(210, 127, 35, 0);
        }
    }
}
