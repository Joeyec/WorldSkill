using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanOpenBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(()=> {
            MainUICtr.Instance.ScanningView.SetActive(true);
            MainUICtr.Instance.MachineView.SetActive(false);
            MainUICtr.Instance.AspectView.SetActive(false);
            ScanTargetsCtr.Instance.IsFound = false;
        });
	}
	
}
