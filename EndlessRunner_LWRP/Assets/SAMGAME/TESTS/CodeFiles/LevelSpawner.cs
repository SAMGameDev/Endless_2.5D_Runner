using UnityEngine;

namespace EndlessRunning
{
    public class LevelSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] platformsPrefab;
        [Space(15)]
        [SerializeField]
        public Transform playerTransform;

        [SerializeField]
        private float platformLength;
        [SerializeField]
        private float spawnZ;
        
        void Start()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            SpawnPlatforms();
        }

        private void SpawnPlatforms()
        {
            GameObject obj;

            for (int i = 0; i < platformsPrefab.Length; i++)
            {
                obj = Instantiate(platformsPrefab[i]) as GameObject;
                obj.transform.SetParent(transform);
                obj.transform.position = Vector3.forward * spawnZ;
                spawnZ += platformLength;
            }
        }
    }
}


