using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAnimations : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }
    private IEnumerator LoadSceneAFterTransition(string scene)
    {
        //show animate out animation
        animator.SetBool("animateOut", true);
        yield return new WaitForSeconds(0.6f);
        //load the scene we want
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(LoadSceneAFterTransition(scene));
    }
}
