using UnityEngine;
using System.Collections;
using Game.Model.Define;
using Game.Core.Manager;
using UnityEngine.UI;

namespace Game.Util
{
    public  class SpriteLoadUtil
    {
        //public static Sprite loadSprite(string spriteName)
        //{
        //    return Resources.Load<GameObject>("Prefab/Image/" + spriteName).GetComponent<SpriteRenderer>().sprite;
        //}

        public static Sprite loadImageSprite(string spriteName)
        {
            return Resources.Load<GameObject>("Prefab/Sprite/" + spriteName).GetComponent<SpriteRenderer>().sprite;
        }

        public static Sprite loadMoneyIcon(int type)
        {
            Sprite sprite = null;
            if(type == MoneyType.gold)
            {
                sprite = loadImageSprite(ResourcesMgr.SPRITE_CHAT + "gold");
            }
            else if(type == MoneyType.bindGold)
            {
                sprite = loadImageSprite(ResourcesMgr.SPRITE_CHAT + "bindGold");
            }
            else if (type == MoneyType.diamond)
            {
                sprite = loadImageSprite(ResourcesMgr.SPRITE_CHAT + "diamond");
            }
            else if (type == MoneyType.bindDiamond)
            {
                sprite = loadImageSprite(ResourcesMgr.SPRITE_CHAT + "bindDiamond");
            }
            else if (type == MoneyType.skillPoint)
            {
                sprite = loadImageSprite(ResourcesMgr.SPRITE_CHAT + "skillPoint");
            }
            else if (type == MoneyType.prestige)
            {
                sprite = loadImageSprite(ResourcesMgr.SPRITE_CHAT + "prestige");
            }
            return sprite;
        }

        public static void setMoneyIcon(Image image, int type)
        {
            image.sprite = loadMoneyIcon(type);
        }
    }
}
