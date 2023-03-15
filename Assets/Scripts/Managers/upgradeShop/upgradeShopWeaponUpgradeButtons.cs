using TMPro;
using UnityEngine;

/*public class upgradeShopWeaponUpgradeButtons : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;

    public TextMeshProUGUI damage;
    public TextMeshProUGUI fireRate;
    public TextMeshProUGUI reload;
    public TextMeshProUGUI knockBack;
    public TextMeshProUGUI bullet;
    public TextMeshProUGUI pierce;
    public TextMeshProUGUI size;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI ammo;

    public GameObject damageB;
    public GameObject fireRateB;
    public GameObject reloadB;
    public GameObject knockBackB;
    public GameObject bulletB;
    public GameObject pierceB;
    public GameObject sizeB;
    public GameObject speedB;
    public GameObject ammoB;

    public int damageI;
    public int damageII;
    public int damageIII;

    public int ammoI;
    public int ammoII;
    public int ammoIII;

    public int fireRateI;
    public int fireRateII;
    public int fireRateIII;

    public int knockBackI;
    public int knockBackII;
    public int knockBackIII;

    public int reloadI;
    public int reloadII;
    public int reloadIII;

    public int bulletI;
    public int bulletII;
    public int bulletIII;

    public int pierceI;
    public int pierceII;
    public int pierceIII;

    public int sizeI;
    public int sizeII;
    public int sizeIII;

    public int speedI;
    public int speedII;
    public int speedIII;

    public GameObject revolver;
    public GameObject shotgun;
    public GameObject machineGun;
    public GameObject sniper;

    private int rBaseDmg;
    private int rBaseAmmo;
    private float rBaseFire;
    private float rBaseReload;
    private int rBaseBullet;
    private int rBasePierce;
    private float rBaseSize;
    private float rBaseSpeed;
    private float rBaseKnock;

    private int sGBaseDmg;
    private int sGBaseAmmo;
    private float sGBaseFire;
    private float sGBaseReload;
    private int sGBaseBullet;
    private int sGBasePierce;
    private float sGBaseSize;
    private float sGBaseSpeed;
    private float sGBaseKnock;

    private int mBaseDmg;
    private int mBaseAmmo;
    private float mBaseFire;
    private float mBaseReload;
    private int mBaseBullet;
    private int mBasePierce;
    private float mBaseSize;
    private float mBaseSpeed;
    private float mBaseKnock;

    private int sBaseDmg;
    private int sBaseAmmo;
    private float sBaseFire;
    private float sBaseReload;
    private int sBaseBullet;
    private int sBasePierce;
    private float sBaseSize;
    private float sBaseSpeed;
    private float sBaseKnock;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameObject.GetComponent<upgradeShopManager>().gameManager;
        player = gameObject.GetComponent<upgradeShopManager>().player;
        revolver = gameObject.GetComponent<upgradeShopWepButtons>().revObj;
        shotgun = gameObject.GetComponent<upgradeShopWepButtons>().shotgunObj;
        machineGun = gameObject.GetComponent<upgradeShopWepButtons>().machinegunObj;
        sniper = gameObject.GetComponent<upgradeShopWepButtons>().sniperObj;

        rBaseDmg = revolver.GetComponent<Gun>().damage;
        rBaseAmmo = revolver.GetComponent<Gun>().maxAmmo;
        rBaseFire = revolver.GetComponent<Gun>().fireRate;
        rBaseReload = revolver.GetComponent<Gun>().reloadSpeed;
        rBaseBullet = revolver.GetComponent<Gun>().projectiles;
        rBasePierce = revolver.GetComponent<Gun>().piecre;
        rBaseSize = revolver.GetComponent<Gun>().bulletSize;
        rBaseSpeed = revolver.GetComponent<Gun>().bulletForce;
        rBaseKnock = revolver.GetComponent<Gun>().knockBack;

        sGBaseDmg = shotgun.GetComponent<Gun>().damage;
        sGBaseAmmo = shotgun.GetComponent<Gun>().maxAmmo;
        sGBaseFire = shotgun.GetComponent<Gun>().fireRate;
        sGBaseReload = shotgun.GetComponent<Gun>().reloadSpeed;
        sGBaseBullet = shotgun.GetComponent<Gun>().projectiles;
        sGBasePierce = shotgun.GetComponent<Gun>().piecre;
        sGBaseSize = shotgun.GetComponent<Gun>().bulletSize;
        sGBaseSpeed = shotgun.GetComponent<Gun>().bulletForce;
        sGBaseKnock = shotgun.GetComponent<Gun>().knockBack;

        mBaseDmg = machineGun.GetComponent<Gun>().damage;
        mBaseAmmo = machineGun.GetComponent<Gun>().maxAmmo;
        mBaseFire = machineGun.GetComponent<Gun>().fireRate;
        mBaseReload = machineGun.GetComponent<Gun>().reloadSpeed;
        mBaseBullet = machineGun.GetComponent<Gun>().projectiles;
        mBasePierce = machineGun.GetComponent<Gun>().piecre;
        mBaseSize = machineGun.GetComponent<Gun>().bulletSize;
        mBaseSpeed = machineGun.GetComponent<Gun>().bulletForce;
        mBaseKnock = machineGun.GetComponent<Gun>().knockBack;

        sBaseDmg = sniper.GetComponent<Gun>().damage;
        sBaseAmmo = sniper.GetComponent<Gun>().maxAmmo;
        sBaseFire = sniper.GetComponent<Gun>().fireRate;
        sBaseReload = sniper.GetComponent<Gun>().reloadSpeed;
        sBaseBullet = sniper.GetComponent<Gun>().projectiles;
        sBasePierce = sniper.GetComponent<Gun>().piecre;
        sBaseSize = sniper.GetComponent<Gun>().bulletSize;
        sBaseSpeed = sniper.GetComponent<Gun>().bulletForce;
        sBaseKnock = sniper.GetComponent<Gun>().knockBack;

        gameManager.GetComponent<gameManager>().wepUpgrade(revolver);
        gameManager.GetComponent<gameManager>().wepUpgrade(shotgun);
        gameManager.GetComponent<gameManager>().wepUpgrade(machineGun);
        gameManager.GetComponent<gameManager>().wepUpgrade(sniper);
    }

// Update is called once per frame
void Update()
    {
        wepUpgrades();
    }

    void wepUpgrades()
    {
        switch (gameManager.GetComponent<gameManager>().ammoUp)
        {
            case 0:
                ammo.text = "Ammo Up Level I";
                ammoB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + ammoI;
                break;
            case 1:
                ammo.text = "Ammo Up Level II";
                ammoB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + ammoII;
                break;
            case 2:
                ammo.text = "Ammo Up Level III";
                ammoB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + ammoIII;
                break;
            case 3:
                ammo.text = "Ammo Up Maxed";
                ammoB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().damageUp)
        {
            case 0:
                damage.text = "Damage Up Level I";
                damageB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + damageI;
                break;
            case 1:
                damage.text = "Damage Up Level II";
                damageB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + damageII;
                break;
            case 2:
                damage.text = "Damage Up Level III";
                damageB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + damageIII;
                break;
            case 3:
                damage.text = "Damage Up Maxed";
                damageB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().fireUp)
        {
            case 0:
                fireRate.text = "Fire Rate Up Level I";
                fireRateB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + fireRateI;
                break;
            case 1:
                fireRate.text = "Fire Rate Up Level II";
                fireRateB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + fireRateII;
                break;
            case 2:
                fireRate.text = "Fire Rate Up Level III";
                fireRateB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + fireRateIII;
                break;
            case 3:
                fireRate.text = "Fire Rate Up Maxed";
                fireRateB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().reloadUp)
        {
            case 0:
                reload.text = "Reload Speed Up Level I";
                reloadB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + reloadI;
                break;
            case 1:
                reload.text = "Reload Speed Up Level II";
                reloadB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + reloadII;
                break;
            case 2:
                reload.text = "Reload Speed Up Level III";
                reloadB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + reloadIII;
                break;
            case 3:
                reload.text = "Reload Speed Up Maxed";
                reloadB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().knockUp)
        {
            case 0:
                knockBack.text = "Knock Back Up Level I";
                knockBackB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + knockBackI;
                break;
            case 1:
                knockBack.text = "Knock Back Up Level II";
                knockBackB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + knockBackII;
                break;
            case 2:
                knockBack.text = "Knock Back Up Level III";
                knockBackB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + knockBackIII;
                break;
            case 3:
                knockBack.text = "knockBack Up Maxed";
                knockBackB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().speedUp)
        {
            case 0:
                speed.text = "Bullet Speed Up Level I";
                speedB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + speedI;
                break;
            case 1:
                speed.text = "Bullet Speed Up Level II";
                speedB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + speedII;
                break;
            case 2:
                speed.text = "Bullet Speed Up Level III";
                speedB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + speedIII;
                break;
            case 3:
                speed.text = "Bullet Speed Up Maxed";
                speedB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().projectileUp)
        {
            case 0:
                bullet.text = "Extra Bullet Up Level I";
                bulletB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + bulletI;
                break;
            case 1:
                bullet.text = "Extra Bullet Up Level II";
                bulletB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + bulletII;
                break;
            case 2:
                bullet.text = "Extra Bullet Up Level III";
                bulletB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + bulletIII;
                break;
            case 3:
                bullet.text = "Extra Bullet Up Maxed";
                bulletB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().pierceUp)
        {
            case 0:
                pierce.text = "Pierce Up Level I";
                pierceB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pierceI;
                break;
            case 1:
                pierce.text = "Pierce Up Level II";
                pierceB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pierceII;
                break;
            case 2:
                pierce.text = "Pierce Up Level III";
                pierceB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pierceIII;
                break;
            case 3:
                pierce.text = "Pierce Up Maxed";
                pierceB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().sizeUp)
        {
            case 0:
                size.text = "Bullet Size Up Level I";
                sizeB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost :" + sizeI;
                break;
            case 1:
                size.text = "Bullet Size Up Level II";
                sizeB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost :" + sizeII;
                break;
            case 2:
                size.text = "Bullet Size Up Level III";
                sizeB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost :" + sizeIII;
                break;
            case 3:
                size.text = "Bullet Size Up Maxed";
                sizeB.SetActive(false);
                break;
        }
    }

    public void damageButton()
    {
        switch (gameManager.GetComponent<gameManager>().damageUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= damageI)
                {
                    gameManager.GetComponent<gameManager>().damageUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= damageI;
                    bulletDamageCal();
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= damageII)
                {
                    gameManager.GetComponent<gameManager>().damageUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= damageII;
                    bulletDamageCal();
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= damageIII)
                {
                    gameManager.GetComponent<gameManager>().damageUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= damageIII;
                    bulletDamageCal();
                }
                break;
        }
    }

    public void ammoButton()
    {
        switch (gameManager.GetComponent<gameManager>().ammoUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= ammoI)
                {
                    gameManager.GetComponent<gameManager>().ammoUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= ammoI;
                    revolver.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(rBaseAmmo * gameManager.GetComponent<gameManager>().ammoI);
                    shotgun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(sGBaseAmmo * gameManager.GetComponent<gameManager>().ammoI);
                    machineGun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(mBaseAmmo * gameManager.GetComponent<gameManager>().ammoI);
                    sniper.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(sBaseAmmo * gameManager.GetComponent<gameManager>().ammoI);
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= ammoII)
                {
                    gameManager.GetComponent<gameManager>().ammoUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= ammoII;
                    revolver.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(rBaseAmmo * gameManager.GetComponent<gameManager>().ammoII);
                    shotgun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(sGBaseAmmo * gameManager.GetComponent<gameManager>().ammoII);
                    machineGun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(mBaseAmmo * gameManager.GetComponent<gameManager>().ammoII);
                    sniper.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(sBaseAmmo * gameManager.GetComponent<gameManager>().ammoII);
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= ammoIII)
                {
                    gameManager.GetComponent<gameManager>().ammoUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= ammoIII;
                    revolver.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(rBaseAmmo * gameManager.GetComponent<gameManager>().ammoIII);
                    shotgun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(sGBaseAmmo * gameManager.GetComponent<gameManager>().ammoIII);
                    machineGun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(mBaseAmmo * gameManager.GetComponent<gameManager>().ammoIII);
                    sniper.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(sBaseAmmo * gameManager.GetComponent<gameManager>().ammoIII);
                }
                break;
        }
    }

    public void fireRateButton()
    {
        switch (gameManager.GetComponent<gameManager>().fireUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= fireRateI)
                {
                    gameManager.GetComponent<gameManager>().fireUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= fireRateI;
                    revolver.GetComponent<Gun>().fireRate = rBaseFire* gameManager.GetComponent<gameManager>().fireRateI;
                    shotgun.GetComponent<Gun>().fireRate = sGBaseFire * gameManager.GetComponent<gameManager>().fireRateI;
                    machineGun.GetComponent<Gun>().fireRate = mBaseFire * gameManager.GetComponent<gameManager>().fireRateI;
                    sniper.GetComponent<Gun>().fireRate = sBaseFire * gameManager.GetComponent<gameManager>().fireRateI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= fireRateII)
                {
                    gameManager.GetComponent<gameManager>().fireUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= fireRateII;
                    revolver.GetComponent<Gun>().fireRate = rBaseFire * gameManager.GetComponent<gameManager>().fireRateII;
                    shotgun.GetComponent<Gun>().fireRate = sGBaseFire * gameManager.GetComponent<gameManager>().fireRateII;
                    machineGun.GetComponent<Gun>().fireRate = mBaseFire * gameManager.GetComponent<gameManager>().fireRateII;
                    sniper.GetComponent<Gun>().fireRate = sBaseFire * gameManager.GetComponent<gameManager>().fireRateII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= fireRateIII)
                {
                    gameManager.GetComponent<gameManager>().fireUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= fireRateIII;
                    revolver.GetComponent<Gun>().fireRate = rBaseFire * gameManager.GetComponent<gameManager>().fireRateIII;
                    shotgun.GetComponent<Gun>().fireRate = sGBaseFire * gameManager.GetComponent<gameManager>().fireRateIII;
                    machineGun.GetComponent<Gun>().fireRate = mBaseFire * gameManager.GetComponent<gameManager>().fireRateIII;
                    sniper.GetComponent<Gun>().fireRate = sBaseFire * gameManager.GetComponent<gameManager>().fireRateIII;
                }
                break;
        }
    }

    public void reloadButton()
    {
        switch (gameManager.GetComponent<gameManager>().reloadUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= reloadI)
                {
                    gameManager.GetComponent<gameManager>().reloadUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= reloadI;
                    revolver.GetComponent<Gun>().reloadSpeed = rBaseReload * gameManager.GetComponent<gameManager>().reloadI;
                    shotgun.GetComponent<Gun>().reloadSpeed = sGBaseReload * gameManager.GetComponent<gameManager>().reloadI;
                    machineGun.GetComponent<Gun>().reloadSpeed = mBaseReload * gameManager.GetComponent<gameManager>().reloadI;
                    sniper.GetComponent<Gun>().reloadSpeed = sBaseReload * gameManager.GetComponent<gameManager>().reloadI;

                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= reloadII)
                {
                    gameManager.GetComponent<gameManager>().reloadUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= reloadII;
                    revolver.GetComponent<Gun>().reloadSpeed = rBaseReload * gameManager.GetComponent<gameManager>().reloadII;
                    shotgun.GetComponent<Gun>().reloadSpeed = sGBaseReload * gameManager.GetComponent<gameManager>().reloadII;
                    machineGun.GetComponent<Gun>().reloadSpeed = mBaseReload * gameManager.GetComponent<gameManager>().reloadII;
                    sniper.GetComponent<Gun>().reloadSpeed = sBaseReload * gameManager.GetComponent<gameManager>().reloadII;

                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= reloadIII)
                {
                    gameManager.GetComponent<gameManager>().reloadUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= reloadIII;
                    revolver.GetComponent<Gun>().reloadSpeed = rBaseReload * gameManager.GetComponent<gameManager>().reloadIII;
                    shotgun.GetComponent<Gun>().reloadSpeed = sGBaseReload * gameManager.GetComponent<gameManager>().reloadIII;
                    machineGun.GetComponent<Gun>().reloadSpeed = mBaseReload * gameManager.GetComponent<gameManager>().reloadIII;
                    sniper.GetComponent<Gun>().reloadSpeed = sBaseReload * gameManager.GetComponent<gameManager>().reloadIII;

                }
                break;
        }
    }

    public void knockBackButton()
    {
        switch (gameManager.GetComponent<gameManager>().knockUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= knockBackI)
                {
                    gameManager.GetComponent<gameManager>().knockUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= knockBackI;
                    revolver.GetComponent<Gun>().knockBack = rBaseKnock + gameManager.GetComponent<gameManager>().knockBackI;
                    shotgun.GetComponent<Gun>().knockBack = sGBaseKnock + gameManager.GetComponent<gameManager>().knockBackI;
                    machineGun.GetComponent<Gun>().knockBack = mBaseKnock + gameManager.GetComponent<gameManager>().knockBackI;
                    sniper.GetComponent<Gun>().knockBack = sBaseKnock + gameManager.GetComponent<gameManager>().knockBackI;

                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= knockBackII)
                {
                    gameManager.GetComponent<gameManager>().knockUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= knockBackII;
                    revolver.GetComponent<Gun>().knockBack = rBaseKnock + gameManager.GetComponent<gameManager>().knockBackII;
                    shotgun.GetComponent<Gun>().knockBack = sGBaseKnock + gameManager.GetComponent<gameManager>().knockBackII;
                    machineGun.GetComponent<Gun>().knockBack = mBaseKnock + gameManager.GetComponent<gameManager>().knockBackII;
                    sniper.GetComponent<Gun>().knockBack = sBaseKnock + gameManager.GetComponent<gameManager>().knockBackII;

                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= knockBackIII)
                {
                    gameManager.GetComponent<gameManager>().knockUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= knockBackIII;
                    revolver.GetComponent<Gun>().knockBack = rBaseKnock + gameManager.GetComponent<gameManager>().knockBackIII;
                    shotgun.GetComponent<Gun>().knockBack = sGBaseKnock + gameManager.GetComponent<gameManager>().knockBackIII;
                    machineGun.GetComponent<Gun>().knockBack = mBaseKnock + gameManager.GetComponent<gameManager>().knockBackIII;
                    sniper.GetComponent<Gun>().knockBack = sBaseKnock + gameManager.GetComponent<gameManager>().knockBackIII;

                }
                break;
        }
    }

    public void speedButton()
    {
        switch (gameManager.GetComponent<gameManager>().speedUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= speedI)
                {
                    gameManager.GetComponent<gameManager>().speedUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= speedI;
                    revolver.GetComponent<Gun>().bulletForce = rBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedI;
                    shotgun.GetComponent<Gun>().bulletForce = sGBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedI;
                    machineGun.GetComponent<Gun>().bulletForce = mBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedI;
                    sniper.GetComponent<Gun>().bulletForce = sBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= speedII)
                {
                    gameManager.GetComponent<gameManager>().speedUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= speedII;
                    revolver.GetComponent<Gun>().bulletForce = rBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedII;
                    shotgun.GetComponent<Gun>().bulletForce = sGBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedII;
                    machineGun.GetComponent<Gun>().bulletForce = mBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedII;
                    sniper.GetComponent<Gun>().bulletForce = sBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= speedIII)
                {
                    gameManager.GetComponent<gameManager>().speedUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= speedIII;
                    revolver.GetComponent<Gun>().bulletForce = rBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedIII;
                    shotgun.GetComponent<Gun>().bulletForce = sGBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedIII;
                    machineGun.GetComponent<Gun>().bulletForce = mBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedIII;
                    sniper.GetComponent<Gun>().bulletForce = sBaseSpeed * gameManager.GetComponent<gameManager>().bulletSpeedIII;
                }
                break;
        }
    }

    public void bulletButton()
    {
        switch (gameManager.GetComponent<gameManager>().projectileUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= bulletI)
                {
                    gameManager.GetComponent<gameManager>().projectileUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= bulletI;
                    bulletDamageCal();
                    revolver.GetComponent<Gun>().projectiles = rBaseBullet + 1;
                    shotgun.GetComponent<Gun>().projectiles = sGBaseBullet+ 1;
                    machineGun.GetComponent<Gun>().projectiles = mBaseBullet + 1;
                    sniper.GetComponent<Gun>().projectiles = sBaseBullet + 1;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= bulletII)
                {
                    gameManager.GetComponent<gameManager>().projectileUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= bulletII;
                    bulletDamageCal();
                    revolver.GetComponent<Gun>().projectiles = rBaseBullet + 2;
                    shotgun.GetComponent<Gun>().projectiles = sGBaseBullet + 2;
                    machineGun.GetComponent<Gun>().projectiles = mBaseBullet + 2;
                    sniper.GetComponent<Gun>().projectiles = sBaseBullet + 2;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= bulletIII)
                {
                    gameManager.GetComponent<gameManager>().projectileUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= bulletIII;
                    bulletDamageCal();
                    revolver.GetComponent<Gun>().projectiles = rBaseBullet + 3;
                    shotgun.GetComponent<Gun>().projectiles = sGBaseBullet + 3;
                    machineGun.GetComponent<Gun>().projectiles = mBaseBullet + 3;
                    sniper.GetComponent<Gun>().projectiles = sBaseBullet + 3;
                }
                break;
        }
    }

    public void pierceButton()
    {
        switch (gameManager.GetComponent<gameManager>().pierceUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= pierceI)
                {
                    gameManager.GetComponent<gameManager>().pierceUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= pierceI;
                    revolver.GetComponent<Gun>().piecre = rBasePierce + gameManager.GetComponent<gameManager>().pierceI;
                    shotgun.GetComponent<Gun>().piecre = sGBasePierce + gameManager.GetComponent<gameManager>().pierceI;
                    machineGun.GetComponent<Gun>().piecre = mBasePierce + gameManager.GetComponent<gameManager>().pierceI;
                    sniper.GetComponent<Gun>().piecre = sBasePierce + gameManager.GetComponent<gameManager>().pierceI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= pierceII)
                {
                    gameManager.GetComponent<gameManager>().pierceUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= pierceII;
                    revolver.GetComponent<Gun>().piecre = rBasePierce + gameManager.GetComponent<gameManager>().pierceII;
                    shotgun.GetComponent<Gun>().piecre = sGBasePierce + gameManager.GetComponent<gameManager>().pierceII;
                    machineGun.GetComponent<Gun>().piecre = mBasePierce + gameManager.GetComponent<gameManager>().pierceII;
                    sniper.GetComponent<Gun>().piecre = sBasePierce + gameManager.GetComponent<gameManager>().pierceII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= pierceIII)
                {
                    gameManager.GetComponent<gameManager>().pierceUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= pierceIII;
                    revolver.GetComponent<Gun>().piecre = rBasePierce + gameManager.GetComponent<gameManager>().pierceIII;
                    shotgun.GetComponent<Gun>().piecre = sGBasePierce + gameManager.GetComponent<gameManager>().pierceIII;
                    machineGun.GetComponent<Gun>().piecre = mBasePierce + gameManager.GetComponent<gameManager>().pierceIII;
                    sniper.GetComponent<Gun>().piecre = sBasePierce + gameManager.GetComponent<gameManager>().pierceIII;
                }
                break;
        }
    }

    public void sizeButton()
    {
        switch (gameManager.GetComponent<gameManager>().sizeUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= sizeI)
                {
                    gameManager.GetComponent<gameManager>().sizeUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= sizeI;
                    revolver.GetComponent<Gun>().bulletSize = rBaseSize * gameManager.GetComponent<gameManager>().sizeI;
                    shotgun.GetComponent<Gun>().bulletSize = sGBaseSize * gameManager.GetComponent<gameManager>().sizeI;
                    machineGun.GetComponent<Gun>().bulletSize = mBaseSize * gameManager.GetComponent<gameManager>().sizeI;
                    sniper.GetComponent<Gun>().bulletSize = sBaseSize * gameManager.GetComponent<gameManager>().sizeI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= sizeII)
                {
                    gameManager.GetComponent<gameManager>().sizeUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= sizeII;
                    revolver.GetComponent<Gun>().bulletSize = rBaseSize * gameManager.GetComponent<gameManager>().sizeII;
                    shotgun.GetComponent<Gun>().bulletSize = sGBaseSize * gameManager.GetComponent<gameManager>().sizeII;
                    machineGun.GetComponent<Gun>().bulletSize = mBaseSize * gameManager.GetComponent<gameManager>().sizeII;
                    sniper.GetComponent<Gun>().bulletSize = sBaseSize * gameManager.GetComponent<gameManager>().sizeII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= sizeIII)
                {
                    gameManager.GetComponent<gameManager>().sizeUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= sizeIII;
                    revolver.GetComponent<Gun>().bulletSize = rBaseSize * gameManager.GetComponent<gameManager>().sizeIII;
                    shotgun.GetComponent<Gun>().bulletSize = sGBaseSize * gameManager.GetComponent<gameManager>().sizeIII;
                    machineGun.GetComponent<Gun>().bulletSize = mBaseSize * gameManager.GetComponent<gameManager>().sizeIII;
                    sniper.GetComponent<Gun>().bulletSize = sBaseSize * gameManager.GetComponent<gameManager>().sizeIII;
                }
                break;
        }
    }

    void bulletDamageCal()
    {
        switch (gameManager.GetComponent<gameManager>().damageUp)
        {
            case 0:
                break;
            case 1:
                revolver.GetComponent<Gun>().damage = Mathf.CeilToInt(rBaseDmg * gameManager.GetComponent<gameManager>().damageI);
                shotgun.GetComponent<Gun>().damage = Mathf.CeilToInt(sGBaseDmg * gameManager.GetComponent<gameManager>().damageI);
                machineGun.GetComponent<Gun>().damage = Mathf.CeilToInt(mBaseDmg * gameManager.GetComponent<gameManager>().damageI);
                sniper.GetComponent<Gun>().damage = Mathf.CeilToInt(sBaseDmg * gameManager.GetComponent<gameManager>().damageI);
                break;
            case 2:
                revolver.GetComponent<Gun>().damage = Mathf.CeilToInt(rBaseDmg * gameManager.GetComponent<gameManager>().damageII);
                shotgun.GetComponent<Gun>().damage = Mathf.CeilToInt(sGBaseDmg * gameManager.GetComponent<gameManager>().damageII);
                machineGun.GetComponent<Gun>().damage = Mathf.CeilToInt(mBaseDmg * gameManager.GetComponent<gameManager>().damageII);
                sniper.GetComponent<Gun>().damage = Mathf.CeilToInt(sBaseDmg * gameManager.GetComponent<gameManager>().damageII);
                break;
            case 3:
                revolver.GetComponent<Gun>().damage = Mathf.CeilToInt(rBaseDmg * gameManager.GetComponent<gameManager>().damageIII);
                shotgun.GetComponent<Gun>().damage = Mathf.CeilToInt(sGBaseDmg * gameManager.GetComponent<gameManager>().damageIII);
                machineGun.GetComponent<Gun>().damage = Mathf.CeilToInt(mBaseDmg * gameManager.GetComponent<gameManager>().damageIII);
                sniper.GetComponent<Gun>().damage = Mathf.CeilToInt(sBaseDmg * gameManager.GetComponent<gameManager>().damageIII);
                break;
        }
        switch (gameManager.GetComponent<gameManager>().projectileUp)
        {
            case 0:
                    
                break;
            case 1:
                revolver.GetComponent<Gun>().damage = Mathf.FloorToInt(revolver.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletI);
                shotgun.GetComponent<Gun>().damage = Mathf.FloorToInt(shotgun.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletI);
                machineGun.GetComponent<Gun>().damage = Mathf.FloorToInt(machineGun.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletI);
                sniper.GetComponent<Gun>().damage = Mathf.FloorToInt(sniper.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletI);
                break;
            case 2:
                revolver.GetComponent<Gun>().damage = Mathf.FloorToInt(revolver.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletII);
                shotgun.GetComponent<Gun>().damage = Mathf.FloorToInt(shotgun.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletII);
                machineGun.GetComponent<Gun>().damage = Mathf.FloorToInt(machineGun.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletII);
                sniper.GetComponent<Gun>().damage = Mathf.FloorToInt(sniper.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletII);
                break;
            case 3:
                revolver.GetComponent<Gun>().damage = Mathf.FloorToInt(revolver.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletIII);
                shotgun.GetComponent<Gun>().damage = Mathf.FloorToInt(shotgun.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletIII);
                machineGun.GetComponent<Gun>().damage = Mathf.FloorToInt(machineGun.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletIII);
                sniper.GetComponent<Gun>().damage = Mathf.FloorToInt(sniper.GetComponent<Gun>().damage * gameManager.GetComponent<gameManager>().bulletIII);
                break;
        }

    }
}*/
