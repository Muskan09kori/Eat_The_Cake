using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;

    [Header("Health Bar UI")]
    public Image frontHealthBar;
    public Image backHealthBar;

    [Header("Collision Tags")]
    public string damageTag = "Wall";
    public string healTag = "HealthPickup";

    [Header("Death Settings")]
    public float restartDelay = 2f;
    public StartMenu startMenu;   // drag StartMenu object in Inspector

    private float health;
    private float lerpTimer;
    private bool isDead = false;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (health <= 0 && !isDead)
        {
            isDead = true;
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(restartDelay);
        startMenu.RestartGame();   // calls StartMenu to handle restart
    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;

        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(damageTag))
        {
            TakeDamage(Random.Range(5, 10));
        }

        if (other.CompareTag(healTag))
        {
            RestoreHealth(Random.Range(5, 10));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(damageTag))
        {
            TakeDamage(Random.Range(5, 10));
        }

        if (collision.gameObject.CompareTag(healTag))
        {
            RestoreHealth(Random.Range(5, 10));
        }
    }
}