using Game.Core.DataStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Core.Util
{
    public class MathC
    {
        public const int MAXINT = 9999999;

        
        /// <summary>
        /// 是否再矩形范围内；
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static bool isInRect(Rectangle rectangle,Vector3 pos) {
            Vector3 org = rectangle.transform.position - rectangle.transform.forward * 1 + rectangle.offset ;
            Vector3 vec3 = (rectangle.transform.worldToLocalMatrix * (pos - org));
            //vec3 -= rectangle.transform.localPosition;
            return (vec3.x > -rectangle.width && vec3.x < rectangle.width && vec3.z > 0 && vec3.z < rectangle.length);
        }


        /// <summary>
        /// 是否在扇形内；
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static bool isInSector(Sector sector,Vector3 pos)
        {
            Vector3 org = sector.org + sector.offset;
            if (Vector3.Distance(pos, org) > sector.r) { return false; }
            float angle = Vector3.Angle(pos, sector.org);
            if (angle > sector.angle) { return false; }

            return true;
        }





        /// <summary>
        /// 获取向量模；
        /// </summary>
        /// <param name="vect"></param>
        /// <returns></returns>
        public static double getVector3Size(Vector3 vect) {

            float t = vect.x * vect.x + vect.y * vect.y + vect.z * vect.z;
            return Math.Sqrt(t); ;
        }

        /// <summary>
        /// 世界坐标到屏幕；
        /// </summary>
        /// <param name="worldPosition"></param>
        /// <returns></returns>
        public static Vector2 worldToSceen(Vector3 worldPosition)
        {
            Vector2 position = Camera.main.WorldToScreenPoint(worldPosition);
            position.y = Screen.height - position.y;
            return position;
        }



         /// <summary>  
      /// 求num在n位上的数字,取个位,取十位  
      /// </summary>  
      /// <param name="num">正整数</param>  
       /// <param name="n">所求数字位置(个位 1,十位 2 依此类推)</param>  
       public static int findNum(int num, int n)  
       {  
           int power = (int)Math.Pow(10, n);  
           return (num - num / power * power) * 10 / power;  
       }


       public static int sum(int[] elements) {
           int result = 0;
           for (int i = 0, len = elements.Length; i < len; i++) {
               result += elements[i];
           }
           return result;
       }
    }
}
