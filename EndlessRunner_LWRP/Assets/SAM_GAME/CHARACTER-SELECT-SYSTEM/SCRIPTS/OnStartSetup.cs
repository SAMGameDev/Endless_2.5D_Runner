using UnityEngine;

namespace EndlessRunning
{
    public class OnStartSetup : MonoBehaviour
    {
        [SerializeField] protected CharacterSelect characterSelect;
        [SerializeField] protected CharacterControlCache CachedControl;

        //[SerializeField]
        //private CharacterControl characterControl;

        ////public Transform CharacterModel_Transform;
        //public CharacterControl GetCharacterControl
        //{
        //    get
        //    {
        //        if (characterControl == null)
        //        {
        //            GameObject Player = GameObject.FindGameObjectWithTag("Player");
        //            characterControl = Player.GetComponent<CharacterControl>();
        //        }
        //        return characterControl;
        //    }
        //}
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
            // Changes Animator to gameplay animator
            switch (characterSelect.SelectedCharacter)
            {
                case PlayableCharacterTypes.Charlotte:
                    CachedControl.characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_CHARLOTTE");
                    break;

                case PlayableCharacterTypes.Jane:
                    CachedControl.characterControl.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JANE");
                    break;

                case PlayableCharacterTypes.Noah:
                    CachedControl.characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_NOAH");
                    break;

                case PlayableCharacterTypes.Jessica:
                    CachedControl.characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JESSICA");
                    break;

                case PlayableCharacterTypes.Emma:
                    CachedControl.characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_EMMA");
                    break;

                case PlayableCharacterTypes.William:
                    CachedControl.characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_WILLIAM");
                    break;

                case PlayableCharacterTypes.Liam:
                    CachedControl.characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_LIAM");
                    break;

                case PlayableCharacterTypes.James:
                    CachedControl.characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JAMES");
                    break;

                case PlayableCharacterTypes.Mike:
                    CachedControl.characterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_MIKE");
                    break;
            }
            CachedControl.characterControl.isStarted = true;
            gameObject.SetActive(false);
            #endregion
        }
    }
}