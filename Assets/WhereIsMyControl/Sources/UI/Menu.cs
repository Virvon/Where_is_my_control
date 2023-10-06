using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _screen;

    private void OnEnable()
    {
        _screen.SetActive(false);
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(Close);
    }

    private void Open()
    {
        Time.timeScale = 0;
        _screen.SetActive(true);
    }

    private void Close()
    {
        Time.timeScale = 1;
        _screen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Open();
    }
}
