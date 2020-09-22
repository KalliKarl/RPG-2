using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Equipment" , menuName ="Inventory/Equipment")]
public class Equipment : Item{

    public EquipmentSlot equipSlot;

    public int armorModifier, damageModifier, level,degree,critical,durability,block,range;

    public override void Use() {
        base.Use();

        EquipmentManager.instance.Equip(this);

        removeFromInventory();
        //Equip the item
        //Remove item from inventory
    }




}

public enum EquipmentSlot { Weapon, Shield, Head, Chest , Shoulder, Hand, Legs, Feet}
