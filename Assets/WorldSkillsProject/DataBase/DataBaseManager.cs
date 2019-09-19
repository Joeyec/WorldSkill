using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IDTOR
using UnityEditor;
#endif

[CreateAssetMenu()]
public class DataBaseManager : ScriptableObject
{

    static void CreateExampleAssetInstance()
    {
        var exampleAsset = CreateInstance<DataBaseManager>();
    }

}
public class DataCriteriaList:ScriptableObject {

  //  public CriteriaList CriteriaList

    static void CreateExampleAssetInstance()
    {
        var exampleAsset = CreateInstance<DataCriteriaList>();
    }

}