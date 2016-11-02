using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Threading;
using ECN;
using Game.Model.Define;
using Game.Model.PO;
using Game.Util;
using Game.Model.Cache;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.Events;
using MVVMDynamic;
using UnityEngine.SceneManagement;
using NJG;
using Game.Core.Manager;
using System.IO;
using Game.Model.VO;

namespace Game.Core.Util
{
    public class GMCommandUtil
    {
        static string[] commandList = new string[] { "changescene", "123" };

        public static bool  volidate(string s)
        {
            string[] ss = s.Split('@');
            if (ss.Length == 2)
            {
                return chooseCmd(ss[0], ss[1]);
            }
            return false; 
        }

        static bool chooseCmd(string cmd, string value)
        {
            if(cmd.CompareTo(commandList[0]) == 0)
            {
                changeScene(int.Parse(value));
                return true;
            }
            return false;
        }

        static void changeScene(int roomID)
        {
            GameApp.changeScene(roomID);
        }
    }
 }

