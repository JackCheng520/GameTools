using UnityEngine;
using System.Collections;
using Game.Util;

public class DebugScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPostRender()
    {
        DebugUtil.drawGrids();
        DebugUtil.drawMonsterProxy();

    }
}
