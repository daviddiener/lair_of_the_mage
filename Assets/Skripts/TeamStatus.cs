using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TeamStatus : MonoBehaviour
{
    public float maxBaseHP;
    public float money;
    public Image healthBar;
    public bool isTeam1;
    public GameObject panel;
    public GameObject text;
    SceneAnimations sceneAnimations;
    Text moneyText;


    private float currBaseHP;
    // Start is called before the first frame update
    void Start()
    {
        currBaseHP = maxBaseHP;
        sceneAnimations = panel.GetComponent<SceneAnimations>();
        moneyText = text.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currBaseHP <= 0)
        {
            if (isTeam1)
            {
                sceneAnimations.LoadScene("GameLostScene");
            }
            else
            {
                sceneAnimations.LoadScene("GameWonScene");
            }


        }

        if (currBaseHP < 30)
        {
            healthBar.color = new Color32(255, 0, 0, 255); ;
        }

        //update money
        moneyText.text = "Money: "+money; 
        
    }

    public void receiveDamage(int damage)
    {
        currBaseHP = currBaseHP - damage;
        healthBar.fillAmount = currBaseHP / maxBaseHP;

    }
}
