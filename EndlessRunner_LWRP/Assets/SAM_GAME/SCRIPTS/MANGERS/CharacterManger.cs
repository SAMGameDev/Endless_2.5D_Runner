﻿using System.Collections.Generic;

namespace EndlessRunning
{
    public class CharacterManger : Singleton<CharacterManger>
    {
        public List<CharacterControl> characters = new List<CharacterControl>();

        public CharacterControl GetCharacterControl(PlayableCharacterTypes characterTypes)
        {
            foreach (CharacterControl control in characters)
            {
                if (control.type == characterTypes)
                {
                    return control;
                }
            }

            return null;
        }
    }
}