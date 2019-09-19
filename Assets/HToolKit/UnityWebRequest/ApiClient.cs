using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient
{
    private async Task<UnityWebRequest> GET(string url)
    {
        UnityWebRequest wr = new UnityWebRequest();
        wr.url = url;
        wr.method = UnityWebRequest.kHttpVerbGET;
        wr.timeout = 30;
        wr.downloadHandler = new DownloadHandlerBuffer();
        await wr.SendWebRequest();
        return wr;
    }

    private async Task<UnityWebRequest> POST(string url, string request)
    {
        UnityWebRequest wr = new UnityWebRequest();
        wr.url = url;
        wr.method = UnityWebRequest.kHttpVerbPOST;
        wr.timeout = 30;

        var bytes = System.Text.Encoding.UTF8.GetBytes(request);

        UploadHandler uploader = new UploadHandlerRaw(bytes);
        uploader.contentType = "application/json";
        wr.uploadHandler = uploader;

        wr.downloadHandler = new DownloadHandlerBuffer();
        await wr.SendWebRequest();
        return wr;
    }

    private string GetUrl(string endpoint, string host)
    {
        endpoint = endpoint ?? "";
        var url = host + endpoint;
        return url;
    }

    public async Task<T> GetAsync<T>(string endpoint, string host) where T : class
    {
        var url = GetUrl(endpoint, host);

        var wr = await GET(url);
        var response = wr.downloadHandler.text;
        Debug.Log(response);
        var result = JsonConvert.DeserializeObject<T>(response);

        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">is request post data</typeparam>
    /// <typeparam name="R">is reture data</typeparam>
    /// <param name="request"></param>
    /// <param name="endpoint"></param>
    /// <param name="host"></param>
    /// <returns></returns>
    public async Task<R> PostAsync<T, R>(T request, string endpoint, string host) where R : class
    {
        var url = GetUrl(endpoint, host);
        var wr = await POST(url, JsonConvert.SerializeObject(request));
        var response = wr.downloadHandler.text;
        Debug.Log(response);
        var result = JsonConvert.DeserializeObject<R>(response);
        return result;
    }
}
