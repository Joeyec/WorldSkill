using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubCriteriaItemCtr : MonoBehaviour , IPageTurnItem
{
    public Text Index;
    public Text Content;
    public Toggle SubBtn;

    SubCriteriaViewModel SubCriteriaViewModel;

    public void SetItemProperty(string ItemId, int ItemIndex)
    {
        OnViewShow(ItemId, ItemIndex);
    }

    public void OnViewShow(string Id, int ItemIndex)
    {
        if (Id == null)
        {
            MainUICtr.Instance?.OnMessageBox("_SubCriteriaViewModel data error");
            return;
        }

        if (Index == null)
        {
            Index = transform.Find("Index").GetComponent<Text>();
        }

        if (Content == null)
        {
            Content = transform.Find("Content").GetComponent<Text>();
        }

        Index.text = (ItemIndex + 1).ToString();

        SubCriteriaViewModel = DataManager.Instance.DicSubCriteria[Id];

        Content.text = SubCriteriaViewModel.Description;

        SubBtn.onValueChanged.AddListener((isOn) => {

            if (isOn)
            {
                OnEvent();
            }
        });
    }

    public void OnEvent() {

        DataManager.Instance.OnSetCurSubCriteriaModel(SubCriteriaViewModel);
        AspectViewCtr.Instance.AspectListView.SetActive(true);
        AspectViewCtr.Instance.IAspectList.OnReFreshList();
        AspectViewCtr.Instance.AspectContenView.SetActive(false);
    }
}

