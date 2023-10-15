using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RetainerCommentModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 33 ED 48 89 51 10 48 8D 05 ?? ?? ?? ?? 48 89 69 08 48 8B F1"
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
public unsafe partial struct RetainerCommentModule {
    public static RetainerCommentModule* Instance() => UIModule.Instance()->GetRetainerCommentModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;

    [FixedSizeArray<RetainerComment>(10)]
    [FieldOffset(0x40)] public fixed byte Retainers[0x68 * 10];

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B BC 24 ?? ?? ?? ?? 48 8B B4 24 ?? ?? ?? ?? 49 8B 4E 10")]
    [GenerateCStrOverloads]
    public partial void SetComment(ulong retainerId, byte* comment);

    [MemberFunction("4C 8B D9 48 85 D2 74 27")]
    public partial byte* GetComment(ulong retainerId);

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public struct RetainerComment {
        [FieldOffset(0)] public ulong Id;
        [FieldOffset(0x8)] public fixed byte Comment[0x5B];
    }
}
