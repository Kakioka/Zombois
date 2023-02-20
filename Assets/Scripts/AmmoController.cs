using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    public int maxAmmo = 10;
    public float reloadTime = 1f;
    public float shootCooldown = 0.5f;
    public Text ammoText;

    private int currentAmmo;
    private bool isReloading = false;
    private float lastShotTime = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
        }

        if (Input.GetButton("Fire1") && !isReloading && Time.time - lastShotTime > shootCooldown && currentAmmo > 0)
        {
            lastShotTime = Time.time;
            currentAmmo--;
            UpdateAmmoText();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.SetText = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }
}