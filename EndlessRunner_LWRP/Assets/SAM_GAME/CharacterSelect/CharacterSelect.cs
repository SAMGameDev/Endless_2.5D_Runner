using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public enum PlayableCharacterTypes
    {
        NONE,
        JessicaCoat,
        JaneJacket,
        EmmaPolice
    }

    [CreateAssetMenu(fileName = "characterSelect", menuName = "ScriptableObject/CharacterSelect/CharacterSelect")]
    public class CharacterSelect : ScriptableObject
    {
        public PlayableCharacterTypes SelectedCharacter;
    }
}

