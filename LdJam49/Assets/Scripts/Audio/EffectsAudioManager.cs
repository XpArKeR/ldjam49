
using System;
using System.Collections;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class EffectsAudioManager : MultiAudioManager
    {
        public override void Initialize()
        {
            this.Volume = Core.Options.EffectsVolume;
        }
    }
}
