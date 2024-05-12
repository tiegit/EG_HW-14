using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image _scale;
    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth.OnHealthChenge += SetScale;
    }

    private void SetScale(float currentHealth, float maxHealth)
    {
        _scale.fillAmount = currentHealth / maxHealth;
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthChenge -= SetScale;
    }
}