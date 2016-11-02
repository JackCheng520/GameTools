using Game.Model.VO;
using Game.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Core.Util
{
    /**
     * 字符串
     * 2015/4/23 Johnny
     */
    class StringUtil
    {
        /**
         * 合并
         * 2015/4/23 Johnny
         */
        public static String implode(String delim, List<int> ary) {
		    if(ary.Count<=0){
			    return null;
		    }
		    String finalStr ="";
	        for(int i=0; i<ary.Count(); i++) {
	            if(i!=0) {finalStr+=delim; }
	            finalStr+=ary[i];
	        }

            return finalStr;
    	}

        /**
         * 获得JAVA风格字符串
         * 2015/4/23 Johnny
         */
        public static String getJavaStyleString(String fieldName)
        {
            char[] chars = fieldName.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char current = chars[i];
                if (current == '_')
                {
                    if ((i + 1) <= chars.Length - 1)
                    {
                        char c = chars[i + 1];
                        string value = c.ToString(); 
                        value = value.ToUpper();
                        chars[i + 1] = value[0];
                    }
                }
            }
            String result = new string(chars);
            result = result.Replace("_", "");
            return result;
        }

        /**
        * 方法功能:
        * 更新时间:2010-10-28, 作者:johnny
        * @param javaFieldName
        * @return 首字母大写
        */
        public static String firstUpper(String javaFieldName)
        {
            char[] chars = javaFieldName.ToCharArray();
            String single = chars[0].ToString().ToUpper();
            chars[0] = single[0];
            return new string(chars);
        }

        /**
         * 切割字符串
         * 2015/4/23 Johnny
         */
        public static List<String> Split(string p1, char token)
        {
            String[] strs = p1.Split(token);
            return strs.ToList<String>();
        }

        /**
         * 切割INT
         * 2015/4/23 Johnny
         */
        public static List<int> SplitInt(string p1, char token)
        {
            if (p1 == null || p1.Equals(""))
            {
                return new List<int>();
            }
            String[] strs = p1.Split(token);
            int[] ints = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                ints[i] = Convert.ToInt32(strs[i]);
            }
            return ints.ToList<int>();
        }

        /**
         * 创建array
         * 2015/4/23 Johnny
         */
        public static List<List<int>> createIntArrays(string strs)
        {
            if (strs == null || strs.ToString() == "")
            {
                return new List<List<int>>();
            }
            List<List<int>> items = new List<List<int>>();

            string[] str1s = strs.Split(',');
            for (int i = 0; i < str1s.Length; i++)
            {
                string[] strs2 = str1s[i].Split('|');
                List<int> values = new List<int>();
                for (int j = 0; j < strs2.Length; j++)
                {
                    values.Add(Convert.ToInt32(strs2[j]));
                }
                items.Add(values);
            }
            return items;
        }

        /**
         * 创建数组
         * 2015/4/23 Johnny
         */
        public static List<int> createSingleIntArrays(string taskCondition)
        {
            string[] strs2 = taskCondition.Split('|');
            List<int> values = new List<int>();
            for (int j = 0; j < strs2.Length; j++)
            {
                values.Add(Convert.ToInt32(strs2[j]));
            }
            return values;
        }

        /**  [4/25/2016 hjw]
        * @desc:   转成IdNumberVo列表
        * @param:  resStr 源字符串
        * @return: list<IdNumberVo> 列表
        **/
        public static List<IdNumberVo> GetIdNumberVoList(string resStr)
        {
            return GetIdNumberVoList(resStr, ',', '|');
        }

        /**  [4/25/2016 hjw]
        * @desc:   转成IdNumberVo列表
        * @param:  resStr 源字符串
        * @param:  sign1 一级分隔符
        * @param:  sign2 二级分隔符
        * @return: list<IdNumberVo> 列表
        **/
        public static List<IdNumberVo> GetIdNumberVoList(string resStr, char sign1, char sign2)
        {
            List<IdNumberVo> listRet = null;
            if (!string.IsNullOrEmpty(resStr))
            {
                listRet = new List<IdNumberVo>();
                string[] firstArray = resStr.Split(sign1);
                for (int i = 0; i < firstArray.Length; ++i)
                {
                    string[] secondArray = firstArray[i].Split(sign2);
                    if (secondArray.Length > 1)
                    {
                        IdNumberVo idVo = new IdNumberVo();
                        idVo.id = int.Parse(secondArray[0]);
                        idVo.num = int.Parse(secondArray[1]);
                        listRet.Add(idVo);
                    }
                }
            }
            return listRet;
        }

		/**  [2016/10/11 yong]
        * @desc:   转成IdNumberVo2列表
        * @param:  resStr 源字符串
        * @return: list<IdNumberVo2> 列表
        **/
		public static List<IdNumberVo2> GetIdNumberVo2List(string resStr)
		{
			return GetIdNumberVo2List(resStr, ',', '|');
		}
		/**  [2016/10/11 yong]
        * @desc:   转成IdNumberVo2列表
        * @param:  resStr 源字符串
        * @param:  sign1 一级分隔符
        * @param:  sign2 二级分隔符
        * @return: list<IdNumberVo2> 列表
        **/
		public static List<IdNumberVo2> GetIdNumberVo2List(string resStr, char sign1, char sign2)
		{
			List<IdNumberVo2> listRet = null;
			if (!string.IsNullOrEmpty(resStr))
			{
				listRet = new List<IdNumberVo2>();
				string[] firstArray = resStr.Split(sign1);
				for (int i = 0; i < firstArray.Length; ++i)
				{
					string[] secondArray = firstArray[i].Split(sign2);
					if (secondArray.Length > 1)
					{
						IdNumberVo2 idVo = new IdNumberVo2();
						idVo.int1 = int.Parse(secondArray[0]);
						idVo.int2 = int.Parse(secondArray[1]);
						idVo.int3 = int.Parse(secondArray[2]);
						listRet.Add(idVo);
					}
				}
			}
			return listRet;
		}

        /**  [5/26/2016 hjw]
        * @desc:   转成IdNumberVo列表的列表
        * @param:  sign1 一级分隔符
        * @param:  sign2 二级分隔符
        * @param:  sign3 三级分隔符
        * @return: void
        **/
        public static List<List<IdNumberVo>> GetIdNumberVoListList(string resStr, char sign1)
        {
            List<List<IdNumberVo>> retList = null;
            if (!string.IsNullOrEmpty(resStr))
            {
                retList = new List<List<IdNumberVo>>();
                string[] firstArray = resStr.Split(sign1);
                for (int i = 0; i < firstArray.Length; ++i)
                {
                    List<IdNumberVo> tmpList = GetIdNumberVoList(firstArray[i]);
                    if (tmpList != null)
                    {
                        retList.Add(tmpList);
                    }
                }
            }
            return retList;
        }

        public static float[] converToFloatArr(string str, char division) {
            string[] strArr = str.Split(division);
            int len = strArr.Length;
            float[] result = new float[len];

            for (int i = 0; i < len; i++)
            {
                result[i] = Convert.ToSingle(strArr[i]);
            }

            return result;
        }

        public static int[] converToIntArr(string str, char division)
        {
            string[] strArr = strArr = str.Split(division);
            int len         = strArr.Length;
            int[] result    = new int[len];

            for (int i = 0; i < len; i++) {
                result[i] = Convert.ToInt32(strArr[i]);
            }

            return result;
        }

        public static Vector3 getVector3ByString(string str,char divite)
        {
            if (string.IsNullOrEmpty(str)){
                return Vector3.zero;
            }

            string[] strs = str.Split(divite);

            Vector3 vec3 = new Vector3(Convert.ToSingle(strs[0]), Convert.ToSingle(strs[1]), Convert.ToSingle(strs[2]));

            return vec3;

        }

        public static Vector3[] getVector3sByString(string str,char divi1,char divi2) {

            if (string.IsNullOrEmpty(str)) return null;

            string[] strGroups = str.Split(divi1);
            int len = strGroups.Length;
            Vector3[] results = new Vector3[len];

            for (int i = 0; i < len; i++) {
                string[] attStr = strGroups[i].Split(divi2);
                Vector3 vec3 = new Vector3(Convert.ToSingle(attStr[0]), Convert.ToSingle(attStr[1]), Convert.ToSingle(attStr[2]));
                results[i] = vec3;
            }

            return results;
        }

        public static List<IdNumberVo> buildRewardList(string express)
        {
            List<IdNumberVo> rewardList = new List<IdNumberVo>();
            string[] rewards = express.Split(',');
            for (int i = 0; i < rewards.Length; i++)
            {
                string[] reward = rewards[i].Split('|');
                IdNumberVo vo = new IdNumberVo();
                vo.id = int.Parse(reward[0]);
                vo.num = int.Parse(reward[1]);
                rewardList.Add(vo);
            }
            return rewardList;
        }

        public static List<IdNumberVo> buildUnicRewardList(List<IdNumberVo> reward)
        {
            List<IdNumberVo> ret = new List<IdNumberVo>();
            List<int> unic = new List<int>();
            for(int i = 0; i < reward.Count; i++)
            {
                if (!unic.Contains(reward[i].id))
                {
                    unic.Add(reward[i].id);
                    ret.Add(reward[i]);
                }
            }
            return ret;
        }

    }
}
