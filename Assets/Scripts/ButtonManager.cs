using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void LoadGameEnd()
    {
        SceneManager.LoadScene("EndScreen");
    }

    private void MuteSound()
    {
        AudioListener.volume = 0;
        Debug.Log(AudioListener.volume);
    }

    private void AmplifySound()
    {
        AudioListener.volume = 1;
        Debug.Log(AudioListener.volume);
    }
}
