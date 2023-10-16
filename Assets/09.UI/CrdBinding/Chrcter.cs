using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Chrcter
{
    public event Action OnChanged;

    private string _name;
    private string _description;
    private Sprite _sprite;

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnChanged?.Invoke();
            }
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnChanged?.Invoke();
            }
        }
    }

    public Sprite Sprite
    {
        get => _sprite;
        set
        {
            if (_sprite != value)
            {
                _sprite = value;
                OnChanged?.Invoke();
            }
        }
    }

    public Chrcter(string name, string description, Sprite sprite)
    {
        _name = name;
        _description = description;
        _sprite = sprite;
        OnChanged?.Invoke();
    }
}
