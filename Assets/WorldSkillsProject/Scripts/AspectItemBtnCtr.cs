using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AspectItemBtnCtr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public Image HighImg;
    public Image OverImg;
    public Text IndexNum;
    public bool IsComplete = false;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        HighImg.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HighImg.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HighImg.gameObject.SetActive(false);
    }

    public void OnIsOver(bool _IsComplete) {
        IsComplete = _IsComplete;
        OverImg.gameObject.SetActive(_IsComplete);
        if (IsComplete)
        {
            IndexNum.color = Color.green;
        }
        else {
            IndexNum.color = Color.white;
        }
    }

    public void OnInitProperty() {
        HighImg.gameObject.SetActive(false);
        IsComplete = false;
        OnIsOver(IsComplete);
    }
}
