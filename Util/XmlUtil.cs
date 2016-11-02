using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Game.Util
{
    /// <summary>
    /// xml工具；
    /// added by LY;
    /// 2016-5-3
    /// </summary>
    public class XmlUtil
    {
 
        /// <summary>
        /// 获取属性值；
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string getAttribute(XmlNode node, string attributeName) {
            XmlAttribute att = node.Attributes[attributeName]; 
            if (att != null) { 
                return att.Value; 
            } else {
                return "";
            } 
        }

        /// <summary>
        /// 获取节点值
        /// </summary>
        /// <param name="nodeXPath"></param>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        public static string getNodeValue(string nodeXPath,XmlNode parentNode)
        {
            XmlNode node = parentNode.SelectSingleNode(nodeXPath);
            if (node.FirstChild != null){
                return node.FirstChild.Value;
            } else if (node != null){
                return node.Value; }
            else{
                return "";
            }
        }
    }
}
