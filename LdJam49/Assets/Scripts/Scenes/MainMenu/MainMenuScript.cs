

using System;

using Assets.Scripts;
using Assets.Scripts.Audio;

using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenuContainer;
    public GameObject OptionsMenuContainer;
    public GameObject CreditsContainer;
    public Text VersionText;

    public GameObject QuitButton;
    public GameObject BackButton;

    public BackgroundManager BackgroundManager;
    public ForegroundManager ForegroundManager;


    // Start is called before the first frame update
    void Start()
    {
        if (VersionText != default)
        {
            this.VersionText.text = Application.version;
        }

        if (Core.BackgroundMusicManager == default)
        {
            Core.BackgroundMusicManager = this.BackgroundManager;
            Core.BackgroundMusicManager.Initialize();
        }

        if (Core.ForegroundMusicManager == default)
        {
            Core.ForegroundMusicManager = this.ForegroundManager;
            Core.ForegroundMusicManager.Initialize();
        }

        if (!Core.BackgroundMusicManager.IsPlaying)
        {
            Core.BackgroundMusicManager.Resume();
        }
        else
        {
            Core.BackgroundMusicManager.Unmute();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

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
    }

    public void BackToMainMenu()
    {
        this.ChangeContainerVisiblity(mainMenu: true);
    }

    public void Quit()
    {
        Application.Quit();
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
