using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MachineListTitleBtn : MonoBehaviour,IPointerClickHandler {

    public Image NoSelect;
    public Image Select;

    public GameObject ListView;

    public bool IsAvtive = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnEvent();
    }

    public void OnEvent() {
        IsAvtive = ListView.activeSelf;
        if (IsAvtive)
        {
            NoSelect.enabled = true;
            Select.enabled = false;
            ListView.SetActive(false);
        }
        else
        {
            NoSelect.enabled = false;
            Select.enabled = true;
            ListView.SetActive(true);
            AspectViewCtr.Instance.IMachineTitleList.OnReFreshList();
        }
    }

    private void OnEnable()
    {
        IsAvtive = false;
        NoSelect.enabled = true;
        Select.enabled = false;
        ListView.SetActive(IsAvtive);
    }
}
