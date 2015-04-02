using UnityEngine;
using System.Collections;

public enum EquipmentSlot : int
{
    Unequipable = -1,
    Head = 0,
    LeftArm = 1,
    RightArm = 2,
    BothArms = 3,
    Chest = 4,
    Feet = 5,
}

public enum Type
{
    Canteen,
    FishingPole,
    Axe,
    Dagger,
    CraftingMaterials,
    Pickaxe,
    MouthFilter,
    Shovel,
    WaterFilter,
}
