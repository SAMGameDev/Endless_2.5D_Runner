using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class LevelGenrator : MonoBehaviour
    {
        [SerializeField] private float safeZone = 55;
        private const float PLAYER_DISTANCE_FROMENDPOS_OBJECT = 30;
        int spawnNumberWhenGameStarts = 3;
        [SerializeField] private Transform levelparStart;
        [SerializeField] private List<Transform> levelPrefabList = new List<Transform>();
        [SerializeField] private CharacterControl control;


        Transform levelPartTransform;

        private Vector3 lastEndPsotion;
        private void Awake()
        {
            lastEndPsotion = levelparStart.Find("EndPosition").position;

            for (int i = 0; i < spawnNumberWhenGameStarts; i++)
            {
                SpawnLevelPart();
            }
        }

        private void Update()
        {
            float distance = Vector3.Distance(control.transform.position, lastEndPsotion);
            if (distance < PLAYER_DISTANCE_FROMENDPOS_OBJECT)
            {
                SpawnLevelPart();
            }

            foreach (Transform t in levelPrefabList)
            {
                Vector3 p = t.Find("EndPosition").position;
                if (control.transform.position.z - safeZone > p.z)
                {
                    DestroyPlatform();
                }
            }
        }

        void SpawnLevelPart()
        {
            Transform chosenLevelPart = levelPrefabList[Random.Range(0, levelPrefabList.Count)];
            Transform lastLevelPartTransform = spawnLevelParts(chosenLevelPart, lastEndPsotion);
            lastEndPsotion = lastLevelPartTransform.Find("EndPosition").position;
        }

        private Transform spawnLevelParts(Transform levelpart, Vector3 spawnPos)
        {
            levelPartTransform = Instantiate(levelpart, spawnPos, Quaternion.identity);
            return levelPartTransform;
        }

        void DestroyPlatform()
        {
            Destroy(levelPartTransform.gameObject);
            levelPrefabList.RemoveAt(0);
        }
    }
}
