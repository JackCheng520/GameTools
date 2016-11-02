using UnityEngine;
using System.Collections;
using Game.Model.VO;
using System.Collections.Generic;

namespace Game.Util
{
    public class AttributesUtil
    {
		
        //属性名数组
        public static string[] AttributeNameArray = { "Yin", "Yang", "Gang", "Rou", "Qi", "Life", "Attack", "Defense"
                                                    , "YinAttack", "YangAttack", "GangAttack", "RouAttack", "QiAttack"
                                                    , "YinDefense", "YangDefense", "GangDefense", "RouDefense", "QiDefense"
                          , "Dodge", "Hit", "Crit", "Toughness", "CritDamage", "ReboundDamage"
                          , "DamageIncrease", "DamageReduction","MP","GQ","MoveSpeed","SwordAttack","DoubleStilettoAttack","RodAttack",
                "GlovesAttack","DoubleKnifeAttack","SwordDefense","DoubleStilettoDefense","RodDefense","GlovesDefense","DoubleKnifeDfense"
    };

        /**  [4/25/2016 hjw]
            * @desc:   返回属性字符串
            * @param:  attriList 属性列表
            * @return: 字符串
            **/
        public static string GetAttributesString(List<IdNumberVo> attriList)
        {
            string retStr = "";
            foreach (IdNumberVo idVo in attriList)
            {
                string tmpStr = LocalizationText.GetText(AttributeNameArray[idVo.id - 1]) + "：" + idVo.num + "\n";
                retStr += tmpStr;
            }
            return retStr;
        }

        /**  [5/4/2016 hjw]
            * @desc:   返回属性字符串
            * @param:  idVo 单属性
            * @param:  isShowNum 是否显示数值/或问号
            * @return: 字符串
            **/
        public static string GetAttributesString(IdNumberVo idVo, bool isShowNum = true)
        {
            string retStr = "";
            if (null != idVo)
            {
                retStr = LocalizationText.GetText(AttributeNameArray[idVo.id - 1]) + "：" + (isShowNum ? idVo.num.ToString() : "？？？？");
            }
            return retStr;
        }

        /// <summary>
        /// 返回属性字符串
        /// </summary>
        /// <param name="idVo">idVo 单属性</param>
        /// <param name="connect">链接符</param>
        /// <param name="isShowNum">isShowNum 是否显示数值/或问号</param>
        /// <returns></returns>
        public static string GetAttributesString(IdNumberVo idVo, string connect, bool isShowNum = true)
        {
            string retStr = "";
            if (null != idVo)
            {
                retStr = LocalizationText.GetText(AttributeNameArray[idVo.id - 1]) + connect + (isShowNum ? idVo.num.ToString() : "？？？？");
            }
            return retStr;
        }
    }

}
