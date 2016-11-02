using UnityEngine;
using System.Collections;


namespace Game.Core.Util
{
    /// <summary>
    /// 自销毁功能
    /// </summary>
    public class SelfDestroy : MonoBehaviour
    {

        //invalid code
        public void DestroyInTime(float time)
        {
            StartCoroutine(DestroyInTimeS(time));
        }

        //
        IEnumerator DestroyInTimeS(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(this.gameObject);
        }

    }

}
