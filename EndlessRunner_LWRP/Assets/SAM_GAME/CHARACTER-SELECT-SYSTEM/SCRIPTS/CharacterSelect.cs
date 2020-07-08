using UnityEngine;

namespace EndlessRunning
{
    public enum CharacterGender
    {
        MALE,
        FEMALE
    }

    public enum PlayableCharacterTypes
    {
        NONE,
        Mike,
        James,
        Liam,
        Noah,
        Charlotte,
        Jessica,
        Jane,
        Emma,
        William
    }

    [CreateAssetMenu(fileName = "characterSelect", menuName = "ScriptableObject/CharacterSelect/CharacterSelect")]
    public class CharacterSelect : ScriptableObject
    {
        public PlayableCharacterTypes SelectedCharacter;
    }
}