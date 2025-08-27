using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIConditions : MonoBehaviour
{
    public Image hp;
    public Image mp;
    public Image exp;

    public TextMeshProUGUI level;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI jewel;

    public void HpChange(float value, float maxValue)
    {
        hp.fillAmount = value / maxValue;
    }

    public void MpChange(float value, float maxValue)
    {
        mp.fillAmount = value / maxValue;
    }

    public void ExpChange(float value, float maxValue)
    {
        exp.fillAmount = value / maxValue;
    }

    public void LevelChange(int level)
    {
        this.level.text = $"Lv {level.ToString("D2")}";
    }

    public void GoldChange(int value)
    {
        gold.text = value.ToString();
    }

    public void JewelChange(int value)
    {
        jewel.text = value.ToString();
    }
}
