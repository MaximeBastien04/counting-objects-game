    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class ButtonManager : MonoBehaviour
    {
        private GameObject MuteSoundButton;
        private GameObject PlaySoundButton;
        private String SceneName;

        void Start()
        {
            SceneName = SceneManager.GetActiveScene().name;
            if (SceneName != "StartScene" && SceneName != "EndScene")
            {
                MuteSoundButton = GameObject.Find("MuteButton");
                PlaySoundButton = GameObject.Find("SoundButton");
                MuteSoundButton.SetActive(false);
            }
        }

        void Update()
        {
            SceneName = SceneManager.GetActiveScene().name;
            if (SceneName != "StartScene" && SceneName != "EndScene")
            {
                SoundButtons();
            }
        }

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

        public void MuteSound()
        {
            AudioListener.volume = 0;
        }

        public void AmplifySound()
        {
            AudioListener.volume = 1;
        }

        private void SoundButtons()
        {
            if (AudioListener.volume == 1)
            {
                PlaySoundButton.SetActive(true);
                MuteSoundButton.SetActive(false);
            }
            else if (AudioListener.volume == 0)
            {
                PlaySoundButton.SetActive(false);
                MuteSoundButton.SetActive(true);
            }
        }
    }
