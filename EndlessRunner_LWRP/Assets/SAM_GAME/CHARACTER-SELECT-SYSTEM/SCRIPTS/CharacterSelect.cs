using UnityEngine;

namespace EndlessRunning
{
    public enum CharacterGender
    {
        Male,
        Female
    }

    public enum PlayableCharacterTypes
    {
        None,
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