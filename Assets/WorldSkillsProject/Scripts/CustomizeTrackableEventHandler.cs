using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CustomizeTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    public CriteriaViewModel _CriteriaViewModel; 

    protected TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
             newStatus == TrackableBehaviour.Status.TRACKED ||
             newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    void OnTrackingFound()
    {
        OnFind();
    }

    void OnTrackingLost()
    {

    }

    public void OnFind()
    {
        if (ScanTargetsCtr.Instance.IsFound)
        {
            return;
        }
        Debug.Log("_CriteriaViewModel------- "  + _CriteriaViewModel.Id);
        DataManager.Instance.OnSetCurCriteriaModel(_CriteriaViewModel);
        MainUICtr.Instance.MachineView.SetActive(true);
        MainUICtr.Instance._IMachineList.OnReFreshList();
        MainUICtr.Instance.ScanningView.SetActive(false);
        ScanTargetsCtr.Instance.IsFound = true;
    }
}
