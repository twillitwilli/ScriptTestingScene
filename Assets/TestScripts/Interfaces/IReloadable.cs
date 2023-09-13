public interface IReloadable
{
    bool reloading { get; set; }
    int maxAmmo { get; set; }
    int currentAmmo { get; set; }

    void ReloadAmmo(float reloadTime);
}