using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    public GameObject tower;
    public TeamStatus teamStatusOwn;
    public Text towerText;

    private int towerCount;

    // Start is called before the first frame update
    void Start()
    {
        towerCount = 0;
    }

    public void spawnTower()
    {
        if (teamStatusOwn.money >= 200*(towerCount+1))
        {
            if (towerCount<5)
            {
                towerCount++;
                GameObject ai = Instantiate(tower, new Vector3(transform.position.x, transform.position.y+(-1*towerCount), transform.position.z), Quaternion.identity);
                teamStatusOwn.money -= 200*towerCount;
                towerText.text = "Build Bullet-Machine ("+200*(towerCount+1)+")";
            }
            
        }
    }
}
