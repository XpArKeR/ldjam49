

using System;
using System.IO;

using Assets.Scripts;
using Assets.Scripts.Audio;

using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private float backgroundPlayedTime;

    public GameObject MainMenuContainer;
    public GameObject OptionsMenuContainer;
    public GameObject CreditsContainer;
    public Text VersionText;

    public GameObject QuitButton;
    public GameObject BackButton;

    public EffectsAudioManager EffectsAudioManager;
    public BackgroundAudioManager BackgroundAudioManager;
    public AmbienceAudioManager AmbienceAudioManager;

    public void StartGame()
    {
        Core.StartGame();
    }

    public void ShowOptions()
    {
        this.ChangeContainerVisiblity(options: true);
    }

    public void ShowCredits()
    {
        this.ChangeContainerVisiblity(credits: true);

        this.backgroundPlayedTime = Core.BackgroundAudioManager.AudioSource.time;
        Core.BackgroundAudioManager.PlayDelayed(Path.Combine("Audio", "Scenes", "HighSea", "HighSeaBackground"), 25f, true);
    }

    public void BackToMainMenu()
    {
        if (this.CreditsContainer.activeSelf)
        {
            Core.BackgroundAudioManager.PlayDelayed(Path.Combine("Audio", "Scenes", "MainMenu", "Background_without_Melody"), this.backgroundPlayedTime, true);
        }

        this.ChangeContainerVisiblity(mainMenu: true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (VersionText != default)
        {
            this.VersionText.text = Application.version;
        }

        if (Core.EffectsAudioManager == default)
        {
            Core.EffectsAudioManager = this.EffectsAudioManager;
            Core.EffectsAudioManager.Initialize();
        }
        if (Core.BackgroundAudioManager == default)
        {
            Core.BackgroundAudioManager = this.BackgroundAudioManager;
            Core.BackgroundAudioManager.Initialize();
        }

        if (Core.AmbienceAudioManager == default)
        {
            Core.AmbienceAudioManager = this.AmbienceAudioManager;
            Core.AmbienceAudioManager.Initialize();
        }

        if (!Core.AmbienceAudioManager.IsPlaying)
        {
            Core.AmbienceAudioManager.Resume();
        }
        else
        {
            Core.AmbienceAudioManager.Unmute();
        }

        if (!Core.BackgroundAudioManager.IsPlaying)
        {
            Core.BackgroundAudioManager.Play(Path.Combine("Audio", "Scenes", "MainMenu", "Background_without_Melody"), true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnApplicationQuit()
    {
        Core.OnClose();
    }

    private void ChangeContainerVisiblity(Boolean mainMenu = false, Boolean options = false, Boolean credits = false)
    {
        if (!mainMenu && !options && !credits)
        {
            throw new InvalidOperationException("No visiblity is not allowed!");
        }

        this.MainMenuContainer.SetActive(mainMenu);
        this.OptionsMenuContainer.SetActive(options);
        this.CreditsContainer.SetActive(credits);

        this.QuitButton.SetActive(mainMenu);
        this.BackButton.SetActive(!mainMenu);
    }
}
