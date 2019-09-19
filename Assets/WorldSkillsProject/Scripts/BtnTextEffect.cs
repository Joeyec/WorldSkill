using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnTextEffect : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler{

    public Text ChangeText;

    public Color ChangeColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeText.color = ChangeColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ChangeText.color = Color.white;
    }

    private void OnEnable()
    {
        ChangeText.color = Color.white;
    }
}
