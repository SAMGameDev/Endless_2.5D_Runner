using UnityEngine;

namespace EndlessRunning
{
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField]
        protected Vector3 parallaxEffectMultiplier;
        public Transform camTransfor;
        private Vector3 lastCamPostion;
        void Start()
        {
            camTransfor = Camera.main.transform;
            lastCamPostion = camTransfor.position;
        }
        void LateUpdate()
        {
            Vector3 deltaPostion = camTransfor.position - lastCamPostion;
            transform.position += new Vector3(deltaPostion.x, deltaPostion.y * parallaxEffectMultiplier.y,
                deltaPostion.z * parallaxEffectMultiplier.z);
            lastCamPostion = camTransfor.position;
        }
    }
}

