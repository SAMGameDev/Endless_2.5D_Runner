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
            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            RaycastHit hit;

            Ray ray = new Ray(control.transform.position, -control.transform.up);
            if (Physics.Raycast(ray, out hit, 0.3f))
            {
                control.transform.rotation = Quaternion.LookRotation(Vector3.Cross(control.transform.right, hit.normal));
                //control.transform.rotation = Quaternion.Slerp(control.transform.rotation, rot, smoothRottation * Time.deltaTime);
            }
            Debug.DrawRay(control.transform.position, -control.transform.up * 0.7f, Color.red);
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
