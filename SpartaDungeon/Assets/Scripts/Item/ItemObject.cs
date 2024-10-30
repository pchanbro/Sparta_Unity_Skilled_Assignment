using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
    public void OnUse();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData itemData;

    public string GetInteractPrompt()
    {
        string str = $"{itemData.ItemName}\n{itemData.ItemDescription}";
        foreach(ItemDataConsumable itemDataConsumable in itemData.consumables)
        {
            str = $"{str}\n{itemDataConsumable.type} : {itemDataConsumable.value}";
        }
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = itemData;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }

    public void OnUse()
    {
        CharacterManager.Instance.Player.itemData = itemData;
        CharacterManager.Instance.Player.useItem?.Invoke();
        Destroy(gameObject);
    }
}
