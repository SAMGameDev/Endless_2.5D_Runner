using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class IKControl : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        public CharacterControl control;
        [SerializeField] private Animator foot_anim;
        [SerializeField] private Transform left_foot;
        [SerializeField] private Transform right_foot;
        [SerializeField] private Transform left_knee;
        [SerializeField] private BoxCollider boxCol;
        private Vector3 ref_point;
        private float final_angle;
        private RaycastHit hit;

        private float foot_ray()
        {
            if (Physics.Raycast(boxCol.bounds.center, -Vector3.up, out hit))
            {
                ref_point = hit.point;
                Plane plane = new Plane(left_foot.transform.position, right_foot.transform.position, left_knee.transform.position);
                float Cos_theta = Vector3.Dot(hit.normal.normalized, plane.normal.normalized);
                Vector3 projection = hit.normal.normalized - (Cos_theta * plane.normal.normalized);
                return Vector3.Angle(projection, player.transform.right);
            }
            else
            {
                return 0f;
            }
        }

        private void OnAnimatorIK(int layerIndex)

        {
            if (control.isGrounded == true)
            {
                foot_anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                foot_anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                foot_anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                foot_anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);

                float half_dist_between_feet = (left_foot.transform.position - right_foot.transform.position).magnitude / 2f;
                float left_pos = ref_point.y - (Mathf.Tan(final_angle) * half_dist_between_feet);
                float right_pos = ref_point.y + (Mathf.Tan(final_angle) * half_dist_between_feet);

                Vector3 slopeCorrected = -Vector3.Cross(hit.normal, player.transform.right);

                Quaternion leftFootRot = Quaternion.LookRotation(slopeCorrected, hit.normal);
                Quaternion rightFootRot = Quaternion.LookRotation(slopeCorrected, hit.normal);

                foot_anim.SetIKPosition(AvatarIKGoal.LeftFoot, new Vector3(left_foot.transform.position.x, left_pos, left_foot.transform.position.z));
                foot_anim.SetIKPosition(AvatarIKGoal.RightFoot, new Vector3(right_foot.transform.position.x, right_pos, right_foot.transform.position.z));
                foot_anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRot);
                foot_anim.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRot);
            }
        }

        private void LateUpdate()
        {
            final_angle = (foot_ray() - 90f) * (3.1416f / 180f);
        }

        private void Start()
        {
            control = player.GetComponent<CharacterControl>();
        }
    }
}
