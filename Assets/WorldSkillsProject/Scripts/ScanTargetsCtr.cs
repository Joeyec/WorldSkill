using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ScanTargetsCtr : MonoSingletion<ScanTargetsCtr> {

    protected override void Awake()
    {
        base.Awake();
        VuforiaBehaviour.Instance.UpdateEvent += OnCtrTargets;
    }

    public bool IsFound = false;

    void Start () {

    }

    void OnCtrTargets() {

        IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
        int i = 1;
        foreach (var item in tbs)
        {
            item.name = item.GetComponent<TrackableBehaviour>().TrackableName;
            item.transform.SetParent(this.transform);

            switch (item.name)
            {
                case "Astronaut":
                    item.gameObject.AddComponent<CustomizeTrackableEventHandler>()._CriteriaViewModel = new CriteriaViewModel()
                    {
                        Id = "0"
                    };
                    break;
                case "Drone":
                    item.gameObject.AddComponent<CustomizeTrackableEventHandler>()._CriteriaViewModel = new CriteriaViewModel()
                    {
                        Id = "1"
                    };
                    break;
                case "Fissure":
                    item.gameObject.AddComponent<CustomizeTrackableEventHandler>()._CriteriaViewModel = new CriteriaViewModel()
                    {
                        Id = "2"
                    };
                    break;
                case "Oxygen":
                    item.gameObject.AddComponent<CustomizeTrackableEventHandler>()._CriteriaViewModel = new CriteriaViewModel()
                    {
                        Id = "3"
                    };
                    break;
                default:
                    break;
            }
            
            i++;
        }
        VuforiaBehaviour.Instance.UpdateEvent -= OnCtrTargets;
    }

    [ContextMenu("aa")]
    public void OnSerQRCodeProperty() {

        foreach (Transform item in transform)
        {
            
        }
    }
}
