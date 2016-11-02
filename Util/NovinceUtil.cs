using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Game.Util;
using Game.Model.VO;
using Game.Model.PO;
using Game.UI;
using System.Collections.Generic;
using Game.Model.Define;
using System;

/* ==============================
*
* Author: yong
* Time：2016/8/24
* FileName：NovinceUtil
* ===============================
*/
namespace Game.Core.Util
{
    public class NovinceUtil
    {
		public static GameObject currentBtn = null;

		//1	进入场景
		public static int TRIGGER_ENTERSCENES = 1;

		//2	移动
		public static int TRIGGER_MOVE = 2;

		//3	升级
		public static int TRIGGER_UPLV = 3;

		//4	完成任务
		public static int TRIGGER_FINISHEDTASK = 4;

		//5	怪物死亡
		public static int TRIGGER_MONSTERDEATH = 5;

		//6 背包获得物品
		public static int TRIGGER_GETBAGGOODS = 6;

        public void test(){
        }

		public static void showNovincePrefab(NewbiePo newbiePo)
		{
			if (newbiePo == null) return;

			String controllerPrefabString = newbiePo.clickCoordinate;
			String [] controllerPrefabs =controllerPrefabString.Split('|');

			//只配了一条是3个职业都通用的地址，3条的话是3个职业的地址
			String controllerPrefab="";
			if(controllerPrefabs.Length == 1){
				controllerPrefab=controllerPrefabs[0];
			}
			//			else if(controllerPrefabs.Length==3){
			//				int career=DataCache.rolePo.career;
			//				controllerPrefab=controllerPrefabs[career-1];
			//			}

			GameObject controller = GameObject.Find(controllerPrefab);
			if (controller == null) {
				Debug.Log("没有找到路径：" + controllerPrefab);
				return;
			}

			NovinceUtil.currentBtn = controller;
			//novincePanel.SetActive(true);
			NovinceController.Instance().Show();

			GameObject novincePanelPrefab = NovinceController.Instance().m_objRoot;
			if (novincePanelPrefab == null) return;

			//GameObject novincePrefab = novincePanel.transform.Find("NovincePrefab").gameObject;
			GameObject novincePrefab = novincePanelPrefab.transform.Find("NovincePrefab").gameObject;

			Transform currentG = controller.transform;
			Vector3 pos = currentG.transform.position;

			//if(newbiePo.deviant!=null){
			//		float xdeviant=Int32.Parse(newbiePo.deviant.Split(',')[0])/100f;
			//		float ydeviant=Int32.Parse(newbiePo.deviant.Split(',')[1])/100f;
			//		pos += new Vector3(xdeviant,ydeviant,0);
			//}

			//计算当前目标位置；
			Camera uiCamera = UICanvas.Instance().UICamera();

			float orthographicSize = uiCamera.orthographicSize;
			orthographicSize = 1.001f;

			//UIMgr.Get2DCamera();
			Vector3 vec3 = uiCamera.WorldToScreenPoint(pos);

			int width = Int32.Parse((newbiePo.widthHeight).Split(',')[0]);
			int height = Int32.Parse((newbiePo.widthHeight).Split(',')[1]);

			width = Convert.ToInt32( width / orthographicSize);
			height = Convert.ToInt32(height / orthographicSize);

			//UICameraAdjustor adjustor =  uiCamera.GetComponent<UICameraAdjustor>();
			//int[] intArrWH = adjustor.getScreentWidthHeight();

			int screenWidth = Screen.width;//intArrWH[0];
			int screenHeight = Screen.height;//intArrWH[1];

			//定位指示方框，定位箭头,定位提示框；
			GameObject box = novincePrefab.transform.Find("box").gameObject;
			GameObject textObj = box.transform.Find("Text").gameObject;
			GameObject arrow = novincePrefab.transform.Find("arrow").gameObject;
			GameObject boxText = box.transform.Find("Text").gameObject;
			GameObject clickBox = novincePrefab.transform.Find("clickBtn").gameObject;

			Image clickBoxSprite = clickBox.GetComponent<Image>();

			//float fw =  width / 100.0f  * UICamera.orthographicSize;
			//  float fh = height / 100.0f  * UICamera.orthographicSize;
			//clickBox.transform.localScale = new Vector3(fw, fh, 1);

			Vector2 vct2 = new Vector2 (width * orthographicSize, height * orthographicSize);
			clickBoxSprite.rectTransform.sizeDelta = vct2;

			textObj.GetComponent<Text>().text = newbiePo.descTxt;
			novincePrefab.transform.position = pos;


			arrow.transform.localEulerAngles = Vector3.zero;
			novincePrefab.transform.localEulerAngles = Vector3.zero;
			boxText.transform.localEulerAngles = Vector3.zero;
			clickBox.transform.localEulerAngles = Vector3.zero;

			if (vec3.x < Screen.width * 0.5f)
			{
				novincePrefab.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				boxText.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				clickBox.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			}


			if (vec3.y > Screen.height - 320) {
				box.transform.localPosition = new Vector3 (-309f, Screen.height - 320 - vec3.y, 0);
			} else if (vec3.y < 280) {
				box.transform.localPosition = new Vector3 (-309f, 280 - vec3.y, 0);
			}

			//clickBox.transform.localScale=new Vector3(width/100f,height/100f,0f);
			if(newbiePo.id==17){
				arrow.transform.localEulerAngles=new Vector3(0f,180f,0f);
			}
			///////////////////////////////////////////////////////////////////////

			//计算遮罩；
			//UITexture maskTexture = novincePanel.transform.Find("TextureMask").GetComponent<UITexture>();
			//GameObject maskTextureObj = novincePanelPrefab.transform.Find("TextureMask").gameObject;
			RawImage maskTexture = NovinceController.Instance ().m_rawImageTexture;
			if (maskTexture) {
				Material mMat = maskTexture.material;

				//数轴缩到 0 - 1区间；
				// float h = (Screen.height * UICamera.orthographicSize) / maskTexture.localSize.y;
				// float w = (Screen.width * UICamera.orthographicSize) / maskTexture.localSize.x;

				Vector2 maskVct2 = new Vector2 (screenWidth, screenHeight);
				maskTexture.rectTransform.sizeDelta = maskVct2;

				//maskTexture.mainTexture.width  = screenWidth;   // Convert.ToInt32(Screen.width * UICamera.orthographicSize / (900 / 640));// Convert.ToInt32(Screen.width * UICamera.orthographicSize / UICamera.aspect);
				//maskTexture.mainTexture.height = screenHeight; // Convert.ToInt32(Screen.height * UICamera.orthographicSize / (900 / 640)); // Convert.ToInt32(Screen.height * UICamera.orthographicSize / UICamera.aspect); 

				// float orx = (vec3.x - widget.localSize.x * 0.5f) / Screen.width;
				// float ory = (vec3.y - widget.localSize.y * 0.5f) / Screen.height;

				float orx = (vec3.x - width * 0.5f) / Screen.width;
				float ory = (vec3.y - height * 0.5f) / Screen.height;

				// maskTexture.transform.localScale = new Vector3(w, h, 1);


				Vector4 vec4 = new Vector4 (orx, orx + (width * (1.0f / Screen.width)), ory, ory + (height * (1.0f / Screen.height)));
				mMat.SetVector ("_Params", vec4);
			}
			//清除全部正在播放的声音
			//SoundUtil.clearAllPlaySound();
			//播放新手音效 //foxfoxfox
			//SoundUtil.playUISoundPrefab(newbiePo.newbieSound, 5f, "Music/Sound/");
		}

		public static void hideNovincePrefab()
		{
			//novincePanel.SetActive(false);
			NovinceController.Instance().Hidden();
			NovinceController.DestroyInSceneHierarchy ();
		}

		//检测新手触发器
		public static void checkNovinceTrigger(int triggerType){
			//NewbiePo newbiePo = NewbiePo.FindEntity(DataCache.rolePo.newbieStepGroup);
			NewbiePo newbiePo = GameApp.dataCache.getGamePo<NewbiePo>(triggerType);
			bool matched = false;
			int num = GameApp.dataCache.rolePo.listNewbieStepGroup [0].num;
			//判断条件添加
			if (newbiePo != null && newbiePo.id == num) {
				string[] itemStrs = newbiePo.conditions.Split ('|');
                if (itemStrs.Length < 2)
                {
                    DebugUtil.log("NovinceUtil.checkNovinceTrigger:新手表中conditions字段策划配置的不对,Id:" + newbiePo.id, DebugUtil.ERROR);
                    return;
                }
				int listConditionId = Int32.Parse (itemStrs [0]);
				int listConditionNum = Int32.Parse (itemStrs [1]);
				//当前等级
				if (listConditionId == 1) {
					if (GameApp.dataCache.rolePo.lv >= listConditionNum) {
						matched = true;
					}
				}

				//当前任务
				if (listConditionId == 2) {
					for (int i = 0; i < GameApp.dataCache.rolePo.listRoleTasks.Count; i++) {
						IdNumberVo2 listRoleTasksVo = GameApp.dataCache.rolePo.listRoleTasks [i];
						TaskPo taskPo = GameApp.dataCache.getGamePo<TaskPo> (listRoleTasksVo.int1);
						if (listConditionNum == taskPo.id) {
							matched = true;
						}
					}
				}

				//当前剧情
				if (listConditionId == 3) {
					if (listConditionNum == GameApp.scriptController.getLuaG_Process ()) {
						matched = true;
					}
				}

				//当前拥有道具
				if (listConditionId == 4) {
					if (GameApp.dataCache.rolePo.GetBagItemCount (listConditionNum) > 0) {
						matched = true;
					}
				}
			}

			if (matched)
			{
				showNovincePrefab(newbiePo);
			}
		}
    }
}
