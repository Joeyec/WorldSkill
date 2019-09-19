using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoadingDataView : MonoBehaviour, IView
{
    public Slider LoadProgress;

    //async void Start() {

    //    await OnLoadData();

    //}

    //async Task OnLoadData() {

    //    ApiClient api = new ApiClient();
    //    ConfigDataRequest dataReq = new ConfigDataRequest() {
    //        QuestionType = AppConfig.LogInRequestResult.QuestionType
    //    };
    //    AppConfig.DataRequestResult = await api.PostAsync<ConfigDataRequest, ConfigDataResponse>(dataReq, AppConfig.DataReqEndPoint, AppConfig.DataReqHost);
    //    Debug.Log(AppConfig.DataRequestResult.DataInfo);
    //}

    public void OnEnd()
    {
       
    }

    public void OnRefresh()
    {
      
    }
}
