using System;

using Assets.Scripts;

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

    public GameFrame.Core.Audio.Multi.EffectsAudioManager EffectsAudioManager;
    public GameFrame.Core.Audio.Single.BackgroundAudioManager BackgroundAudioManager;
    public GameFrame.Core.Audio.Single.AmbienceAudioManager AmbienceAudioManager;

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
        Core.BackgroundAudioManager.PlayStarted("HighSeaBackground", 25f, true);
    }

    public void BackToMainMenu()
    {
        if (this.CreditsContainer.activeSelf)
        {
            Core.BackgroundAudioManager.PlayStarted("Background_without_Melody", this.backgroundPlayedTime, true);
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
            Core.EffectsAudioManager.Volume = Core.Options.EffectsVolume;
        }
        if (Core.BackgroundAudioManager == default)
        {
            Core.BackgroundAudioManager = this.BackgroundAudioManager;
            Core.BackgroundAudioManager.Initialize();
            Core.BackgroundAudioManager.Volume = Core.Options.BackgroundVolume;
        }

        if (Core.AmbienceAudioManager == default)
        {
            Core.AmbienceAudioManager = this.AmbienceAudioManager;
            Core.AmbienceAudioManager.Initialize();
            Core.AmbienceAudioManager.Volume = Core.Options.AmbienceVolume;
        }

        if (!Core.AmbienceAudioManager.IsPlaying)
        {
            Core.AmbienceAudioManager.Resume();
        }
        else
        {
            Core.AmbienceAudioManager.Unmute();
        }

        Core.BackgroundAudioManager.Play("Background_without_Melody", true);
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
