using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CharacterManger : Singleton<CharacterManger>
    {
        public List<CharacterControl> characters = new List<CharacterControl>();
        public CharacterControl GetCharacterControl(PlayableCharacterTypes characterTypes)
        {
            foreach(CharacterControl control in characters)
            {
                if(control.Type == characterTypes)
                {
                    return control;
                }
            }

            return null;
        }
    }
}

