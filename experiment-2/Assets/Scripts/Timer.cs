using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Timer : MonoBehaviour
{
    public PerspectiveManager perspectiveManager;
    public Slider slider;
    public float Time;
    public void TimeOut()
    {
        perspectiveManager.ChangePerspective();
    }

    public void Start()
    {
        slider.DOValue(1, Time).onComplete += TimeOut;
    }

}
