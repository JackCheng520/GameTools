using UnityEngine;
using System.Collections;
using System;

namespace Game.Util
{
    public class AudioDelay : MonoBehaviour
    {
     
        public string delaySeconds = "";

        private int repeat = 0;
        private string[] arrDelayScond;

        private AudioSource audioSource;

        private int curNumb = 0;

  

        // Use this for initialization
        void Start()
        {
       
        }

        void OnEnable()
        {

            audioSource = GetComponent<AudioSource>();
            audioSource.Stop();
            curNumb = 0;
            arrDelayScond = delaySeconds.Split('|');
            repeat = arrDelayScond.Length;
            audioSource.PlayDelayed(Convert.ToSingle(arrDelayScond[0]));
        }


 

        // Update is called once per frame
        void Update(){
       
            if (!audioSource.isPlaying) return;
            if (curNumb >= repeat - 1) return;

            if (audioSource.time >= audioSource.clip.length) {
                curNumb += 1;
                audioSource.Stop();
                audioSource.PlayDelayed(Convert.ToSingle(arrDelayScond[curNumb]));
            }
          
           // DebugUtil.log("AudioDelay:" + audioSource.time.ToString() + ";" + audioSource.isPlaying.ToString());
           // DebugUtil.log("AudioDelayClipLenght:" + audioSource.clip.length.ToString());

            // audioSource.time;
        }
    }
}