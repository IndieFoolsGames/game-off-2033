using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 0;


    public void LoadLevelNew()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadLevelByName(string name)
    {
        Scene scene = SceneManager.GetSceneByName(name);

        if (scene == null)
            return;

        int sceneIndex = scene.buildIndex;

        StartCoroutine(LoadLevel(sceneIndex));
    }

    public void LoadLevelByIndex(int index)
    {
        Scene scene = SceneManager.GetSceneByBuildIndex(index);
        if (scene == null)
            return;

        StartCoroutine(LoadLevel(index));
    }

    public void LoadNextLevel()
    {
        if(SceneManager.sceneCountInBuildSettings <= SceneManager.GetActiveScene().buildIndex + 1)
        {
            LoadLevelByIndex(0);
            return;
        }

        StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    
    IEnumerator LoadLevel(int Index)
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        if(animator != null)
        {
            animator.SetTrigger("Start");
        }      

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(Index);
    }
}
