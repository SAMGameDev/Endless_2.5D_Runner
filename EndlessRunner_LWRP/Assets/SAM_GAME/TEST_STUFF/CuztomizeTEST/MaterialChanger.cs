using UnityEngine;

namespace RunnerGame
{
    public class MaterialChanger : MonoBehaviour
    {
        [Header("Components")]
        public SkinnedMeshRenderer skinnedMesh;
        public CharacterSelect selectedCharacter;
        public CharacterControl control;

        public static MaterialChanger instance;

        [Header("Variables")]
        public Material[] materials;
        int arraycount = 0;

        private void Awake()
        {
            skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            control = GetComponent<CharacterControl>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (selectedCharacter.SelectedCharacter == control.Type)
                {
                    arraycount++;

                    if (arraycount >= materials.Length)
                    {
                        arraycount = 0;
                    }
                    skinnedMesh.material = materials[arraycount];

                    if (instance == null)
                    {
                        instance = this;
                        DontDestroyOnLoad(instance);
                    }
                    else
                    {
                        if (control.isStarted)
                        {
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
}

