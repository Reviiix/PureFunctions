﻿using UnityEngine;
using UnityEngine.UI;

namespace PureFunctions
{
    [RequireComponent(typeof(Button))]
    public class OpenURLButton : MonoBehaviour
    {
        [SerializeField] private string url;
        private Button _button;

        private void Awake()
        {
            AssignButtonEvents();
        }
    
        private void AssignButtonEvents()
        {
            GetComponent<Button>().onClick.AddListener(OpenURLButtonPressed);
        }

        private void OpenURLButtonPressed()
        {
            Application.OpenURL(url);
        }
    }
}
