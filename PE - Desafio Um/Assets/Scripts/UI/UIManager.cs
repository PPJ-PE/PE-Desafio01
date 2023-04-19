using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IDamageObserver, IDeathObserver
{
    public PlayerHealth _playerHealth;
    public Slider healthSlider;
    public GameObject gameOverPanel;

    void Start()
    {
        healthSlider.value = healthSlider.maxValue;
        ObserveSubject();
    }
    public void OnNotify(float damage)
    {
        healthSlider.value -= damage;
    }

    void ObserveSubject()
    {
        _playerHealth.AddDamageObserver(this);
        _playerHealth.AddDeathObserver(this);
    }

    public void OnNotifyDeath()
    {
        healthSlider.value = 0f;
        gameOverPanel.SetActive(true);
    }
}
