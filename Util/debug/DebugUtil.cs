using UnityEngine;
using System.Collections;
using Game.Core.Obj;
using Game.UI;
using System.Collections.Generic;

namespace Game.Util
{
    public class DebugUtil{

        const int CONSOLE = 0;
        const int RUNTIME = 1;


        public const int ERROR    = 0;
        public const int WARNING  = 1;
        public const int INFO     = 2;
        public const int QINGGONG = 3;

        public static int target  = CONSOLE;
        public static int    type = 0;
        public static bool enable = true;

        public static bool isBattleEdit = false;
        public static bool isDistEdit   = false;

        public static void  drawRay(Vector3 start,Vector3 dir,Color color,float duration){
            if (!enable) return;

            Debug.DrawRay(start, dir, color, duration);
        }           
        

        public static void drawGrids() {
            if (!enable) return;

            if (GameApp.sceneController.hero == null)  return;

           int mapWidth  =  GameApp.sceneController.cellData.mapWidth;
           int mapHeight =  GameApp.sceneController.cellData.mapHeight;
           
           int cellSizeX = GameApp.sceneController.cellData.cellSizeX;
           int cellSizeY = GameApp.sceneController.cellData.cellSizeY;

           int numX = (mapWidth / cellSizeX);
           int numY = (mapHeight / cellSizeY);

           float y  = GameApp.sceneController.hero.transform.position.y + 0.4f;  
           float x = 0; float z = 0;
            GL.Color(Color.red);
            GL.Begin(GL.LINES);

            for (int i = 0; i < numY; i++)
            {
                z = cellSizeY * i;
                GL.Vertex(new Vector3(x, y, z));
                GL.Vertex(new Vector3(mapWidth, y, z));
            }

            z = 0;
            for (int i = 0; i < numX; i++)
            {
                x = cellSizeX * i;
                GL.Vertex(new Vector3(x, y, z));
                GL.Vertex(new Vector3(x, y, mapHeight));
            }

            GL.End();
        }



        public static void log(string str,int aType = INFO) {
            if (!enable) return;

            if (target == CONSOLE) {
                switch (aType) {
                    case INFO:     Debug.Log(str);          return;
                    case WARNING:  Debug.LogWarning(str);   return;
                    case ERROR:    Debug.LogError(str);     return;
                    case QINGGONG: Debug.Log(str);          return;
                    default: break;
                }
            }

        }


        public static void drawMonsterProxy() {

            if(!enable) return;

            createLineMaterial();
            //Debug.DrawLine(posStart, posEnd);
            GL.Color(Color.red);
            mat.SetPass(0);

            GL.Begin(GL.LINES);

            for (int i = 0, len = GameApp.sceneController.monsters.Count; i < len; i++) {
                Monster monster = GameApp.sceneController.monsters[i];

                if (monster == null) continue;
                if (monster.charactorVo.proxyId  == 0) continue;

                Charactor charactor = GameApp.sceneController.getCharactor(monster.charactorVo.proxyId);
                if (charactor == null) continue;
                GL.Vertex(monster.transform.position + Vector3.up);
                GL.Vertex(charactor.transform.position + Vector3.up);
            }

            GL.End();
        }


        private static Material mat;

        //画线框用的mat
        public static void createLineMaterial()
        {
            if (mat != null) return;
            mat = new Material("Shader \"Lines/Colored Blended\" {" +
                                   "SubShader { Pass { " +
                                   " Blend SrcAlpha OneMinusSrcAlpha " +
                                   " ZWrite Off Cull Off Fog { Mode Off } " +
                                   " BindChannels {" +
                                   " Bind \"vertex\", vertex Bind \"color\", color }" +
                                   "} } }");
            mat.hideFlags = HideFlags.HideAndDontSave;
            mat.shader.hideFlags = HideFlags.HideAndDontSave;



        }


        public static void showServerError() {

            if (!enable) return; 

            if (GameApp.dataCache.errorQueue.Count > 0)
            {
                string erroInfo = GameApp.dataCache.errorQueue.Dequeue();
                PopUpTips.showText(erroInfo);
            }

        }


        public static void printTime(string  sign) {
            DebugUtil.log(sign + ":" + Time.fixedTime.ToString());
        }

        #region 单人副本相关；
        /// <summary>
        /// 场景中怪物全部死亡；
        /// </summary>
        public static void monsterAllDie() {
            if (!enable) return;

            List<Monster> list = GameApp.sceneController.monsters;
            for (int i = 0, len = list.Count; i < len; i++) {
                GameApp.virtualServerController.die(list[i]);
            }

        }


        #endregion

    }
}