using UnityEngine;
using Cinemachine;

namespace RunnerGame
{
    public class CharacterSpawn : MonoBehaviour
    {
        public CharacterSelect characterSelect;
        private string ObjName;
        GameObject CamFollow;
        private void Awake()
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

            /* this cinemachine related block of code , you put this in
             * characterSpawn.Cs. now i am asking why didn't you put it in
             * CameraController.Cs or CameraManger since it is camera related code. 
             * YES IT WORKING PERFECTLY NO BUG OR SOMETHING JUST ASKING.
             * 
             * OPEN CameraController.cs
            */

            CinemachineVirtualCamera[] arr;

            arr = FindObjectsOfType<CinemachineVirtualCamera>();

            if (CamFollow == null)
            {
                CamFollow = GameObject.FindGameObjectWithTag("CamFollow"); ;
            }

            foreach (CinemachineVirtualCamera virtualCameras in arr)
            {
                virtualCameras.LookAt = CamFollow.transform;
                virtualCameras.Follow = CamFollow.transform;
            }
        }
    }
}

