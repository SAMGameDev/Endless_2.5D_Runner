using UnityEngine;
using Cinemachine;

namespace RunnerGame
{
    public class CharacterSpawn : MonoBehaviour
    {
        public CharacterSelect characterSelect;
        [SerializeField] private CharacterControl character;
        private string ObjName;
        private GameObject CamFollow;
        private void Awake()
        {

            switch (characterSelect.SelectedCharacter)
            {
                case PlayableCharacterTypes.Mike:
                    {
                        ObjName = "Mike";
                    }
                    break;
                case PlayableCharacterTypes.James:
                    {
                        ObjName = "James";
                    }
                    break;
                case PlayableCharacterTypes.Liam:
                    {
                        ObjName = "Liam";
                    }
                    break;
                case PlayableCharacterTypes.Noah:
                    {
                        ObjName = "Noah";
                    }
                    break;
                case PlayableCharacterTypes.Charlotte:
                    {
                        ObjName = "Charlotte";
                    }
                    break;

                case PlayableCharacterTypes.Emma:
                    {
                        ObjName = "Emma";
                    }
                    break;
                case PlayableCharacterTypes.Jane:
                    {
                        ObjName = "Jane";
                    }
                    break;
                case PlayableCharacterTypes.Jessica:
                    {
                        ObjName = "Jessica";
                    }
                    break;
                case PlayableCharacterTypes.William:
                    {
                        ObjName = "William";
                    }
                    break;
            }

            GameObject obj = Instantiate(Resources.Load(ObjName,
                typeof(GameObject))) as GameObject;

            obj.transform.position = this.transform.position;

            GetComponent<MeshRenderer>().enabled = false;

            character = FindObjectOfType<CharacterControl>();

            if (characterSelect.SelectedCharacter != PlayableCharacterTypes.NONE)
            {
                character.anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("PlayerAnimator");
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

