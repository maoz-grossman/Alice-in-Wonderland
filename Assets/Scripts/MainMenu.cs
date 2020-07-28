using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 50f;
    public AudioManager AM;
    private static bool again=false;

    public void PlayGame()
    {
        LoadNextLevel();
    }

    public void QuitGame()
    {
        Debug.Log("you quit the game.");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        if (!again)
        {
            again = true;
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        if (again)
            Application.LoadLevel(1);
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        //play animation
        transition.SetTrigger("StartIt");
        yield return new WaitForSeconds(1f);
        //Change soundtrack
        AM.Pause("menu");
        yield return new WaitForSeconds(.6f);
        AM.Play("AliceRuning");
        yield return new WaitForSeconds(.3f);
        //load next scene
        SceneManager.LoadScene(LevelIndex);
    }
}
