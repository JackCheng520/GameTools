using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Model.Define;
using UnityEngine;

namespace Game.Util
{
    class ColorUtil
    {
        public static string COLOR_UI_GREEN = "00FF00";
        public static string COLOR_UI_RED = "FF0000";
        public static string COLOR_UI_GOLD = "edd3ba";
        public static string COLOR_UI_YELLOW = "eff800";
        public static Color TXT_Yellow = new Color((float)254/255, (float)255/255, (float)172/255);
        /**  [2014/11/04 UQIANTU]
        * @desc:	根据聊天类型返回聊天的颜色值
        * @param:	int 类型
        * @return:  string
        **/
        public static string ColorByType(int type)
        {
            switch (type)
            {
                case ChatType.WORLD:
                    return "[e2d0aa]";
                case ChatType.CHAT:
                    return "[fe00df]";
                case ChatType.NEAR:
                    return "[fefefe]";
                case ChatType.FRIENDS:
                    return "[00baff]";
                case ChatType.SYSTEM:
                    return "[ff0000]";
                case ChatType.TEAM:
                    return "[00ffca]";
            }

            return "[fff000]";
        }

        /**  [2015/11/06 UQIANTU]
        * @desc:	根据品质获取颜色值
        * @param:	int 品质
        * @return:  string
        **/
        public static string ColorByQuality(int type)
        {
            string color = "[ffffff]";
            switch (type)
            {
                case QualityType.QUALITY_WHITE:
                    color = "[e6e1da]";
                    break;
                case QualityType.QUALITY_GREEN:
                    color = "[60ff00]";
                    break;
                case QualityType.QUALITY_BLUE:
                    color = "[005aff]";
                    break;
                case QualityType.QUALITY_PURPLE:
                    color = "[ff00fc]";
                    break;
                case QualityType.QUALITY_ORANGE:
                    color = "[ff9c00]";
                    break;
                case QualityType.QUALITY_GOLD:
                    color = "[ffe800]";
                    break;
            }
            return color;
        }

        /// <summary>
        /// 获取品质文字描述颜色格式化字符串.
        /// </summary>
        /// <returns>返回品质颜色值.</returns>
        /// <param name="itemQuality">属性品质.</param>
        public static string GetQualityColorByQuality(ItemQualityUtil.ITEM_QUALITY itemQuality)
        {
            string ret = string.Empty;
            switch (itemQuality)
            {
                case ItemQualityUtil.ITEM_QUALITY.QUALITY_WHITE://白色品质
                    ret = "[e6e1da]{0}[-]";
                    break;
                case ItemQualityUtil.ITEM_QUALITY.QUALITY_GREEN://绿色品质
                    ret = "[18ff00]{0}[-]";
                    break;
                case ItemQualityUtil.ITEM_QUALITY.QUALITY_BLUE://蓝色品质
                    ret = "[228aff]{0}[-]";
                    break;
                case ItemQualityUtil.ITEM_QUALITY.QUALITY_PURPLE://紫色品质.
                    ret = "[ff02fc]{0}[-]";
                    break;
                case ItemQualityUtil.ITEM_QUALITY.QUALITY_ORANGE://橙色品质.
                    ret = "[ff9c00]{0}[-]";
                    break;
                case ItemQualityUtil.ITEM_QUALITY.QUALITY_GOLD://金色品质.
                    ret = "[fffc00]{0}[-]";
                    break;
            }
            return ret;
        }

        //返回UI绿色和红色值，用于0/12这种自动变色需求
        public static string ColorByUiGreenAndRed(bool condition, string text)
        {
            return ColorByBoolean(condition, COLOR_UI_GREEN, COLOR_UI_RED, text);
        }

        //返回颜色值
        public static string ColorByBoolean(bool conditon, string color1, string color2, string text)
        {
            if (conditon)
            {
                return "[" + color1 + "]" + text + "[-]";
            }
            else
            {
                return "[" + color2 + "]" + text + "[-]";
            }
        }

        //给文字附色
        public static string ColorText(string color, string text)
        {
            return "[" + color + "]" + text + "[-]";
        }

        //获取暗金色
        public static Color getGold()
        {
            return new Color((float)226 / 255, (float)207 / 255, (float)172 / 255);
        }

        /**  [4/27/2016 hjw]
        * @desc:   返回带品质颜色字符串
        * @param:  resStr 内容字符串
        * @param:  quality 品质
        * @return: 结果字符串
        **/
        public static string GetColorStringByQuality(string resStr, int quality)
        {
            string colorStr = "#ffffff";
            switch (quality)
            {
                case QualityType.QUALITY_WHITE:
                    colorStr = "#e6e1daff";
                    break;
                case QualityType.QUALITY_GREEN:
                    colorStr = "#60ff00ff";
                    break;
                case QualityType.QUALITY_BLUE:
                    colorStr = "#005affff";
                    break;
                case QualityType.QUALITY_PURPLE:
                    colorStr = "#ff00fcff";
                    break;
                case QualityType.QUALITY_ORANGE:
                    colorStr = "#ff9c00ff";
                    break;
                case QualityType.QUALITY_GOLD:
                    colorStr = "#ffe800ff";
                    break;
            }

            return "<color=" + colorStr + ">" + resStr + "</color>";
        }
    }
}
