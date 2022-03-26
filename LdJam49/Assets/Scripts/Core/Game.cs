
using Assets.Scripts.Constants;

using UnityEngine;

namespace Assets.Scripts
{
    public class Game : GameFrame.Core.Game<GameState, PlayerOptions>
    {
        public Game() : base()
        {

        }

        private GameFrame.Core.Audio.Multi.EffectsAudioManager effectsAudioManager;
        public GameFrame.Core.Audio.Multi.EffectsAudioManager EffectsAudioManager
        {
            get
            {
                return effectsAudioManager;
            }
            set
            {
                if (effectsAudioManager != value)
                {
                    effectsAudioManager = value;
                }
            }
        }

        private GameFrame.Core.Audio.Single.BackgroundAudioManager backgroundAudioManager;
        public GameFrame.Core.Audio.Single.BackgroundAudioManager BackgroundAudioManager
        {
            get
            {
                return backgroundAudioManager;
            }
            set
            {
                if (backgroundAudioManager != value)
                {
                    backgroundAudioManager = value;
                }
            }
        }

        private GameFrame.Core.Audio.Single.AmbienceAudioManager ambienceAudioManager;
        public GameFrame.Core.Audio.Single.AmbienceAudioManager AmbienceAudioManager
        {
            get
            {
                return ambienceAudioManager;
            }
            set
            {
                if (ambienceAudioManager != value)
                {
                    ambienceAudioManager = value;
                }
            }
        }

        protected override GameState InitializeGameState()
        {
            return new GameState()
            {
                Ship = ShipManager.GetDefaultShip(),
                CurrentScene = SceneNames.Port
            };
        }

        protected override PlayerOptions InitialzePlayerOptions()
        {
            return new PlayerOptions()
            {
                AreAnimationsEnabled = true,
                EffectsVolume = 1f,
                BackgroundVolume = 0.125f,
                AmbienceVolume = 0.125f
            };
        }


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Test1()
        {
            Base.Core.Game.Startup();
        }
    }
}
