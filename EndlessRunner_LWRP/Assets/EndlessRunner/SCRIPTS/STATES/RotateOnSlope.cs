using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/RotateOnSlope")]
    public class RotateOnSlope : ScriptableObjectData
    {
        [SerializeField]
        protected float smoothRottation;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            RaycastHit hit;
            Ray ray = new Ray(control.transform.position, -control.transform.up);
            if (Physics.Raycast(ray, out hit, 3.3f))
            {
                Debug.DrawRay(hit.point, hit.normal * 3.3f, Color.white);
               
                Quaternion rot = Quaternion.LookRotation(Vector3.Cross(control.transform.right, hit.normal));
                control.transform.rotation = Quaternion.Slerp(control.transform.rotation, rot, smoothRottation * Time.deltaTime);
            }

            // control.transform.rotation = Quaternion.Euler(25f, 0f, 0f);
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
