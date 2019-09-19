using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ReferenceDetailsBtn : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler{

    public Text ShowText;
    public Color HighColor;

    public UnityEvent onEnter;

    public UnityEvent OnEnter
    {
        get
        {
            if (onEnter == null)
            {
                onEnter = new UnityEvent();
            }
            return onEnter;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowText.color = HighColor;
        OnEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShowText.color = Color.white;
    }
    
}
