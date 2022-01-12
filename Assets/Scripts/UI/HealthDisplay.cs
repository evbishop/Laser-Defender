using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    PlayerStatus player;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerStatus>();
    }

    void Update()
    {
        healthText.text = player.Health.ToString();
    }
}
