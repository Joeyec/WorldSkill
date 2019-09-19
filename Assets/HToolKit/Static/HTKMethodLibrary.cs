using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTKMethodLibrary : MonoBehaviour {


    public static GameObject FindChildObj(Transform parentObj,string name) {

        return parentObj.Find(name).gameObject;
    }

    public static Transform FindChildTra(Transform parentObj, string name) {

        return parentObj.Find(name);
    }
}
