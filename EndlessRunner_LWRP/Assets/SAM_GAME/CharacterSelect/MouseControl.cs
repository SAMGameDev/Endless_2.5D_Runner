using UnityEngine;
using Cinemachine;

namespace RunnerGame
{
    public class MouseControl : MonoBehaviour
    {
        Ray _ray;
        RaycastHit hit;
        public PlayableCharacterTypes selectedCharacter;
        public CharacterSelect select;
        [SerializeField] private CinemachineVirtualCamera vCam;
        private void Awake()
        {
            vCam = FindObjectOfType<CinemachineVirtualCamera>();
        }

        private void Update()
        {
            _ray = CameraManger.Instance.mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out hit))
            {
                CharacterControl control = hit.collider.gameObject.GetComponent<CharacterControl>();

                if (control != null)
                {
                    selectedCharacter = control.Type;
                }
                else
                {
                    selectedCharacter = PlayableCharacterTypes.NONE;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (selectedCharacter != PlayableCharacterTypes.NONE)
                {
                    select.SelectedCharacter = selectedCharacter;
                }
                else
                {
                    select.SelectedCharacter = PlayableCharacterTypes.NONE;
                }

                foreach (CharacterControl c in CharacterManger.Instance.characters)
                {
                    if (c.Type == selectedCharacter)
                    {
                        c.anim.SetBool(HashManger.Instance.DicMainParameters
                            [TranistionParemeters.OnClick], true);

                        vCam.Follow = c.spinTransform;
                        vCam.LookAt = c.spinTransform;

                    }
                    else
                    {
                        c.anim.SetBool(HashManger.Instance.DicMainParameters
                                                    [TranistionParemeters.OnClick], false);
                    }
                }
            }
        }
    }
}

