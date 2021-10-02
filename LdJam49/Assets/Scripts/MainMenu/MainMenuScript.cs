
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
            this.VersionText.text = Math.Round(Random.Range(1f, 25.2145f), 4).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {

    }

    public void Quit()
    {

    }
}
