using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：围绕某点旋转  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/7/14 9:37:39
// ================================
namespace Assets.JackCheng.Script
{
    public class MyRotateAround : MonoBehaviour
    {
        public Transform target;

        void Start() { }
        void Update()
        {
            //this.transform.RotateAround(this.transform.parent.position, this.transform.parent.up, 1);

            RotateAround(target.position, Vector3.up, 1);
        }

        private void RotateAround(Vector3 pos, Vector3 up, float degree)
        {
            Quaternion q = Quaternion.AngleAxis(degree, up);
            this.transform.position = q * (this.transform.position - pos) + pos;
            this.transform.rotation *= q;
        }
    }
}
