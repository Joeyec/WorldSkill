using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectItemCtr : MonoBehaviour, IPageTurnItem
{

    public Text ShowImageIndex;

    public int Index;

    public string Id {

        get {
            if (AspectViewModel == null)
            {
                return null;
            }
            return AspectViewModel.Id;
        }
    }

    AspectViewModel AspectViewModel;

    void Start() {

        GetComponent<Button>().onClick.AddListener(OnEvent);
    }

    public void SetItemProperty(string ItemId, int ItemIndex)
    {
        OnViewShow(ItemId, ItemIndex);
    }

    public void OnEvent()
    {
        DataManager.Instance.OnSetCurAspectModel(AspectViewModel);
        AspectViewCtr.Instance.AspectListView.SetActive(false);
        AspectViewCtr.Instance.AspectContenView.SetActive(true);
        DataManager.Instance.CurDataSelectState.CurSelectAspectIndex = Index;
        AspectViewCtr.Instance._AspectContentViewCtr.OnRefreshContent(Index);
    }

    public void OnViewShow(string ItemId,int _Index)
    {
        if (ItemId == null)
        {
            MainUICtr.Instance?.OnMessageBox("_AspectViewModel data error");
            return;
        }

        Index = _Index;

        ShowImageIndex.text = (_Index + 1).ToString();

        AspectViewModel = DataManager.Instance.DicAspect[ItemId];
    }
}
