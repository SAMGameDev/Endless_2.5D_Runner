using UnityEngine;
using Cinemachine;

namespace RunnerGame
{
    public class CharacterSpawn : MonoBehaviour
    {
        public CharacterSelect characterSelect;
        private CharacterControl character;
        private GameObject CamFollow;
        public Transform animTrans;

        //private string ObjName;
        private void Awake()
        {
            #region BigAss Comment Related TO Old Spawn System
            //    switch (characterSelect.SelectedCharacter)
            //    {
            //        case PlayableCharacterTypes.Mike:
            //            {
            //                ObjName = "Mike";
            //            }
            //            break;
            //        case PlayableCharacterTypes.James:
            //            {
            //                ObjName = "James";
            //            }
            //            break;
            //        case PlayableCharacterTypes.Liam:
            //            {
            //                ObjName = "Liam";
            //            }
            //            break;
            //        case PlayableCharacterTypes.Noah:
            //            {
            //                ObjName = "Noah";
            //            }
            //            break;
            //        case PlayableCharacterTypes.Charlotte:
            //            {
            //                ObjName = "Charlotte";
            //            }
            //            break;

            //        case PlayableCharacterTypes.Emma:
            //            {
            //                ObjName = "Emma";
            //            }
            //            break;
            //        case PlayableCharacterTypes.Jane:
            //            {
            //                ObjName = "Jane";
            //            }
            //            break;
            //        case PlayableCharacterTypes.Jessica:
            //            {
            //                ObjName = "Jessica";
            //            }
            //            break;
            //        case PlayableCharacterTypes.William:
            //            {
            //                ObjName = "William";
            //            }
            //            break;
            //    }

            //    GameObject obj = Instantiate(Resources.Load(ObjName,
            //   typeof(GameObject))) as GameObject;

            // obj.transform.position = this.transform.position;
            #endregion

            character = FindObjectOfType<CharacterControl>();
            animTrans = character.anim.GetComponent<Transform>();

            if (animTrans.position != character.transform.position)
            {
                animTrans.position = character.transform.position;
            }

            if (characterSelect.SelectedCharacter != PlayableCharacterTypes.NONE)
            {
                character.isStarted = true;
                character.gameObject.transform.position = gameObject.transform.position;
                character.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PlayerAnimator");
            }
            CinemachineVirtualCamera[] arr;

            arr = FindObjectsOfType<CinemachineVirtualCamera>();

            if (CamFollow == null)
            {
                CamFollow = GameObject.FindGameObjectWithTag("CamFollow"); ;
            }
            foreach (CinemachineVirtualCamera virtualCameras in arr)
            {
                virtualCameras.LookAt = CamFollow.transform;
                virtualCameras.Follow = CamFollow.transform;
            }
        }
    }
}

