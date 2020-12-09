using UnityEngine;

namespace EndlessRunning
{
    public class OnStartSetup : MonoBehaviour
    {
        [SerializeField] protected CharacterSelect characterSelect;

        public CacheCharacterControl controlCache;

        private void Start()
        {
            #region Change Animator

            switch (characterSelect.SelectedCharacter)
            {
                case PlayableCharacterTypes.Charlotte:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_CHARLOTTE"); // Animation done
                    break;

                case PlayableCharacterTypes.Jane:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JANE");
                    break;

                case PlayableCharacterTypes.Noah:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_NOAH"); // Animation done
                    break;

                case PlayableCharacterTypes.Jessica:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JESSICA"); // Animation done
                    break;

                case PlayableCharacterTypes.Emma:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_EMMA"); // Animation done
                    break;

                case PlayableCharacterTypes.William:
                    controlCache.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_WILLIAM"); // Animation done
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

            #endregion Change Animator
        }
    }
}