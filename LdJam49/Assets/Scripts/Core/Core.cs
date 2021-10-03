using System;
using System.IO;

using Assets.Scripts.Audio;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Core
    {
        private static Sprite currentBackground;

        private readonly static ResourceCache resourceCache = new ResourceCache();
        public static ResourceCache ResourceCache
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


        private static EffectsAudioManager foregroundMusicManager;
        public static EffectsAudioManager EffectsAudioManager
        {
            get
            {
                return foregroundMusicManager;
            }
            set
            {
                if (foregroundMusicManager != value)
                {
                    foregroundMusicManager = value;
                }
            }
        }

        private static AmbienceAudioManager ambienceMusicManager;
        public static AmbienceAudioManager AmbienceAudioManager
        {
            get
            {
                return ambienceMusicManager;
            }
            set
            {
                if (ambienceMusicManager != value)
                {
                    ambienceMusicManager = value;
                }
            }
        }

        private static BackgroundAudioManager backgroundAudioManager;
        public static BackgroundAudioManager BackgroundAudioManager
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
                    Ship = new BasicShip()
                    {
                        Width = 195,
                        Height = 170,
                        MaxDraft = 118,
                        Buoyancy = 40,
                        RelativeCenterOfMass = new Vector2(0.5f, 0.5f),

                        StabilityConstant1 = 1.2f,
                        StabilityConstant2 = -10f,
                        TiltingAngle = 20f,

                        Mass = 4f,
                        Damping = 3f,

                        ShipLoad = new ShipLoad()
                    }
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
                    AmbienceVolume = 1.125f,
                    BackgroundVolume = 0.125f,
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
