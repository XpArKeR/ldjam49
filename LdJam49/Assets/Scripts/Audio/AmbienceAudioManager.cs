
using System;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AmbienceAudioManager : SingleAudioManager
    {
        public override void Initialize()
        {
            base.Initialize();

            this.Volume = Core.Options.AmbienceVolume;
        }

        protected override void OnVolumeChanged(System.Single volume)
        {
            base.OnVolumeChanged(volume);

            Core.Options.AmbienceVolume = volume;
        }
    }
}
