using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/FrontDetector")]
    public class FrontDetector : ScriptableObjectData
    {
        public float rayDist = 10f;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (Die(playerStateBase.characterControl))
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], true);
            }
            else
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], false);
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        bool Die(CharacterControl control)
        {
            foreach (GameObject o in control.spheres)
            {
                RaycastHit hitInfo;

                Debug.DrawRay(o.transform.position, Vector3.forward * 1f, Color.yellow, 0.01f);

                if (Physics.Raycast(o.transform.position, Vector3.forward, out hitInfo, rayDist))
                {
                    if (hitInfo.collider.gameObject.tag == "Obsticel")
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    }
}