using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugLogTextCtr : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    [ContextMenu("leng")]
    void ShowTextLength() {
        Debug.Log(GetComponentInChildren<Text>().text.Length);
        Debug.Log(GetComponentInChildren<Text>().text);

    }
}
