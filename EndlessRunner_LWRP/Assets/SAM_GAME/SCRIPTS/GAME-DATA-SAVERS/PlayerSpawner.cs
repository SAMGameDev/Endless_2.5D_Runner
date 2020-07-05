using UnityEngine;

namespace RunnerGame
{
    public class PlayerSpawner : MonoBehaviour
    {
        public GameSaveData saveData;
        //  public CharacterSelect SelectedCharacterData;
        private string objName;

        public void Awake()
        {
            saveData.LoadSelectedCharacter();
        }
        private void Start()
        {
            if (saveData.SelectedCharacterData.SelectedCharacter != PlayableCharacterTypes.NONE)
            {
                switch (saveData.SelectedCharacterData.SelectedCharacter)
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
            }
        }
    }
}

