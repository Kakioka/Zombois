using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherManager : MonoBehaviour
{

    public GameObject gm;
    public GameObject gun;
    public GameObject evilGun;

    void Awake()
    {
        gm = gm.GetComponent<gameManager>();
    }

    void Start()
    {
        gm.GetComponent<gameManager>().itemUpgradeGun(evilGun, gun);
    }

    public void itemUpgradeGun(GameObject gun, GameObject gunb)
    {
        gun.GetComponent<Gun>().fireRate = gunb.GetComponent<Gun>().fireRate * ((1 - (stim * gm.GetComponent<gameManager>.itemCounts[0])) * (1 + (bangFire * itemCounts[4])));
        gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gunb.GetComponent<Gun>().damage * Mathf.Pow(2, itemCounts[17]) * (1 + (bangDmg * itemCounts[4]) + (highDmg * itemCounts[3]) + (powerDmg * itemCounts[12])) * (1 - (MultiDmg * itemCounts[6]) - (lowDmg * itemCounts[13])));
        if (gun.GetComponent<Gun>().damage <= 0)
        {
            gun.GetComponent<Gun>().damage = 1;
        }
        gun.GetComponent<Gun>().bulletSize = gunb.GetComponent<Gun>().bulletSize * (1 + (bangSize * itemCounts[4]));
        gun.GetComponent<Gun>().boomScale = gunb.GetComponent<Gun>().boomScale * (1 + (bangSize * itemCounts[4]));
        gun.GetComponent<Gun>().bulletForce = gunb.GetComponent<Gun>().bulletForce * (1 + (gunpowder * itemCounts[2])) * (1 + (highSpeed * itemCounts[3])) * (1 - (powerSpeed * itemCounts[12]));
        gun.GetComponent<Gun>().piecre = gunb.GetComponent<Gun>().piecre + itemCounts[2] + itemCounts[12];
        gun.GetComponent<Gun>().reloadSpeed = gunb.GetComponent<Gun>().reloadSpeed * (1 + (fullReload * itemCounts[5])) * (1 - (glove * itemCounts[16]));
        float temp = 1 - (fullAmmo * itemCounts[5]);
        if (temp < 0.3 && itemCounts[3] > 0)
        {
            temp = 0.3f;
        }
        float temp2 = 1 - (highAmmo * itemCounts[3]);
        if (temp < 0.3 && itemCounts[5] > 0)
        {
            temp2 = 0.3f;
        }
        gun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(gunb.GetComponent<Gun>().ammo * (1 + (lowAmmo * itemCounts[13])) * (temp * temp2));
        if (gun.GetComponent<Gun>().maxAmmo < 1)
        {
            gun.GetComponent<Gun>().maxAmmo = 1;
        }
        gun.GetComponent<Gun>().projectiles = gunb.GetComponent<Gun>().projectiles + itemCounts[5] + itemCounts[6];
        gun.GetComponent<Gun>().knockBack = gunb.GetComponent<Gun>().knockBack * (1 + (bell * itemCounts[24]));
        if (itemCounts[14] > 0)
        {
            gun.GetComponent<Gun>().bleedOn = true;
            gun.GetComponent<Gun>().bleedLvl = itemCounts[14];
        }

        if (itemCounts[15] > 0)
        {
            gun.GetComponent<Gun>().splinterOn = true;
            gun.GetComponent<Gun>().splintLvl = itemCounts[15];
        }

        if (itemCounts[19] > 0)
        {
            gun.GetComponent<Gun>().burnOn = true;
            gun.GetComponent<Gun>().burnLvl = itemCounts[19];
        }

        if (itemCounts[20] > 0)
        {
            gun.GetComponent<Gun>().freezeOn = true;
            gun.GetComponent<Gun>().freezeLvl = itemCounts[20];
        }

        if (itemCounts[22] > 0)
        {
            if (beatG == null)
            {
                beatG = Instantiate(beats);

            }
            else
            {
                Destroy(beatG);
                beatG = Instantiate(beats);
            }
            beatG.GetComponent<BeatsManager>().player = player;
            beatG.GetComponent<BeatsManager>().beatsLvl = itemCounts[22];
        }

        if (itemCounts[25] > 0)
        {
            gun.GetComponent<Gun>().tridentOn = true;
            gun.GetComponent<Gun>().tridentLvl = itemCounts[25];
        }

        if (itemCounts[26] > 0)
        {
            gun.GetComponent<Gun>().laserOn = true;
            gun.GetComponent<Gun>().laserLvl = itemCounts[26];
        }

        if (itemCounts[27] > 0)
        {
            if (matrixG == null)
            {
                matrixG = Instantiate(matrix);

            }
            else
            {
                Destroy(matrixG);
                matrixG = Instantiate(matrix);
            }
            matrixG.GetComponent<Matrix>().player = player;
            matrixG.GetComponent<Matrix>().matrixLvl = itemCounts[27];
        }

    }

}
