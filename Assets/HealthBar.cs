using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class HealthBar : MonoBehaviour
{
    //max health
    [SerializeField] Slider healthBar;
    [SerializeField] Image healthBarFill;
    [SerializeField] TMP_Text healthText;
    [SerializeField] Gradient healthGradient;
    Color newHealthbarColor;
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] float speed;
    //current health
    //update health method

    private void Start()
    {
        UpdateCurrentHealth(currentHealth);
    }
    public void UpdateCurrentHealth(float newCurrentHealth)
    {
        if (newCurrentHealth <= maxHealth)
        {
            // healthBar.value = currentHealth / maxHealth;
            // healthBar.value = ;
            StartCoroutine(SmoothHealthUpdate(newCurrentHealth));
        }
        else
        {
            Debug.Log("invalid health input");
        }
    }

    public void UpdateHealthGradient()
    {
        // healthBarFill.color = healthGradient.Evaluate(currentHealth / maxHealth);
    }

    public IEnumerator SmoothHealthUpdate(float newCurrentHealth)
    {
        float previusHealth = currentHealth;
        Color currentGradientColor = healthBarFill.color;
        newHealthbarColor = healthGradient.Evaluate(currentHealth / maxHealth);
        float elapsed = 0f;

        while (elapsed < 1)
        {
            elapsed += Time.deltaTime * 5;

            currentHealth = Mathf.Lerp(previusHealth, newCurrentHealth, elapsed);
            healthBar.value = currentHealth / maxHealth;

            healthBarFill.color = Color.Lerp(currentGradientColor, newHealthbarColor, elapsed);

            healthText.text = $"{Mathf.RoundToInt(currentHealth)}/{Mathf.RoundToInt(maxHealth)}";


            yield return null;
        }

        currentHealth = newCurrentHealth;
        healthBar.value = currentHealth / maxHealth;
        healthBarFill.color = newHealthbarColor;
        healthText.text = $"{Mathf.RoundToInt(currentHealth)}/{Mathf.RoundToInt(maxHealth)}";
    }
}
