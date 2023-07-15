using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthDisplay : MonoBehaviour
{
    private TMP_Text _textDisplay;

    private void Start()
    {
        _textDisplay = GetComponent<TMP_Text>();

        PlayerHealth.damaged += UpdateHealth;
        PlayerHealth.healed += UpdateHealth;
    }

    public void UpdateHealth(int health)
    {
        if (health <= 0)
        {
            _textDisplay.text = "Played Dead";
        }
        else
        {
            _textDisplay.text = "Health: " + health + "/100";
        }
    }
}
