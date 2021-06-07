using UnityEngine;

namespace EndlessRunning
{
    public class MouseControl : MonoBehaviour
    {
        public PlayableCharacterTypes selectedCharacter;
        public CharacterSelect SelectedCharacterData;
        [SerializeField] private Animator characterselect_camController;

        private void FixedUpdate()
        {
            Ray ray;
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Player");

            ray = CameraManger.Instance.mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, mask))
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

                //from mouse input to below was out of raycast conditon idk what problems
                //this will create moving it inside raycast condition
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
                    }
                    characterselect_camController.SetBool(selectedCharacter.ToString(), true);
                }
            }
            else
            {
                return;
            }
        }
    }
}