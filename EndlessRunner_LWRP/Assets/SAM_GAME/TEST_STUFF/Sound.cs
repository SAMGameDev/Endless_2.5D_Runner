using UnityEngine;

namespace RunnerGame
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public bool loop;

        [Range(0, 1)]
        public float volume;

        [Range(.1f, 3f)]
        public float pitch;

        public AudioClip clip;

        [HideInInspector]
        public AudioSource source;
    }
}