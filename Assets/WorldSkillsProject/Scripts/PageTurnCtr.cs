using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageTurnCtr : MonoBehaviour {

    public GameObject PageTurnObject;

    Transform ListParent;

    public int ListShowMaxNum = 3;

    public bool IsAutoClickFirstElement = false;

    Transform ListPageViewCtr;

    Text PageNumText;

    Button PrePageBtn;

    Button NextPageBtn;

    IPageTurnObject _IPageTurnObject;

    int CurPageIndex = 1;

    int TotalPage = 1;

    int TotalElment;

    private void Awake()
    {
        _IPageTurnObject = PageTurnObject.GetComponent<IPageTurnObject>();
        ListParent = PageTurnObject.transform.Find("ListParent");
    }

    public void OnInitData()
    {
        ListPageViewCtr = transform.Find("View");

        PageNumText = ListPageViewCtr.Find("PageNumText").GetComponent<Text>();
        PrePageBtn = ListPageViewCtr.Find("PrePage").GetComponent<Button>();
        NextPageBtn = ListPageViewCtr.Find("NextPage").GetComponent<Button>();

        PrePageBtn.onClick.AddListener(OnPrePage);
        NextPageBtn.onClick.AddListener(OnNextPage);

        Debug.Log(PageTurnObject.name + "****** " + _IPageTurnObject.IdList.Count);
       
        CurPageIndex = 1;

        TotalElment = _IPageTurnObject.IdList.Count;

        bool IsShowListPate = TotalElment > ListShowMaxNum ? true : false;

        ListPageViewCtr.gameObject.SetActive(IsShowListPate);

        TotalPage = Mathf.CeilToInt((float)TotalElment / ListShowMaxNum);

        OnPageTurnCtr(CurPageIndex);
    }

    public void OnFreshPageIndexData(string Info) {

        PageNumText.text = Info;
    }

    void OnPrePage()
    {
        CurPageIndex--;
        if (CurPageIndex >= 1)
        {
            OnPageTurnCtr(CurPageIndex);
        }
        else
        {
            CurPageIndex = 1;
        }
    }

    void OnNextPage()
    {
        CurPageIndex++;
        if (CurPageIndex <= TotalPage)
        {
            OnPageTurnCtr(CurPageIndex);
        }
        else
        {
            CurPageIndex = TotalPage;
        }
    }

    void OnPageTurnCtr(int _CurPageIndex)
    {
        int CurPageShowElmentNum = ListShowMaxNum;

        int DataStartIndex = 0;

        int DataEndIndex = 0;

        DataStartIndex = (_CurPageIndex - 1) * ListShowMaxNum;

        if (_CurPageIndex < TotalPage)
        {
            DataEndIndex = _CurPageIndex * ListShowMaxNum - 1;
            CurPageShowElmentNum = ListShowMaxNum;
        }
        else
        {
            DataEndIndex = TotalElment - 1;
            CurPageShowElmentNum = TotalElment - (_CurPageIndex - 1) * ListShowMaxNum;
        }

        foreach (Transform item in ListParent)
        {
            item.gameObject.SetActive(false);
        }
     
        List<string> IdList = new List<string>();
        List<int> IdIndex = new List<int>();

        Debug.Log(DataStartIndex + "-------" + DataEndIndex);

        for (int i = DataStartIndex; i <= DataEndIndex; i++)
        {
            IdList.Add(_IPageTurnObject.IdList[i]);
            IdIndex.Add(i);
        }

        for (int i = 0; i < CurPageShowElmentNum; i++)
        {
            ListParent.GetChild(i).gameObject.SetActive(true);
            ListParent.GetChild(i).GetComponent<IPageTurnItem>().SetItemProperty(IdList[i],IdIndex[i]);
        }

        if (ListPageViewCtr.gameObject.activeSelf)
        {
            string PageInfo = CurPageIndex + " / " + TotalPage;
            OnFreshPageIndexData(PageInfo);
        }

        if (IsAutoClickFirstElement)
        {
            ListParent.GetChild(0).GetComponent<IPageTurnItem>().OnEvent();
        } 
    }

}

public interface IPageTurnItem {

    void SetItemProperty(string ItemId,int ItemIndex);
    void OnEvent();
}

public interface IPageTurnObject {

    List<string> IdList { get; set; }
    void OnReFreshList();
}