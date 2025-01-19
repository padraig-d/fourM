using System;
using System.Collections.Generic;
using System.IO;
using CitizenFX.Core;


public class WeaponPickup
{
    private string name;
    private int id;
    private float x;
    private float y;
    private float z;
    private UInt32 hash;
    private int ammo;
    private int blip;
    private int pickup; // the physical item

    public WeaponPickup(string name, int id, float x, float y, float z, UInt32 hash, int ammo, int blip)
    {
        this.name = name;
        this.id = id;
        this.x = x;
        this.y = y;
        this.z = z;
        this.hash = hash;
        this.ammo = ammo;
        this.blip = blip;
    }


    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }
    public float Z { get => z; set => z = value; }
    public UInt32 Hash { get => hash; set => hash = value; }
    public int Ammo { get => ammo; set => ammo = value; }
    public int Blip { get => blip; set => blip = value; }
    public int Pickup { get => pickup; set => pickup = value; }

}