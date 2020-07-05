using UnityEngine;

namespace RunnerGame
{
    public class MouseControl : MonoBehaviour
    {       
        public PlayableCharacterTypes selectedCharacter;
        public CharacterSelect SelectedCharacterData;
        [SerializeField] protected Animator characterselect_camController;

        public GameSaveData SaveData;

        private void Update()
        {
            Ray _ray;
            RaycastHit hit;

            _ray = CameraManger.Instance.mainCamera.ScreenPointToRay
                (Input.mousePosition);

            if (Physics.Raycast(_ray, out hit))
            {
                CharacterControl control = hit.collider.GetComponent<CharacterControl>();

                if (control != null)
                {
                    selectedCharacter = control.Type;
                }
                else
                {
                    selectedCharacter = PlayableCharacterTypes.NONE;
                }
            }
            else
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (selectedCharacter != PlayableCharacterTypes.NONE)
                {
                    SelectedCharacterData.SelectedCharacter = selectedCharacter;
                }
                else
                {
                    SelectedCharacterData.SelectedCharacter = PlayableCharacterTypes.NONE;
                }

                foreach (CharacterControl c in CharacterManger.Instance.characters)
                {
                    if (c.Type == selectedCharacter)
                    {
                        c.anim.SetBool(HashManger.Instance.DicMainParameters
                                          [TranistionParemeters.OnClick], true);
                        // DontDestroyOnLoad(c.gameObject);
                    }
                    else
                    {
                        c.anim.SetBool(HashManger.Instance.DicMainParameters
                                          [TranistionParemeters.OnClick], false);

                        // SceneManager.MoveGameObjectToScene(c.gameObject,
                        //   SceneManager.GetActiveScene());
                    }
                    if (selectedCharacter == PlayableCharacterTypes.NONE)
                    {
                        return;
                    }
                }
                characterselect_camController.SetBool(selectedCharacter.ToString(), true);
            }
        }
        public void OnDisable()
        {
            SaveData.SaveSelectedCharacter();
        }
    }
}