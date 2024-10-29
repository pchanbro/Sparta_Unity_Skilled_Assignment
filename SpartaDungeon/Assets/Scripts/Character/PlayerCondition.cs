using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
}


public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UICondition uiCondition;

    public void TakeDamage(float damage)
    {
        uiCondition.health.Subtract(damage);
    }

     void Update()
    {
        TakeDamage(uiCondition.health.passiveValue  * Time.deltaTime);
    }
}
