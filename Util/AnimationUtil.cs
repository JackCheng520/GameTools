using Game.Core.Obj;
using Game.Core.Obj.Fms;
using Game.Model.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Util
{
    public delegate int OnGetMaxValue(int value);
    public class AnimationUtil
    {

        public static float getMaxLength(Animator animator,int layer){
            
            float result = 0;
            AnimatorClipInfo[] acs = animator.GetCurrentAnimatorClipInfo(layer);
            for (int i = 0, len = acs.Length; i < len; i++) {
                result = Math.Max(result, acs[i].clip.length);
            }
            return result;
        }

        public static StateMachineBehaviour getStatemachineBehaviour(Charactor target, string type)
        {

            //switch (type)
            //{
            //    case AnimationUtil.AnimalType.RUN: return target.animator.GetBehaviour<CharactorRun>();
            //    case AnimationUtil.AnimalType.IDLE: return target.animator.GetBehaviour<CharactorIdle>();
            //    case AnimationUtil.AnimalType.HIT: return target.animator.GetBehaviour<CharactorHit>();
            //    default: break;
            //}

            return null;
        }


        public static bool isName(Animator animator,string name){
            return (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == Animator.StringToHash(name));
        }


        public static string getIdleAnimName(int gendar,int weaponType){
            string strGendar = (gendar > 0) ? "m" : "f";
            return "idle_" + strGendar + weaponType;
        }

        public static string getRunAnimName(int gendar, int weaponType) {
            string strGendar = (gendar > 0) ? "m" : "f";
            return "run_" + strGendar + weaponType;
        }

        public static List<IdNumberVo2> getProgressFloatRate(float increaseValue, int oldLv, float oldValue, OnGetMaxValue onGetMaxValue)
        {
            List<IdNumberVo2> retList = new List<IdNumberVo2>();
            float curValue = oldValue;
            int curLv = oldLv;
            float curMax = onGetMaxValue(curLv);
            float curLeftValue = increaseValue;
            float rate = 0.04f;
            while (curLeftValue > 0)
            {
                IdNumberVo2 vo2 = new IdNumberVo2();
                float addUnit = rate * increaseValue;
                curLeftValue -= addUnit;
                if(curLeftValue < 0)
                {
                    curValue += addUnit;
                    curValue += curLeftValue;
                }
                else
                {
                    curValue += addUnit;
                }
                //如果升级
                if (curValue >= curMax)
                {
                    curLv += 1;
                    curValue = curValue - curMax;
                    curMax = onGetMaxValue(curLv);
                }
                vo2.int1 = (int)curValue;
                vo2.int2 = (int)curMax;
                vo2.int3 = curLv;
                retList.Add(vo2);
            }
            return retList;
        }

    }
}
