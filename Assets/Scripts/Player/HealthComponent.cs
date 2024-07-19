using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : ParentComponent
{
    [SerializeField] HealthBar healthBar = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;
    
    [SerializeField] int health = 0;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int damage = 5;

    [SerializeField] bool isInvincible = false;
    [SerializeField] float invincibilityFlashDelay = .2f;
    [SerializeField] float invincibilityDelay = 2;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) AddHealth(-damage);
    }

    public void AddHealth(int _value)
    {
        if (!isInvincible)
        {
            health += _value;
            health = health < 0 ? 0 : health;
            healthBar.SetHealth(health);

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(InvincibilityDelay());
        }
    }

    IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    IEnumerator InvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityDelay);
        isInvincible = false;
    }
}
