using UnityEngine;

namespace RunnerGame
{
    public enum CameraTrigger
    {
        Default,
        Shake,
    }
    public class CameraController : MonoBehaviour
    {
        private Animator animator;
        //Gamobject CamFollow
        public Animator ANIMATOR
        {
            get
            {
                if (animator == null)
                {
                    animator = GetComponent<Animator>();
                }
                return animator;
            }
        }

        /*THAT CODE HERE. i was doing this way, before i made character Instantiate (FOR CHARACTER SELECTION)
         * by following your tutorial. it was working fine BEFORE, after character
         * selection. 
         * IT IS [ NOT ] WOTKING IN AWAKE AND START FUNCTION GIVING NULL REFERENCE
         * 
         * BUT IT IS WORKING IN UPDATE FUNCTION
         * 
         * AGAING IT IS NOT A PROBLEM YOUR WAY IS WORKING FINE IT IS JUST
         * A GENRAL QUESTION, MY HABIBT IS I ALAWAYS TRY TO PUT CODE IN FILES/SCRIPT THAT ARE 
         * ALREDY DOING SOMETHING FOR SAME GAMEOBJECT 
         *  
         */

        private void Awake()
        {
            //CinemachineVirtualCamera[] arr;

            //arr = FindObjectsOfType<CinemachineVirtualCamera>();

            //if (CamFollow == null)
            //{
            //    CamFollow = GameObject.FindGameObjectWithTag("CamFollow"); ;
            //}

            //foreach (CinemachineVirtualCamera virtualCameras in arr)
            //{
            //    virtualCameras.LookAt = CamFollow.transform;
            //    virtualCameras.Follow = CamFollow.transform;
            //}
        }

        public void TriggerCamera(CameraTrigger trigger)
        {
            ANIMATOR.SetTrigger(trigger.ToString());
        }
    }
}

