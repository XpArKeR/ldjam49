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

        private static BackgroundManager backgroundMusicManager;
        public static BackgroundManager BackgroundMusicManager
        {
            get
            {
                return backgroundMusicManager;
            }
            set
            {
                if (backgroundMusicManager != value)
                {
                    backgroundMusicManager = value;
                }
            }
        }

        private static ForegroundManager foregroundMusicManager;
        public static ForegroundManager ForegroundMusicManager
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

        public static Sprite GetBackgroundSprite()
        {
            if ((currentBackground == default) && (!String.IsNullOrEmpty(GameState?.CurrentBackground)))
            {
                currentBackground = ResourceCache.GetSprite(Path.Combine("UI", "Sprites", GameState.CurrentBackground));
            }

            return currentBackground;
        }

        public static void SetCurrentBackground(Sprite background)
        {
            currentBackground = background;
            GameState.CurrentBackground = background.name;
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
                    Ship = default
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
                    BackgroundVolume = 1f,                    //BackgroundVolume = 0.125f,
                    ForegroundVolume = 1f
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
