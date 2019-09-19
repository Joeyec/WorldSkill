using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.UI.Keyboard;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System;
//using System.Data.SqlClient;
//using Mono.Data.Sqlite;
using Newtonsoft.Json;

public class LogInViewCtr : MonoBehaviour, IView {

    public GameObject LogInLoading;

    public KeyboardInputField UserName;
    public KeyboardInputField Password;
    public Button LogInBtn;

    // Use this for initialization
    void Start() {

        //OnInputInit();
        UserName.text = "1";
        Password.text = "2";

        LogInBtn.onClick.AddListener(() => {

            MainUICtr.Instance.LogInView.SetActive(false);
            MainUICtr.Instance.ScanningView.SetActive(true);
        });

        //LogInBtn.onClick.AddListener(async () =>
        //{
        //    await OnLogInAsync();
        //});
    }

    [ContextMenu("111")]
    void OnReadData()
    {
        StartCoroutine(LoadLocalJson());
    }

    IEnumerator LoadLocalJson()
    {
        //Debug.Log("111");
        WWW www = new WWW(Application.dataPath + "/Resources/ConfigProfiles/QRCodeInfo.json");
        yield return www;
        // Debug.Log(www.text);
       // AppConfig.QRCodeList = JsonConvert.DeserializeObject<QRCodeInfoList>(www.text);
        www = new WWW(Application.dataPath + "/Resources/ConfigProfiles/QuestionInfo.json");
        yield return www;
        //Debug.Log(www.text);
       // AppConfig.QuestionList = JsonConvert.DeserializeObject<QuestionInfoList>(www.text);

        www = new WWW(Application.dataPath + "/Resources/ConfigProfiles/MachineInfo.json");
        yield return www;
        //Debug.Log(www.text);
     //   AppConfig.MachineList = JsonConvert.DeserializeObject<MachineInfoList>(www.text);
      
    }

    public void OnRefresh()
    {
        
    }

    //#region 

    //public void OnRefresh()
    //{
    //    OnInputInit();
    //}

    //async Task OnLogInAsync() {

    //    if (string.IsNullOrEmpty(UserName.text) || string.IsNullOrEmpty(Password.text))
    //    {
    //        return;
    //    }
    //    LogInLoading.SetActive(true);
    //    ApiClient api = new ApiClient();
    //  //  AppConfig.CurUserInfo.UserName = UserName.text;
    //  //  AppConfig.CurUserInfo.UserName = Password.text;
    //  //  AppConfig.LogInRequestResult = await api.PostAsync<ConfigUserInfo, ConfigLogInResponse>(AppConfig.CurUserInfo, AppConfig.UserReqEndPoint, AppConfig.UserReqHost);
    //    //  Debug.Log(AppConfig.LogInRequestResult.UserIsExist);
    //    OnLogInComfirm();
    //}

    //void OnLogInComfirm() {

    //    //if (!AppConfig.LogInRequestResult.UserIsExist)
    //    //{
    //    //    MainUICtr.Instance.OnMessageBox("User is not exist");
    //    //    OnInputInit();
    //    //    return;
    //    //}
    //    //LogInLoading.SetActive(false);
    //    //MainUICtr.Instance.LoadDataView.SetActive(false);
    //    //if (AppConfig.LogInRequestResult.DataIsModify)
    //    //{
    //    //    MainUICtr.Instance.LoadDataView.SetActive(true);
    //    //}
    //    //else {
    //    //    MainUICtr.Instance.ScanningView.SetActive(true);
    //    //}
    //}

    //void OnInputInit() {
    //    UserName.text = null;
    //    Password.text = null;
    //    LogInLoading.SetActive(false);
    //}

    //SqliteConnection connection;
    //SqliteCommand command;
    //SqliteDataReader reader;

    //#region

    //[ContextMenu("aaaaa")]
    //public void OnLoadLocalDataAsync()
    //{
    //    string path = "D:/sqlite-tools-win32-x86-3280000/wsDB";
    //    Debug.Log(path);
    //    connection = new SqliteConnection("Data Source=" + path);
    //    connection.Open();
    //    Debug.Log("打开数据库");
    //    command = connection.CreateCommand();

    //    command.CommandText = "select userName,userpwd from ws_userinfo";

    //    reader = command.ExecuteReader();

    //    //await reader.ReadAsync();

    //    while (reader.Read()) {

    //        for (int i = 0; i < reader.FieldCount; i++)
    //        {
    //            Debug.Log(reader.GetName(i) + "--------------" + reader.GetValue(i));
    //        }

    //    }

    //    command.Dispose();
    //    command.Dispose();
    //    connection.Dispose();

    //}

    //void OnInsertValues() {
    //    string commandUser = "insert info ws_userinfo(username,userpwd)" ;
    //    string commandQuestion = "insert info ws_questionInfo(questionIndex,questionType,answer)";
    //    string commandQRinfo = "insert info ws_QRcodeInfo(QRName,QuestionCount,questionIndex) ";

    //}

    //string UserInsertValue1 = "('1','123')";
    //string UserInsertValue2 = "('2','123')";
    //string UserInsertValue3 = "('3','123')";


    //string QuestionInsertValue1       = "('1','Measurement','yes')";
    //string QuestionInsertValue2       = "('2','Judge','1')";
    //string QuestionInsertValue3       = "('3','Judge','3')";
    //string QuestionInsertValue4       = "('4','Judge','0')";
    //string QuestionInsertValue5       = "('5','Measurement','no')";
    //string QuestionInsertValue6       = "('6','Measurement','no')";
    //string QuestionInsertValue7       = "('7','Judge','2')";
    //string QuestionInsertValue8       = "('8','Judge','1')";
    //string QuestionInsertValue9       = "('9','Measurement','yes')";
    //string QuestionInsertValue10      = "('10','Judge','0')";
    //string QuestionInsertValue11      = "('11','Judge','1')";
    //string QuestionInsertValue12      = "('12','Judge','3')";
    //string QuestionInsertValue13      = "('13','Measurement','yes')";


    //string QRCodeInsertValue1 = "('Acode','3','1,2,5')";
    //string QRCodeInsertValue2 = "('Bcode','5','3,4,6,7,10')";
    //string QRCodeInsertValue3 = "('Ccode','2','8,12')";


    //void OReader() {

    //    while (reader.Read())
    //    {
    //        for (int i = 0; i < reader.FieldCount; i++)
    //        {
    //            Debug.Log(i + "******" + reader.GetName(i) + "******" + reader.GetValue(i));
    //            //  Debug.Log(sqliteData.GetValue(i));
    //        }
    //    }
    //}
    //[ContextMenu("bbbb")]
    //public void ExecuteCMD() {

    //    DBManager.OnOpenDB();

    //    DBManager.OnCreateTable("ws_userInfo", new string[] { "userID integer not null primary key autoincrement", "userName varchar(10)", "userPwd varchar(11)" });
    //    DBManager.OnCreateTable("ws_questionInfo", new string[] { "questionID integer not null primary key autoincrement", "questionIndex varchar", "questionType varchar(20)", "answer varchar" });
    //    DBManager.OnCreateTable("ws_QRCodeInfo", new string[] { "QRcodeID integer not null primary key autoincrement", "QRName varchar(10)", "questionCount varchar(11)", "questionIndexs varchar" });

    //    DBManager.OnInsertValues("ws_userInfo",new string[] {"userName","userPwd" },new string[] { UserInsertValue1, UserInsertValue2, UserInsertValue3 } );
    //    DBManager.OnInsertValues("ws_questionInfo", new string[] {"questionIndex","questionType", "answer" },new string[] { QuestionInsertValue1, QuestionInsertValue2, QuestionInsertValue3 } );
    //    DBManager.OnInsertValues("ws_QRCodeInfo", new string[] { "QRName", "questionCount","questionIndexs" },new string[] { QRCodeInsertValue1, QRCodeInsertValue2, QRCodeInsertValue3 } );

    //    DBManager.OnCloseDB();
    //}
    //#endregion


    //#endregion

}

