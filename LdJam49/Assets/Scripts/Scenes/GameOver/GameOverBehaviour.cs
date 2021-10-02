using System.Collections;
using System.Collections.Generic;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
