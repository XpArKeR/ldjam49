
using System;

using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class Manager : MonoBehaviour
    {
        protected float? oldVolume;

        public UnityEvent<float> VolumeChanged = new UnityEvent<float>();
        public UnityEvent<Boolean> PauseToggled = new UnityEvent<Boolean>();

        private Boolean isPlaying;
        public Boolean IsPlaying
        {
            get
            {
                return this.isPlaying;
            }
            protected set
            {
                if (isPlaying != value)
                {
                    isPlaying = value;
                }
            }
        }

        private float volume;
        public float Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                if (this.volume != value)
                {
                    this.volume = value;
                    this.VolumeChanged.Invoke(value);
                    OnVolumeChanged(value);
                }
            }
        }

        public virtual void Initialize()
        {

        }

        public virtual void Pause()
        {
            this.PauseToggled?.Invoke(true);
        }

        public virtual void Stop()
        {
            if (IsPlaying)
            {
                this.IsPlaying = false;
            }
        }

        public virtual void Resume()
        {
        }

        public virtual void Mute()
        {
            if (this.Volume > 0)
            {
                this.oldVolume = this.Volume;
                this.Volume = 0;
            }
        }

        public virtual void Unmute()
        {
            if (this.oldVolume.HasValue)
            {
                this.Volume = this.oldVolume.Value;
                this.oldVolume = default;
            }
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
        }

        protected abstract void OnVolumeChanged(float volume);
    }
}
