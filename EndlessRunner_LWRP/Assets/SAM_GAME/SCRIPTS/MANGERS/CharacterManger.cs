using System.Collections.Generic;

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

