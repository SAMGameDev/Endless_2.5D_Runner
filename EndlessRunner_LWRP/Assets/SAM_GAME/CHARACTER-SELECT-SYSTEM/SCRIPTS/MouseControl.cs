using UnityEngine;

namespace EndlessRunning
{
    public class MouseControl : MonoBehaviour
    {
        Ray ray;
        RaycastHit hit;

        public PlayableCharacterTypes selectedCharacter;
        public CharacterSelect SelectedCharacterData;
        [SerializeField] protected Animator characterselect_camController;

        private void Update()
        {          
            ray = CameraManger.Instance.mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                CharacterControl control = hit.collider.GetComponent<CharacterControl>();

                if (control != null)
                {
                    selectedCharacter = control.TYPE;
                }
                else
                {
                    selectedCharacter = PlayableCharacterTypes.None;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (selectedCharacter != PlayableCharacterTypes.None)
                {
                    SelectedCharacterData.SelectedCharacter = selectedCharacter;
                }
                else
                {
                    SelectedCharacterData.SelectedCharacter = PlayableCharacterTypes.None;
                }

                foreach (CharacterControl c in CharacterManger.Instance.characters)
                {
                    if (c.TYPE == selectedCharacter)
                    {
                        c.anim.SetBool(HashManger.Instance.DicMainParameters
                                          [TranistionParemeters.OnClick], true);
                    }
                    else
                    {
                        c.anim.SetBool(HashManger.Instance.DicMainParameters
                                          [TranistionParemeters.OnClick], false);
                    }
                    if (selectedCharacter == PlayableCharacterTypes.None)
                    {
                        return;
                    }
                }
                characterselect_camController.SetBool(selectedCharacter.ToString(), true);
            }
        }
    }
}