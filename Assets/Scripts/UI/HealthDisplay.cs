using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] PlayerStatus player;

    void Start()
    {
        player.OnPlayerHealthUpdated += UpdateHealthText;
    }

    void OnDestroy()
    {
        player.OnPlayerHealthUpdated -= UpdateHealthText;
    }

    void UpdateHealthText(int newHealth)
    {
        healthText.text = newHealth.ToString();
    }
}
