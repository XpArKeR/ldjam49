using System;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class SingleAudioManager : Manager
    {
        public AudioSource AudioSource;
        private Single pauseTime;

        public virtual void Play(String resourceKey, Boolean isLooped = false, Action onFinishedCallback = default)
        {
            var audioClip = Core.Resources.GetAudioClip(resourceKey);

            if (audioClip != null)
            {
                this.Play(audioClip, isLooped, onFinishedCallback);
            }
        }

        public override void Play(String resourceName)
        {
            this.Play(Core.Resources.GetAudioClip(resourceName), false, default);
        }

        public override void Play(AudioClip audioClip)
        {
            this.Play(audioClip, false, default);
        }

        public virtual void Play(AudioClip audioClip, Boolean isLooped = false, Action onFinishedCallback = default)
        {
            if (audioClip != default)
            {
                this.IsPlaying = true;

                this.AudioSource.loop = isLooped;
                this.AudioSource.clip = audioClip;
                this.AudioSource.Play();

                if (!isLooped)
                {
                    StartCoroutine(this.AudioSource.WaitForFinished(() => { OnPlayBackFinishedCallback(onFinishedCallback); }));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(audioClip));
            }
        }

        public virtual void PlayStarted(String resourceKey, Single delay, Boolean isLooped = false, Action onFinishedCallback = default)
        {
            this.PlayStarted(Core.Resources.GetAudioClip(resourceKey), delay, isLooped, onFinishedCallback);
        }

        public virtual void PlayStarted(AudioClip audioClip, Single startTime, Boolean isLooped = false, Action onFinishedCallback = default)
        {
            if (audioClip != default)
            {
                this.IsPlaying = true;

                this.AudioSource.loop = isLooped;
                this.AudioSource.clip = audioClip;
                this.AudioSource.time = startTime;
                this.AudioSource.Play();

                if (!isLooped)
                {
                    StartCoroutine(this.AudioSource.WaitForFinished(() =>
                    {
                        OnPlayBackFinishedCallback(onFinishedCallback);
                    }
                    ));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(audioClip));
            }
        }

        private void OnPlayBackFinishedCallback(Action onFinishedCallback)
        {
            this.IsPlaying = false;

            onFinishedCallback?.Invoke();
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
