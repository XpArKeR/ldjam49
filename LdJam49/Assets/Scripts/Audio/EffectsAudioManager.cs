
using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class EffectsAudioManager : SingleAudioManager
    {
        public override void Initialize()
        {
            base.Initialize();

            this.Volume = Core.EffectsAudioManager.Volume;
        }

        protected override void OnVolumeChanged(System.Single volume)
        {
            base.OnVolumeChanged(volume);

            Core.Options.EffectsVolume = volume;
        }
    }
}