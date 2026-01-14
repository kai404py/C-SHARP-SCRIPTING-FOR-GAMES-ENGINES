using System;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider Slider;

    public void SetMaxHealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }

    public void SetHeath(int health)
    {
        Slider.value = health;
    }
}
