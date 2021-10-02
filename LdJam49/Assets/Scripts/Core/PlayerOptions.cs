using System;

using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class PlayerOptions
    {
        [SerializeField]
        private Boolean areAnimationsEnabled;
        public Boolean AreAnimationsEnabled
        {
            get
            {
                return this.areAnimationsEnabled;
            }
            set
            {
                if (this.areAnimationsEnabled != value)
                {
                    this.areAnimationsEnabled = value;
                }
            }
        }

        [SerializeField]
        private float backgroundVolume;
        public float BackgroundVolume
        {
            get
            {
                return this.backgroundVolume;
            }
            set
            {
                if (this.backgroundVolume != value)
                {
                    this.backgroundVolume = value;
                }
            }
        }

        [SerializeField]
        private float foregroundVolume;
        public float EffectsVolume
        {
            get
            {
                return this.foregroundVolume;
            }
            set
            {
                if (this.foregroundVolume != value)
                {
                    this.foregroundVolume = value;
                }
            }
        }

        [SerializeField]
        private float ambienceVolume;
        public float AmbienceVolume
        {
            get
            {
                return this.ambienceVolume;
            }
            set
            {
                if (this.ambienceVolume != value)
                {
                    this.ambienceVolume = value;
                }
            }
        }
    }
}