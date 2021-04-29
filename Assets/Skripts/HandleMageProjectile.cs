using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMageProjectile : MonoBehaviour
{
    public bool team1;
    public GameObject cloneSoldier;
    public GameObject cloneBowman;
    public GameObject cloneSwordsman;

    public TeamStatus teamStatusEnemy;

    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //soldier collission
        Soldier_ai soldier_ai = collision.collider.GetComponent<Soldier_ai>();
        if (soldier_ai != null)
        {
            if (team1 != soldier_ai.team1) //not same team
            {
                Destroy(soldier_ai.gameObject);

                if (soldier_ai.soldierType=="soldier")
                {
                    GameObject ai = Instantiate(cloneSoldier, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    ai.GetComponent<Soldier_ai>().teamStatusEnemy = teamStatusEnemy;
                }
                else if (soldier_ai.soldierType == "bowman")
                {
                    GameObject ai = Instantiate(cloneBowman, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    ai.GetComponent<Soldier_ai>().teamStatusEnemy = teamStatusEnemy;
                }
                else if (soldier_ai.soldierType == "swordsman")
                {
                    GameObject ai = Instantiate(cloneSwordsman, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    ai.GetComponent<Soldier_ai>().teamStatusEnemy = teamStatusEnemy;
                }
                Destroy(this.gameObject);
            }
        }
     }
}
