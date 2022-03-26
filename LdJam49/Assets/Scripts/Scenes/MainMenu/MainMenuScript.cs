using System;

using Assets.Scripts.Base;

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
        Core.Game.Start();
    }

    public void ShowOptions()
    {
        this.ChangeContainerVisiblity(options: true);
    }

    public void ShowCredits()
    {
        this.ChangeContainerVisiblity(credits: true);

        this.backgroundPlayedTime = Core.Game.BackgroundAudioManager.AudioSource.time;
        Core.Game.BackgroundAudioManager.PlayStarted("HighSeaBackground", 25f, true);
    }

    public void BackToMainMenu()
    {
        if (this.CreditsContainer.activeSelf)
        {
            Core.Game.BackgroundAudioManager.PlayStarted("Background_without_Melody", this.backgroundPlayedTime, true);
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

        if (Core.Game.EffectsAudioManager == default)
        {
            Core.Game.EffectsAudioManager = this.EffectsAudioManager;
            Core.Game.EffectsAudioManager.Initialize();
        }
        if (Core.Game.BackgroundAudioManager == default)
        {
            Core.Game.BackgroundAudioManager = this.BackgroundAudioManager;
            Core.Game.BackgroundAudioManager.Initialize();
        }

        if (Core.Game.AmbienceAudioManager == default)
        {
            Core.Game.AmbienceAudioManager = this.AmbienceAudioManager;
            Core.Game.AmbienceAudioManager.Initialize();
        }

        if (!Core.Game.AmbienceAudioManager.IsPlaying)
        {
            Core.Game.AmbienceAudioManager.Resume();
        }
        else
        {
            Core.Game.AmbienceAudioManager.Unmute();
        }

        Core.Game.BackgroundAudioManager.Play("Background_without_Melody", true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnApplicationQuit()
    {
        Core.Game.SaveOptions();
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
