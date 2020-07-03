using UnityEngine;

namespace RunnerGame
{
    public class GameSaveData : MonoBehaviour
    {
        public CharacterSelect SelectedCharacterData;
        public string objName;
        private void Awake()
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

                obj.transform.position = this.transform.position;
                obj.transform.rotation = this.transform.rotation;
            }
        }
    }
}


