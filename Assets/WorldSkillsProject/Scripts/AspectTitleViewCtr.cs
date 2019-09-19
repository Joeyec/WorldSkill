using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectTitleViewCtr : MonoBehaviour{

    public Text TitleContent;

    public Text[] RemainingInfo;

    public void OnRefreshView(int[] _RemainingNums) {

        for (int i = 0; i < RemainingInfo.Length; i++)
        {
            RemainingInfo[i].text = _RemainingNums[i].ToString();
        }
    }
}
