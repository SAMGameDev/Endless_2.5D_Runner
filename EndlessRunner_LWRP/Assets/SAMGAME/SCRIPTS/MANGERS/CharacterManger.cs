using System.Collections.Generic;

namespace EndlessRunning
{
    public class CharacterManger : Singleton<CharacterManger>
    {
        public List<CharacterControl> characters = new List<CharacterControl>();

        public CharacterControl GetCharacterControl(PlayableCharacterTypes characterType)
        {
            foreach (CharacterControl control in characters)
            {
                if (control.TYPE == characterType)
                {
                    return control;
                }
            }
            return null;
        }
    }
}