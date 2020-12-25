using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace EndlessRunning
{
    public class GameSaveData : MonoBehaviour
    {
        public CharacterSelect SelectedCharacterData;
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