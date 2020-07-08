using UnityEngine;
using System.Collections.Generic;

namespace EndlessRunning
{
    [RequireComponent(typeof(AudioSource))]
    public class CharacterAudioManger : MonoBehaviour
    {
        public AudioClip[] RunClips;
        public AudioClip Land;
        public AudioClip Dash;
        public AudioClip[] grunts;
        
        [Header("Components")]
        public AudioSource source;
        public CharacterControl control;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            control = GetComponentInParent<CharacterControl>();
        }

        public void Step()
        {
            AudioClip clip = GetRandomClip();
            source.PlayOneShot(clip);
        }

        private AudioClip GetRandomClip()
        {
            return RunClips[Random.Range(0, RunClips.Length)];
        }

        public void Landing()
        {
            source.PlayOneShot(Land);

        }

        public void Dashing()
        {
            source.PlayOneShot(Dash);
        }

        public void Death()
        {
            switch (control.gender)
            {
                case CharacterGender.MALE:
                    {
                        source.PlayOneShot(grunts[0]);
                    }
                    break;
                case CharacterGender.FEMALE:
                    {
                        source.PlayOneShot(grunts[1]);
                    }
                    break;
            }           
        }       
    }
}

