using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace RunnerGame
{
    public class GameSaveData : MonoBehaviour
    {
        public CharacterSelect SelectedCharacterData;

        private string objName;
        private void Awake()
        {
            LoadSelectedCharacter();
        }
        private void Start()
        {
            if (SelectedCharacterData.SelectedCharacter != PlayableCharacterTypes.NONE)
            {
                switch (SelectedCharacterData.SelectedCharacter)
                {
                    case PlayableCharacterTypes.Charlotte:
                        objName = "Charlotte";
                        break;
                    case PlayableCharacterTypes.Emma:
                        objName = "Emma";
                        break;
                    case PlayableCharacterTypes.James:
                        objName = "James";
                        break;
                    case PlayableCharacterTypes.Jane:
                        objName = "Jane";
                        break;
                    case PlayableCharacterTypes.Jessica:
                        objName = "Jessica";
                        break;
                    case PlayableCharacterTypes.Liam:
                        objName = "Liam";
                        break;
                    case PlayableCharacterTypes.Mike:
                        objName = "Mike";
                        break;
                    case PlayableCharacterTypes.Noah:
                        objName = "Noah";
                        break;
                    case PlayableCharacterTypes.William:
                        objName = "William";
                        break;
                }

                GameObject obj = Instantiate(Resources.Load(objName,
               typeof(GameObject))) as GameObject;

                obj.transform.position = transform.position;

                DontDestroyOnLoad(obj);
            }
        }
        public void LoadSelectedCharacter()
        {
            if (File.Exists(Application.persistentDataPath + "/SavedData/SelectedCharacter.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/SavedData/SelectedCharacter.dat", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), SelectedCharacterData);
                file.Close();
            }
        }
    }
}


