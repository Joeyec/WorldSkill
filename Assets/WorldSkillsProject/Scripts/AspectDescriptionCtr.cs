using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectDescriptionCtr : MonoBehaviour {

    public Text AnswerText;
    public Text Content;

    public List<AspectScoreRequiremnt> aspectScoreRequiremnts;

    public void OnClearInfo() {
        Content.text = "";
    }

    public void OnShowView(List<AspectScoreRequiremnt> _AspectScoreRequiremnts,int _Answer)
    {
        OnClearInfo();

        aspectScoreRequiremnts = _AspectScoreRequiremnts;

        if (DataManager.Instance.CurDataSelectState.CurAspectModel.RequirementModels.Count == 1)
        {
            string Info = DataManager.Instance.CurDataSelectState.CurAspectModel.RequirementModels[0].Description;
            Content.text += Info ;
            AnswerText.text = "Correct Answer : " + Convert.ToBoolean(_Answer);
        }
        else
        {
            AnswerText.text = "Correct Answer : " + _Answer;
            int Index = 0;
            foreach (AspectScoreRequiremnt item in aspectScoreRequiremnts)
            {
                string Info = item.Description;
                if (Index != DataManager.Instance.CurDataSelectState.CurAspectModel.RequirementModels.Count - 1)
                {
                    Content.text += Index.ToString() + ":" + Info + "\n";
                }
                else
                {
                    Content.text += Index.ToString() + ":" + Info;
                }
                Index++;
            }
        }
    }

    public void OnCloseAspectDes()
    {
        AspectViewCtr.Instance.AspectDescriptionView.SetActive(false);

        int index = DataManager.Instance.CurDataSelectState.GetNextAspectIndex();
        Debug.Log("CurAspectIndex --------------- " + index);
        if (index == -1)
        {
            AspectViewCtr.Instance.AspectListView.SetActive(true);
            AspectViewCtr.Instance.IAspectList.OnReFreshList();
            AspectViewCtr.Instance.AspectContenView.SetActive(false);
        }
        else {
            DataManager.Instance.CurDataSelectState.CurAspectModel = DataManager.Instance.ListAspect._AspectList[index];
            AspectViewCtr.Instance.AspectContenView.SetActive(true);
            AspectViewCtr.Instance._AspectContentViewCtr.OnRefreshContent(index);
            AspectViewCtr.Instance._AspectContentViewCtr.CurAspectIndex.text = (index + 1).ToString();
        }
    }

}
