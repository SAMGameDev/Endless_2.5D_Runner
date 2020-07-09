using UnityEngine;

namespace EndlessRunning
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

        public void ClothChangeForward()
        {
            GenralAudioManger.instance.SoundPlay("Click");

            arraycount++;

            if (selectedCharacter.SelectedCharacter == control.Type)
            {
                if (arraycount >= materials.Length)
                {
                    arraycount = 0;
                }

                skinnedMesh.material = materials[arraycount];              
                Debug.LogWarning(arraycount);
            }
        }
        public void ClothChangeBackWards()
        {
            GenralAudioManger.instance.SoundPlay("Click");

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
                Debug.LogWarning(arraycount);
            }
        }
    }
}