using UnityEngine;

namespace RunnerGame
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public bool loop;
        public bool playOnAwake;

        [Range(0, 1)]
        public float volume;

        [Range(0, 1)]
        public float spatialBlend;

        [Range(.1f, 3f)]
        public float pitch;

        public AudioClip clip;

        [HideInInspector]
        public AudioSource source;
    }
}