﻿using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunning
{
    public class LevelManger : MonoBehaviour
    {
        public GameObject[] levelPrefabs;

        [SerializeField]
        private List<GameObject> activeTiles = new List<GameObject>();

        [SerializeField]
        private Transform playertransform;

        private float spawnZ = 0;

        [SerializeField]
        protected float tileLength;

        [SerializeField]
        protected float AmountOfPlatforms;

        [SerializeField]
        protected float safeZone;

        protected int lastIndexprefab = 0;

        private void Start()
        {
            playertransform = GameObject.FindGameObjectWithTag("Player").transform;

            for (int i = 0; i < AmountOfPlatforms; i++)
            {
                if (i < 1)
                {
                    SpawnTile(0);
                }
                else
                {
                    SpawnTile();
                }
            }
        }

        private void Update()
        {
            if (playertransform.position.z - safeZone > (spawnZ - AmountOfPlatforms * tileLength))
            {
                SpawnTile();
                DestroyPlatform();
            }
        }

        private void SpawnTile(int prefabIndex = -1)
        {
            GameObject go;
            if (prefabIndex == -1)
                go = Instantiate(levelPrefabs[RandomPrefabIndex()]) as GameObject;
            else
                go = Instantiate(levelPrefabs[prefabIndex]) as GameObject;
            go.transform.SetParent(transform);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLength;
            activeTiles.Add(go);
        }

        private void DestroyPlatform()
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

        private int RandomPrefabIndex()
        {
            if (levelPrefabs.Length <= 1)
            {
                return 0;
            }
            int randomIndex = lastIndexprefab;

            while (randomIndex == lastIndexprefab)
            {
                randomIndex = Random.Range(0, levelPrefabs.Length);
            }
            lastIndexprefab = randomIndex;
            return randomIndex;
        }
    }
}