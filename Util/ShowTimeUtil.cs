using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using ECN;
using Game.Core.Obj;
using Game.Model.Define;
using Game.Core.Manager;

namespace Game.Util
{
    /// <summary>
    /// added by Harry
    /// </summary>
    public class ShowTimeUtil : MonoBehaviour
    {
        public static GameCD staminaCD = null;
        public static int staminaRecoverLeftTime = 0;


        public static string DateDiff(DateTime DateTime1, DateTime DateTime2, bool showDay = false)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if (showDay) dateDiff = ts.Days.ToString() + ":" + ts.Hours.ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            else dateDiff = ts.Hours.ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            return dateDiff;
        }

        //t是时间差
        public static List<int> getLeftDayHourMinSec(int t)
        {
            List<int> list = new List<int>();
            TimeSpan ts = new TimeSpan(0, 0, t);
            int days = ts.Days;
            int hours = ts.Hours;
            int minutes = ts.Minutes;
            int seconds = ts.Seconds;
            list.Add(days);
            list.Add(hours);
            list.Add(minutes);
            list.Add(seconds);
            return list;
        }

        public static string buildTimeShowStringWithChar(int time, string prev, string next)
        {
            if (time < 0) time = 0;
            List<int> list = getLeftDayHourMinSec(time);
            string s = buildTimeShowStringWithChar(list, "", "");
            return s;
        }

        public static string buildTimeShowString(int time)
        {
            if (time < 0) time = 0;
            List<int> list = getLeftDayHourMinSec(time);
            string s = buildTimeShowString(list);
            return s;
        }

        public static string buildTimeShowStringWithChar(List<int> times, string prev, string next)
        {
            int day = times[0];
            int hour = times[1];
            int minute = times[2];
            int second = times[3];
            string v = null;
            if (day == 0 && hour == 0 && minute == 0)
            {
                v = second.ToString() + "秒";//ECNLocalization.Get("秒");
            }
            else if (day == 0 && hour == 0)
            {
                //v = minute.ToString() + ECNLocalization.Get("分") + second.ToString() + ECNLocalization.Get("秒");
                v = minute.ToString() + "分" + second.ToString() + "秒";
            }
            else if (day == 0)
            {
                v = hour.ToString() + "小时" + minute.ToString() + "分" + second.ToString() + "秒";
            }
            else
            {
                v = day.ToString() + "天" + hour.ToString() + "小时" + minute.ToString() + "分" + second.ToString() + "秒";
            }
            return prev + v + next;
        }

        static string buildTimeShowString(List<int> times)
        {
            int day = times[0];
            int hour = times[1];
            int minute = times[2];
            int second = times[3];
            string sec = null;
            string m = null;
            string h = null;
            string d = null;
            if (second < 10) sec = "0" + second;
            else sec = second.ToString();
            if (minute < 10) m = "0" + minute;
            else m = minute.ToString();
            if (hour < 10) h = "0" + hour;
            else h = hour.ToString();
            if (day < 10) d = "0" + day;
            else d = day.ToString();
            string v = null;
            if (day == 0 && hour == 0 && minute == 0)
            {
                v = m + ":" + sec;
            }
            else if (day == 0 && hour == 0)
            {
                v = m + ":" + sec;
            }
            else if (day == 0)
            {
                v = h + ":" + m + ":" + sec;
            }
            else
            {
                v = d + ":" + h + ":" + m + ":" + sec;
            }
            return v;
        }


        /// <summary>
        /// 时间戳转显示datetime by chx
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string TicksFormat(long t)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            DateTime dt = startTime.AddMilliseconds(t);
            string dateDiff = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return dateDiff;
        }
        /// <summary>
        /// 时间戳转datetime by chx
        /// </summary>
        /// <param name="t">服务器时间</param>
        /// <returns></returns>
        public static DateTime TicksToDataTime(long t)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return startTime.AddMilliseconds(t);

        }
        /// <summary>
        /// 根据时间戳获得剩余时间 by chx
        /// </summary>
        /// <param name="_lastTime">上次操作记录的时间戳，毫秒</param>
        /// <param name="duration">cd时间，秒</param>
        /// <returns></returns>
        public static int GetLeftTime(long _lastTime,int duration)
        {
            double cdDelyTime = TimeSpan.FromSeconds(duration).TotalMilliseconds;
            long cd = (long)(_lastTime + cdDelyTime - GameApp.getServerTime());
            //Debug.Log("--durationTime:" +( _lastTime - GameApp.getServerTime() ));
            //Debug.Log("--_lastTime:" + _lastTime + " -- cddelaytime:" + cdDelyTime + " --SeverTime:" + GameApp.getServerTime() + "--cd:" + cd);
            return (int)(cd > 0 ? TimeSpan.FromMilliseconds(cd).TotalSeconds : 0);
        }

        //开始刷新体力
        public static void startRefreshStamina()
        {
            GameApp.socketController.sendRequest(ProtocalType.REQUEST_KEY_ROLEREMOTING_CHECKSTAMINAFRESH, "");
            if(staminaCD == null)
            {
                staminaCD = GameApp.gameCDMgr.startCDTimer(GameCDMgr.staminaRecover, (GameApp.dataCache.rolePo.nextStaminaFreshTime - GameApp.getServerTime()) / 1000, 1f);
                staminaCD.onTimeTick = onStaminaTick;
                staminaCD.onTimeOver = onStaminaOver;
            }
            else
            {
                if (!GameApp.gameCDMgr.checkGameCD(GameCDMgr.staminaRecover))
                {
                    staminaCD = GameApp.gameCDMgr.startCDTimer(GameCDMgr.staminaRecover, (GameApp.dataCache.rolePo.nextStaminaFreshTime - GameApp.getServerTime()) / 1000, 1f);
                    staminaCD.onTimeTick = onStaminaTick;
                    staminaCD.onTimeOver = onStaminaOver;
                }
            }

        }

        //停止刷新体力
        //public static void stopRefreshStamina()
        //{
        //    if (staminaCD != null)
        //    {
        //        GameApp.gameCDMgr.removeKey(GameCDMgr.staminaRecover);
        //    }
        //}

        static void onStaminaTick(float runTime, float cd)
        {
            staminaRecoverLeftTime = (int) (cd - runTime);
            if(staminaRecoverLeftTime <= 0)
            {
                staminaRecoverLeftTime = 0;
            }
        }

        static void onStaminaOver()
        {
            GameApp.socketController.sendRequest(ProtocalType.REQUEST_KEY_ROLEREMOTING_CHECKSTAMINAFRESH, "");
            startRefreshStamina();
        }
    }
}
