using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundHandler : MonoBehaviour
{
    public void toggleSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
