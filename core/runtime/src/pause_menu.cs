//TODO: Implement adding new menu options
//TODO: Implement support for additional characters
//TODO: Reimplement whatever it takes

using Fahrenheit.FFX;

namespace Fahrenheit.Runtime;

[FhLoad(FhGameId.FFX)]
public unsafe class FhPauseMenuModule : FhModule {
    // Delegates for method handles
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuCtrl(TkMenu* menu);
    public const nint __addr_TkMenuCtrlMain = 0x4e0340;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuMainActiveMenu(int menu_id, int arg);
    public const nint __addr_TkMenuMainActiveMenu = 0x4aa0b0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuMainSleepMenu(int menu_id);
    public const nint __addr_TkMenuMainSleepMenu = 0x4aad20;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuMainRemoveMenu(int menu_id);
    public const nint __addr_TkMenuMainRemoveMenu = 0x4aaad0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUN_008e2270(int option_idx);
    public const nint __addr_FUN_008e2270 = 0x4e2270;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUN_008e2280();
    public const nint __addr_FUN_008e2280 = 0x4e2280;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUN_008e24c0(int option_idx);
    public const nint __addr_FUN_008e24c0 = 0x4e24c0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte* TkMenuMainHelp(int menu_id);
    public const nint __addr_TkMenuMainHelp = 0x4ddf40;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuSetHelpMessage(byte* help_msg);
    public const nint __addr_TkMenuSetHelpMessage = 0x4aae60;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuMainSetIgnoreJoinFlag(int value);
    public const nint __addr_TkMenuMainSetIgnoreJoinFlag = 0x4aad10;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TkMenuGetCurrentPlayerPos();
    public const nint __addr_TkMenuGetCurrentPlayerPos = 0x4a9820;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuSetCurrentPlayerPos(int value);
    public const nint __addr_TkMenuSetCurrentPlayerPos = 0x4aae30;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TkMenuGetCurrentPlayer();
    public const nint __addr_TkMenuGetCurrentPlayer = 0x4a9810;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuSetPrevPlayer2();
    public const nint __addr_TkMenuSetPrevPlayer2 = 0x4aaf70;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuSetNextPlayer2();
    public const nint __addr_TkMenuSetNextPlayer2 = 0x4aaef0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TkMenuGetPlayerListMax();
    public const nint __addr_TkMenuGetPlayerListMax = 0x4a9ae0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TkMenuGetPlayerListMax2();
    public const nint __addr_TkMenuGetPlayerListMax2 = 0x4a9b00;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SndSepPlaySimple(uint sound_id);
    public const nint __addr_SndSepPlaySimple = 0x486de0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte TkMenuGetPlayerFromIndex2(int ply_idx);
    public const nint __addr_TkMenuGetPlayerFromIndex2 = 0x4a9ab0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MsGetSavePlyJoin(byte ply_id);
    public const nint __addr_MsGetSavePlyJoin = 0x385440;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MsSetSaveParamAll();
    public const nint __addr_MsSetSaveParamAll = 0x3869c0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuExchangePlayerPos(int ply1_id, int ply2_id);
    public const nint __addr_TkMenuExchangePlayerPos = 0x4a96d0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuMainFreeWindowGroup(int group);
    public const nint __addr_TkMenuMainFreeWindowGroup = 0x4aa3c0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuDrawShadeRatioDiff(int value);
    public const nint __addr_TkMenuDrawShadeRatioDiff = 0x4a9630;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TkMenuGetDrawShadeRatio();
    public const nint __addr_TkMenuGetDrawShadeRatio = 0x4a9850;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TOMenuGetFirstReadEndFlag();
    public const nint __addr_TOMenuGetFirstReadEndFlag = 0x4a8e00;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMn2SetMainFrameRatioDiff(int value);
    public const nint __addr_TkMn2SetMainFrameRatioDiff = 0x4ab210;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TkMn2GetMainFrameRatio();
    public const nint __addr_TkMn2GetMainFrameRatio = 0x4ab1e0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ushort TOMenuGetControlPad();
    public const nint __addr_TOMenuGetControlPad = 0x4be3e0;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ushort TOMenuGetControlPadRep();
    public const nint __addr_TOMenuGetControlPadRep = 0x4be440;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ushort TOMenuGetControlPadTrg();
    public const nint __addr_TOMenuGetControlPadTrg = 0x4be480;

    // Method handles
    private readonly FhMethodHandle<TkMenuCtrl> _h_TkMenuCtrlMain;
    private readonly FhMethodHandle<FUN_008e2270> _h_FUN_008e2270;

    // Function pointers
    private readonly SndSepPlaySimple _SndSepPlaySimple = FhUtil.get_fptr<SndSepPlaySimple>(__addr_SndSepPlaySimple);
    private readonly TkMenuMainActiveMenu _TkMenuMainActiveMenu = FhUtil.get_fptr<TkMenuMainActiveMenu>(__addr_TkMenuMainActiveMenu);
    private readonly TkMenuMainSleepMenu _TkMenuMainSleepMenu = FhUtil.get_fptr<TkMenuMainSleepMenu>(__addr_TkMenuMainSleepMenu);
    private readonly TkMenuMainRemoveMenu _TkMenuMainRemoveMenu = FhUtil.get_fptr<TkMenuMainRemoveMenu>(__addr_TkMenuMainRemoveMenu);
    private readonly TkMenuMainHelp _TkMenuMainHelp = FhUtil.get_fptr<TkMenuMainHelp>(__addr_TkMenuMainHelp);
    private readonly TkMenuSetHelpMessage _TkMenuSetHelpMessage = FhUtil.get_fptr<TkMenuSetHelpMessage>(__addr_TkMenuSetHelpMessage);
    private readonly FUN_008e2280 _TkMenuMainGetMaxOptions = FhUtil.get_fptr<FUN_008e2280>(__addr_FUN_008e2280);
    private readonly FUN_008e24c0 _TkMenuMainOpenMenu = FhUtil.get_fptr<FUN_008e24c0>(__addr_FUN_008e24c0);
    private readonly TkMenuMainSetIgnoreJoinFlag _TkMenuMainSetIgnoreJoinFlag = FhUtil.get_fptr<TkMenuMainSetIgnoreJoinFlag>(__addr_TkMenuMainSetIgnoreJoinFlag);
    private readonly TkMenuGetCurrentPlayerPos _TkMenuGetCurrentPlayerPos = FhUtil.get_fptr<TkMenuGetCurrentPlayerPos>(__addr_TkMenuGetCurrentPlayerPos);
    private readonly TkMenuSetCurrentPlayerPos _TkMenuSetCurrentPlayerPos = FhUtil.get_fptr<TkMenuSetCurrentPlayerPos>(__addr_TkMenuSetCurrentPlayerPos);
    private readonly TkMenuGetCurrentPlayer _TkMenuGetCurrentPlayer = FhUtil.get_fptr<TkMenuGetCurrentPlayer>(__addr_TkMenuGetCurrentPlayer);
    private readonly TkMenuSetPrevPlayer2 _TkMenuSetPrevPlayer2 = FhUtil.get_fptr<TkMenuSetPrevPlayer2>(__addr_TkMenuSetPrevPlayer2);
    private readonly TkMenuSetNextPlayer2 _TkMenuSetNextPlayer2 = FhUtil.get_fptr<TkMenuSetNextPlayer2>(__addr_TkMenuSetNextPlayer2);
    private readonly TkMenuGetPlayerListMax _TkMenuGetPlayerListMax = FhUtil.get_fptr<TkMenuGetPlayerListMax>(__addr_TkMenuGetPlayerListMax);
    private readonly TkMenuGetPlayerListMax2 _TkMenuGetPlayerListMax2 = FhUtil.get_fptr<TkMenuGetPlayerListMax2>(__addr_TkMenuGetPlayerListMax2);
    private readonly TkMenuGetPlayerFromIndex2 _TkMenuGetPlayerFromIndex2 = FhUtil.get_fptr<TkMenuGetPlayerFromIndex2>(__addr_TkMenuGetPlayerFromIndex2);
    private readonly MsGetSavePlyJoin _MsGetSavePlyJoin = FhUtil.get_fptr<MsGetSavePlyJoin>(__addr_MsGetSavePlyJoin);
    private readonly MsSetSaveParamAll _MsSetSaveParamAll = FhUtil.get_fptr<MsSetSaveParamAll>(__addr_MsSetSaveParamAll);
    private readonly TkMenuExchangePlayerPos _TkMenuExchangePlayerPos = FhUtil.get_fptr<TkMenuExchangePlayerPos>(__addr_TkMenuExchangePlayerPos);
    private readonly TkMenuMainFreeWindowGroup _TkMenuMainFreeWindowGroup = FhUtil.get_fptr<TkMenuMainFreeWindowGroup>(__addr_TkMenuMainFreeWindowGroup);
    private readonly TkMenuDrawShadeRatioDiff _TkMenuDrawShadeRatioDiff = FhUtil.get_fptr<TkMenuDrawShadeRatioDiff>(__addr_TkMenuDrawShadeRatioDiff);
    private readonly TkMenuGetDrawShadeRatio _TkMenuGetDrawShadeRatio = FhUtil.get_fptr<TkMenuGetDrawShadeRatio>(__addr_TkMenuGetDrawShadeRatio);
    private readonly TOMenuGetFirstReadEndFlag _TOMenuGetFirstReadEndFlag = FhUtil.get_fptr<TOMenuGetFirstReadEndFlag>(__addr_TOMenuGetFirstReadEndFlag);
    private readonly TkMn2SetMainFrameRatioDiff _TkMn2SetMainFrameRatioDiff = FhUtil.get_fptr<TkMn2SetMainFrameRatioDiff>(__addr_TkMn2SetMainFrameRatioDiff);
    private readonly TkMn2GetMainFrameRatio _TkMn2GetMainFrameRatio = FhUtil.get_fptr<TkMn2GetMainFrameRatio>(__addr_TkMn2GetMainFrameRatio);
    private readonly TOMenuGetControlPad _TOMenuGetControlPad = FhUtil.get_fptr<TOMenuGetControlPad>(__addr_TOMenuGetControlPad);
    private readonly TOMenuGetControlPadRep _TOMenuGetControlPadRep = FhUtil.get_fptr<TOMenuGetControlPadRep>(__addr_TOMenuGetControlPadRep);
    private readonly TOMenuGetControlPadTrg _TOMenuGetControlPadTrg = FhUtil.get_fptr<TOMenuGetControlPadTrg>(__addr_TOMenuGetControlPadTrg);

    // Sound Ids
    private const uint SND_PREFIX = 0x80000000;

    private const uint SND_MENU_ACTION   = 0x1 | SND_PREFIX;
    private const uint SND_MENU_DISABLED = 0x3 | SND_PREFIX;
    private const uint SND_MENU_CANCEL   = 0x4 | SND_PREFIX;

    // Fahrenheit-related
    private FhModContext? _mod_context;
    private FileStream? _global_state;

    public FhPauseMenuModule() {
        const string GAME = "FFX.exe";

        _h_TkMenuCtrlMain = new(this, GAME, __addr_TkMenuCtrlMain, tk_ctrl_main);
        _h_FUN_008e2270 = new(this, GAME, __addr_FUN_008e2270, get_option_menu);
    }

    public override bool init(FhModContext mod_context, FileStream global_state_file) {
        _mod_context = mod_context;
        _global_state = global_state_file;

        byte[] help_buf = new byte[FhEncoding.compute_encode_buffer_size("{COLOR:B0}There is no escape...{COLOR:0A}"u8)];
        FhEncoding.encode("{COLOR:B0}There is no escape...{COLOR:0A}"u8, help_buf);

        _logger.Info("Decoded help message!");

        help_mes = (byte*)NativeMemory.AllocZeroed((nuint)(help_buf.Length + 1));

        _logger.Info("Allocated help message!");

        byte* ptr = help_mes;
        foreach (byte b in help_buf) {
            *ptr = b;
            ptr++;
        }

        _logger.Info("Set help message!");

        return _h_TkMenuCtrlMain.hook();
    }

    private static byte* help_mes;

    private enum TkMenuMainOptionPlySelect : short {
        NONE,
        ANY,
        ONLY_JOINED,
    }

    private struct TkMenuMain_Option {
        public int new_menu_id;
        private short _enabled;
        public TkMenuMainOptionPlySelect player_selection;

        public bool is_enabled => _enabled != 0;
    }

    private int get_option_menu(int option_idx) {
        return options[option_idx].new_menu_id;
    }

    private bool get_option_enabled(int option_idx) {
        return options[option_idx].is_enabled;
    }

    private void update_help_for_option() {
        byte* help = _TkMenuMainHelp(selected_option->new_menu_id);
        _TkMenuSetHelpMessage(help);
    }

    private void set_ignore_join_flag(bool value) {
        _TkMenuMainSetIgnoreJoinFlag(value ? 1 : 0);
    }

    private void open_menu_from_main(TkMenu* menu, int* state) {
        int new_menu = _TkMenuMainOpenMenu(*selected_option_idx);

        if (new_menu == TkMenuId.TK_MENU_ITEM) {
            menu->state = *state = 27;
        } else if (new_menu == TkMenuId.TK_MENU_KAIZOU) {
            menu->state = *state = 31;
        } else {
            menu->state = *state = 25;
        }
    }

    private readonly int* TkMenuMainOpenWaitTimer = FhUtil.ptr_at<int>(0x1471504);
    private readonly int* DAT_01871514 = FhUtil.ptr_at<int>(0x1471514);
    private readonly int* DAT_01871524 = FhUtil.ptr_at<int>(0x1471524);

    private readonly int* selected_option_idx = FhUtil.ptr_at<int>(0x1471508);
    private readonly int* selected_player_idx = FhUtil.ptr_at<int>(0x147150c);
    private readonly int* switch_player1_idx = FhUtil.ptr_at<int>(0x147151c);
    private readonly int* switch_player2_idx = FhUtil.ptr_at<int>(0x1471520);
    private readonly TkMenuMain_Option* options = FhUtil.ptr_at<TkMenuMain_Option>(0x1471528);
    private TkMenuMain_Option* selected_option => options + *selected_option_idx;

    private void tk_ctrl_main(TkMenu* menu) {

        // There is no escape
        // if (menu->state == 38) {
        //     menu->state = 4;
        // }

        // _h_TkMenuCtrlMain.orig_fptr(menu);

        if (Globals.TkMenus.active_help_message != help_mes) {
            *Globals.TkMenus.previous_help_message = *Globals.TkMenus.active_help_message;
            *Globals.TkMenus.active_help_message = help_mes;
        }

        _TOMenuGetControlPad();
        ushort rep = _TOMenuGetControlPadRep();
        ushort trg = _TOMenuGetControlPadTrg();

        *TkMenuMainOpenWaitTimer += 0xAA;
        if (*TkMenuMainOpenWaitTimer > 0xFFF) {
            *TkMenuMainOpenWaitTimer = 0x1000;
        }

        int state = menu->state;

        while (true) {
            if (state > 38) return;

            switch (state) {
                case 0:
                    _TkMn2SetMainFrameRatioDiff(-16);
                    menu->state = 1;
                    return;

                case 1:
                    if (*TkMenuMainOpenWaitTimer < 0x1000) return;

                    if (*DAT_01871524 != 0) return;

                    menu->state = 2;
                    return;

                case 4:
                    menu->state = 5;
                    goto case 5;

                case 5: // Selecting menu
                    // Confirm button
                    if (trg.get_bit(5)) {
                        if (!selected_option->is_enabled) {
                            _SndSepPlaySimple(SND_MENU_DISABLED);
                            return;
                        }

                        _SndSepPlaySimple(SND_MENU_ACTION);

                        int new_menu = selected_option->new_menu_id;

                        if (new_menu == TkMenuId.TK_MENU_STATUS) {
                            state = 10;
                            break;
                        }

                        var confirm_behavior = selected_option->player_selection;

                        if (confirm_behavior == TkMenuMainOptionPlySelect.NONE) {
                            open_menu_from_main(menu, &state);
                            break;
                        }

                        if (confirm_behavior == TkMenuMainOptionPlySelect.ANY) {
                            set_ignore_join_flag(true);

                            menu->state = 6;
                            return;
                        }

                        if (confirm_behavior == TkMenuMainOptionPlySelect.ONLY_JOINED) {
                            set_ignore_join_flag(false);

                            int player = _TkMenuGetCurrentPlayerPos();
                            int player_max = _TkMenuGetPlayerListMax();
                            if (player > player_max) {
                                _TkMenuSetCurrentPlayerPos(player_max - 1);
                            }

                            menu->state = 6;
                            return;
                        }

                        break;
                    }

                    // Cancel button
                    if (trg.get_bit(6)) {
                        _SndSepPlaySimple(SND_MENU_CANCEL);
                        menu->state = 35;
                        return;
                    }

                    // Up button
                    if (rep.get_bit(12)) {
                        _SndSepPlaySimple(SND_MENU_ACTION);

                        *selected_option_idx -= 1;
                        if (*selected_option_idx < 0) {
                            *selected_option_idx = _TkMenuMainGetMaxOptions() - 1;
                        }

                        update_help_for_option();
                        return;
                    }

                    // Down button
                    if (rep.get_bit(14)) {
                        _SndSepPlaySimple(SND_MENU_ACTION);

                        *selected_option_idx += 1;
                        if (*selected_option_idx >= _TkMenuMainGetMaxOptions()) {
                            *selected_option_idx = 0;
                        }

                        update_help_for_option();
                        return;
                    }

                    return;

            case 6:
                *selected_player_idx = _TkMenuGetCurrentPlayer();

                menu->state = 7;
                goto case 7;

            case 7: // Selecting player
                    if (trg.get_bit(5)) {
                        int player = _TkMenuGetCurrentPlayerPos();
                        int player_max = _TkMenuGetPlayerListMax();
                        if (player > player_max) {
                            _SndSepPlaySimple(SND_MENU_DISABLED);
                            return;
                        }

                        _SndSepPlaySimple(SND_MENU_ACTION);
                        open_menu_from_main(menu, &state);
                        break;
                    }

                    if (trg.get_bit(6)) {
                        _SndSepPlaySimple(SND_MENU_CANCEL);
                        menu->state = 8;
                        return;
                    }

                    // If there's only one player, there's no point in trying to handle up/down inputs
                    if (_TkMenuGetPlayerListMax2() < 2) {
                        return;
                    }

                    if (rep.get_bit(12)) {
                        _SndSepPlaySimple(SND_MENU_ACTION);
                        _TkMenuSetPrevPlayer2();
                        *selected_player_idx = _TkMenuGetCurrentPlayer();
                    } else if (rep.get_bit(14)) {
                        _SndSepPlaySimple(SND_MENU_ACTION);
                        _TkMenuSetNextPlayer2();
                        *selected_player_idx = _TkMenuGetCurrentPlayer();
                    }

                    return;
            case 8:
                *selected_player_idx = -1;

                menu->state = 9;
                goto case 9;

            case 9:
                menu->state = 2;
                return;

            case 10:
                *switch_player1_idx = _TkMenuGetCurrentPlayerPos();
                goto case 11;

            case 11:
                *switch_player2_idx = -1;
                menu->state = 12;
                return;

            case 12:
                menu->state = 13;
                return;

            case 13:
                menu->state = 14;
                return;

            case 14:
                if (trg.get_bit(5)) {
                    int player = _TkMenuGetPlayerFromIndex2(*selected_player_idx);

                    if (_MsGetSavePlyJoin((byte)player) == 0) {
                        _SndSepPlaySimple(SND_MENU_DISABLED);
                        return;
                    }

                    _SndSepPlaySimple(SND_MENU_ACTION);
                    menu->state = 17;
                    return;
                }

                if (trg.get_bit(6)) {
                    _SndSepPlaySimple(SND_MENU_CANCEL);
                    menu->state = 15;
                    return;
                }

                if (rep.get_bit(12)) {
                    _SndSepPlaySimple(SND_MENU_ACTION);

                    *switch_player1_idx -= 1;
                    if (*switch_player1_idx < 0) {
                        *switch_player1_idx = _TkMenuGetPlayerListMax2() - 1;
                    }

                } else if (rep.get_bit(14)) {
                    _SndSepPlaySimple(SND_MENU_ACTION);

                    *switch_player1_idx += 1;
                    if (*switch_player1_idx >= _TkMenuGetPlayerListMax2()) {
                        *switch_player1_idx = 0;
                    }

                }

                return;

            case 15:
                *switch_player1_idx = -1;
                *switch_player2_idx = -1;

                menu->state = 16;
                goto case 16;

            case 16:
                _MsSetSaveParamAll();

                menu->state = 3;
                return;

            case 17:
                *switch_player2_idx = *switch_player1_idx;

                menu->state = 18;
                goto case 18;

            case 18:
                menu->state = 19;
                return;

            case 19:
                menu->state = 20;
                goto case 20;

            case 20:
                    if (trg.get_bit(5)) {
                        if (*switch_player1_idx != *switch_player2_idx) {
                            int player = _TkMenuGetPlayerFromIndex2(*switch_player2_idx);
                            if (_MsGetSavePlyJoin((byte)player) != 0) {
                                _SndSepPlaySimple(SND_MENU_ACTION);

                                menu->state = 21;
                                return;
                            }
                        }

                        _SndSepPlaySimple(SND_MENU_DISABLED);
                        return;
                    }

                    if (trg.get_bit(6)) {
                        _SndSepPlaySimple(SND_MENU_CANCEL);

                        menu->state = 23;
                        return;
                    }

                    if (rep.get_bit(12)) {
                        _SndSepPlaySimple(SND_MENU_ACTION);

                        *switch_player2_idx -= 1;
                        if (*switch_player2_idx < 0) {
                            *switch_player2_idx = _TkMenuGetPlayerListMax2() - 1;
                        }
                    } else if (rep.get_bit(14)) {
                        _SndSepPlaySimple(SND_MENU_ACTION);

                        *switch_player2_idx += 1;
                        if (*switch_player2_idx >= _TkMenuGetPlayerListMax2()) {
                            *switch_player2_idx = 0;
                        }
                    }

                    return;

            case 21:
                _TkMenuExchangePlayerPos(*switch_player1_idx, *switch_player2_idx);
                *switch_player1_idx = *switch_player2_idx;
                *switch_player2_idx = -1;

                menu->state = 22;
                goto case 22;

            case 22:
                menu->state = 11;
                return;

            case 23:
                menu->state = 24;
                goto case 24;

            case 24:
                menu->state = 11;
                return;

            case 25:
                _MsSetSaveParamAll();

                menu->state = 26;
                return;

            case 26:
                if (*DAT_01871514 == 0) {
                    return;
                }

                _TkMenuMainFreeWindowGroup(0);
                _TkMenuMainFreeWindowGroup(3);

                menu->state = 2;
                return;

            case 27:
                _TkMenuDrawShadeRatioDiff(10);

                menu->state = 28;
                return;

            case 28:
                if (_TkMenuGetDrawShadeRatio() < 128) {
                    return;
                }

                _TkMenuMainActiveMenu(TkMenuId.TK_MENU_ABILITY_MAP_2, 0);
                _TkMenuMainSleepMenu(TkMenuId.TK_MENU_MAIN);

                menu->state = 29;
                return;

            case 29:
                if (*DAT_01871514 == 0) return;

                _TkMenuMainFreeWindowGroup(0);
                _TkMenuMainFreeWindowGroup(3);
                _TkMenuDrawShadeRatioDiff(-10);

                menu->state = 30;
                return;

            case 30:
            case 34:
                if (_TkMenuGetDrawShadeRatio() > 0) return;

                menu->state = 2;
                return;

            case 31:
                _TkMenuDrawShadeRatioDiff(10);

                menu->state = 32;
                return;

            case 32:
                if (_TkMenuGetDrawShadeRatio() < 128) return;

                _TkMenuMainActiveMenu(TkMenuId.TK_MENU_HELP, 0);
                _TkMenuMainSleepMenu(TkMenuId.TK_MENU_MAIN);

                menu->state = 33;
                return;

            case 33:
                if (*DAT_01871514 == 0) return;

                _TkMenuMainFreeWindowGroup(0);
                _TkMenuMainFreeWindowGroup(3);
                _TkMenuDrawShadeRatioDiff(-10);

                menu->state = 34;
                return;

            case 35:
                menu->state = 36;
                goto case 36;

            case 36:
                if (_TOMenuGetFirstReadEndFlag() == 0) return;

                _TkMn2SetMainFrameRatioDiff(16);

                menu->state = 37;
                return;

            case 37:
                if (_TkMn2GetMainFrameRatio() < 0x80) return;

                menu->state = 38;
                return;

            case 38:
                _TkMenuMainRemoveMenu(TkMenuId.TK_MENU_MAIN);
                return;

            default:
                set_ignore_join_flag(false);

                menu->state = 4;
                return;
            }
        }
    }
}
