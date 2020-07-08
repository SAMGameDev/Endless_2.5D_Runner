using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "MaterialData", menuName = "ScriptableObject/CharacterSelect/MaterialDataHolder")]
    public class MaterialChangeData : ScriptableObject
    {
        public Material currentMaterial;
        public string matName;        
    }
}
