using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private const string studentId = "666666";
    private const string _svrAddr = "http://remoteassistdemo.azurewebsites.net/api/ClientApi/";
    private string token;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void Clicked()
    {
        //loading
        var api = new ApiClient();
        var result = await api.GetAsync<ConfirmLogonResponse>("ConfirmLogon?StudentId=666666", _svrAddr);
        token = result.Token;
        //complete
    }

    public async void Clicked1()
    {
        var api = new ApiClient();
        var result = await api.PostAsync<SendAnswerRequest, SendAnswerResponse>(
            new SendAnswerRequest()
            {
                Token = token,
                StudentId = studentId,
                Answers = new string[] { "A" },
                ExerciseId = 1
            }, "SendAnswer", _svrAddr);
        Debug.Log(result.IsSuccess);
    }
}
