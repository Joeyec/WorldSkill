using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnSelectShowHighImage : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

    public Image ChangeImg;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeImg.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ChangeImg.color = Color.clear;
    }

    private void OnEnable()
    {
        ChangeImg.color = Color.clear;
    }

    void Start()
    {
        ChangeImg.color = Color.clear;
    }

}
