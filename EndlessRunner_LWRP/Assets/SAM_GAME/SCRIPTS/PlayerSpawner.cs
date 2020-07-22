using UnityEngine;

namespace EndlessRunning
{
    public class PlayerSpawner : MonoBehaviour
    {
        public CharacterSelect SelectedCharacter;

        private string objName;
        private void Awake()
        {
            //instansiting character in mainmenu according to saved data in SO,
            //LOADING DEPENDS ON INSTANSITING 

            if (SelectedCharacter.SelectedCharacter != PlayableCharacterTypes.NONE)
            {
                switch (SelectedCharacter.SelectedCharacter)
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
                GameObject player = Instantiate(Resources.Load(objName,
                 typeof(GameObject))) as GameObject;

                player.transform.position = transform.position;

                gameObject.SetActive(false);
            }
        }
    }
}

