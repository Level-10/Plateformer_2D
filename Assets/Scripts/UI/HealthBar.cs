using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider = null;
    [SerializeField] Image fill = null;
    [SerializeField] Gradient gradient = null;

    void Awake()
    {
        slider = GetComponent<Slider>();
        //fill = GetComponent<Image>();
    }
    public void SetMaxHealth(int _maxHealth)
    {
        slider.maxValue = _maxHealth;
        slider.value = _maxHealth;
        // Set the value of gradient 1 = right
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int _health)
    {
        slider.value = _health;
        // Set the slider value between 0 and 1 (normalized)
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
