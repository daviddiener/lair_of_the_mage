using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleProjectile : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float Smoothing = .05f;
    public float speed;
    public bool team1;
    public int damage;
    private bool FacingRight = true;


    private Rigidbody2D Rigidbody_2D;
    private Vector3 Velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody_2D = GetComponent<Rigidbody2D>();

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
        Vector3 targetVelocity = new Vector2(speed, Rigidbody_2D.velocity.y);
        Rigidbody_2D.velocity = Vector3.SmoothDamp(Rigidbody_2D.velocity, targetVelocity, ref Velocity, Smoothing);
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

}
