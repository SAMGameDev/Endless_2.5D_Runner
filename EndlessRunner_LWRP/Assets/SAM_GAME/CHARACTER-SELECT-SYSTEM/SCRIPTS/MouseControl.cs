using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace RunnerGame
{
    public class MouseControl : MonoBehaviour
    {
        public PlayableCharacterTypes selectedCharacter;
        public CharacterSelect SelectedCharacterData;
        [SerializeField] protected Animator characterselect_camController;

        private void Start()
        {
            foreach (CharacterControl c in CharacterManger.Instance.characters)
            {
                if (SelectedCharacterData.SelectedCharacter != PlayableCharacterTypes.NONE
                    && SelectedCharacterData.SelectedCharacter == c.Type)
                {
                    DontDestroyOnLoad(c.gameObject);
                }
            }
        }
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
            SaveSelectedCharacter();
        }

        public void SaveSelectedCharacter()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/SavedData"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/SavedData");
            }
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SavedData/SelectedCharacter.dat");
            var jason = JsonUtility.ToJson(SelectedCharacterData);
            bf.Serialize(file, jason);
            file.Close();
        }
    }
}