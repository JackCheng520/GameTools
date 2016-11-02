using Game.Core.DataStruct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Core.Util
{
    /// <summary>
    /// 数据结构工具类；
    /// </summary>
    public class DataStructTool
    {
        
           // 打乱列表
        public static void shuffle<T>(ref List<T> list)
        {
            int size = list.Count;
            System.Random random = new System.Random();
        
            for(int i = 0; i < size; i++) {
                // 获取随机位置
                int randomPos = random.Next(size);
            
                // 当前元素与随机元素交换
                T temp = list[i];
                list[i] = list[randomPos];
                list[randomPos] = temp;
            }
        }

        

        /// <summary>
        /// 字符数组 转换 整型数组；
        /// </summary>
        /// <param name="strArr"></param>
        public static int[] strArrayToIntArray(string[] strArr) {
            int len = strArr.Length;
            int[] resultArray = new int[len];
            for (int i = 0; i < len; i++) {
                resultArray[i] = Convert.ToInt32(strArr[i]);
            }

            return resultArray;
            
        }

        /// <summary>
        /// 字符数组 转换 整型数组；
        /// </summary>
        /// <param name="strArr"></param>
        public static float[] strArrayToFloatArray(string[] strArr)
        {
            int len = strArr.Length;
            float[] resultArray = new float[len];
            for (int i = 0; i < len; i++)
            {
                resultArray[i] = Convert.ToSingle(strArr[i]);
            }

            return resultArray;

        }



        /// <summary>
        /// 获取某位置的九宫格索引；
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="celldata"></param>
        /// <returns></returns>
        public static Vector2 getGridIndex(float x,float y,CellData celldata) {

            int gridX =  Convert.ToInt32(Math.Floor(x / celldata.cellSizeX));
            int gridY =  Convert.ToInt32(Math.Floor(y / celldata.cellSizeY));

            //处理边界；
            if (x % celldata.cellSizeX == 0) gridX -= 1;
            if (y % celldata.cellSizeY == 0) gridY -= 1;

            if(gridX < 0) gridX  = 0;
            if (gridY < 0) gridY = 0;

            Vector2 grid = Vector2.zero;
            grid.x = gridX;
            grid.y = gridY;

            return grid;

        }

        /// <summary>
        /// 是否再九宫格内；
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="celldata"></param>
        /// <param name="gridCenter"></param>
        /// <returns></returns>
        public static bool isIn9Grid(float x,float y, CellData celldata,Vector2 gridCenter) {
            Vector2 gridIndex = DataStructTool.getGridIndex(x, y, GameApp.sceneController.cellData);

            if( Math.Abs(gridCenter.x - gridIndex.x) < 2 && Math.Abs(gridCenter.y - gridIndex.y) < 2) return true;

            return false;
        }
 
    }
}
