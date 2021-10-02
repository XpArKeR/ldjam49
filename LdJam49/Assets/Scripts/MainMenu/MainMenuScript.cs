

using System;

using Assets.Scripts;
using Assets.Scripts.Constants;

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

    public AudioSource AudioSource;


    // Start is called before the first frame update
    void Start()
    {
        if (this.VersionText != null)
        {
            this.VersionText.text = System.Math.Round(UnityEngine.Random.Range(1f, 25.2145f), 4).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Core.ChangeScene(SceneNames.HighSea);
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
