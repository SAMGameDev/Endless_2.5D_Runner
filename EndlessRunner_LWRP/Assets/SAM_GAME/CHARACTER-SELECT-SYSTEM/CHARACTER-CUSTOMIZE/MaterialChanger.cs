using UnityEngine;

namespace RunnerGame
{
    public class MaterialChanger : MonoBehaviour
    {
        [Header("Components")]
        public SkinnedMeshRenderer skinnedMesh;

        public CharacterSelect selectedCharacter;
        public CharacterControl control;

        [Header("Variables")]
        [SerializeField] protected MaterialChangeData matData;
        [SerializeField] protected Material[] materials;

        private int arraycount = 0;

        private void Awake()
        {
            skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            control = GetComponent<CharacterControl>();
            matData.currentMaterial = materials[0];
            matData.matName = materials[0].name;
        }

        private void Update()
        {
            matData.currentMaterial = materials[arraycount];
            matData.matName = materials[arraycount].name;
        }

        public void ClothChangeForward()
        {
            GenralAudioManger.instance.SoundPlay("Click");

            if (!control.isStarted)
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
        }

        public void ClothChangeBackWards()
        {
            GenralAudioManger.instance.SoundPlay("Click");

            if (!control.isStarted)
            {
                if (arraycount > 0)
                {
                    arraycount--;
                }

                if (selectedCharacter.SelectedCharacter == control.Type)
                {
                    if (arraycount <= -1)
                    {
                        arraycount = 0;
                    }

                    skinnedMesh.material = materials[arraycount];
                }
            }
        }
    }
}