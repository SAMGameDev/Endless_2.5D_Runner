using UnityEngine;

namespace RunnerGame
{
    public class OnStartSetup : MonoBehaviour
    {
        [SerializeField] protected CharacterSelect characterSelect;
        [SerializeField] protected GameObject Player;
        private CharacterControl characterControl;

        public Transform CharacterModel_Transform;

        public CharacterControl GetCharacterControl
        {
            get
            {
                if (characterControl == null)
                {
                    Player = GameObject.FindGameObjectWithTag("Player");
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

            CharacterModel_Transform = GetCharacterControl.anim.GetComponent<Transform>();

            if (CharacterModel_Transform.position != characterControl.transform.position)
            {
                CharacterModel_Transform.position = characterControl.transform.position;
            }

            switch (characterSelect.SelectedCharacter)
            {
                case PlayableCharacterTypes.Charlotte:
                    characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_CHARLOTTE");
                    break;

                case PlayableCharacterTypes.Jane:
                    characterControl.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JANE");
                    break;

                case PlayableCharacterTypes.Noah:
                    characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_NOAH");
                    break;

                case PlayableCharacterTypes.Jessica:
                    characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JESSICA");
                    break;

                case PlayableCharacterTypes.Emma:
                    characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_EMMA");
                    break;

                case PlayableCharacterTypes.William:
                    characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_WILLIAM");
                    break;

                case PlayableCharacterTypes.Liam:
                    characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_LIAM");
                    break;

                case PlayableCharacterTypes.James:
                    characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JAMES");
                    break;

                case PlayableCharacterTypes.Mike:
                    characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_MIKE");
                    break;
            }
            characterControl.isStarted = true;
            characterControl.gameObject.transform.position = gameObject.transform.position;
        }

        private void Update()
        {
            Time.timeScale = 0.05f;
        }
    }
}