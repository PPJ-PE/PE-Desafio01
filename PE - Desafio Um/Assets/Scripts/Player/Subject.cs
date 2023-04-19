using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    // a collection of all the observers of this subject
    private List<IDamageObserver> _damageObservers = new List<IDamageObserver>();
    private List<IDeathObserver> _deathObservers = new List<IDeathObserver>();


    // Add the observer to the subject's collection
    public void AddDamageObserver(IDamageObserver observer)
    {
        _damageObservers.Add(observer);
    }

    // Remove the observer to the subject's collection

    public void RemoveDamageObserver(IDamageObserver observer)
    {
        _damageObservers.Remove(observer);
    }

    public void AddDeathObserver(IDeathObserver observer)
    {
        _deathObservers.Add(observer);
    }

    // Remove the observer to the subject's collection

    public void RemoveDeathObserver(IDeathObserver observer)
    {
        _deathObservers.Remove(observer);
    }

    // Notify each observer that an event has occurred
    protected void NotifyDamage(float damageToNotify)
    {
        _damageObservers.ForEach((_observer) =>
        {
            _observer.OnNotify(damageToNotify);
        });
    }

    protected void NotifyDeath()
    {
        _deathObservers.ForEach((_observer) =>
        {
            _observer.OnNotifyDeath();
        });
    }
}
