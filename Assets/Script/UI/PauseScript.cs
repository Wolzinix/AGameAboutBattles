using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject PauseScreen;
    [SerializeField] private InputActionReference _PauseAction;

    private void Start()
    {
        _PauseAction.action.started += SetPause;
    }

    private void SetPause(InputAction.CallbackContext context)
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisablePause()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

}
