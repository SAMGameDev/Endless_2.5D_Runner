using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class MouseControl : MonoBehaviour
    {
        Ray _ray;
        RaycastHit hit;
        public PlayableCharacterTypes mouseHoverd_Character;
        public CharacterSelect select;

        private void Update()
        {
            _ray = CameraManger.Instance.mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out hit))
            {
                CharacterControl control = hit.collider.gameObject.GetComponent<CharacterControl>();

                if(control != null)
                {
                    mouseHoverd_Character = control.Type;
                }
                else
                {
                    mouseHoverd_Character = PlayableCharacterTypes.NONE;
                }
            }

            if(Input.GetMouseButtonDown(0))
            {
                if(mouseHoverd_Character != PlayableCharacterTypes.NONE)
                {
                    select.SelectedCharacter = mouseHoverd_Character;
                }
                else
                {
                    select.SelectedCharacter = PlayableCharacterTypes.NONE;
                }
            }
        }
    }
}

