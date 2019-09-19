using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUICtr : MonoSingletion<MainUICtr> {

    public GameObject Canvas;
    public GameObject FlashView;
    public GameObject LogInView;
    public GameObject LoadDataView;
    public GameObject ScanningView;
    public GameObject MachineView;
    public GameObject AspectView;

    public IPageTurnObject _IMachineList;

    public GameObject MessageBox;

    public float FlashLogoShowTime = 2f;

    protected override void Awake()
    {
        base.Awake();
        FlashView.SetActive(true);
        LogInView.SetActive(false);
        LoadDataView.SetActive(false);
        ScanningView.SetActive(false);
        MachineView.SetActive(false);
        AspectView.SetActive(false);

        FlashView.transform.localPosition = Vector3.zero;
        LogInView.transform.localPosition = Vector3.zero;
        LoadDataView.transform.localPosition = Vector3.zero;
        ScanningView.transform.localPosition = Vector3.zero;
        MachineView.transform.localPosition = Vector3.zero;
        AspectView.transform.localPosition = Vector3.zero;

        _IMachineList = MachineView.GetComponent<IPageTurnObject>();

        Invoke("OnSwitchLogInView", FlashLogoShowTime);
    }
    // Use this for initialization
    void Start () {
      
    }
	
    void OnSwitchLogInView()
    {
        FlashView.SetActive(false);
        LogInView.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CriteriaViewModel _CriteriaViewModel = new CriteriaViewModel()
            {
                Id = "0"
            };

            Debug.Log("_CriteriaViewModel------- " + _CriteriaViewModel.Id);
            DataManager.Instance.OnSetCurCriteriaModel(_CriteriaViewModel);
            MachineView.SetActive(true);
            _IMachineList.OnReFreshList();
            ScanningView.SetActive(false);
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

        }
    }

    public void OnMessageBox(string showInfo) {
        MessageBox.transform.SetAsLastSibling();
        CancelInvoke("OnMessageBoxClose");
        MessageBox.SetActive(true);
        MessageBox.GetComponentInChildren<Text>().text = showInfo;
        Invoke("OnMessageBoxClose", 3f);
    }

    void OnMessageBoxClose()
    {
        MessageBox.SetActive(false);
    }

}
