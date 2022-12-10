using System;
using UnityEngine;

[RequireComponent(typeof(MobMovement))]
public class Mob : MonoBehaviour
{
    private float _money;
    private float _health;

    private MobMovement _mobMovement;

    public event Action<Mob> Died;

    private void Awake()
    {
        _mobMovement = GetComponent<MobMovement>();
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {  
            _mobMovement.Stop();
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke(this);
    }

    public void StartMovement()
    {
        _mobMovement.Restart();
    }
}
