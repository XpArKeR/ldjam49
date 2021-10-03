using System;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class SingleAudioManager : Manager
    {
        public AudioSource AudioSource;
        private Single pauseTime;

        public void Play(String resourceKey, Boolean isLooped = false)
        {
            this.Play(Core.ResourceCache.GetAudioClip(resourceKey), isLooped);
        }

        public void Play(AudioClip audioClip, Boolean isLooped = false)
        {
            if (audioClip != default)
            {
                Core.BackgroundAudioManager.AudioSource.loop = isLooped;
                Core.BackgroundAudioManager.AudioSource.clip = audioClip;
                Core.BackgroundAudioManager.AudioSource.Play();
            }
            else
            {
                throw new ArgumentNullException(nameof(audioClip));
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

        public override void Pause()
        {
            base.Pause();

            if (this.AudioSource.isPlaying)
            {
                this.AudioSource.Pause();
                pauseTime = this.AudioSource.time;
            }
        }

        public override void Resume()
        {
            base.Resume();

            if ((!this.AudioSource.isPlaying) && (pauseTime > 0))
            {
                this.AudioSource.time = pauseTime;
                this.AudioSource.Play();

                pauseTime = default;
            }
        }
    }
}
