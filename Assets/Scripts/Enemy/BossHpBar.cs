using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    
    public Slider slider;
    public GameObject boss;

    void Start(){
        slider.maxValue = boss.GetComponent<Enemy>().health;
        slider.value = slider.maxValue;
    }

    void Update(){
        slider.value = boss.GetComponent<Enemy>().health;
    }
}
