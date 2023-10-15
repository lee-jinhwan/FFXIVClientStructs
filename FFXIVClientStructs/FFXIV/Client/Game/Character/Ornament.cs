namespace FFXIVClientStructs.FFXIV.Client.Game.Character;
// Client::Game::Character::Ornament
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
// ornament = accessory

// ctor E8 ?? ?? ?? ?? 48 8B C8 EB 03 48 8B CF 48 8B 46 08 45 33 C9
[StructLayout(LayoutKind.Explicit, Size = 0x1B60)]
public unsafe partial struct Ornament {
    [FieldOffset(0x0)] public Character Character;

    [FieldOffset(0x1B20)] public uint OrnamentId;
    [FieldOffset(0x1B24)] public byte AttachmentPoint;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 55 ?? 48 8D 4D ?? E8 ?? ?? ?? ?? 44 8B 4D")]
    public partial void SetupOrnament(uint* unk1, float* unk2);
}
