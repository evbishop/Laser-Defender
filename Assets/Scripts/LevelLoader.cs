using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 1f;

    void Start()
    {
        PlayerStatus.OnPlayerDeath += LoadGameOver;
    }

    void OnDestroy()
    {
        PlayerStatus.OnPlayerDeath -= LoadGameOver;
    }

    public void LoadStartMenu()
    {
        FindObjectOfType<ScoreHander>().ResetScore();
        SceneManager.LoadScene("Menu");
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReloadMainGame()
    {
        FindObjectOfType<ScoreHander>().ResetScore();
        LoadMainGame();
    }

    void LoadGameOver()
    {
        StartCoroutine(DelayedLoading());
    }

    IEnumerator DelayedLoading()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
