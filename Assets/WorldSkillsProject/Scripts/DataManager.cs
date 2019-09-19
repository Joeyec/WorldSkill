using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoSingletion<DataManager> {

    public CriteriaList ListCritera = new CriteriaList();

    public MachineList ListMachine = new MachineList();

    public SubCriteriaList ListSubCriteria = new SubCriteriaList();

    public AspectList ListAspect = new AspectList();

    /******************************************/

    public DataListSum CurDataListSum = new DataListSum();

    public DataSelectState CurDataSelectState = new DataSelectState();

    public Dictionary<string, CriteriaViewModel> DicCriteria = new Dictionary<string, CriteriaViewModel>();
    public Dictionary<string, MachineViewModel> DicMachine = new Dictionary<string, MachineViewModel>();
    public Dictionary<string, SubCriteriaViewModel> DicSubCriteria = new Dictionary<string, SubCriteriaViewModel>();
    public Dictionary<string, AspectViewModel> DicAspect = new Dictionary<string, AspectViewModel>();

    public List<string> ListAspectComplete = new List<string>();

    private void Start()
    {
        LoadAllData();
    }

    public void LoadAllData() {

        //StartCoroutine(LoadLocalJson());
        TextAsset str1 = Resources.Load<TextAsset>("ConfigProfiles/CriteriaInfo");
        TextAsset str2 = Resources.Load<TextAsset>("ConfigProfiles/MachineInfo");
        TextAsset str3 = Resources.Load<TextAsset>("ConfigProfiles/SubCriteriaInfo");
        TextAsset str4 = Resources.Load<TextAsset>("ConfigProfiles/AspectInfo");

        ListCritera = JsonConvert.DeserializeObject<CriteriaList>(str1.text);
        ListMachine = JsonConvert.DeserializeObject<MachineList>(str2.text);
        ListSubCriteria = JsonConvert.DeserializeObject<SubCriteriaList>(str3.text);
        ListAspect = JsonConvert.DeserializeObject<AspectList>(str4.text);

        OnInitStatisticsData();
    }

    IEnumerator LoadLocalJson()
    {
        //Debug.Log("111");
        WWW www = new WWW(Application.dataPath + "/Resources/ConfigProfiles/CriteriaInfo.json");
        yield return www;
        Debug.Log(www.text);
        ListCritera = JsonConvert.DeserializeObject<CriteriaList>(www.text);

        www = new WWW(Application.dataPath + "/Resources/ConfigProfiles/MachineInfo.json");
        yield return www;
        Debug.Log(www.text);
        ListMachine = JsonConvert.DeserializeObject<MachineList>(www.text);

        www = new WWW(Application.dataPath + "/Resources/ConfigProfiles/SubCriteriaInfo.json");
        yield return www;
        Debug.Log(www.text);
        ListSubCriteria = JsonConvert.DeserializeObject<SubCriteriaList>(www.text);

        www = new WWW(Application.dataPath + "/Resources/ConfigProfiles/AspectInfo.json");
        yield return www;
        Debug.Log(www.text);
        ListAspect = JsonConvert.DeserializeObject<AspectList>(www.text);

        OnInitStatisticsData();
    }

    void OnInitStatisticsData() {

        CurDataListSum.CriteriaTotalNum = ListCritera._CriteriaList.Count;
        CurDataListSum.MachineTotalNum = ListMachine._MachineList.Count;
        CurDataListSum.SubCriteriaTotalNum = ListSubCriteria._SubCriteriaList.Count;
        CurDataListSum.AspectTotalNum = ListAspect._AspectList.Count;

        foreach (var item in ListCritera._CriteriaList)
        {
            DicCriteria.Add(item.Id, item);
        }
        foreach (var item in ListMachine._MachineList)
        {
            DicMachine.Add(item.Id, item);
        }
        foreach (var item in ListSubCriteria._SubCriteriaList)
        {
            DicSubCriteria.Add(item.Id, item);
        }
        foreach (var item in ListAspect._AspectList)
        {
            DicAspect.Add(item.Id, item);
        }

        ListAspectComplete.Clear();
    }

    public void OnSetCurCriteriaModel(CriteriaViewModel _CurCriteriaModel) {

        CurDataSelectState.CurCriteriaModel = _CurCriteriaModel;
        CurDataSelectState.CriteriaId = _CurCriteriaModel.Id;
    }

    public void OnSetCurMachineModel(MachineViewModel _CurMachineModel)
    {
        CurDataSelectState.CurMachineModel = _CurMachineModel;
        CurDataSelectState.MachineId = _CurMachineModel.Id;
    }

    public void OnSetCurSubCriteriaModel(SubCriteriaViewModel _CurSubCriteriaModel)
    {
        CurDataSelectState. CurSubCriteriaModel = _CurSubCriteriaModel;
        CurDataSelectState.SubCriteriaId = _CurSubCriteriaModel.Id;
    }

    public void OnSetCurAspectModel(AspectViewModel _CurAspectModel)
    {
        CurDataSelectState. CurAspectModel = _CurAspectModel;
        CurDataSelectState.AspectId = _CurAspectModel.Id;
    }

}

public class DataListSum {

    public int CriteriaTotalNum;
    public int MachineTotalNum;
    public int SubCriteriaTotalNum;
    public int AspectTotalNum;
}

public class DataSelectState {

    string criteriaId;

    public string CriteriaId {
        get { return criteriaId; }
        set {
            criteriaId = value;
            if (value != null)
            {
                if (MachineList.Count != 0)
                {
                    MachineList.Clear();
                }
                foreach (var item in DataManager.Instance.DicMachine)
                {
                    if (CriteriaId == item.Value.CriteriaId)
                    {
                        MachineList.Add(item.Value);
                    }
                }
            }
            MachineNum = MachineList.Count;
        }
    }

    string machineId;

    public string MachineId
    {
        get { return machineId; }
        set {
            machineId = value;
            if (MachineId != null)
            {
                if (SubCriteriaList.Count != 0)
                {
                    SubCriteriaList.Clear();
                }

                foreach (var item in DataManager.Instance.DicSubCriteria)
                {
                    if (MachineId == item.Value.MachineId)
                    {
                        this.SubCriteriaList.Add(item.Value);
                    }
                }
            }
            SubCriteriaNum = SubCriteriaList.Count;
        }
    }

    string subCriteriaId;

    public string SubCriteriaId
    {
        get { return subCriteriaId; }
        set {
            subCriteriaId = value;
            if (SubCriteriaId != null)
            {
                if (AspectList.Count != 0)
                {
                    AspectList.Clear();
                }

                foreach (var item in DataManager.Instance.DicAspect)
                {
                    if (SubCriteriaId == item.Value.SubCriteriaId)
                    {
                        this.AspectList.Add(item.Value);
                    }
                }
            }
            AspectNum = AspectList.Count;
        }
    }

    string aspectId;

    public string AspectId
    {
        get { return aspectId; }
        set {
            aspectId = value;
        }
    }

    public CriteriaViewModel CurCriteriaModel = null;

    public MachineViewModel CurMachineModel = null;

    public SubCriteriaViewModel CurSubCriteriaModel = null;

    public AspectViewModel CurAspectModel = null;

    public List<MachineViewModel> MachineList = new List<MachineViewModel>();
    public List<SubCriteriaViewModel> SubCriteriaList = new List<SubCriteriaViewModel>();
    public List<AspectViewModel> AspectList = new List<AspectViewModel>();

    public int MachineNum;
    public int SubCriteriaNum;
    public int AspectNum;
    public int CurSelectAspectIndex;

    public int CompletedMachine = 0;
    public int CompletedSubCriter = 0;
    public int CompletedAspect = 0;

    public int GetNextAspectIndex() {

        CurSelectAspectIndex++;
        if (CurSelectAspectIndex > AspectNum - 1)
        {
            //return -1 is complete curSub Aspect
            return -1;
        }
        return CurSelectAspectIndex;
    }

    public int[] GetRemainingNums() {
        int[] nums = new int[4];
        nums[0] = AspectNum - (CurSelectAspectIndex + 1);
        nums[1] = MachineNum - CompletedMachine;
        nums[2] = SubCriteriaNum - CompletedSubCriter;
        nums[3] = AspectNum - CompletedAspect;

        return nums;
    }

}