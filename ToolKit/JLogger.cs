using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game.Toolkit
{
    public class JLogger : JLogHelpBase<JLogger>
    {
        public enum LOG_CHANNEL
        {
            DEFAULT = 0,
            WARING,
            INFO,
            ERROR,
            NUM,
        }

        private bool[] channelEnabled;
        private List<JUnityLogerListener> listeners;

        public override void OnInit()
        {
            base.OnInit();
            channelEnabled = new bool[(int)LOG_CHANNEL.NUM];
            for (int i = 0, len = channelEnabled.Length; i < len; i++)
            {
                channelEnabled[i] = true;
            }
            listeners = new List<JUnityLogerListener>();
        }
        public override void OnUnit()
        {
            base.OnUnit();
            channelEnabled = null;
            listeners = null;
        }

        public void EnableChannel(LOG_CHANNEL _channel, bool isEnable)
        {
            if (!beInit)
                return;
            if (_channel == LOG_CHANNEL.NUM)
                return;
            channelEnabled[(int)_channel] = isEnable;
        }

        public void AddListener(JUnityLogerListener _listener)
        {
            if (!beInit)
                return;
            listeners.Add(_listener);
        }

        private void Log(LOG_CHANNEL _channel, string msg, bool isSample = true)
        {
            if (!beInit)
                return;
            if (!channelEnabled[(int)_channel])
                return;

            string data = null;
            if (isSample)
            {
                data = msg;
            }
            else
            {
                data = "at time[" + System.DateTime.Now + "] -- [" + _channel.ToString() + "]" + msg;
            }

            for (int i = 0, len = listeners.Count; i < len; i++)
            {
                listeners[i].log(data);
            }
        }

        //-------------------------
        public static void LOG(string msg)
        {
            JLogger.Ins.Log(LOG_CHANNEL.INFO, msg, false);
        }
        public static void WARING(string msg)
        {
            JLogger.Ins.Log(LOG_CHANNEL.WARING, msg, false);
        }
        public static void ERROR(string msg)
        {
            JLogger.Ins.Log(LOG_CHANNEL.ERROR, msg, false);
        }


    }
}
