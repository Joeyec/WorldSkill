using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningCtr : MonoBehaviour {

    public float ForwardDis = 2f;

    void Update()
    {
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * ForwardDis;
        transform.LookAt(Camera.main.transform);
    }
}
