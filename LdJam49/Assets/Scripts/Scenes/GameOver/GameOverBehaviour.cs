using Assets.Scripts;
using Assets.Scripts.Base;
using Assets.Scripts.Constants;

using UnityEngine;

public class GameOverBehaviour : MonoBehaviour
{
    public void BackButtonClicked()
    {
        Core.Game.Stop();
        Core.Game.ChangeScene(SceneNames.MainMenu);
    }

    // Start is called before the first frame update
    void Start()
    {
        Core.Game.BackgroundAudioManager?.Play("GameOverMan");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
