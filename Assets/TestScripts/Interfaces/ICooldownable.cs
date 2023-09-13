public interface ICooldownable
{
    float cooldownTimer { get; set; }

    bool CooldownDone(bool setTimer, float cooldownTime);
}