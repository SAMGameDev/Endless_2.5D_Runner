using System.Collections;
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
            StartCoroutine(ChangeAnimator(0.003f));
        }

        IEnumerator ChangeAnimator(float time)
        {
            yield return new WaitForSeconds(time);

            #region Change Animator
            // Changes Animator to gameplay animator
            switch (characterSelect.SelectedCharacter)
            {
                case PlayableCharacterTypes.Charlotte:
                    CachedControl.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_CHARLOTTE");
                    break;

                case PlayableCharacterTypes.Jane:
                    CachedControl.GetCharacterControl.anim.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JANE");
                    break;

                case PlayableCharacterTypes.Noah:
                    CachedControl.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_NOAH");
                    break;

                case PlayableCharacterTypes.Jessica:
                    CachedControl.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JESSICA");
                    break;

                case PlayableCharacterTypes.Emma:
                    CachedControl.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_EMMA");
                    break;

                case PlayableCharacterTypes.William:
                    CachedControl.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_WILLIAM");
                    break;

                case PlayableCharacterTypes.Liam:
                    CachedControl.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_LIAM");
                    break;

                case PlayableCharacterTypes.James:
                    CachedControl.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_JAMES");
                    break;

                case PlayableCharacterTypes.Mike:
                    CachedControl.GetCharacterControl.anim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController>("PLAYERANIMATOR_MIKE");
                    break;
            }
            CachedControl.GetCharacterControl.isStarted = true;
            gameObject.SetActive(false);
            #endregion

            StopAllCoroutines();
        }
    }
}