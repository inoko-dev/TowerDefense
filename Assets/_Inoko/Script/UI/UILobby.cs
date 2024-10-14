using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InnoStudio
{
    public class UILobby : UICanvas
    {
        [FoldoutGroup("Button")]
        [SerializeField] private Button btnPlay;

        public void Init()
        {
            btnPlay.onClick.AddListener(OnBtnPlay);
        }

        public void OnBtnPlay()
        {
            GameManager.Instance.StartLevel();
        }
    }
}