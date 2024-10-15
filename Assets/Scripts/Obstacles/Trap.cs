using Audio;
using UnityEngine;

namespace Obstacles
{
    public class Trap : MonoBehaviour, IObstacle
    {
        [field: SerializeField] public SoundType ObstacleSound { get; set; }
    }
}