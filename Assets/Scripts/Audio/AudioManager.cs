using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public enum SoundType
    {
        Trap,
        PickUpKey
    }
    
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource 
            sfxSource, footstepsSource;

        [SerializeField] private List<Sound> _sounds;
        
        private void Awake()
        {
            ManageStatusFootsteps(false);
        }

        public bool IsFootStepsEnable => footstepsSource.enabled;
        
        public void PlayOneShot(SoundType soundType)
        {
            AudioClip clip = GetSoundClip(soundType);
            
            if(clip == null) Debug.LogError("Clip Not Found!");
            
            sfxSource.PlayOneShot(clip);
        }

        private AudioClip GetSoundClip(SoundType soundType)
        {
            foreach (var sound in _sounds)
            {
                if (sound.SoundType == soundType)
                    return sound.Clip;
            }

            return null;
        }
        
        public void ManageStatusFootsteps(bool status)
        {
            footstepsSource.enabled = status;
        }
    }

    [System.Serializable]
    public class Sound
    {
       [field: SerializeField] public SoundType SoundType { get; private set; }
       [field: SerializeField] public AudioClip Clip { get; private set; }
    }
}