using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Gun : MonoBehaviour, IReloadable, ICooldownable
{
    public bool reloading { get; set; }
    public int maxAmmo { get; set; }
    public int currentAmmo { get; set; }

    public float cooldownTimer { get; set; }

    [SerializeField]
    private Transform _bulletSpawnLocation;

    private void Start()
    {
        maxAmmo = 12;
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (currentAmmo > 0 && CooldownDone() && Input.GetKeyDown(KeyCode.Space))
        {
            currentAmmo--;

            GameObject newBullet = BulletPoolManager.Instance.GetItem();

            newBullet.transform.position = _bulletSpawnLocation.position;
            newBullet.transform.rotation = _bulletSpawnLocation.rotation;

            newBullet.SetActive(true);

            CooldownDone(true, 0.25f);
        }

        else if (currentAmmo <= 0 && !reloading)
            ReloadAmmo(3.5f);
    }

    public void ReloadAmmo(
        float reloadTime = 0)
    {
        reloading = true;

        Reloading(reloadTime);
    }

    private async Task Reloading(float reloadTime)
    {
        int reloadingTime = Mathf.RoundToInt(reloadTime * 1000);

        await Task.Delay(reloadingTime);

        currentAmmo = maxAmmo;

        reloading = false;
    }

    public bool CooldownDone(
        bool setTimer = false, 
        float cooldownTime = 0)
    {
        if (setTimer)
            cooldownTimer = cooldownTime;

        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        else
            return true;

        return false;
    }
}
