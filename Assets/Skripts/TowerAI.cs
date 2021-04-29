using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{

    public GameObject ammo;
    public float attackSpeed;
    public Animator animator;

    private IEnumerator rou;
    public List<Collider2D> onHold;
    private int targetCount;

    private void Start()
    {
        targetCount = 0;
    }

    void Update()
    {
        if (onHold[0] != null)
        {
            var dir = onHold[0].transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //soldier collission
        Soldier_ai soldier_ai = collider.GetComponent<Soldier_ai>();
        if (soldier_ai != null)
        {
            if (targetCount==0)
            {
                //start attack
                onHold.Add(collider);
                rou = attack();
                StartCoroutine(rou);
                animator.SetBool("isAttacking", true);
            }
            else
            {
                onHold.Add(collider);
            }
            targetCount++;


        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //soldier collission
        Soldier_ai soldier_ai = collider.GetComponent<Soldier_ai>();
        if (soldier_ai != null)
        {
            targetCount--;
            onHold.RemoveAt(0);
            if (targetCount<1)
            {
                StopCoroutine(rou);
                animator.SetBool("isAttacking", false);
            }
        }
    }

    private IEnumerator attack()
    {
        while (true)
        {
            if (onHold[0] != null)
            {
                GameObject projectile = Instantiate(ammo, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                projectile.GetComponent<HandleTowerProjectile>().targetTransform = onHold[0].transform;
                yield return new WaitForSeconds(1f / attackSpeed);
            }
            
        }
    }

}
