using Cinemachine;
using System.Collections;
using UnityEngine;

namespace RunnerGame
{
    public class OnStartSetup : MonoBehaviour
    {
        public CharacterSelect characterSelect;
        [SerializeField] private GameObject Player;
        [SerializeField] private CharacterControl characterControl;
        [SerializeField] private CinemachineVirtualCamera[] VirtualCameras;

        private Transform CamFollow;
        public Transform CharacterModel_Transform;

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

            #endregion BigAss Comment Related TO Old Spawn System

            Player = GameObject.FindGameObjectWithTag("Player");
            characterControl = Player.GetComponent<CharacterControl>();
            CharacterModel_Transform = characterControl.anim.GetComponent<Transform>();

            if (CharacterModel_Transform.position != characterControl.transform.position)
            {
                CharacterModel_Transform.position = characterControl.transform.position;
            }

            //switch (characterSelect.SelectedCharacter)
            //{
            //    case PlayableCharacterTypes.Jane:
            //        characterControl.anim.runtimeAnimatorController =
            //        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JANE");
            //        break;
            //}
            //characterControl.isStarted = true;
            //characterControl.gameObject.transform.position = gameObject.transform.position;

            if (characterSelect.SelectedCharacter != PlayableCharacterTypes.NONE)
            {
                characterControl.isStarted = true;
                characterControl.gameObject.transform.position = gameObject.transform.position;
                characterControl.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR");
            }

            if (CamFollow == null)
            {
                CamFollow = GameObject.FindGameObjectWithTag("CamFollow").transform;
            }

            VirtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();

            foreach (CinemachineVirtualCamera virtualCamera in VirtualCameras)
            {
                virtualCamera.LookAt = CamFollow;
                virtualCamera.Follow = CamFollow;
            }

            StartCoroutine(CameraStopper(0.001f));
        }

        private IEnumerator CameraStopper(float time)
        {
            yield return new WaitForSeconds(time);

            if (characterControl.Death)
            {
                foreach (CinemachineVirtualCamera virtualCamera in VirtualCameras)
                {
                    if (virtualCamera.LookAt != null && virtualCamera.Follow != null)
                    {
                        virtualCamera.LookAt = null;
                        virtualCamera.Follow = null;
                    }
                }
                StopAllCoroutines();
                characterControl.Death = false;
            }
            else
            {
                StartCoroutine(CameraStopper(0.4f));
            }
        }
    }
}