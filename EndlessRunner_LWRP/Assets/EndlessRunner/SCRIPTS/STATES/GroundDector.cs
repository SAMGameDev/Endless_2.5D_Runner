using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/GroundDector")]
    public class GroundDector : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

            if (playerStateBase.characterControl.isGrounded)
            {
                animator.SetBool(TranistionParemeters.Grounded.ToString(), true);
            }
            else
            {
                animator.SetBool(TranistionParemeters.Grounded.ToString(), false);
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        /* private bool isGrounded(CharacterControl control)
         {
             RaycastHit hit;
             Physics.Raycast(control.Bcollider.bounds.center, -Vector3.up, out hit, control.Bcollider.bounds.extents.y + hieght);
             Color rayColor;

             if (hit.collider != null)
             {
                 rayColor = Color.white;
                 Debug.Log(hit.collider.name);
             }
             else
             {
                 rayColor = Color.red;
             }

             Debug.DrawRay(control.Bcollider.bounds.center, -Vector3.up * (control.Bcollider.bounds.extents.y + hieght), rayColor);
             return hit.collider != null;
         }*/
    }

}
