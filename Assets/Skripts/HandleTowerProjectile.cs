using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTowerProjectile : MonoBehaviour
{
    public float speed;
    public bool team1;
    public int damage;
    private bool FacingRight = true;

    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        if (speed > 0 && !FacingRight)
        {
            Flip();
        }
        else if (speed < 0 && FacingRight)
        {
            Flip();
        }

        Destroy(this.gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //soldier collission
        Soldier_ai soldier_ai = collision.collider.GetComponent<Soldier_ai>();
        if (soldier_ai != null)
        {
            if (team1 != soldier_ai.team1) //not same team
            {
                //start attack
                soldier_ai.receiveDamage(damage);
                Destroy(this.gameObject);
            }
        }

        //wall collission
        TeamStatus teamStatus = collision.collider.GetComponent<TeamStatus>();
        if (teamStatus != null)
        {
            //start attack
            teamStatus.receiveDamage(damage);
            Destroy(this.gameObject);
        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void setTargetVector(Transform target)
    {
        targetTransform = target;
    }
}
