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
        [SerializeField] protected Material[] materials;

        private int arraycount = 0;

        private void Awake()
        {
            skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            control = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            Time.timeScale = 0.25f;
        }

        public void ClothChangeForward()
        {
            AudioManger.instance.SoundPlay("Click");

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
            AudioManger.instance.SoundPlay("Click");

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