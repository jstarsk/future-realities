// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureRealities
{
    [RequireComponent(typeof(GazeReceiver))]
    public class GazeButton : MonoBehaviour
    {
        public float duration = 1.8f;
        private float gazeBeginTime = float.NaN;
        public bool Trigger;

        public float gazeTime
        {
            get
            {
                if (float.IsNaN(gazeBeginTime))
                {
                    return 0f;
                }
                else
                {
                    return Time.time - gazeBeginTime;
                }
            }
        }

        public float normalizedGazeTime
        {
            get
            {
                return gazeTime / duration;
            }
        }

        // Update is called once per frame
        protected void Update()
        {
            if (normalizedGazeTime > 1f)
            {
                gazeBeginTime = float.NaN;
                //gameObject.SendMessage("OnButtonGaze", SendMessageOptions.DontRequireReceiver);
                Trigger = true;
            }
        }

        protected void OnGazeBegin()
        {
            gazeBeginTime = Time.time;
        }

        protected void OnGazeEnd()
        {
            gazeBeginTime = float.NaN;
        }
    }
}