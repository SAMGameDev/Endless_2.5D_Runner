﻿using UnityEngine;

namespace EndlessRunning
{
    public class LoadSelectedCharacter : MonoBehaviour
    {
        public GameSaveData saveData;
        private void Awake()
        {
            //Loads Selected character in mainMenu Scene
            saveData.LoadSelectedCharacter();
        }
    }

}
