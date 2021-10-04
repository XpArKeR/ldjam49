using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;

public class GameOverBehaviour : MonoBehaviour
{
    public void BackButtonClicked()
    {
        Core.CloseGamestate();
        Core.ChangeScene(SceneNames.MainMenu);
    }

    // Start is called before the first frame update
    void Start()
    {
        Core.BackgroundAudioManager?.Play(System.IO.Path.Combine("Audio", "Scenes", "GameOver", "GameOverMan"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
