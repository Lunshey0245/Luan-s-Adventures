using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{

    public Animator animator;

    public string sceneToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene()
    {
        animator.SetTrigger("Change");
    }

    public void LoadSceneFade()
    {
        SceneManager.LoadScene(sceneToLoad);

    }


}
