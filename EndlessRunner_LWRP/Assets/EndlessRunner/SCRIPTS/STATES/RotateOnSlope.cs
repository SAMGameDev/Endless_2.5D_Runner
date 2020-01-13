using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/RotateOnSlope")]
    public class RotateOnSlope : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            RaycastHit hit;

            Ray ray = new Ray(playerStateBase.characterControl.transform.position, -playerStateBase.characterControl.transform.up);
            if (Physics.Raycast(ray, out hit, 0.3f))
            {
                playerStateBase.characterControl.transform.rotation = Quaternion.LookRotation(Vector3.Cross(playerStateBase.characterControl.transform.right, hit.normal));
                //control.transform.rotation = Quaternion.Slerp(control.transform.rotation, rot, smoothRottation * Time.deltaTime);
            }
          //  Debug.DrawRay(playerStateBase.characterControl.transform.position, -playerStateBase.characterControl.transform.up * 0.7f, Color.red);
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
