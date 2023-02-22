using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    public Revolver revolver;
    public TextMeshProUGUI ammoText;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial ammo text
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + revolver.ammo.ToString() + "/" + revolver.maxAmmo.ToString();

        if (int.TryParse(ammoText.text, out int result))
        {
            ammoText.text = "Ammo: " + revolver.ammo.ToString() + "/" + revolver.maxAmmo.ToString();
        }
    }

    void UpdateAmmoText()
    {
        // Update the ammo text with the current ammo value
        ammoText.SetText("Ammo: " + revolver.ammo.ToString() + "/" + revolver.maxAmmo.ToString());
    }
}
