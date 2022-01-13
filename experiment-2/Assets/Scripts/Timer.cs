using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public PerspectiveManager perspectiveManager;
    public void TimeOut()
    {
        perspectiveManager.ChangePerspective();
    }
}
