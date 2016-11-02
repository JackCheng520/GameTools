using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DebugWindowUtil : MonoBehaviour {
    static Dictionary<string, string> contentList = new Dictionary<string, string>();
    static GameObject canvas = null;
    [SerializeField]
    Button btnClose = null;
    void Awake()
    {
        btnClose.onClick.AddListener(delegate () { closeOnClick(); });
    }

    public static void log(string key, string content)
    {
        if(canvas == null)
        {
            canvas = Instantiate(Resources.Load("Prefab/UI/DebugWindow/DebugWindowPrefab")) as GameObject;
        }
        if (contentList.ContainsKey(key))
        {
            contentList[key] = content;
        }
        else
        {
            contentList.Add(key, content);
        }
        show(key, content);
    }

    static void show(string key, string content)
    {
        Transform anchor = canvas.transform.Find("Anchor");
        Transform tran = anchor.Find(key);
        Text sub = null;
        if (tran == null)
        {
            GameObject obj = Instantiate(Resources.Load("Prefab/UI/DebugWindow/Text")) as GameObject;
            sub = obj.GetComponent<Text>();
            sub.name = key;
            sub.transform.SetParent(anchor, false);
            sub.transform.SetAsLastSibling();
        }
        else
        {
            sub = tran.GetComponent<Text>();
        }
        sub.text = key + ":" + content;
    }

    void closeOnClick()
    {
        Destroy(this.gameObject);
    }


}
