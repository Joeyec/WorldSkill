using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineListViewCtr : MonoBehaviour, IPageTurnObject
{
    public PageTurnCtr _PageTurnCtr;

    List<string> iDList = new List<string>();

    public List<string> IdList
    {
        get
        {
           
            return iDList;
        }

        set
        {
           
        }
    }

    public void OnReFreshList()
    {
        #region
        if (DataManager.Instance == null)
        {
            return;
        }

        if (DataManager.Instance.CurDataSelectState.CurCriteriaModel == null)
        {
            MainUICtr.Instance?.OnMessageBox("AppConfig.CurCriteriaModel.List data error");
            return;
        }

        if (DataManager.Instance.ListMachine == null)
        {
            MainUICtr.Instance?.OnMessageBox("DataManager.Instance.ListMachine data error");
            return;
        }
        iDList.Clear();
        foreach (var item in DataManager.Instance.CurDataSelectState.MachineList)
        {
            iDList.Add(item.Id);
        }

        Debug.Log(DataManager.Instance.CurDataSelectState.CriteriaId);
        Debug.Log(DataManager.Instance.CurDataSelectState.MachineNum);

        #endregion
        _PageTurnCtr.OnInitData();
    }
}
