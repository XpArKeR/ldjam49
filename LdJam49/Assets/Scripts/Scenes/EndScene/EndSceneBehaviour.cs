
using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;

public class EndSceneBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Scene started");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackToTitleScreen()
    {
        Core.CloseGamestate();
        Core.ChangeScene(SceneNames.MainMenu);
    }
}
