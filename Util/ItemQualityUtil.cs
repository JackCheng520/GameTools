using UnityEngine;
using System.Collections;
using ECN;

namespace Game.Util
{
    /// <summary>
    /// 创建时间:[2015/04/15]
    /// 作者:Jerry
    /// 
    /// 描述:物品品质工具类.
    /// </summary>
    public class ItemQualityUtil
    {
        /// <summary>
        /// 物品品质.
        /// </summary>
        public enum ITEM_QUALITY
        {
            QUALITY_NONE = 0,//物品没有品质.
            QUALITY_WHITE = 1,//白色品质
            QUALITY_GREEN = 2,//绿色品质
            QUALITY_BLUE = 3,//蓝色品质
            QUALITY_PURPLE = 4,//紫色品质.
            QUALITY_ORANGE = 5,//橙色品质.
            QUALITY_GOLD = 6//金色品质.
        }

        //部位品质精灵名
        public const string QUALITY_WHITE_SPRITE_NAME = "item_quality_1";//白色品质精灵名
        public const string QUALITY_GREEN_SPRITE_NAME = "item_quality_2";//绿色品质精灵名
        public const string QUALITY_BLUE_SPRITE_NAME = "item_quality_3";//蓝色品质精灵名
        public const string QUALITY_PURPLE_SPRITE_NAME = "item_quality_4";//紫色品质精灵名
        public const string QUALITY_ORANGE_SPRITE_NAME = "item_quality_5";//橙色品质精灵名
        public const string QUALITY_GOLDEN_SPRITE_NAME = "item_quality_6";//金色品质精灵名

        //部位品质文字描述
        public static string QUALITY_NONE_DESC = ECNLocalization.Get("无品质");//无品质
        public static string QUALITY_WHITE_DESC = ECNLocalization.Get("白色");//白色
        public static string QUALITY_GREEN_DESC = ECNLocalization.Get("绿色");//绿色
        public static string QUALITY_BLUE_DESC = ECNLocalization.Get("蓝色");//蓝色
        public static string QUALITY_PURPLE_DESC = ECNLocalization.Get("紫色");//紫色
        public static string QUALITY_ORANGE_DESC = ECNLocalization.Get("橙色");//橙色
        public static string QUALITY_GOLDEN_DESC = ECNLocalization.Get("金色");//金色

        /// <summary>
        /// 根据品质枚举类型，获取对应的品质sprite名.
        /// </summary>
        /// <param name="itemQuality">品质枚举</param>
        /// <returns>品质sprite名</returns>
        public static string GetQualitySpriteNameByItemQuality(ITEM_QUALITY itemQuality)
        {
            string ret = string.Empty;
            switch (itemQuality)
            {
                case ITEM_QUALITY.QUALITY_NONE:
                    ret = "";
                    break;
                case ITEM_QUALITY.QUALITY_WHITE:
                    ret = QUALITY_WHITE_SPRITE_NAME;
                    break;
                case ITEM_QUALITY.QUALITY_GREEN:
                    ret = QUALITY_GREEN_SPRITE_NAME;
                    break;
                case ITEM_QUALITY.QUALITY_BLUE:
                    ret = QUALITY_BLUE_SPRITE_NAME;
                    break;
                case ITEM_QUALITY.QUALITY_PURPLE:
                    ret = QUALITY_PURPLE_SPRITE_NAME;
                    break;
                case ITEM_QUALITY.QUALITY_ORANGE:
                    ret = QUALITY_ORANGE_SPRITE_NAME;
                    break;
                case ITEM_QUALITY.QUALITY_GOLD:
                    ret = QUALITY_GOLDEN_SPRITE_NAME;
                    break;
                default:
                    ret = "";
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 根据品质枚举类型，获取品质描述.
        /// </summary>
        /// <param name="itemQuality">品质枚举</param>
        /// <returns>槽位品质描述</returns>
        public static string GetQualityDescByItemQuality(ITEM_QUALITY itemQuality)
        {
            string ret = string.Empty;
            if (itemQuality == ITEM_QUALITY.QUALITY_NONE)
            {
                ret = QUALITY_NONE_DESC;
            }
            else if (itemQuality == ITEM_QUALITY.QUALITY_WHITE)
            {
                ret = QUALITY_WHITE_DESC;
            }
            else if (itemQuality == ITEM_QUALITY.QUALITY_GREEN)
            {
                ret = QUALITY_GREEN_DESC;
            }
            else if (itemQuality == ITEM_QUALITY.QUALITY_BLUE)
            {
                ret = QUALITY_BLUE_DESC;
            }
            else if (itemQuality == ITEM_QUALITY.QUALITY_PURPLE)
            {
                ret = QUALITY_PURPLE_DESC;
            }
            else if (itemQuality == ITEM_QUALITY.QUALITY_ORANGE)
            {
                ret = QUALITY_ORANGE_DESC;
            }
            else if (itemQuality == ITEM_QUALITY.QUALITY_GOLD)
            {
                ret = QUALITY_GOLDEN_DESC;
            }
            return ret;
        }

        //检查物品是否设置可拾取
        //public static bool CheckTryPickMapTreasure(TreasureVo treasureVo)
        //{
        //    ItemPo itemPo = DataCache.GetItemPoById(treasureVo.itemId);
        //    if (itemPo != null)
        //    {
        //        if (itemPo.type == 1)
        //        {
        //            switch (itemPo.quality)
        //            {
        //                case (int)ITEM_QUALITY.QUALITY_WHITE:
        //                    if (GameSetting.CanAutoPickupEquipQualityWhite())
        //                    {
        //                        return true;
        //                    }
        //                    break;
        //                case (int)ITEM_QUALITY.QUALITY_GREEN:
        //                    if (GameSetting.CanAutoPickupEquipQualityGreen())
        //                    {
        //                        return true;
        //                    }
        //                    break;
        //                case (int)ITEM_QUALITY.QUALITY_BLUE:
        //                    if (GameSetting.CanAutoPickupEquipQualityBlue())
        //                    {
        //                        return true;
        //                    }
        //                    break;
        //                case (int)ITEM_QUALITY.QUALITY_PURPLE:
        //                    if (GameSetting.CanAutoPickupEquipQualityPurple())
        //                    {
        //                        return true;
        //                    }
        //                    break;
        //                case (int)ITEM_QUALITY.QUALITY_ORANGE:
        //                    if (GameSetting.CanAutoPickupEquipQualityOrange())
        //                    {
        //                        return true;
        //                    }
        //                    break;
        //            }
        //        }
        //        else if (itemPo.type == 2 || itemPo.type == 6)
        //        {
        //            if (GameSetting.CanAutoPickupItemGem())
        //            {
        //                return true;
        //            }
        //        }
        //        else if (itemPo.type == 3)
        //        {
        //            if (GameSetting.CanAutoPickupItemDrug())
        //            {
        //                return true;
        //            }
        //        }
        //        else if (GameSetting.CanAutoPickupItemOther())
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}

