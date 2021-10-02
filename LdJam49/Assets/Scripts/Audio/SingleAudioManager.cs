using System;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class SingleAudioManager : Manager
    {
        public AudioSource AudioSource;

        public void Play(AudioClip audioClip, Boolean isLooped = false)
        {
            if (audioClip != default)
            {
                Core.AmbienceAudioManager.AudioSource.loop = isLooped;
                Core.AmbienceAudioManager.AudioSource.clip = audioClip;
                Core.AmbienceAudioManager.AudioSource.Play();
            }
        }

        protected override void OnVolumeChanged(float volume)
        {
            this.VolumeChanged.Invoke(volume);

            if (AudioSource != default)
            {
                AudioSource.volume = volume;
            }
        }
    }
}
