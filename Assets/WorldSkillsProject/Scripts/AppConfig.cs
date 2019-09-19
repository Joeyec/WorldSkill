using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class AppConfig
{
    //public static ConfigUserInfo CurUserInfo = new ConfigUserInfo();
    //public static ConfigLogInResponse LogInRequestResult;
    //public static ConfigDataResponse DataRequestResult;

    public static readonly string UserReqEndPoint = "";
    public static readonly string UserReqHost = "http://10.11.12.76/WorldSkillsFile/GetInfo.json";

    public static readonly string DataReqEndPoint = "";
    public static readonly string DataReqHost = "http://10.11.12.76/WorldSkillsFile/GetInfo.json";

    public static string LocalUserInfo = Application.dataPath + "/Resources/ConfigProfiles/UserInfo.json";
    public static string LocalQRCodeInfo = Application.dataPath + "/Resources/ConfigProfiles/QRCodeInfo.json";
    public static string LocalMachineInfo = Application.dataPath + "/Resources/ConfigProfiles/MachineInfo.json";
    public static string LocalQuestionInfo = Application.dataPath + "/Resources/ConfigProfiles/QuestionInfo.json";

    //public static R GetIndexProprety<T,R>(int Index,T t) where T : CustomList<R> where R : CustomProp<R>
    //{
    //    foreach (var item in t.List)
    //    {
    //        if (Index == item.Index)
    //        {
    //            return item;
    //        }
    //    }
    //    return null;
    //}

}

public class CriteriaList {
    [JsonProperty(PropertyName = "CriteriaList")]
    public List<CriteriaViewModel> _CriteriaList;
}

public class MachineList {
    [JsonProperty("MachineList")]
    public List<MachineViewModel> _MachineList;
}

public class SubCriteriaList {
    [JsonProperty("SubCriteriaList")]
    public List<SubCriteriaViewModel> _SubCriteriaList;
}

public class AspectList {
    [JsonProperty("AspectList")]
    public List<AspectViewModel> _AspectList;
}

public class ExamViewModel
{
    [JsonProperty]
    public string Id { get; set; }
    [JsonProperty]
    public string Name { get; set; }
    [JsonProperty]
    public string Description { get; set; }
    [JsonProperty]
    public ExamType Type { get; set; }

    [JsonProperty]
    public string CreatorId { get; set; }
    [JsonProperty]
    public string EditorId { get; set; }
    [JsonProperty]
    public DateTime CreationTime { get; set; }
    [JsonProperty]
    public DateTime? LastEditTime { get; set; }
    [JsonProperty]
    public bool IsValid { get; set; }
}

public enum ExamType
{
    NA = 0,
    Training = 1,
    Examing = 2,
    Competing = 3
}

public class CriteriaViewModel
{
    [JsonProperty]
    public string Id { get; set; }
    [JsonProperty]
    public string Name { get; set; }
    [JsonProperty]
    public string Description { get; set; }

    [JsonProperty]
    public string CreatorId { get; set; }
    [JsonProperty]
    public string EditorId { get; set; }
    [JsonProperty]
    public DateTime CreationTime { get; set; }
    [JsonProperty]
    public DateTime? LastEditTime { get; set; }
    [JsonProperty]
    public bool IsValid { get; set; }
}

public class MachineViewModel
{
    [JsonProperty]
    public string Id { get; set; }
    [JsonProperty]
    public string CriteriaId { get; set; }
    [JsonProperty]
    public string Name { get; set; }
    [JsonProperty]
    public string Description { get; set; }

    [JsonProperty]
    public string CreatorId { get; set; }
    [JsonProperty]
    public string EditorId { get; set; }
    [JsonProperty]
    public DateTime CreationTime { get; set; }
    [JsonProperty]
    public DateTime? LastEditTime { get; set; }
    [JsonProperty]
    public bool IsValid { get; set; }
}

public class SubCriteriaViewModel
{
    [JsonProperty]
    public string Id { get; set; }
    [JsonProperty]
    public string MachineId { get; set; }
    [JsonProperty]
    public string IdLabel { get; set; }
    [JsonProperty]
    public string Name { get; set; }
    [JsonProperty]
    public string Description { get; set; }
   
    [JsonProperty]
    public string CreatorId { get; set; }
    [JsonProperty]
    public string EditorId { get; set; }
    [JsonProperty]
    public DateTime CreationTime { get; set; }
    [JsonProperty]
    public DateTime? LastEditTime { get; set; }
    [JsonProperty]
    public bool IsValid { get; set; }
}

public class AspectViewModel
{
    [JsonProperty]
    public string Id { get; set; }

    [JsonProperty]
    public string IdLabel { get; set; }
    [JsonProperty]
    public int SequenceNumber { get; set; }

    [JsonProperty]
    public string SubCriteriaId { get; set; }

    [JsonProperty]
    public string Name { get; set; }
    [JsonProperty]
    public double MaxMark { get; set; }
    [JsonProperty]
    public string Description { get; set; }

    [JsonProperty]
    public AspectType Type { get; set; }
    [JsonProperty]
    public List<AspectScoreRequiremnt> RequirementModels { get; set; }
    [JsonProperty]
    public int Sequence { get; set; }

    [JsonProperty]
    public string CreatorId { get; set; }
    [JsonProperty]
    public string EditorId { get; set; }
    [JsonProperty]
    public DateTime CreationTime { get; set; }
    [JsonProperty]
    public DateTime? LastEditTime { get; set; }
    [JsonProperty]
    public bool IsValid { get; set; }
}

public class AspectScoreRequiremnt
{
    [JsonProperty]
    public int Score { get; set; }
    [JsonProperty]
    public string Description { get; set; }
}

public enum AspectType
{
    NA =0 ,
    /// <summary>
    /// have answer is yes no
    /// </summary>
    Measurement = 1,
    /// <summary>
    /// have answer is 0 1 2 3 
    /// </summary>
    Judge = 2,

}