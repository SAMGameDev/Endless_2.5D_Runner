using UnityEngine;
using System.Collections.Generic;

namespace RunnerGame
{
    public class MaterialChanger : MonoBehaviour
    {
        [Header("Components")]
        public SkinnedMeshRenderer skinnedMesh;
        public CharacterSelect selectedCharacter;
        public CharacterControl control;

        [Header("Variables")]
        [SerializeField] protected Material[] materials;
        int arraycount = 0;
        private void Awake()
        {
            skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            control = GetComponent<CharacterControl>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ClothChangeForward();
                Debug.Log(arraycount);
            }
            //if (Input.GetKeyDown(KeyCode.LeftArrow))
            //{
            //    ClothChangeBackWards();
            //    Debug.Log(arraycount);
            //}
        }

        public void ClothChangeForward()
        {
            arraycount++;

            if (selectedCharacter.SelectedCharacter == control.Type)
            {
                if (arraycount >= materials.Length)
                {
                    arraycount = 0;
                }

                skinnedMesh.material = materials[arraycount];
            }
        }

        //public void ClothChangeBackWards()
        //{
        //    arraycount--;

        //    if (selectedCharacter.SelectedCharacter == control.Type)
        //    {
        //        if (arraycount <= materials.Length)
        //        {
        //            arraycount = 0;
        //        }

        //        skinnedMesh.material = materials[arraycount];
        //    }
        //}
    }
}

