using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public float SpeedMultiplier { get; private set; } = 1f;
    [field: SerializeField] public float ShotsColldownMultiplier { get; private set; } = 1f;
    [field: SerializeField] public float DamageMultiplier { get; private set; } = 1f;

    public void IncreaseSpeed(float speedMultiplier)
    {
        SpeedMultiplier *= speedMultiplier;
        Debug.Log($"Скорость увеличена на 10% и коэффициент составляет: {SpeedMultiplier}");
    }

    public void IncreaseShotsColldown(float shotsColldownMultiplier)
    {
        ShotsColldownMultiplier *= shotsColldownMultiplier;
        Debug.Log($"Перезарядк снижена на 10% и коэффициент составляет: {ShotsColldownMultiplier}");
    }

    public void IncreaseDamage(float damageMultiplier)
    {
        DamageMultiplier *= damageMultiplier;
        Debug.Log($"Урон увеличен на 10% и коэффициент составляет: {SpeedMultiplier}");
    }
}