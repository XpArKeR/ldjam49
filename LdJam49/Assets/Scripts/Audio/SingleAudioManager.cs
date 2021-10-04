using System;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class SingleAudioManager : Manager
    {
        public AudioSource AudioSource;
        private Single pauseTime;

        public virtual void Play(String resourceKey, Boolean isLooped = false)
        {
            this.Play(Core.ResourceCache.GetAudioClip(resourceKey), isLooped);
        }

        public virtual void Play(AudioClip audioClip, Boolean isLooped = false)
        {
            if (audioClip != default)
            {
                this.IsPlaying = true;

                this.AudioSource.loop = isLooped;
                this.AudioSource.clip = audioClip;
                this.AudioSource.Play();

                if (!isLooped)
                {
                    StartCoroutine(this.AudioSource.WaitForFinished(OnPlayBackFinishedCallback));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(audioClip));
            }
        }

        public virtual void PlayDelayed(String resourceKey, Single delay, Boolean isLooped = false)
        {
            this.PlayDelayed(Core.ResourceCache.GetAudioClip(resourceKey), delay);
        }

        public virtual void PlayDelayed(AudioClip audioClip, Single delay, Boolean isLooped = false)
        {
            if (audioClip != default)
            {
                this.IsPlaying = true;

                this.AudioSource.loop = isLooped;
                this.AudioSource.clip = audioClip;
                this.AudioSource.time = delay;
                this.AudioSource.Play();

                if (!isLooped)
                {
                    this.AudioSource.WaitForFinished(OnPlayBackFinishedCallback);
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(audioClip));
            }
        }

        private void OnPlayBackFinishedCallback()
        {
            Debug.Log("OnPlaybackFinished triggered");
            this.IsPlaying = false;
        }

        public void PlayAndWaitForSound(String audioClipPath, Action onEffectFinished)
        {
            this.Play(audioClipPath, false);
            this.AudioSource.WaitForSound(onEffectFinished);
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
