using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float Healt { get; private set; }

    public void Damaged(float value)
    {
        Healt -= value;
    }

    internal void SetMaxHealth(float maxHealth)
    {
        throw new NotImplementedException();
    }
}
