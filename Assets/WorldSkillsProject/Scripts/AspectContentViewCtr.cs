using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectContentViewCtr : MonoBehaviour {

    public GameObject AspectContenView;
    public Text Content;

    public GameObject MView;
    public GameObject JView;

    public GameObject AspectDescription;

    public GameObject ReferenceDetails;
    public Button _ReferenceDetailsBtn;

    public Text CurAspectIndex;

    AspectType curAspectType = AspectType.Judge;

    AspectDescriptionCtr _AspectDescriptionCtr;

    private void Start()
    {
        _ReferenceDetailsBtn.onClick.AddListener(() =>
        {
            ReferenceDetails.SetActive(true);
        });

        _AspectDescriptionCtr = AspectDescription.GetComponent<AspectDescriptionCtr>();
    }

    public void OnRefreshContent(int _Index) {
       
        if (DataManager.Instance == null)
        {
            return;
        }
        if (DataManager.Instance.CurDataSelectState.CurAspectModel == null)
        {
            MainUICtr.Instance?.OnMessageBox("DataManager.Instance.CurAspectModel data error");
            return;
        }

        AspectContenView.SetActive(true);
        MView.SetActive(false);
        JView.SetActive(false);
        ReferenceDetails.SetActive(false);
        AspectDescription.SetActive(false);

        Content.text = DataManager.Instance.CurDataSelectState.CurAspectModel.Description;

        curAspectType = DataManager.Instance.CurDataSelectState.CurAspectModel.Type;

        Debug.Log(curAspectType);

        switch (curAspectType)
        {
            case AspectType.NA:
                break;
            case AspectType.Measurement:
                MView.SetActive(true);
                break;
            case AspectType.Judge:
                JView.SetActive(true);
                break;
            default:
                break;
        }

        CurAspectIndex.text = (_Index + 1).ToString();
    }

    public void OnAnswerCall(int answer) {
        AspectDescription.SetActive(true);
        _AspectDescriptionCtr.OnShowView(DataManager.Instance.CurDataSelectState.CurAspectModel.RequirementModels,DataManager.Instance.CurDataSelectState.CurAspectModel.Sequence);
        AspectContenView.SetActive(false);
        DataManager.Instance.ListAspectComplete.Add(DataManager.Instance.CurDataSelectState.CurAspectModel.Id);

        //int[] RemaningNums = DataManager.Instance.CurDataSelectState.CurSelectAspectIndex

     //   AspectViewCtr.Instance._AspectTitleViewCtr.OnRefreshView();

    }

    public void OnReferenceDetailsBtnClose() {

        ReferenceDetails.SetActive(false);
    }

}
