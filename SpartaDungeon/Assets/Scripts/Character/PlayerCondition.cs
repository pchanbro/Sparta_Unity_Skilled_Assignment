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

    private void Start()
    {
        CharacterManager.Instance.Player.useItem += ChangeConditionByItem;
    }

    void Update()
    {
        TakeDamage(uiCondition.health.passiveValue * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        uiCondition.health.Subtract(damage);
    }

    void ChangeConditionByItem()
    {
        Debug.Log("실행했냐1");
        if (CharacterManager.Instance.Player.itemData.Type == ItemType.Consumable)
        {
            foreach (ItemDataConsumable itemDataConsumable in CharacterManager.Instance.Player.itemData.consumables)
            {
                if (itemDataConsumable.type == ConsumableType.Health)
                {
                    uiCondition.health.Add(itemDataConsumable.value);
                }
            }
        }
    }


}
