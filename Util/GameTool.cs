using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Game.Core.Manager;
using Game.UI;
//========================================
// 游戏中的重复方法封装 by chx
//========================================
public class GameTool : MonoBehaviour
{
    /// <summary>
    /// 加载UIprefab路径
    /// </summary>
    private static string UIRootPath = "Prefab/UI/";

    private static string UIRootTexturePath = "Icon/";

    /// <summary>
    /// Load UI GameObject
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static GameObject LoadUIObj(string path)
    {
        string arg = UIRootPath + path;
        GameObject obj = GameObject.Instantiate(Resources.Load(arg)) as GameObject;

        return obj;
    }

    static string wuxueSubPath = "wuxue/";
    public static Sprite LoadSkillGroupsIcon(string name)
    {
        string arg = UIRootTexturePath + wuxueSubPath + name;

        Sprite tex = Resources.Load(arg, typeof(Sprite)) as Sprite;
        if (tex == null)
        {
            Debug.Log(name + "is none");
        }
        return tex;
    }

    static string skillSubPath = "skill/";
    public static Sprite LoadSkillIcon(string name)
    {
        string arg = UIRootTexturePath + skillSubPath + name;

        Sprite tex = Resources.Load(arg, typeof(Sprite)) as Sprite;
        if (tex == null)
        {
            Debug.LogError(name + "is none");
        }
        return tex;
    }

    /// <summary>
    /// 挂载UI父节点
    /// </summary>
    public const string UICanvasName = "UICanvas";
    public static void SetToUIParent(GameObject obj)
    {
        GameObject _UICanvas = GameObject.Find(UICanvasName);
        if (_UICanvas == null)
        {
            GameObject o = Resources.Load("Prefab/UI/MainUI/Canvas") as GameObject;
            _UICanvas = Instantiate(o);
            _UICanvas.name = UICanvasName;
        }

        obj.transform.SetParent(_UICanvas.transform, false);
    }

    public static string GetSkillGroupsWeaponName(int type)
    {
        string arg = "";
        switch ((eSkillWeaponType)type)
        {//1、剑 2、双刺 3、棍 4、拳套 5、双刀
            case eSkillWeaponType.SWORD:
                arg = "剑";
                break;
            case eSkillWeaponType.STINGER:
                arg = "双刺";
                break;
            case eSkillWeaponType.STICK:
                arg = "棍";
                break;
            case eSkillWeaponType.GLOVES:
                arg = "拳套";
                break;
            case eSkillWeaponType.DUALBLADE:
                arg = "双刀";
                break;
        }

        return arg;
    }

    /// <summary>
    /// 相机位置转换
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="worldCamera"></param>
    /// <returns></returns>
    public static Vector3 ConvertScreenToWorld(Vector3 pos,Camera worldCamera)
    {
        Camera uiCamera = UICanvas.Instance().UICamera();
        Vector3 tempV =  uiCamera.WorldToScreenPoint(pos);
        tempV.z = 20;
        Vector3 v3 = worldCamera.ScreenToWorldPoint(tempV);

        return v3;
    }


}
