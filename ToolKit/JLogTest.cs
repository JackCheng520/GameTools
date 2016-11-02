using UnityEngine;
using System.Collections;
using Game.Toolkit;

public class JLogTest : MonoBehaviour
{

    void Awake()
    {
        JUnityToolKit.Init();
    }

    private float _time;
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 1)
        {
            _time = 0;
            JLogger.LOG(Time.realtimeSinceStartup.ToString() );
        }
    }

    
    void OnDestroy()
    {
        JUnityToolKit.Unit();
    }
}
