using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField] private GameObject _flashlight;
    [SerializeField] private GameObject _flashlightOn;

    private PlayerItems _playerItems;

    private void Start()
    {
        _playerItems = GetComponent<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleFlashlight();
    }

    private void HandleFlashlight()
    {
        if (!_playerItems.FlashlightEquipped)
        {
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            _flashlightOn.SetActive(true);
        }

        if (Input.GetButtonUp("Fire2"))
        {
            _flashlightOn.SetActive(false);
        }
    }
}
