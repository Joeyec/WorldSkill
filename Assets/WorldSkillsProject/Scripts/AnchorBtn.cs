using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnchorBtn : MonoBehaviour {

    Tagalong tagalong;

    Image ParentImage;

    private void Start()
    {
        tagalong = MainUICtr.Instance.Canvas.GetComponent<Tagalong>();

        ParentImage = GetComponent<Image>();

        GetComponent<Toggle>().onValueChanged.AddListener((isOn)=> {
            tagalong.enabled = !isOn;
            ParentImage.enabled = !isOn;
        });
    }

}
