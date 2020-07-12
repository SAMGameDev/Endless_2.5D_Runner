using System.Collections;
using UnityEngine;

namespace EndlessRunning
{
    public class OnStartSetup : MonoBehaviour
    {
        [SerializeField] protected CharacterSelect characterSelect;

        public CharacterControl GetCharacter;
        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GetCharacter = player.GetComponent<CharacterControl>();
            #region Reset Model
            //reset postion of 3d model to colliders gameobject postion , USE ONLY IF PLAYER COMES
            // FROM DontDestroyOnLoad METHOD

            // CharacterModel_Transform = GetCharacterControl.anim.GetComponent<Transform>();

            // if (CharacterModel_Transform.position != characterControl.transform.position)
            // {
            //    CharacterModel_Transform.position = characterControl.transform.position;
            //}
            #endregion

            #region Change Animator
            switch (characterSelect.SelectedCharacter)
            {
                case PlayableCharacterTypes.Charlotte:
                    GetCharacter.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_CHARLOTTE");
                    break;

                case PlayableCharacterTypes.Jane:
                    GetCharacter.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JANE");
                    break;

                case PlayableCharacterTypes.Noah:
                    GetCharacter.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_NOAH");
                    break;

                case PlayableCharacterTypes.Jessica:
                    GetCharacter.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JESSICA");
                    break;

                case PlayableCharacterTypes.Emma:
                    GetCharacter.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_EMMA");
                    break;

                case PlayableCharacterTypes.William:
                    GetCharacter.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_WILLIAM");
                    break;

                case PlayableCharacterTypes.Liam:
                    GetCharacter.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_LIAM");
                    break;

                case PlayableCharacterTypes.James:
                    GetCharacter.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JAMES");
                    break;

                case PlayableCharacterTypes.Mike:
                    GetCharacter.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_MIKE");
                    break;
            }
            GetCharacter.isStarted = true;
            gameObject.SetActive(false);
            #endregion
        }
    }
}