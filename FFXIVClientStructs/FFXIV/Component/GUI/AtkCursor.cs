namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct AtkCursor {
    public bool ShouldAutoHide {
        get => false;
        set { /* 6.5 */ }
    }
    public bool IsAutoHidden {
        get => false;
        set { /* 6.5 */ }
    }
    [FieldOffset(0x00)] public CursorType Type;
    [FieldOffset(0x0E)] public bool IsVisible;

    [Obsolete("Use IsVisible", true)]
    [FieldOffset(0x1A)] public byte Visible;

    [MemberFunction("48 83 EC ?? 80 79 ?? ?? 74 ?? C6 41")]
    public partial void Hide();

    [MemberFunction("48 83 EC 58 80 79 0E 00 75 68")]
    public partial void Show();

    [MemberFunction("E8 ?? ?? ?? ?? 83 BE ?? ?? ?? ?? ?? 41 B8")]
    public partial void SetVisible(bool visible);

    [MemberFunction("E8 ?? ?? ?? ?? C6 47 ?? ?? 48 8B CD")]
    public partial void SetCursorType(CursorType type, byte a3 = 0);

    public enum CursorType : byte {
        Arrow,
        Boot,
        Search,
        ChatPointer,
        Interact,
        Attack,
        Hand,
        ResizeWE,
        ResizeNS,
        ResizeNWSR,
        ResizeNESW,
        Clickable,
        TextInput,
        TextClick,
        Grab,
        ChatBubble,
        NoAccess,
        Hidden
    }
}
