// SPDX-License-Identifier: LGPL-3.0-or-later
//
// This file is part of Fahrenheit, © 2023-2026 The Fahrenheit contributors.
// It is licensed to you under the GNU Lesser General Public License, version 3.0 or later. See COPYING, COPYING.LESSER.

namespace Fahrenheit.FFX2;

[StructLayout(LayoutKind.Explicit, Size = 0xE4)]
public struct Job {
    [FieldOffset(0x00)] public ushort            name_string_offset;
    // [FieldOffset(0x02)] public ushort         name_unk; 
    [FieldOffset(0x04)] public ushort            help_string_offset;
    // [FieldOffset(0x06)] public ushort         help_unk;
    [FieldOffset(0x08)] public byte              user;
    [FieldOffset(0x09)] public byte              data;
    [FieldOffset(0x0A)] public byte              seq;
    [FieldOffset(0x0B)] public byte              icon;
    [FieldOffset(0x0C)] public ushort            berserk_action;

    [FieldOffset(0xE)]  public StatGrowth3       hp_up;
    [FieldOffset(0x11)] public StatGrowth3       mp_up;

    [FieldOffset(0x14)] public StatGrowth5       str_up;
    [FieldOffset(0x19)] public StatGrowth5       def_up;
    [FieldOffset(0x1E)] public StatGrowth5       mag_up;
    [FieldOffset(0x23)] public StatGrowth5       mdef_up;
    [FieldOffset(0x28)] public StatGrowth5       agl_up;
    [FieldOffset(0x2D)] public StatGrowth5       eva_up;
    [FieldOffset(0x32)] public StatGrowth5       acc_up;
    [FieldOffset(0x37)] public StatGrowth5       luck_up;

    [FieldOffset(0x3c)] public InlineArray16<JobAbility>      dressphere_abilities;

    [FieldOffset(0x7c)] public JobWeapon         yuna_weapons;
    [FieldOffset(0x8c)] public JobWeapon         rikku_weapons;
    [FieldOffset(0x9c)] public JobWeapon         paine_weapons;

    [FieldOffset(0xAC)] public JobCreatureData   creature_data;

}

// stat growth
[InlineArray(3)]
public struct StatGrowth3 {
    public byte e0;

    public void set(byte a, byte b, byte c) {
        this[0] = a;
        this[1] = b;
        this[2] = c;

    }

}

[InlineArray(5)]
public struct StatGrowth5 {
    public byte e0;

    public void set(byte a, byte b, byte c, byte d, byte e) {
        this[0] = a;
        this[1] = b;
        this[2] = c;
        this[3] = d;
        this[4] = e;

    }

}

//dressphere abilities
[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public struct JobAbility{
    [FieldOffset(0x00)] public ushort requirement;
    [FieldOffset(0x02)] public ushort ability;
}

// weapons
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct JobWeapon {
    [FieldOffset(0x00)] public JobWeaponData weapon_1;
    [FieldOffset(0x04)] public JobWeaponData weapon_2;
    [FieldOffset(0x08)] public JobWeaponData weapon_3;
    [FieldOffset(0x0C)] public JobWeaponData weapon_4;
}

[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public struct JobWeaponData {
    [FieldOffset(0x00)] public  ushort weapon_model;
    [FieldOffset(0x02)] public  ushort weapon_position;
}

// creature data - Int/Remaster
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public struct JobCreatureData{
    [FieldOffset(0x00)] public  ushort          cre_help_string_offset;
    //[FieldOffset(0x02)] public  ushort          cre_help_unknown;

    [FieldOffset(0x04)] public  ushort          ability_prerequisite;
    [FieldOffset(0x06)] public  ushort          ability;
    [FieldOffset(0x08)] public  ushort          auto_ability_prerequisite;
    [FieldOffset(0x0A)] public  ushort          auto_ability;
    //[FieldOffset(0x0C)] public  byte[16]        unk_bytes;
    [FieldOffset(0x1C)] public StatChanges        stat_changes; // buffs/debuffs creature stats
    //[FieldOffset(0x26)] public  byte[18]        unk_bytes2;
}

// generic struct, also used in a_ability for example
[StructLayout(LayoutKind.Explicit, Size = 0xA)]
public struct StatChanges {
    [FieldOffset(0x00)] public  sbyte hp;
    [FieldOffset(0x01)] public  sbyte mp;
    [FieldOffset(0x02)] public  sbyte str;
    [FieldOffset(0x03)] public  sbyte def;
    [FieldOffset(0x04)] public  sbyte mag;
    [FieldOffset(0x05)] public  sbyte mdef;
    [FieldOffset(0x06)] public  sbyte agility;
    [FieldOffset(0x07)] public  sbyte accuracy;
    [FieldOffset(0x08)] public  sbyte evasion;
    [FieldOffset(0x09)] public  sbyte luck;
}


