using UnityEngine;

namespace EndlessRunning
{
    public class OnStartSetup : MonoBehaviour
    {
        [SerializeField] protected CharacterSelect characterSelect;

        [SerializeField]
        private CharacterControl characterControl;

        //public Transform CharacterModel_Transform;

        public CharacterControl GetCharacterControl
        {
            get
            {
                if (characterControl == null)
                {
                    GameObject Player = GameObject.FindGameObjectWithTag("Player");
                    characterControl = Player.GetComponent<CharacterControl>();
                }
                return characterControl;
            }
        }
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

            //reset postion of 3d model to colliders gameobject postion , USE ONLY IF PLAYER COMES
            // FROM DontDestroyOnLoad METHOD

            // CharacterModel_Transform = GetCharacterControl.anim.GetComponent<Transform>();

            // if (CharacterModel_Transform.position != characterControl.transform.position)
            // {
            //    CharacterModel_Transform.position = characterControl.transform.position;
            //}

            #region Change Animator
            // Changes Animator to gameplay animator
            switch (characterSelect.SelectedCharacter)
            {
                case PlayableCharacterTypes.Charlotte:
                    GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_CHARLOTTE");
                    break;

                case PlayableCharacterTypes.Jane:
                    GetCharacterControl.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JANE");
                    break;

                case PlayableCharacterTypes.Noah:
                    GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_NOAH");
                    break;

                case PlayableCharacterTypes.Jessica:
                    GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JESSICA");
                    break;

                case PlayableCharacterTypes.Emma:
                    GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_EMMA");
                    break;

                case PlayableCharacterTypes.William:
                    GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_WILLIAM");
                    break;

                case PlayableCharacterTypes.Liam:
                    GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_LIAM");
                    break;

                case PlayableCharacterTypes.James:
                    GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JAMES");
                    break;

                case PlayableCharacterTypes.Mike:
                    GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_MIKE");
                    break;
            }
            characterControl.isStarted = true;
            // characterControl.gameObject.transform.position = gameObject.transform.position;
            #endregion
        }
    }
}