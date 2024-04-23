using TMPro;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    public bool godMode;
    private Transform tagPlayer;

    public void Awake()
    {
        godMode = false;
        tagPlayer = transform;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            godMode = !godMode;
            GodMode();
        }
    }

    public void GodMode()
    {
        if (godMode)
        {
            tagPlayer.gameObject.tag = "godMode";
        }
        else
        {
            tagPlayer.gameObject.tag = "Player";
        }
    }
}
