using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineItemCtr : MonoBehaviour, IPageTurnItem
{

    public Text Content;

    MachineViewModel MachineViewModel;

    public void SetItemProperty(string ItemId, int ItemIndex)
    {
        OnViewShow(ItemId, ItemIndex);
    }

    public void OnViewShow(string Id, int ItemIndex) {

        if (Id == null)
        {
            MainUICtr.Instance?.OnMessageBox("_MachineViewModel data error");
            return;
        }

        if (Content == null)
        {
            Content = transform.Find("Content").GetComponent<Text>();
        }

        MachineViewModel = DataManager.Instance.DicMachine[Id];

        Content.text = MachineViewModel.Name;
   
    }

    void Start() {

        GetComponent<Button>().onClick.AddListener(OnEvent);
    }

    public void OnEvent()
    {
        DataManager.Instance.OnSetCurMachineModel(MachineViewModel);

        MainUICtr.Instance.AspectView.SetActive(true);

        AspectViewCtr.Instance.ISubCriteriaList.OnReFreshList();

        AspectViewCtr.Instance._AspectViewTitleContentCtr.TitleContent.text = MachineViewModel.Name;

        MainUICtr.Instance.MachineView.SetActive(false);
    }
}
