using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Visit()
    {
        //SceneManager.LoadScene("HelloAR");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //用场景名或当前场景的下一个
    }
    public void Visit2()
    {
        //SceneManager.LoadScene("HelloAR");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        //用场景名或当前场景的下一个
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();

    }
}

