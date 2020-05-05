using UnityEngine;

namespace RunnerGame
{
    public class CharacterSpawn : MonoBehaviour
    {
        public CharacterSelect characterSelect;
        private string ObjName;
       
        private void Start()
        {
            switch (characterSelect.SelectedCharacter)
            {
                case PlayableCharacterTypes.EmmaPolice:
                    {
                        ObjName = "EmmaPolice";
                    }
                    break;
                case PlayableCharacterTypes.JaneJacket:
                    {
                        ObjName = "JaneJacket";
                    }
                    break;
                case PlayableCharacterTypes.JessicaCoat:
                    {
                        ObjName = "JessicaCoat";
                    }
                    break;
            }

            GameObject obj = Instantiate(Resources.Load(ObjName,
                typeof(GameObject))) as GameObject;

            obj.transform.position = this.transform.position;
            GetComponent<MeshRenderer>().enabled = false;

           
        }
    }
}

