using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/WallDetector")]
    public class WallDetector : ScriptableObjectData
    {
        RaycastHit HitInfo;
        public Vector3 RayPost;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            Debug.DrawRay(control.transform.position + RayPost, control.transform.forward * Mathf.Infinity, Color.red);

            if (Physics.Raycast(control.transform.position + RayPost, control.transform.forward, out HitInfo, 0.5f))
            {

                if (control.Dowalljump && !control.isGrounded && HitInfo.collider.tag == "Wall")
                {
                    control.RIGIDBODY.velocity = Vector3.zero;
                    control.RIGIDBODY.AddForce(HitInfo.normal * 4f, ForceMode.VelocityChange);
                    control.RIGIDBODY.AddForce(Vector3.up * 3f, ForceMode.VelocityChange);
                    control.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                if (!control.isGrounded && control.Dowalljump == true && HitInfo.collider.tag == "Wall")
                {
                    control.RIGIDBODY.velocity = Vector3.zero;
                    control.RIGIDBODY.AddForce(HitInfo.normal * 4f, ForceMode.VelocityChange);
                    control.RIGIDBODY.AddForce(Vector3.up * 3f, ForceMode.VelocityChange);
                    control.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (!control.isGrounded && control.Dowalljump == false && HitInfo.collider.tag == "Wall" || HitInfo.collider.tag == "Wall")
                {
                    control.RIGIDBODY.velocity = new Vector3(0, -0.5f, 0);
                }
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
