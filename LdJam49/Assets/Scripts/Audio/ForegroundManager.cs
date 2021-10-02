
using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class ForegroundManager : Manager
    {
        public override float Volume
        {
            get
            {
                return Core.Options.ForegroundVolume;
            }
            set
            {
                if (Core.Options.ForegroundVolume != value)
                {
                    Core.Options.ForegroundVolume = value;

                    this.VolumeChanged.Invoke(value);
                }
            }
        }
    }
}
