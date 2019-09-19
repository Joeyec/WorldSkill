using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LogInBtn : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

    public Text ChangeText;

    public Color color;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeText.color = color;
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
