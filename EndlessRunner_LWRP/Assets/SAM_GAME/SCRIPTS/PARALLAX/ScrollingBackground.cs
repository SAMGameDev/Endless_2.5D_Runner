using UnityEngine;

namespace RunnerGame
{
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField]
        protected Vector3 parallaxEffectMultiplier;
        public Transform camTransfor;
        private Vector3 lastCamPostion;

        //[SerializeField]
        //private float texturUniteSizeZ;
        //[SerializeField]
        //private float texturUnitesizeY;
        void Start()
        {
            camTransfor = Camera.main.transform;
            lastCamPostion = camTransfor.position;
            //Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            //Texture2D texture = sprite.texture;
            //texturUniteSizeZ = texture.width / sprite.pixelsPerUnit;
            //texturUnitesizeY = texture.height / sprite.pixelsPerUnit;
        }
        void LateUpdate()
        {
            Vector3 deltaPostion = camTransfor.position - lastCamPostion;
            transform.position += new Vector3(deltaPostion.x, deltaPostion.y * parallaxEffectMultiplier.y,
                deltaPostion.z * parallaxEffectMultiplier.z);
            lastCamPostion = camTransfor.position;

            //if (Mathf.Abs(camTransfor.position.z - transform.position.z) >= texturUniteSizeZ)
            //{
            //    float offsetZ = (camTransfor.position.z - transform.position.z) % texturUniteSizeZ;
            //    transform.position = new Vector3(transform.position.x, transform.position.y,
            //        camTransfor.transform.position.z + offsetZ);
            //}
            //if (Mathf.Abs(camTransfor.position.y - transform.position.y) >= texturUnitesizeY)
            //{
            //    float offsetY = (camTransfor.position.y - transform.position.y) % texturUnitesizeY;
            //    transform.position = new Vector3(transform.position.x, camTransfor.position.y + offsetY,
            //       transform.position.z);
            //}
        }
    }
}

