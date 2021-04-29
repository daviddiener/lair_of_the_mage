using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Image bar1;
    public Image bar2;

    private float bar1save;
    private float bar2save;

    void Update()
    {
        bar1.fillAmount = bar1save;
        bar2.fillAmount = bar2save;
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);

        //get Bar values
        bar1save = bar1.fillAmount;
        bar2save = bar2.fillAmount;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void toggleSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
