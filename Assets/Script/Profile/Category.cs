using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Category : MonoBehaviour
{
    public Transform buttonsParent;

    int time;
    string type;

    public void showCategory()
    {
        this.gameObject.SetActive(true);

        foreach (Transform child in buttonsParent)
        {
            foreach (Transform children in child)
            {
                if (children.childCount > 0 && children.GetComponent<selectCategory>().selected == true)
                {
                    children.GetComponent<Image>().color = new Color32(210, 127, 35, 0);
                    children.GetComponent<selectCategory>().selected = false;
                    children.GetChild(0).GetComponent<Text>().color = new Color32(58, 23, 12, 255);
                }
            }
        }

        buttonsParent.GetChild(0).GetChild(1).GetComponent<selectCategory>().selected = true;
        buttonsParent.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color32(210, 127, 35, 255);
        buttonsParent.GetChild(0).GetChild(1).transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 255, 255, 255);
    }

    public void hideCategory()
    {
        this.gameObject.SetActive(false);
    }    

    public void startGategory()
    {     
        foreach (Transform child in buttonsParent)
        {
            foreach (Transform children in child)
            {
                if (children.childCount > 0 && children.GetComponent<selectCategory>().selected == true)
                {
                    time = int.Parse(children.GetChild(0).GetComponent<Text>().text.Replace("min", ""));
                    type = child.name + " " + children.GetChild(0).GetComponent<Text>().text;
                    type = type.Replace("\n", " ");
                    type = type.Replace("min", "Minute(s)");

                    print(type);
                }
            }
        }

        this.transform.parent.GetChild(4).gameObject.SetActive(true);
        
        StartCoroutine(matching());
    }

    IEnumerator matching()
    {
        yield return new WaitForSeconds(.5f);
        this.transform.parent.GetChild(3).gameObject.SetActive(true);
        this.transform.parent.GetChild(3).GetComponent<CanvasGroup>().alpha = 1;
        this.transform.parent.GetChild(3).GetComponent<Matching>().type.text = type;
        this.transform.parent.GetChild(3).GetComponent<Matching>().minutes = time;
        this.transform.parent.GetChild(3).GetComponent<Matching>().gameType = type;

        yield return new WaitForSeconds(.6f);
        this.transform.parent.GetChild(4).gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
