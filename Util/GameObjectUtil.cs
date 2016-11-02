using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Game.Core.Controller;
using Game.Core.Obj;
using Game.Model.Define;
using Game.Model.PO;
using Game.Core.DataStruct;
using Game.Core.Util;
using UnityEngine.UI;
using Game.Core.Manager;
using Game.UI;
using Game.Model.VO;

namespace Game.Util
{
    public delegate void ItemOnClickDelegate(int itemID);

    public class GameObjectUtil
    {
        public static GameObject findChildByName(GameObject parent, string name)
        {

            if (parent == null) { return null; }

            Transform[] trans = parent.GetComponentsInChildren<Transform>();
            int len = trans.Length;

            for (int i = 0; i < len; i++)
            {
                Transform t = trans[i];
                if (t.name == name)
                {
                    return t.gameObject;
                }
            }

            return null;
        }


        /// <summary>
        /// 旋转；
        /// </summary>
        /// <param name="targetPos">目标点</param>
        public static void rotate(Vector3 targetPos, Transform transform)
        {
            Vector3 targetDir = targetPos - transform.position;
            Vector3 tempDir = Vector3.Cross(transform.forward, targetDir.normalized);
            float dotValue = Vector3.Dot(transform.forward, targetDir.normalized);
            float angle = Mathf.Acos(dotValue) * Mathf.Rad2Deg; //计算夹角；

            if (tempDir.y < 0) angle = angle * -1;

            if (!float.IsNaN(angle))
                transform.RotateAround(transform.position, Vector3.up, angle);
        }

        public static void destory(UnityEngine.Object obj)
        {
            if (obj == null) return;
            GameObject.Destroy(obj);
        }


        public static void playEffect(ParticleSystem[] ps, bool flag)
        {
            playEffect(ps, flag, 1.0f);
        }
        public static void playEffect(ParticleSystem[] ps, bool flag, float speed)
        {
            int particleLen = ps.Length;
            for (int i = 0; i < particleLen; i++)
            {
                ParticleSystem p = ps[i];
                if (flag)
                {
                    p.playbackSpeed = speed;
                    p.Play(true);
                }
                else
                {
                    p.Stop();
                }
            }
        }




        //清除所有子物体
        public static void removeAllChild(GameObject obj)
        {
            while (obj.transform.childCount > 0)
            {
                GameObject sub = obj.transform.GetChild(0).gameObject;
                sub.transform.SetParent(null);
                destory(sub);
            }
        }

        //设置所有子物体为false
        public static void setAllChildFalse(GameObject obj)
        {
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                GameObject sub = obj.transform.GetChild(i).gameObject;
                sub.gameObject.SetActive(false);
            }
        }

        public static void removeImmediately(GameObject obj)
        {
            obj.transform.SetParent(null);
            destory(obj);
        }


        /// <summary>
        /// 是否再扇形内；
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static bool isInView(Sector view, Vector3 pos)
        {
            if (Vector3.Distance(pos, view.org) > view.r)
            {
                return false;
            }

            float angle = Vector3.Angle(pos, view.org);

            if (angle > view.angle)
            {
                return false;
            }

            return true;
        }

        //创建道具图标
        public static GameObject createItem(int itemID, string s = "", bool showName = false)
        {
            GameObject obj = Resources.Load("Prefab/UI/MainUI/ItemPrefab") as GameObject;
            GameObject icon = GameObject.Instantiate(obj);
            ItemPo po = GameApp.dataCache.getGamePo<ItemPo>(itemID);
            Transform qualtiy = icon.transform.Find("Quality");
            Transform image = icon.transform.Find("Image");
            if (po.quality == QualityType.QUALITY_WHITE)
            {
                qualtiy.GetComponent<Image>().sprite = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_COMMON + "ItemQualityWhite");
            }
            else if (po.quality == QualityType.QUALITY_GREEN)
            {
                qualtiy.GetComponent<Image>().sprite = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_COMMON + "ItemQualityGreen");
            }
            else if (po.quality == QualityType.QUALITY_BLUE)
            {
                qualtiy.GetComponent<Image>().sprite = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_COMMON + "ItemQualityBlue");
            }
            else if (po.quality == QualityType.QUALITY_PURPLE)
            {
                qualtiy.GetComponent<Image>().sprite = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_COMMON + "ItemQualityPupple");
            }
            else if (po.quality == QualityType.QUALITY_ORANGE)
            {
                qualtiy.GetComponent<Image>().sprite = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_COMMON + "ItemQualityOrange");
            }
            else if (po.quality == QualityType.QUALITY_GOLD)
            {
                qualtiy.GetComponent<Image>().sprite = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_COMMON + "ItemQualityGold");
            }
            Text txt = icon.transform.Find("TxtNum").GetComponent<Text>();
            txt.text = s;
            icon.name = itemID.ToString();
            Transform name = icon.transform.Find("TxtName");
            Text itemName = name.GetComponent<Text>();
            itemName.text = po.name;
            if (showName)
            {
                name.gameObject.SetActive(true);
            }

            image.GetComponent<Image>().sprite = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_ITEM + po.icon.ToString());
            return icon;
        }

        /// <summary>
        /// 添加道具图标
        /// </summary>
        /// <param name="parent">父物体</param>
        /// <param name="itemID">道具id</param>
        /// <param name="txt">下标描述文字</param>
        /// <param name="itemOnClickDelegate">点击回调</param>
        public static void addItem(Transform parent, int itemID, string txt = "", ItemOnClickDelegate itemOnClickDelegate = null, bool showName = false)
        {
            GameObject obj = createItem(itemID, txt, showName);
            obj.transform.SetParent(parent, false);
            obj.GetComponent<Button>().onClick.AddListener(delegate () { showItemTips(itemID); });
            //if (itemOnClickDelegate != null)
            //{
            //    itemOnClickDelegate(itemID);
            //}
        }

        //public static itemOnClickDelegate itemOnCLick = showItemTips;

        public static void showItemTips(int itemID)
        {
            Debug.Log("点击了道具提示");
            TipMgr.ShowPropTip(itemID,false);
        }

        /// <summary>
        /// 添加道具图标，绑定显示道具提示
        /// </summary>
        /// <param name="parent">父物体</param>
        /// <param name="itemID">道具id</param>
        /// <param name="txt">下标描述文字</param>
        /// <param name="showName">是否在道具icon下方显示文字</param>
        public static void addItemBindShowTips(Transform parent, int itemID, string txt = "", bool showName = false)
        {
            ItemOnClickDelegate itemOnClickDelegate = null;
            itemOnClickDelegate = showItemTips;
            addItem(parent, itemID, txt, itemOnClickDelegate, showName);
        }

        /// <summary>
        /// 显示奖励
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="list"></param>
        public static void showReward(Transform parent, List<IdNumberVo> list)
        {
            GameObjectUtil.removeAllChild(parent.gameObject);
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    GameObjectUtil.addItemBindShowTips(parent, list[i].id, "", true);
                }
            }
        }


        /// <summary>
        /// 播放特效；
        /// </summary>
        /// <param name="target"></param>
        /// <param name="resId"></param>
        public static void playEffect(GameObject target, int resId)
        {
            GameObject effect;

            string node = GameApp.resourcesMgr.getNode(resId);
            if (string.IsNullOrEmpty(node))
            {
                effect = GameApp.effectController.getEffect(resId);
                effect.transform.parent = target.transform;
            }
            else
            {
                GameObject bingingNode = GameObjectUtil.findChildByName(target, node);
                Transform transEffect = bingingNode.transform.Find(resId.ToString());

                if (transEffect == null)
                {
                    effect = GameApp.effectController.getEffect(resId);
                }
                else
                {
                    effect = transEffect.gameObject;
                }

                effect.transform.parent = bingingNode.transform;
            }
            GameApp.effectController.play(effect);


            // effect.transform.position = _me.transform.position;
            // float angle = Vector3.Angle(effect.transform.forward, _me.transform.forward);
            // effect.transform.Rotate(Vector3.up, angle);
            effect.transform.localPosition = Vector3.zero;

        }

        //世界坐标转UI坐标
        public static Vector2 worldToUI(Vector3 pos)
        {
            Vector2 vector2 = Vector2.zero;
            Vector3 vector3 = Vector3.zero;
            Camera uiCam = UICanvas.Instance().UICamera();
            Camera cam3D = GameApp.cameraController.getCurCamera();
            if (cam3D != null && uiCam != null)
            {
                Vector3 screenPos = cam3D.WorldToScreenPoint(pos);
                vector3 = uiCam.ScreenToWorldPoint(screenPos);
            }
            vector2 = new Vector3(vector3.x, vector3.y);
            return vector2;
        }

        //Toggle状态切换
        public static void setToggleState(Transform toggle, bool value, int fontBig, int fontSmall)
        {
            toggle.Find("Label").GetComponent<Text>().fontSize = (value == true ? fontBig : fontSmall);
            toggle.Find("Background/Checkmark").gameObject.SetActive(value);
        }

        /// <summary>
        /// UI界面人物武器切换
        /// </summary>
        /// <param name="roleObj">人物avatar对象</param>
        /// <param name="weaponResId">武器资源id,weaponResId=0则没有装备武器</param>
        /// <param name="layerName">武器LayerMask</param>
        public static void UIRoleSwitchWeapon(GameObject roleObj, int lastWeaponResid, int weaponResId, string layerName)
        {
            //删除上次绑定的武器
            string lastWeaponBandingNodes = GameApp.resourcesMgr.getNode(lastWeaponResid);
            string[] lastWeaponBandingNodeArr = lastWeaponBandingNodes.Split('|');
            foreach (string bingNode in lastWeaponBandingNodeArr)
            {
                string[] nodes = bingNode.Split(',');
                GameObject bindingNode = GameObjectUtil.findChildByName(roleObj, nodes[0]);
                if (bindingNode == null) continue;

                for (int i = 0; i < bindingNode.transform.childCount; i++)
                {
                    GameObjectUtil.destory(bindingNode.transform.GetChild(i).gameObject);
                }
            }

            string strNodes = GameApp.resourcesMgr.getNode(weaponResId);
            string[] strArray = strNodes.Split('|');

            string strNode = string.Empty;
            foreach (string bindNodeName in strArray)
            {
                string[] nodeDetails = bindNodeName.Split(",".ToCharArray());
                strNode = nodeDetails[0];
                GameObject bindingNode = GameObjectUtil.findChildByName(roleObj, strNode);
                if (bindingNode == null) continue;

                for (int i = 0; i < bindingNode.transform.childCount; i++)
                {
                    GameObjectUtil.destory(bindingNode.transform.GetChild(i).gameObject);
                }

                if (weaponResId <= 0)
                {
                    return;
                }

                Transform transform = bindingNode.transform;
                Quaternion qua = roleObj.transform.localRotation;

                GameObject weapon = GameObjectFactory.createWeapon(weaponResId);
                weapon.layer = LayerMask.NameToLayer(layerName);
                foreach (Transform trans in weapon.transform.GetComponentsInChildren<Transform>())
                {
                    trans.gameObject.layer = LayerMask.NameToLayer(layerName);
                }

                weapon.transform.parent = transform;
                weapon.transform.localPosition = Vector3.zero;
                if (nodeDetails.Length > 1)
                {
                    weapon.transform.localEulerAngles = new Vector3(0, int.Parse(nodeDetails[1]), 0);
                }
                else
                {
                    weapon.transform.localRotation = new Quaternion(0, 0, 0, 0.0f);
                }
                weapon.transform.localScale = Vector3.one;
                weapon.SetActive(true);
            }
        }

        //UI界面角色模型换衣服.
        public static void UIRoleSwitchCloth(GameObject curRoleObj, int clothResId)
        {
            //			GameObjectFactory.createUIRole ();
        }

        //显示道具列表
        public static void showRewardList(GameObject parent, string s)
        {
            GameObjectUtil.removeAllChild(parent);
            List<IdNumberVo> rewardList = StringUtil.buildRewardList(s);
            if (s != null)
            {
                for (int i = 0; i < rewardList.Count; i++)
                {
                    GameObjectUtil.addItemBindShowTips(parent.transform, rewardList[i].id);
                }
            }
        }

        /// <summary>
        /// 获取角色半身像
        /// </summary>
        /// <param name="clan"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static Sprite getPortrait(int clan, int gender)
        {
            Sprite s = null;
            if (clan == ClanType.ClanEMei)
            {
                s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_HERO_POTRAIT + "20001");
            }
            else if (clan == ClanType.ClanGaiBang)
            {
                if (gender == GenderType.MALE)
                {
                    s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_HERO_POTRAIT + "20002");
                }
                else if (gender == GenderType.FEMALE)
                {
                    s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_HERO_POTRAIT + "20003");
                }
            }
            else if (clan == ClanType.ClanMingJiao)
            {
                if (gender == GenderType.MALE)
                {
                    s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_HERO_POTRAIT + "20004");
                }
                else if (gender == GenderType.FEMALE)
                {
                    s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_HERO_POTRAIT + "20005");
                }
            }
            else if (clan == ClanType.ClanShaoLin)
            {
                s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_HERO_POTRAIT + "20006");
            }
            else if (clan == ClanType.ClanWuDang)
            {
                if (gender == GenderType.MALE)
                {
                    s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_HERO_POTRAIT + "20007");
                }
                else if (gender == GenderType.FEMALE)
                {
                    s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_HERO_POTRAIT + "20008");
                }
            }
            return s;
        }

        public static GameObject createHeadIcon(int lv, int clan, int gender)
        {
            GameObject obj = Resources.Load("Prefab/UI/MainUI/HeadBGPrefab") as GameObject;
            GameObject icon = GameObject.Instantiate(obj);
            LoadHeadIcon loadHeadIcon = icon.GetComponent<LoadHeadIcon>();
            loadHeadIcon.updateView(lv, clan, gender);
            return icon;
        }

        public static Sprite createClanIcon(int clanType)
        {
            Sprite s = null;
            if (clanType == ClanType.ClanWuDang)
            {
                s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_MAINUI + "CareerWuDang");
            }
            else if (clanType == ClanType.ClanEMei)
            {
                s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_MAINUI + "CareerEmei");
            }
            else if (clanType == ClanType.ClanShaoLin)
            {
                s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_MAINUI + "CareerShaoLin");
            }
            else if (clanType == ClanType.ClanGaiBang)
            {
                s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_MAINUI + "CareerGaiBang");
            }
            else if (clanType == ClanType.ClanMingJiao)
            {
                s = GameApp.resourcesMgr.LoadSprite(ResourcesMgr.SPRITE_MAINUI + "CareerMingJiao");
            }
            return s;
        }

        //获取npc类型
        public static int getNPCType(CharactorVo charactor)
        {
            MonsterPo monsterPo = GameApp.dataCache.getGamePo<MonsterPo>(charactor.itemId);
            return monsterPo.npcType;
        }

        #region 通用添加技能
        /// <summary>
        /// 通用添加技能Icon by chenghaixiao
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="_skillID"></param>
        /// <param name="_type"></param>
        public static void AddSkillIcon(Transform _parent, int _skillID, 
            GameUI_Ctrl_SingleSkillIcon.SkillIconType _type,Probe.Msg callback,params object[] args)
        {
            for (int i = 0; i < _parent.childCount; i++)
            {
                Transform o = _parent.GetChild(i);
                if (o != null)
                {
                    GameObject.Destroy(o.gameObject);
                }
            }

            GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/UI/Common/SingleSkillIcon")) as GameObject;
            obj.transform.SetParent(_parent, false);

            GameUI_Ctrl_SingleSkillIcon ctrl = obj.GetComponent<GameUI_Ctrl_SingleSkillIcon>();
            if (ctrl == null) {
                ctrl = obj.AddComponent<GameUI_Ctrl_SingleSkillIcon>();
            }
            ctrl.Init(_skillID,_type,callback,args);

        }
        /// <summary>
        /// 通用添加技能Icon by chenghaixiao
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="_skillID"></param>
        /// <param name="_type"></param>
        public static void AddSkillIcon(Transform _parent, int _skillID, GameUI_Ctrl_SingleSkillIcon.SkillIconType _type = GameUI_Ctrl_SingleSkillIcon.SkillIconType.SMALL)
        {
            for (int i = 0; i < _parent.childCount; i++)
            {
                Transform o = _parent.GetChild(i);
                if (o != null)
                {
                    GameObject.Destroy(o.gameObject);
                }
            }

            GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/UI/Common/SingleSkillIcon")) as GameObject;
            obj.transform.SetParent(_parent, false);

            GameUI_Ctrl_SingleSkillIcon ctrl = obj.GetComponent<GameUI_Ctrl_SingleSkillIcon>();
            if (ctrl == null)
            {
                ctrl = obj.AddComponent<GameUI_Ctrl_SingleSkillIcon>();
            }
            ctrl.Init(_skillID, _type);
        }
        #endregion

    }
}
