using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {

        this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        this.transform.localScale = new Vector3(1f, 1f, 1f);

    }
}
