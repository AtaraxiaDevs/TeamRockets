using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerSettings : MonoBehaviour
{
    public static MultiPlayerSettings multiPlayerSettings;

    public int maxPlayers = 4;
    public int menuScene;
    public int multiplayerScene;

    private void Awake()
    {
        if (MultiPlayerSettings.multiPlayerSettings = null)
        {
            MultiPlayerSettings.multiPlayerSettings = this;
        }
        else
        {
            if (MultiPlayerSettings.multiPlayerSettings != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
