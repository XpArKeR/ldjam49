
using System;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class BackgroundAudioManager : SingleAudioManager
    {
        public override void Initialize()
        {
            this.Volume = Core.Options.BackgroundVolume;
        }

        protected override void OnVolumeChanged(System.Single volume)
        {
            base.OnVolumeChanged(volume);

            Core.Options.BackgroundVolume = volume;
        }

        public override void Stop()
        {
            base.Stop();

            this.AudioSource.Stop();
        }
    }
}
