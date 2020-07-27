using UnityEngine;

namespace EndlessRunning
{
    public class OnStartSetup : MonoBehaviour
    {
        [SerializeField] protected CharacterSelect characterSelect;

        public CacheCharacterControl controlCache;
        private void Start()
        {
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
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_CHARLOTTE");
                    break;

                case PlayableCharacterTypes.Jane:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JANE");
                    break;

                case PlayableCharacterTypes.Noah:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_NOAH");
                    break;

                case PlayableCharacterTypes.Jessica:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JESSICA");
                    break;

                case PlayableCharacterTypes.Emma:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_EMMA");
                    break;

                case PlayableCharacterTypes.William:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_WILLIAM");
                    break;

                case PlayableCharacterTypes.Liam:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_LIAM");
                    break;

                case PlayableCharacterTypes.James:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JAMES");
                    break;

                case PlayableCharacterTypes.Mike:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_MIKE");
                    break;
            }
            controlCache.GetCharacterControl.isStarted = true;
            gameObject.SetActive(false);
            #endregion
        }
    }
}