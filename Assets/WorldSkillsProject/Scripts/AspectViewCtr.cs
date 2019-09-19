using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectViewCtr : MonoSingletion<AspectViewCtr>
{
    public GameObject SubCriteriaListView;

    public IPageTurnObject ISubCriteriaList;

    public GameObject AspectListView;

    public IPageTurnObject IAspectList;

    public GameObject MachineTitleView;

    public IPageTurnObject IMachineTitleList;

    public ToggleGroup SubCriterToggleGroup;

    public AspectTitleViewCtr _AspectViewTitleContentCtr;

    public GameObject AspectContenView;

    public AspectContentViewCtr _AspectContentViewCtr;

    public GameObject AspectDescriptionView;

    public GameObject TitleContentView;

    public AspectTitleViewCtr _AspectTitleViewCtr;

    protected override void Awake()
    {
        base.Awake();
        ISubCriteriaList = SubCriteriaListView.GetComponent<IPageTurnObject>();
        IAspectList = AspectListView.GetComponent<IPageTurnObject>();
        IMachineTitleList = MachineTitleView.GetComponent<IPageTurnObject>();
        _AspectContentViewCtr = AspectContenView.GetComponent<AspectContentViewCtr>();
        _AspectTitleViewCtr = TitleContentView.GetComponent<AspectTitleViewCtr>();
    }

    private void OnEnable()
    {
        SubCriteriaListView.SetActive(true);
        SubCriterToggleGroup.SetAllTogglesOff();

        AspectListView.SetActive(true);
        AspectContenView.SetActive(false);
        AspectDescriptionView.SetActive(false);
    }
}
