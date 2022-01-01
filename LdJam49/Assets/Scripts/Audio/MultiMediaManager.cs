
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class MultiAudioManager : Manager
    {
        protected IList<AudioSource> audioSources = new List<AudioSource>();
        
        public AudioSource Template;

        public override void Play(string resourceName)
        {
            this.Play(Core.Resources.GetAudioClip(resourceName));
        }

        public override void Play(AudioClip audioClip)
        {
            var audioSource = GetAudioSource();

            if (audioSource != null)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }

        protected override void OnVolumeChanged(System.Single volume)
        {
            foreach (var audioSource in this.audioSources)
            {
                audioSource.volume = volume;
            }

            Core.Options.EffectsVolume = volume;
        }

        protected AudioSource GetAudioSource()
        {
            AudioSource audioSource = audioSources.FirstOrDefault(a => !a.isPlaying);

            if (audioSource == null)
            {
                if (this.Template == null)
                {
                    throw new System.InvalidOperationException("No Template AudioSource provided!");
                }

                audioSource = GameObject.Instantiate<AudioSource>(Template, Template.transform.parent);

                this.audioSources.Add(audioSource);
            }
    
            return audioSource;
        }
    }
}
