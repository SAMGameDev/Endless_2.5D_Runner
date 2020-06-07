using System;
using UnityEngine;

namespace RunnerGame
{
    public class AudioManger : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioManger instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.spatialBlend = s.spatialBlend;
                s.source.playOnAwake = s.playOnAwake;
            }
        }

        public void SoundPlay(string name)
        {
            Sound s = Array.Find(sounds, sounds => sounds.name == name);

            if (s == null)
            {
                Debug.LogError("Sound: " + name + " Not Found");
                return;
            }

            s.source.Play();
        }
    }
}