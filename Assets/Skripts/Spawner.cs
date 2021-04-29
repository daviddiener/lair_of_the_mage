using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] myPrefab;
    public bool repeat;
    public float spawnRate;
    public float verticalOffset;
    public GameObject teamWallOwn;
    public GameObject teamWallEnemy;
    public Image timeoutBar;

    TeamStatus teamStatusOwn;
    TeamStatus teamStatusEnemy;
    float buildSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (repeat)
        {
            InvokeRepeating("SpawnSoldierAI", spawnRate*2, spawnRate*2);
            InvokeRepeating("SpawnBowmanAI", spawnRate * 5f, spawnRate * 5f);
            InvokeRepeating("SpawnSwordsmanAI", spawnRate*7, spawnRate*7);

            StartCoroutine(delay(30)); //more guys
            StartCoroutine(delay(60)); //more guys
            StartCoroutine(delay(90)); //more guys
            StartCoroutine(delay(120)); //more guys
            StartCoroutine(delay(150)); //more guys
            StartCoroutine(delay(180)); //more guys
            StartCoroutine(delay(210)); //more guys
            StartCoroutine(delay(240)); //more guys
            StartCoroutine(delay(270)); //more guys
            StartCoroutine(delay(300)); //more guys

        }

        teamStatusOwn = teamWallOwn.GetComponent<TeamStatus>();
        teamStatusEnemy = teamWallEnemy.GetComponent<TeamStatus>();
    }

    private void Update()
    {
        if (!repeat)
        {
            timeoutBar.fillAmount += 0.01f * buildSpeed;
        }
    }

    public void SpawnSoldier()
    {
        if (teamStatusOwn.money >= 10)
        {
            if (timeoutBar.fillAmount == 1)
            {
                timeoutBar.fillAmount = 0.5f;
                GameObject ai = Instantiate(myPrefab[0], new Vector3(transform.position.x, transform.position.y + verticalOffset, transform.position.z), Quaternion.identity);
                ai.GetComponent<Soldier_ai>().teamStatusEnemy = teamStatusEnemy;
                teamStatusOwn.money -= 10;
            }

        }

    }

    public void SpawnBowman()
    {
        if (teamStatusOwn.money >= 30)
        {
            if (timeoutBar.fillAmount == 1)
            {
                timeoutBar.fillAmount = 0.3f;
                GameObject ai = Instantiate(myPrefab[1], new Vector3(transform.position.x, transform.position.y + verticalOffset, transform.position.z), Quaternion.identity);
                ai.GetComponent<Soldier_ai>().teamStatusEnemy = teamStatusEnemy;
                teamStatusOwn.money -= 30;
            }

        }
    }

    public void SpawnSwordsman()
    {
        if (teamStatusOwn.money >= 60)
        {
            if (timeoutBar.fillAmount == 1)
            {
                timeoutBar.fillAmount = 0f;
                GameObject ai = Instantiate(myPrefab[2], new Vector3(transform.position.x, transform.position.y + verticalOffset, transform.position.z), Quaternion.identity);
                ai.GetComponent<Soldier_ai>().teamStatusEnemy = teamStatusEnemy;
                teamStatusOwn.money -= 60;
            }

        }
    }

    //AI SPAWNER

    public void SpawnSoldierAI()
    {
        GameObject ai = Instantiate(myPrefab[0], new Vector3(transform.position.x, transform.position.y + verticalOffset, transform.position.z), Quaternion.identity);
        ai.GetComponent<Soldier_ai>().teamStatusEnemy = teamStatusEnemy;
    }

    public void SpawnBowmanAI()
    {
        GameObject ai = Instantiate(myPrefab[1], new Vector3(transform.position.x, transform.position.y + verticalOffset, transform.position.z), Quaternion.identity);
        ai.GetComponent<Soldier_ai>().teamStatusEnemy = teamStatusEnemy;
    }

    public void SpawnSwordsmanAI()
    {
        GameObject ai = Instantiate(myPrefab[2], new Vector3(transform.position.x, transform.position.y + verticalOffset, transform.position.z), Quaternion.identity);
        ai.GetComponent<Soldier_ai>().teamStatusEnemy = teamStatusEnemy;
    }
   
    public IEnumerator delay(int time)
    {
        yield return new WaitForSeconds(time);
        spawnRate += 1;
    }
}
