using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayAnimationBehaivour : MonoBehaviour {

    public Animator m_ani;

    public int PlayLayerIndex = 0;

    [Header("最后一帧填-1即可")]
    public AniPlaySegment[] aniPlaySegments;

    string PlayLayerName;

    /// <summary>
    /// 动画总帧数
    /// </summary>
    int AllFrame = 720; 

    /// <summary>
    /// 正在播放中
    /// </summary>
    public bool IsPlaying = false;

    /// <summary>
    /// 当前播放进度
    /// </summary>
    protected float CurPlayTime { get; set; }

    protected float StopFrame { get; set; }

    protected AniPlaySegment CurSegment;
    protected int CurSegmentIndex;

    /// <summary>
    /// 每段播放完毕
    /// </summary>
    public UnityAction<int> OnSegmentPlayeEnd;

    /// <summary>
    /// 动画播放完毕
    /// </summary>
    public UnityAction OnAnimationPlayEnd;

    protected virtual void Start()
    {
        InitAniData();
   
    }

    protected virtual void LateUpdate()
    {
        AnimatorPlaySliderUpdate();
        if (CurSegment.segmentName != null)
        {
            Debug.Log(CurSegment.segmentName + "正在播放");
        }
    }

    void InitAniData() {

        if (m_ani == null)
        {
            m_ani = GetComponent<Animator>();
        }
       
        CurPlayTime = 0;
        AnimationClip aniClip = m_ani.GetCurrentAnimatorClipInfo(PlayLayerIndex)[0].clip;
        float clipLength = aniClip.length;
        float frameRate = aniClip.frameRate;
        AllFrame = (int)(clipLength * frameRate);
        PlayLayerName = aniClip.name;
        OnPause();
    }

    /// <summary>
    /// 模型动画播放进度
    /// </summary>
    void AnimatorPlaySliderUpdate()
    {
        if (IsPlaying)
        {
            if (m_ani.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                CurPlayTime = m_ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
            }
            else
            {
                OnEndPlay();
                CurPlayTime = 1;
                IsPlaying = false;
            }

            PlayStopNextFrame();
        }

       

        #region 
        //同步滑动条
        //if (!isClickSlider)
        //{
        //    if (m_ani.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
        //    {
        //        if (m_ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        //        {
        //            f_CurPlayTime = 1;
        //          //  m_aniSlider.value = 1;
        //        }
        //        else
        //        {
        //            f_CurPlayTime = m_ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
        //          //  m_aniSlider.value = m_ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
        //        }
        //    }
        //}
        #endregion
    }

    /// <summary>
    /// 控制从第几帧播放到第几帧
    /// </summary>
    /// <param name="startFrame"></param>
    /// <param name="stopFrame"></param>
    public void OnFramePlay(int startFrame, int _stopFrame) {

        float startTime = (float)startFrame / AllFrame;

        if (_stopFrame == -1)
        {
            _stopFrame = AllFrame;
        }

        float stopTime = (float)_stopFrame / AllFrame;

        m_ani.Play(PlayLayerName, -1, startTime);

        StopFrame = stopTime;

        m_ani.speed = 1;

        IsPlaying = true;
        
    }

    /// <summary>
    /// 控制从第几帧播放到第几帧
    /// </summary>
    /// <param name="_name">播放段的名字</param>
    public void OnFramePlay(string _name)
    {
        CurSegment = new AniPlaySegment();
        foreach (var item in aniPlaySegments)
        {
            if (item.segmentName == _name)
                CurSegment = item;
        }

        float startTime = (float)CurSegment.minSegment / AllFrame;

        if (CurSegment.maxSegment == -1)
        {
            CurSegment.maxSegment = AllFrame;
        }

        float stopTime = (float)CurSegment.maxSegment / AllFrame;

        m_ani.Play(PlayLayerName, -1, startTime);

        StopFrame = stopTime;

        m_ani.speed = 1;

        IsPlaying = true;
       
    }
    /// <summary>
    /// 控制从第几帧播放到第几帧
    /// </summary>
    /// <param name="_index">分段播放下标</param>
    public void OnFramePlay(int _index)
    {
        CurSegment = new AniPlaySegment();

        CurSegment = aniPlaySegments[_index];

        CurSegmentIndex = _index;

        float startTime = (float)CurSegment.minSegment / AllFrame;

        if (CurSegment.maxSegment == -1)
        {
            CurSegment.maxSegment = AllFrame;
        }

        float stopTime = (float)CurSegment.maxSegment / AllFrame;

        m_ani.Play(PlayLayerName, -1, startTime);

        StopFrame = stopTime;
        Debug.Log(startTime + "*******" + StopFrame);
        m_ani.speed = 1;

        IsPlaying = true;
  
    }

    /// <summary>
    /// 播放到第几针停止
    /// </summary>
    void PlayStopNextFrame()
    {
        if (CurPlayTime >= StopFrame)
        {
            OnPause();
            OnSegmentPlayeEnd(CurSegmentIndex);
        }
    }

    protected virtual void OnPause()
    {
        IsPlaying = false;
        m_ani.speed = 0;
    }

    protected virtual void OnRePlay()
    {
        m_ani.Rebind();
    }

    protected virtual void OnEndPlay()
    {
        Debug.Log("播放完毕");

        OnAnimationPlayEnd?.Invoke();

    }

    void InitAniBtns()
    {

        //按键 - 播放条

        //m_Play.onClick.AddListener(OnContinuePlay);
        //m_Pause.onClick.AddListener(OnPause);
        //m_RePlay.onClick.AddListener(OnRePlay);

        //m_aniSlider.onValueChanged.AddListener(OnSlider);

        //m_aniSlider.gameObject.AddComponent<EventTrigger>();

        //var trigger = m_aniSlider.gameObject.GetComponent<EventTrigger>();

        //trigger.triggers = new List<EventTrigger.Entry>();

        //EventTrigger.Entry sliderClickDown_entry = new EventTrigger.Entry();
        //EventTrigger.Entry sliderClickUp_entry = new EventTrigger.Entry();

        //sliderClickDown_entry.eventID = EventTriggerType.PointerDown;
        //sliderClickUp_entry.eventID = EventTriggerType.PointerUp;

        //sliderClickDown_entry.callback = new EventTrigger.TriggerEvent();
        //sliderClickUp_entry.callback = new EventTrigger.TriggerEvent();


        //sliderClickDown_entry.callback.AddListener(OnClickDown);

        //sliderClickUp_entry.callback.AddListener(OnClickUp);


        //trigger.triggers.Add(sliderClickDown_entry);
        //trigger.triggers.Add(sliderClickUp_entry);

    }

/*
    [ContextMenu("SetName")]
    void InitBtnText()
    {
        for (int i = 0; i < aniPlaySegments.Length; i++)
        {
            aniPlaySegments[i].segmentName = ftan_AniName[i];
        }
    }

    string[] ftan_AniName = {
"完成第一节塔筒吊装",
"完成上部吊架系统吊装",
"完成第二节塔筒吊装",
"完成平衡梁",
"完成第三节塔筒吊装",
"将机舱吊装至临时工装",
"将叶片及轮毂与机舱安装",
"将风机机舱整体安装至上部塔筒",
"安装第二套风机",
"运输至风电安装区域",
"风范号整体安装风机至高桩承台",

    };

    */

}

/// <summary>
/// 播放的段数
/// </summary>
[System.Serializable]
public struct AniPlaySegment {

    public string segmentName;
    public int minSegment;
    public int maxSegment;

}