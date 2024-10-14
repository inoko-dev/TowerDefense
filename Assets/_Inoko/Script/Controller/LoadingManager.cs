using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InnoStudio
{
    public class LoadingManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            LoadSceneMasterLevel();
        }

        void LoadSceneMasterLevel()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        }
    }
}
