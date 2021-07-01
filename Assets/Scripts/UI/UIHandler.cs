using System;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _successUI;
    [SerializeField] private GameObject _failedUI;

    private void OnEnable()
    {
        _successUI.SetActive(false);
        _failedUI.SetActive(false);

        DangerZone.OnPlayerEnter = Player.OnPlayerDie += ShowFailedUI;
        Finish.OnFinish += ShowSuccessUI;
    }

    private void OnDisable()
    {
        DangerZone.OnPlayerEnter = Player.OnPlayerDie -= ShowFailedUI;
        Finish.OnFinish -= ShowSuccessUI;
    }

    private void ShowSuccessUI() => _successUI.SetActive(true);

    private void ShowFailedUI() => _failedUI.SetActive(true);
}
