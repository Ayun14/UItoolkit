using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
   [SerializeField] private int _maxHealth;
    private int _currnetHealth;

    public UnityEvent<float> OnChangeHealth;
    private void Start()
    {
        _currnetHealth = _maxHealth;
        OnChangeHealth?.Invoke((float)_currnetHealth / _maxHealth);
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            DecreaseHealth(10);
        }
    }

    public void DecreaseHealth(int amount)
    {
        _currnetHealth -= amount;
        OnChangeHealth?.Invoke((float)_currnetHealth / _maxHealth);
    }

    public void IncreaseHealth(int amount)
    {
        _currnetHealth += amount;
        OnChangeHealth?.Invoke((float)_currnetHealth / _maxHealth);
    }
}
