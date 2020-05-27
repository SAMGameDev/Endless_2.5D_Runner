using UnityEngine;
using Cinemachine;

namespace RunnerGame
{
    public class OnStartSetup : MonoBehaviour
    {
        public CharacterSelect characterSelect;
        private CharacterControl characterControl;
        CinemachineVirtualCamera[] arr;
        private GameObject CamFollow;
        public Transform animTrans;
       
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

            characterControl = FindObjectOfType<CharacterControl>();
            animTrans = characterControl.anim.GetComponent<Transform>();

            if (animTrans.position != characterControl.transform.position)
            {
                animTrans.position = characterControl.transform.position;
            }

            if (characterSelect.SelectedCharacter != PlayableCharacterTypes.NONE)
            {
                characterControl.isStarted = true;
                characterControl.gameObject.transform.position = gameObject.transform.position;
                characterControl.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PlayerAnimator");
            }

            arr = FindObjectsOfType<CinemachineVirtualCamera>();

            if (CamFollow == null)
            {
                CamFollow = GameObject.FindGameObjectWithTag("CamFollow"); ;
            }
            foreach (CinemachineVirtualCamera virtualCamera in arr)
            {
                virtualCamera.LookAt = CamFollow.transform;
                virtualCamera.Follow = CamFollow.transform;
            }
        }
        private void Update()
        {
            if (characterControl.Death)
            {
                foreach (CinemachineVirtualCamera virtualCamera in arr)
                {
                    virtualCamera.LookAt = null;
                    virtualCamera.Follow = null;
                }
            }
        }
    }
}

