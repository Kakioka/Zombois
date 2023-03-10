using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{

    public Slider slider;
    public GameObject boss;
    public TextMeshProUGUI tmp;

    void Start()
    {
        slider.maxValue = boss.GetComponent<Enemy>().health;
        slider.value = slider.maxValue;
    }

    void Update()
    {
        slider.value = boss.GetComponent<Enemy>().health;
        tmp.text = "HP: " + boss.GetComponent<Enemy>().health;
    }
}
