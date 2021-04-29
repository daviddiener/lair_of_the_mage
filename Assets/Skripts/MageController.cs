using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageController : MonoBehaviour
{
    public GameObject lie;
    public GameObject teamWallEnemy;
    public Image timeoutBar;
    public Animator animator;
    public Text text;

    float buildSpeed = 0.05f;
    TeamStatus teamStatusEnemy;

    private void Start()
    {
        teamStatusEnemy = teamWallEnemy.GetComponent<TeamStatus>();
        timeoutBar.fillAmount = 0;

    }

    private void Update()
    {
        timeoutBar.fillAmount += 0.01f * buildSpeed;
    }

    public IEnumerator SpawnLies()
    {
        if (timeoutBar.fillAmount == 1)
        {
            timeoutBar.fillAmount = 0;
            animator.SetTrigger("magicHappens");
            text.gameObject.SetActive(true);
             yield return new WaitForSeconds(3.5f);
            text.gameObject.SetActive(false);

            GameObject tmp;

            tmp = Instantiate(lie, new Vector3(transform.position.x + 3, transform.position.y + 3, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x + 5, transform.position.y + 5, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x + 7, transform.position.y + 3, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x + 8, transform.position.y + 3, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x + 10, transform.position.y + 7, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x + 12, transform.position.y + 2, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x + 14, transform.position.y + 4, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x - 3, transform.position.y + 3, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x - 5, transform.position.y + 5, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x - 7, transform.position.y + 3, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x - 8, transform.position.y + 3, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x - 10, transform.position.y + 7, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x - 12, transform.position.y + 2, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;

            tmp = Instantiate(lie, new Vector3(transform.position.x - 14, transform.position.y + 4, transform.position.z), lie.transform.rotation);
            tmp.GetComponent<HandleMageProjectile>().teamStatusEnemy = teamStatusEnemy;
        }
    }

    public void SpawnLiesExposed()
    {
        StartCoroutine(SpawnLies());
    }
}
