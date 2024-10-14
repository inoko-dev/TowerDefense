using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public class UICanvas : MonoBehaviour
    {
        public bool IsShow => _isShow;

        private bool _isShow;

        public virtual void Show(bool isShow)
        {
            gameObject.SetActive(isShow);
            _isShow = isShow;
        }

        public virtual void OnBtnClose()
        {
            Show(false);
            //soundmanager button click
        }
    }
}
