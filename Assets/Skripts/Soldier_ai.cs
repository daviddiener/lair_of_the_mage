using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Soldier_ai : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float Smoothing = .05f;
    public float speed;
    public int damage;
    public float attackSpeed;
    public int maxHP;
    public Animator animator;
    public bool team1;
    public string soldierType;
    public GameObject ammo;
    public int moneyDrop;

    public TeamStatus teamStatusEnemy;
    private Rigidbody2D Rigidbody_2D;
    private Vector3 Velocity = Vector3.zero;
    private bool FacingRight = true;
    private int currHP;
    private IEnumerator co;
    private IEnumerator coBow;
    private bool moving;


    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody_2D = GetComponent<Rigidbody2D>();
        currHP = maxHP;
        co = mock();
        coBow = mock();
        animator.SetFloat("speedMultiplier", attackSpeed);

        if (speed > 0 && !FacingRight)
        {
            Flip();
        }
        else if (speed < 0 && FacingRight)
        {
            Flip();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (currHP <= 0)
        {
            //money
            teamStatusEnemy.money += moneyDrop;
            Destroy(this.gameObject);
        }

        animator.SetFloat("currSpeed", Mathf.Abs(Rigidbody_2D.velocity.x));    
    }

    void FixedUpdate()
    {
        //move
        move();
    }

    void move()
    {
        Vector3 targetVelocity = new Vector2(speed * 10f, Rigidbody_2D.velocity.y);
        Rigidbody_2D.velocity = Vector3.SmoothDamp(Rigidbody_2D.velocity, targetVelocity, ref Velocity, Smoothing);
        if (Mathf.Abs(Rigidbody_2D.velocity.x)>1.5)
        {
            animator.SetBool("isAttacking", false);
            StopCoroutine(co);
            Rigidbody_2D.mass = 1;
        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
                co = attack(soldier_ai);
                StartCoroutine(co);
                Rigidbody_2D.mass = 10000;
                animator.SetBool("isAttacking", true);
            }
        }

        //wall collission
        TeamStatus teamStatus = collision.collider.GetComponent<TeamStatus>();
        if (teamStatus != null)
        {
                //start attack
                co = attack(teamStatus);
                StartCoroutine(co);
                Rigidbody_2D.mass = 10000;
                animator.SetBool("isAttacking", true);
        }
    }

    public void OnCollisionEnter2DChild(Collider2D collider)
    {
        //soldier collission
        Soldier_ai soldier_ai = collider.GetComponent<Soldier_ai>();
        if (soldier_ai != null)
        {
            if (team1 != soldier_ai.team1) //not same team
            {
                //start attack
                coBow = attack(soldier_ai);
                StartCoroutine(coBow);
                animator.SetBool("isAttacking", true);
            }
        }

        //wall collission
        TeamStatus teamStatus = collider.GetComponent<TeamStatus>();
        if (teamStatus != null)
        {
            //start attack
            coBow = attack(teamStatus);
            StartCoroutine(coBow);
            animator.SetBool("isAttacking", true);
        }
    }

    public void OnCollisionExit2DChild(Collider2D collider)
    {
        //soldier collission
        Soldier_ai soldier_ai = collider.GetComponent<Soldier_ai>();
        if (soldier_ai != null)
        {
            if (team1 != soldier_ai.team1) //not same team
            {
                //stop attack
                animator.SetBool("isAttacking", false);
                StopCoroutine(coBow);
            }
        }

        //wall collission
        TeamStatus teamStatus = collider.GetComponent<TeamStatus>();
        if (teamStatus != null)
        {
            //stop attack
            animator.SetBool("isAttacking", false);
            StopCoroutine(coBow);
        }
    }

    public void receiveDamage(int damage)
    {
        currHP = currHP - damage;
    }

    private IEnumerator attack(Soldier_ai soldier_ai)
    {
        while (true)
        {
            if (soldierType == "soldier" || soldierType == "swordsman")
            {
                soldier_ai.receiveDamage(damage);
            }
            else if (soldierType=="bowman")
            {
                Instantiate(ammo, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }

            yield return new WaitForSeconds(1f / attackSpeed);

        }
    }

    private IEnumerator attack(TeamStatus teamStatus)
    {
        while (true)
        {
            if (soldierType == "soldier" || soldierType == "swordsman")
            {
                teamStatus.receiveDamage(damage);
            }
            else if (soldierType == "bowman")
            {
                Instantiate(ammo, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }

            yield return new WaitForSeconds(1f / attackSpeed);

        }
    }

    private IEnumerator mock()
    {
        //intentionally empty
        yield return new WaitForSeconds(2f);

    }
}
