using System;
using System.Collections.Generic;
using System.IO;
using CitizenFX.Core;
using CitizenFX.Core.Native;



public class WeaponPickup
{

    // WEAPON HASHES: https://www.vespura.com/fivem/weapons/
    // MODEL HASHES: https://gtahash.ru/?c=Weapon%20models&page=3
    
    private string name;
    private UInt32 hash;
    private int id;
    private Vector3 position;
    private int ammo;
    private int blip;
    private Prop pickup; // the physical item

    public WeaponPickup(string name, int id, float x, float y, float z, UInt32 hash, int ammo, int blip)
    {
        this.name = name;
        this.id = id;
        this.position.X = x;
        this.position.Y = y;
        this.position.Z = z;
        this.hash = hash;
        this.ammo = ammo;
        this.blip = blip;
    }


    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public Vector3 Position { get => position; set => position = value; }
    public UInt32 Hash { get => hash; set => hash = value; }
    public int Ammo { get => ammo; set => ammo = value; }
    public int Blip { get => blip; set => blip = value; }
    public Prop Pickup { get => pickup; set => pickup = value; }

}