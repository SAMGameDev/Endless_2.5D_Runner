//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace EndlessRunning
//{
//    public class ObjectPooler : MonoBehaviour
//    {
//        public static ObjectPooler Instance;

//        [Space(10)] public GameObject PlatformPrefab_1;
//        [Space(10)] public GameObject PlatformPrefab_2;

//        [Space(10)] public List<GameObject> PooledObjects = new List<GameObject>();

//        [Space(10)] public int AmountOfPlatforms;

//        private void Awake()
//        {
//            Instance = this;
//        }

//        private void Start()
//        {
//            GameObject obj;
//            GameObject objA;

//            for (int i = 0; i < AmountOfPlatforms; i++)
//            {
//                obj = (GameObject)Instantiate(PlatformPrefab_1);
//                PooledObjects.Add(obj);
//            }
//            for (int j = 0; j < 1; j++)
//            {
//                objA = (GameObject)Instantiate(PlatformPrefab_2);
//                PooledObjects.Add(objA);
//            }
//        }

//        public void DestroyTile()
//        {
//            PooledObjects[0].gameObject.SetActive(false);
//        }
//    }
//}

