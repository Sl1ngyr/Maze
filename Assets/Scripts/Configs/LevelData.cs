using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "SO/LevelData")]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public int KeysToUnlockDoor { get; private set; }
    }
}