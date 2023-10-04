using System;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public InvScr inventorySystem;
    public Transform firePoint; 
    public GameObject bulletPrefab;
    private PlayerMovement _playerMovement;
    private InventorySlot _ammoSlot;

    private void Start()
    {
        bulletPrefab.SetActive(false);
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (_playerMovement == null)
            throw new Exception("Game object does not have PlayerMovement component");
    }

    public void Shoot()
    {
        Debug.Log("shoot");
        
        if (_ammoSlot == null || !IsAmmo(_ammoSlot))
            _ammoSlot = FindAmmoSlot();
        
        if (_ammoSlot == null)
            return;
        
        _ammoSlot.Count--;
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().goingRight = _playerMovement.rightDirection;
        bullet.SetActive(true);
        Debug.Log("Пиф-паф! Осталось патронов: " + _ammoSlot.Count);
    }
    
    private static bool IsAmmo(in InventorySlot slot)
    {
        return slot.ItemName == "5.45x39";
    }

    [CanBeNull]
    private InventorySlot FindAmmoSlot()
    {
        return inventorySystem.inventory.FirstOrDefault(item => IsAmmo(item));
    }
}