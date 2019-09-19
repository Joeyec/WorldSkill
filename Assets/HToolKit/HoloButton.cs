using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoloButton : MonoBehaviour, IInputClickHandler, IFocusable
{
    UnityEvent unityActionClick;
    UnityEvent unityActionEnter;
    UnityEvent unityActionExit;

    public UnityEvent OnClick
    {
        get
        {
            if (unityActionClick == null)
            {
                unityActionClick = new UnityEvent();
            }
            return unityActionClick;
        }
    }

    public UnityEvent OnEnter
    {
        get
        {
            if (unityActionEnter == null)
            {
                unityActionEnter = new UnityEvent();
            }
            return unityActionEnter;
        }
    }

    public UnityEvent OnExit
    {
        get
        {
            if (unityActionExit == null)
            {
                unityActionExit = new UnityEvent();
            }
            return unityActionExit;
        }
    }


    public void OnFocusEnter()
    {
        unityActionEnter?.Invoke();
        
    }

    public void OnFocusExit()
    {
        unityActionExit?.Invoke();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        unityActionClick?.Invoke();
        eventData.Use();
    }
}
