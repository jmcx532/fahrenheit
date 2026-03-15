// SPDX-License-Identifier: MIT

namespace Fahrenheit.FFX;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TkWindow {
    public  uint   __0x00;
    public  uint   __0x04;
    public  delegate* unmanaged[Cdecl]<TkWindow*, void> fn_init;
    public  delegate* unmanaged[Cdecl]<TkWindow*, void> fn_state;
    public  delegate* unmanaged[Cdecl]<TkWindow*, void> fn_render;
    public  delegate* unmanaged[Cdecl]<TkWindow*, bool> fn_destroy_condition;
    public  delegate* unmanaged[Cdecl]<TkWindow*, void> fn_destructor;
    public  void*  fn_0x1C;
    private uint   __0x20_pad;
    private uint   __0x24_pad;
    public  uint   current_state;
    public  short  __0x2C;
    private ushort __0x2E_pad;
    public  short  num_items;
    public  short  visible_item_offset;
    public  short  scroll_offset;
    public  byte   menu_group;
    public  byte   __0x37;
    public  short  __0x38;
    public  short  max_visible_items;
    private ushort __0x3C_pad;
    public  byte   render_priority;
    public  byte   state_priority;
    public  bool   is_active;
    public  bool   should_destroy;
    public  byte   __0x42;
    public  byte   __0x43;
    public  byte   __0x44;
    public  sbyte  exit_value;
    public  short  scroll_delta;
    public  short  selected_index;
    private ushort __0x4A_pad;
    private uint   __0x4C_pad;
    private uint   __0x50_pad;
    private uint   __0x54_pad;
    public  InlineArray16<uint> data; // menu-specific
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TkMenu {
    public delegate* unmanaged[Cdecl]<TkMenu*, int, void> fn_ctrl;
    public delegate* unmanaged[Cdecl]<TkMenu*,      void> fn_draw;
    public delegate* unmanaged[Cdecl]<TkMenu*, int, void> fn_init;
    public nint fn_0x0C;
    public nint fn_sleep;
    public delegate* unmanaged[Cdecl]<TkMenu*, void> fn_deactivate;
    public byte __0x18;
    public byte __0x19;
    public byte __0x1A;
    public byte __0x1B;
    public int  state;
}

public static class TkMenuId {
    public const int TK_MENU_MAIN          = 0x1;
    public const int TK_MENU_ABILITY       = 0x2;
    public const int TK_MENU_ITEM          = 0x3;
    public const int TK_MENU_EQUIP         = 0x4;
    public const int TK_MENU_STATUS        = 0x6;
    public const int TK_MENU_SUMMON        = 0x7;
    public const int TK_MENU_KAIZOU        = 0x9;
    public const int TK_MENU_CONFIG        = 0xA;
    public const int TK_MENU_HELP          = 0xB;
    public const int TK_MENU_WSHOP         = 0xD;
    public const int TK_MENU_NAME          = 0xE;
    public const int TK_MENU_SAVE          = 0xF;
    public const int TK_MENU_LOAD          = 0x10;
    public const int TK_MENU_BTL_END       = 0x11;
    public const int TK_MENU_ABILITY_MAP_2 = 0x13;
    public const int TK_MENU_HDD           = 0x14;
    public const int TK_MENU_LIMIT         = 0x15;
    public const int TK_MENU_TUTO          = 0x16;
    public const int TK_MENU_WORLD_MAP     = 0x17;
}
