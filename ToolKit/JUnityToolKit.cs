using UnityEngine;
using System.Collections;

namespace Game.Toolkit
{
    public class JUnityLogerListener : ILogerListener
    {
        public void log(string msg)
        {
            Debug.Log(msg);
        }
    }
    public class JUnityToolKit
    {

        public static void Init()
        {
            JAIToolKit.Init();
            JLogger.Ins.AddListener(new JUnityLogerListener());
        }

        public static void Unit()
        {
            JAIToolKit.Unit();
        }
    }
}
