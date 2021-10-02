
using UnityEngine;

public class UnitySingleton : MonoBehaviour
{
    private static UnitySingleton instance;
    void Awake()
    {
        if ((instance != default) && (instance != this))
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
