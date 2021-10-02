
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class BackgroundManager : Manager
    {
        public List<AudioClip> clips;
        public List<AudioSource> AudioSources;

        private Int32 toggle = 0;
        private Double nextStartTime;

        public override float Volume
        {
            get
            {
                return Core.Options.BackgroundVolume;
            }
            set
            {
                if (Core.Options.BackgroundVolume != value)
                {
                    Core.Options.BackgroundVolume = value;

                    this.VolumeChanged.Invoke(value);

                    foreach (var audioSource in this.AudioSources)
                    {
                        audioSource.volume = value;
                    }
                }
            }
        }


        public override void Initialize()
        {
            base.Initialize();

            foreach (var audioSource in this.AudioSources)
            {
                audioSource.volume = Volume;
            }
        }

        public override void Stop()
        {
            if (IsPlaying)
            {
                IsPlaying = false;

                foreach (var audioSource in this.AudioSources)
                {
                    audioSource.Stop();
                }
            }
        }

        public override void Resume()
        {
            if (!IsPlaying)
            {
                this.StartAudio();
            }
            else
            {
                this.PauseToggled?.Invoke(false);

                if (this.oldVolume.HasValue)
                {
                    this.Unmute();
                }
            }
        }

        // Start is called before the first frame update
        protected override void Start()
        {
            //StartAudio();
        }

        private void FixedUpdate()
        {
        }

        // Update is called once per frame
        protected override void Update()
        {
            if (!IsPlaying)
            {
                StartAudio();
            }
            else
            {
                if (AudioSettings.dspTime > nextStartTime)
                {
                    nextStartTime = QueueAudio(nextStartTime);
                }
            }
        }

        private void StartAudio()
        {
            nextStartTime = QueueAudio(AudioSettings.dspTime, 0.2d);
            nextStartTime = QueueAudio(nextStartTime);
        }

        private double QueueAudio(Double startTime, Double delay = 0d)
        {
            var clip = GetRandomClip();

            var audioSource = AudioSources[toggle];

            var duration = (Double)clip.samples / clip.frequency;

            var startAt = startTime + delay;

            var finishedOn = startAt + duration;

            audioSource.clip = clip;

            audioSource.PlayScheduled(startAt);
            Debug.Log(String.Format("Scheduled: {0} at {1} - FinishedOn {4} on AudioSource {2}. Duration: {3}", clip.name, nextStartTime, toggle, duration, finishedOn));

            toggle = 1 - toggle;

            IsPlaying = true;

            return finishedOn;
        }

        private AudioClip GetRandomClip()
        {
            var clip = default(AudioClip);

            if (clips.Count > 0)
            {
                clip = clips[UnityEngine.Random.Range(0, clips.Count)];
            }

            return clip;
        }
    }
}
