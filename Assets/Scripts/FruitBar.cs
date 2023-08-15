using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitBar : MonoBehaviour
{
    public Slider slider;
    public Text counter;

    public void SetFruit(int amount)
    {
        slider.value = amount;
        counter.text = amount.ToString() + "/" + GetFruitMax();

    }
    public void SetFruitMax(int amount)
    {
        slider.maxValue = amount;

    }
    public int GetFruitMax()
    {
        return (int)slider.maxValue;
    }
}
