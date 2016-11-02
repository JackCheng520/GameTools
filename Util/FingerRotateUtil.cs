using UnityEngine;
using System.Collections;

namespace Game.Util
{
    public class FingerRotateUtil:MonoBehaviour
    {
        GameObject rotate = null;
        float speed = 20.0f;
        float pressSpeed = 2f;
        bool leftPressDown = false;
        bool rightPressDown = false;
        float rotateMax = 45f;
        float curRotate = 0f;

        void Update()
        {
            rotateChild();
        }

        void rotateChild()
        {
            if (Input.GetMouseButton(0))
            {
                float h = -speed * Input.GetAxis("Mouse X");
                if (h > 0 && curRotate < rotateMax)
                {
                    curRotate += h;
                    rotate.transform.Rotate(0, h, 0, Space.World);
                }
                if (h < 0 && curRotate > -rotateMax)
                {
                    curRotate += h;
                    rotate.transform.Rotate(0, h, 0, Space.World);
                }
            }
        }

        public void setRotate(GameObject obj)
        {
            rotate = obj;
        }
    }
}
