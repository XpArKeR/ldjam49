using System;

using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Core
    {
        private readonly static ResourceCache resourceCache = new ResourceCache();
        public static ResourceCache Resources
        {
            get
            {
                return resourceCache;
            }
        }

        private static PlayerOptions options;
        public static PlayerOptions Options
        {
            get
            {
                return options;
            }
            private set
            {
                if (options != value)
                {
                    options = value;
                }
            }
        }

        private static GameState gameState;
        public static GameState GameState
        {
            get
            {
                return gameState;
            }
            private set
            {
                if (gameState != value)
                {
                    gameState = value;
                }
            }
        }

        private static GameFrame.Core.Audio.Multi.EffectsAudioManager effectsAudioManager;
        public static GameFrame.Core.Audio.Multi.EffectsAudioManager EffectsAudioManager
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

        private static GameFrame.Core.Audio.Single.BackgroundAudioManager backgroundAudioManager;
        public static GameFrame.Core.Audio.Single.BackgroundAudioManager BackgroundAudioManager
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

        private static GameFrame.Core.Audio.Single.AmbienceAudioManager ambienceAudioManager;
        public static GameFrame.Core.Audio.Single.AmbienceAudioManager AmbienceAudioManager
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

        private static Boolean isFileAccessPossible;
        public static Boolean IsFileAccessPossible
        {
            get
            {
                return isFileAccessPossible;
            }
            private set
            {
                if (isFileAccessPossible != value)
                {
                    isFileAccessPossible = value;
                }
            }
        }

        public static void CloseGamestate()
        {
            GameState = default;
        }

        public static void OnClose()
        {
            SavePlayerOptions();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitGame()
        {

            if (Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.Android)
            {
                IsFileAccessPossible = false;
            }
            else
            {
                IsFileAccessPossible = true;
            }

            LoadPlayerOptions();
        }

        public static void ChangeScene(String sceneName)
        {
            CursorMode cursorMode = CursorMode.Auto;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);

            if (GameState != default)
            {
                GameState.CurrentScene = sceneName;
            }

            SceneManager.LoadScene(sceneName);
        }

        public static void StartGame(GameState providedGameState = default)
        {
            var effectiveGameState = providedGameState;

            if (effectiveGameState == default)
            {
                effectiveGameState = new GameState()
                {
                    Ship = ShipManager.GetDefaultShip()
                };

                effectiveGameState.CurrentScene = SceneNames.Port;
            }

            GameState = effectiveGameState;
            ChangeScene(effectiveGameState.CurrentScene);
        }

        private static void LoadPlayerOptions()
        {
            var configString = PlayerPrefs.GetString("PlayerOptions");

            if (!String.IsNullOrEmpty(configString))
            {
                Options = UnityEngine.JsonUtility.FromJson<PlayerOptions>(configString);
            }

            if (Options == default)
            {
                Options = new PlayerOptions()
                {
                    AreAnimationsEnabled = true,
                    EffectsVolume = 1f,
                    BackgroundVolume = 0.125f,
                    AmbienceVolume = 0.125f,
                };
            }
        }

        private static void SavePlayerOptions()
        {
            var optionsString = UnityEngine.JsonUtility.ToJson(Options);

            PlayerPrefs.SetString("PlayerOptions", optionsString);
        }
    }
}
