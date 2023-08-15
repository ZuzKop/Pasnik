using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HayBar : MonoBehaviour
{
    public Slider slider;
    public Text counter;

    public void SetHay(int amount)
    {
        slider.value = amount;
        counter.text = amount.ToString() + "/" + GetHayMax();

    }
    public void SetHayMax(int amount)
    {
        slider.maxValue = amount;

    }
    public int GetHayMax()
    {
        return (int)slider.maxValue;
    }
}
