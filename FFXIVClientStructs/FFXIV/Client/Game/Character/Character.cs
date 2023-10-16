using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;
// Client::Game::Character::Character
//   Client::Game::Object::GameObject
//   Client::Graphics::Vfx::VfxDataListenner
//   Client::Game::Character::CharacterData

// size = 0x1B40
// ctor E8 ?? ?? ?? ?? 48 8B C8 48 8B 43 08 45 33 C9
[StructLayout(LayoutKind.Explicit, Size = 0x1B40)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 8b d9 48 89 01 48 8d 05 ?? ?? ?? ?? 48 89 81 a0 01 00 00 48 8d 05 ?? ?? ?? ??", 3)]
public unsafe partial struct Character {
    [FieldOffset(0x0)] public GameObject GameObject;

    [FieldOffset(0x1A8)] public CharacterData CharacterData;

    #region This is inside a new 0x48 byte class at offset 0x1A8

    [FieldOffset(0x1B0), Obsolete("Use CharacterData.ModelScale", true)]
    public float ModelScale;
    [FieldOffset(0x1B4), Obsolete("Use CharacterData.ModelCharaId", true)]
    public int ModelCharaId;
    [FieldOffset(0x1B8), Obsolete("Use CharacterData.ModelSkeletonId", true)]
    public int ModelSkeletonId;
    [FieldOffset(0x1BC), Obsolete("Use CharacterData.ModelCharaId_2", true)]
    public int ModelCharaId_2; // == -1 -> return ModelCharaId
    [FieldOffset(0x1C0), Obsolete("Use CharacterData.ModelSkeletonId_2", true)]
    public int ModelSkeletonId_2; // == 0 -> return ModelSkeletonId

    [FieldOffset(0x1C4), Obsolete("Use CharacterData.Health", true)]
    public uint Health;
    [FieldOffset(0x1C8), Obsolete("Use CharacterData.MaxHealth", true)]
    public uint MaxHealth;
    [FieldOffset(0x1CC), Obsolete("Use CharacterData.Mana", true)]
    public uint Mana;
    [FieldOffset(0x1D0), Obsolete("Use CharacterData.MaxMana", true)]
    public uint MaxMana;
    [FieldOffset(0x1D4), Obsolete("Use CharacterData.GatheringPoints", true)]
    public ushort GatheringPoints;
    [FieldOffset(0x1D6), Obsolete("Use CharacterData.MaxGatheringPoints", true)]
    public ushort MaxGatheringPoints;
    [FieldOffset(0x1D8), Obsolete("Use CharacterData.CraftingPoints", true)]
    public ushort CraftingPoints;
    [FieldOffset(0x1DA), Obsolete("Use CharacterData.MaxCraftingPoints", true)]
    public ushort MaxCraftingPoints;
    [FieldOffset(0x1DC), Obsolete("Use CharacterData.TransformationId", true)]
    public short TransformationId;
    [FieldOffset(0x1DE), Obsolete("Use CharacterData.StatusEffectVFXId", true)]
    public short StatusEffectVFXId; // outdated since TitleID moved here
    [FieldOffset(0x1DE), Obsolete("Use CharacterData.TitleID", true)]
    public ushort TitleID;

    [FieldOffset(0x1E2), Obsolete("Use CharacterData.ClassJob", true)]
    public byte ClassJob;
    [FieldOffset(0x1E3), Obsolete("Use CharacterData.Level", true)]
    public byte Level;

    [FieldOffset(0x1ED), Obsolete("Use CharacterData.ShieldValue", true)]
    public byte ShieldValue;

    [FieldOffset(0x1EF), Obsolete("Use CharacterData.OnlineStatus", true)]
    public byte OnlineStatus;

    #endregion

    [FieldOffset(0x200)] public fixed byte Movement[0x420];

    [FieldOffset(0x620)] public EmoteController EmoteController;
    [FieldOffset(0x620 + 0x21), Obsolete("Use EmoteController.CPoseState", true)] public byte CPoseState;

    [FieldOffset(0x660)] public MountContainer Mount;
    [FieldOffset(0x6C8)] public CompanionContainer Companion;

    [FieldOffset(0x6E8)] public DrawDataContainer DrawData;
    [Obsolete($"Use {nameof(DrawData)}", true), FieldOffset(0x6E8 + 0x148)] public fixed byte EquipSlotData[4 * 10];
    [Obsolete($"Use {nameof(DrawData)}.CustomizeData", true), FieldOffset(0x6E8 + 0x170)] public fixed byte CustomizeData[0x1A];

    [FieldOffset(0x878)] public OrnamentContainer Ornament;
    [FieldOffset(0x8E0)] public ReaperShroudContainer ReaperShroud;
    [FieldOffset(0x920)] public ActionTimelineManager ActionTimelineManager;

    [Obsolete($"Use {nameof(LookTargetId)} instead.", true)]
    [FieldOffset(0xCB0)] public uint PlayerTargetObjectID; // offset not updated for 6.5

    /// <summary>
    /// The current target for this character's gaze. Can be set independently of soft or hard targets, and may be set
    /// by NPCs or minions. For players, an action cast will generally target the LookTarget (which generally will be
    /// the soft target if set, then the hard target).
    /// </summary>
    /// <remarks>
    /// Unlike other GameObjectIDs, this one appears to be set to fully 0 if the player is not looking at anything.
    /// </remarks>
    [FieldOffset(0xCB0)] public GameObjectID LookTargetId;

    [FieldOffset(0x19B0)] public VfxContainer Vfx;

    [Obsolete("Use Vfx.VfxData", true)]
    [FieldOffset(0x19B0 + 0x18)] public VfxData* VfxData;
    [Obsolete("Use Vfx.VfxData2", true)]
    [FieldOffset(0x19B0 + 0x20)] public VfxData* VfxData2;
    [Obsolete("Use Vfx.Omen", true)]
    [FieldOffset(0x19B0 + 0x48)] public VfxData* Omen;

    [Obsolete("Use Vfx.VoiceId", false)]
    [FieldOffset(0x1B24)] public ushort VoiceId;

    [FieldOffset(0x1B3A)] public byte StatusFlags4;
    // [FieldOffset(0x1418)] public CharacterSetup CharacterSetup;
    public CharacterSetup CharacterSetup => new CharacterSetup { };

    [FieldOffset(0x17C0)] public Balloon Balloon;

    [FieldOffset(0x1A4C)] public float Alpha;
    [FieldOffset(0x1A80)] public Companion* CompanionObject; // minion
    [FieldOffset(0x1A98)] public fixed byte FreeCompanyTag[6];

    [Obsolete("Use CharacterData.CombatTaggerId instead.", true)]
    [FieldOffset(0x1AB0)] public GameObjectID CombatTaggerId; // offset not updated for 6.5

    [Obsolete($"Use {nameof(TargetId)} instead.", true)]
    [FieldOffset(0x1AB8)] public ulong TargetObjectID;

    /// <summary>
    /// The current (hard) target for this Character. This will not be set for the LocalPlayer.
    /// </summary>
    /// <remarks>
    /// Developers should generally use <see cref="GetTargetId"/> over reading this field directly, as it will
    /// properly handle resolving the target for the local player.
    /// </remarks>
    [FieldOffset(0x1AB8)] public GameObjectID TargetId;

    /// <summary>
    /// The current soft target for this Character. This will not be set for the LocalPlayer.
    /// </summary>
    /// <remarks>
    /// Developers should generally use <see cref="GetSoftTargetId"/> over reading this field directly, as it will
    /// properly handle resolving the soft target for the local player.
    /// </remarks>
    [FieldOffset(0x1AC0)] public GameObjectID SoftTargetId;

    [FieldOffset(0x1B00)] public uint NameID;

    [FieldOffset(0x1B10)] public uint CompanionOwnerID;

    [FieldOffset(0x1B1C)] public ushort CurrentWorld;
    [FieldOffset(0x1B1E)] public ushort HomeWorld;

    [FieldOffset(0x1B26)] public byte EventState; // Leave for backwards compat. See Mode.
    [FieldOffset(0x1B26)] public CharacterModes Mode;
    [FieldOffset(0x1B27)] public byte ModeParam; // Different purpose depending on mode. See CharacterModes for more info.

    [Obsolete("Use CharacterData.CombatTagType instead.", true)]
    [FieldOffset(0x1B31)] public byte CombatTagType; // offset not updated for 6.5

    // Note: These 2 status flags might be just an ushort instead of 2 separate bytes.

    // 0x1 = WeaponDrawn
    // 0x2 = Unknown (Appears to always be set)
    [FieldOffset(0x1B38)] public byte StatusFlags3;
    // 0x20 = GPose wetness toggled

    public bool IsWeaponDrawn => (StatusFlags3 & 0x1) == 0x1;
    public bool IsOffhandDrawn => (CharacterData.Flags1 & 0x40) == 0x40;
    public bool InCombat => (CharacterData.Flags1 & 0x20) == 0x20;
    public bool IsHostile => (CharacterData.Flags1 & 0x10) == 0x10;
    public bool IsCasting => GetCastInfo() != null && (GetCastInfo()->IsCasting & 0x1) == 0x1;
    public bool IsPartyMember => (CharacterData.Flags2 & 0x8) == 0x8;
    public bool IsAllianceMember => (CharacterData.Flags2 & 0x10) == 0x10;
    public bool IsFriend => (CharacterData.Flags2 & 0x20) == 0x20;

    public bool IsGPoseWet {
        get => (StatusFlags4 & 0x01) == 0x01;
        set => StatusFlags4 = (byte)(value ? StatusFlags4 | 0x01 : StatusFlags4 & ~0x01);
    }

    /// <summary>
    /// Gets the (hard) target ID for this character. If this character is the LocalPlayer, this will instead read the
    /// target ID from the <see cref="TargetSystem"/>. Used for calculating ToT via /assist.
    /// </summary>
    /// <returns>Returns the object ID of this character's target.</returns>
    // TODO: Update this return type to GameObjectID with next API bump.
    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C7 0F 84")]
    public partial ulong GetTargetId();

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B FD 74 36")]
    public partial void SetTargetId(GameObjectID id);

    /// <summary>
    /// Gets the soft target ID for this character. If this character is the LocalPlayer, this will instead read the
    /// soft target ID from the <see cref="TargetSystem"/>.
    /// </summary>
    /// <returns>Returns the object ID of this character's target.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C5")]
    public partial GameObjectID GetSoftTargetId();

    [MemberFunction("E8 ?? ?? ?? ?? B8 ?? ?? ?? ?? 4C 3B F0")]
    public partial void SetSoftTargetId(GameObjectID id);

    [Obsolete("Use CharacterSetup.CopyFromCharacter", true)]
    public ulong CopyFromCharacter(Character* source, CharacterSetup.CopyFlags flags) => CharacterSetup.CopyFromCharacter(source, flags);

    [Obsolete("Use CopyFromCharacter(Character*, CopyFlags)", true)]
    public ulong CopyFromCharacter(Character* source, uint flags) => CopyFromCharacter(source, (CharacterSetup.CopyFlags)flags);
    public bool IsMounted() {
        // inlined as of 6.5
        return this.Mount.MountId != 0;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? E8 ?? ?? ?? ?? 48 8B 4C 24 ??")]
    public partial void SetMode(CharacterModes mode, byte modeParam);

    [Obsolete("Use CharacterSetup.SetupBNpc", true)]
    public void SetupBNpc(uint bNpcBaseId, uint bNpcNameId = 0) => CharacterSetup.SetupBNpc(bNpcBaseId, bNpcNameId);

    /// <summary> Can only be used for Mounts, Minions, and Ornaments. Literally just checks if the game object at index - 1 is a character and returns that. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 48 0F 45 F8")]
    public partial Character* GetParentCharacter();

    /// <summary> Uses TransformationId, Clan, BodyType, Gender and Height as well as RSP scaling values to calculate current height.  </summary>
    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 59 C7 48 8B CE")]
    public partial float CalculateHeight();

    [VirtualFunction(79)]
    public partial StatusManager* GetStatusManager();

    /// <summary>
    /// Gets the <see cref="CastInfo"/> struct for this Character.
    /// May be null for certain Character subclasses, e.g. <see cref="Companion"/>.
    /// </summary>
    /// <returns>Returns a pointer to a CastInfo struct, or <c>null</c>.</returns>
    [VirtualFunction(81)]
    public partial CastInfo* GetCastInfo();

    [VirtualFunction(85)]
    public partial ForayInfo* GetForayInfo();

    [VirtualFunction(87)]
    public partial bool IsMount();

    [StructLayout(LayoutKind.Explicit, Size = 0x170)]
    public struct CastInfo {
        [FieldOffset(0x00)] public byte IsCasting;
        [FieldOffset(0x01)] public byte Interruptible;
        [FieldOffset(0x02)] public ActionType ActionType;
        [FieldOffset(0x04)] public uint ActionID;
        [FieldOffset(0x08)] public uint Unk_08;
        [FieldOffset(0x10)] public uint CastTargetID;
        [FieldOffset(0x20)] public Vector3 CastLocation;
        [FieldOffset(0x30)] public uint Unk_30;
        [FieldOffset(0x34)] public float CurrentCastTime;
        [FieldOffset(0x38)] public float TotalCastTime;
        [FieldOffset(0x3C)] public float AdjustedTotalCastTime;

        [FieldOffset(0x40)] public uint UsedActionId;

        [FieldOffset(0x44)] public ActionType UsedActionType;
        //[FieldOffset(0x4C)] public uint TotalActionCounter?;
        //[FieldOffset(0x50)] public uint OwnActionCounter?;

        [FieldOffset(0x58)] public fixed ulong ActionRecipientsObjectIdArray[32];
        [FieldOffset(0x158)] public int ActionRecipientsCount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct ForayInfo {
        [FieldOffset(0x00)] public byte ForayRank;

        //bozja
        public byte ResistanceRank {
            get => ForayRank;
            set => ForayRank = value;
        }

        //eureka
        public byte ElementalLevel {
            get => ForayRank;
            set => ForayRank = value;
        }
        [FieldOffset(0x01)] public EurekaElement Element; //only on enemies
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xF0)]
    public partial struct VfxContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public void** VfxListenerVTable;

        [FieldOffset(0x18)] public VfxData* VfxData;
        [FieldOffset(0x20)] public VfxData* VfxData2;
        [FieldOffset(0x48)] public VfxData* Omen;

        // [FieldOffset(0xD0)] public ushort VoiceId;
        public ushort VoiceId {
            get => (OwnerObject->Character).VoiceId;
            set => (OwnerObject->Character).VoiceId = value;
        }

        [MemberFunction("E8 ?? ?? ?? ?? 0F B6 06 3C")]
        public partial nint LoadCharacterSound(int unk1, int unk2, nint unk3, ulong unk4, int unk5, int unk6, ulong unk7);
    }

    //0x10 bytes are from the base class which is just vtable + gameobject ptr (same as Companion-/DrawDataContainer)
    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct MountContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public Character* MountObject;
        [FieldOffset(0x18)] public ushort MountId;
        [FieldOffset(0x1C)] public float DismountTimer;
        //1 in dismount animation, 4 = instant delete mount when dismounting (used for npcs and such)
        [FieldOffset(0x20)] public byte Flags;
        [FieldOffset(0x24)] public fixed uint MountedObjectIds[7];

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 08 0F B6 90 ?? ?? ?? ?? 84 D2 74 0C 48 8B 4B 10")] // TODO 6.4
        public partial void SetupMount(short mountId, uint buddyModelTop, uint buddyModelBody, uint buddyModelLegs, byte buddyStain);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CompanionContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public Companion* CompanionObject;
        //used if minion is summoned but the object slot is taken by a mount
        [FieldOffset(0x18)] public ushort CompanionId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public struct OrnamentContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public Ornament* OrnamentObject;
        [FieldOffset(0x18)] public ushort OrnamentId;
    }

    // Reaper Shroud seems to be mostly hardcoded.
    // It applies a transformation to NpcEquip row 2161 (which only sets the body slot to 8100,1).
    // It also enables the Vfx in this container, and toggles the 'atr_eye_a' attribute in the model (for the red pupils).
    // We do not actually know where all the other values come in, nothing except Flags and Vfx is actually used by Reaper Shroud (not even NpcEquipId, strangely).
    // This probably is used by other transformations too, but we have not found any yet.
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public struct ReaperShroudContainer {
        [FieldOffset(0x00)] public void** ContainerVTable;
        [FieldOffset(0x08)] public BattleChara* OwnerObject;
        [FieldOffset(0x10)] public void** VfxListenerVTable;
        [FieldOffset(0x18)] public ushort StanceChangeId;
        [FieldOffset(0x1C)] public uint StanceChangeState;
        [FieldOffset(0x20)] public float Timer;
        [FieldOffset(0x28)] public void* CopyObject;
        [FieldOffset(0x30)] public ShroudFlags Flags;
        [FieldOffset(0x40)] public VfxData* Vfx;
        [FieldOffset(0x3C)] public ushort NpcEquipId;

        [Flags]
        public enum ShroudFlags : uint {
            ShroudAttacking = 0x01, // On when the character is using a skill from reaper shroud, can be on for a short time without shroud itself being on.
            ShroudActive = 0x02, // On as long as the transformation is enabled.
            ShroudLoading = 0x0100, // On at the start before the VFX is loaded.
        }
    }

    public enum EurekaElement : byte {
        None = 0,
        Fire = 1,
        Ice = 2,
        Wind = 3,
        Earth = 4,
        Lightning = 5,
        Water = 6,
    }

    // Seems similar to ConditionFlag in Dalamud but not all flags are valid on the character
    public enum CharacterModes : byte {
        None = 0, // Mode is never used
        Normal = 1, // Param always 0
        EmoteLoop = 3, // Param is an EmoteMode entry
        Mounted = 4, // Param always 0
        Crafting = 5, // Param always 0
        AnimLock = 8, // Param always 0
        Carrying = 9, // Param is a Carry entry
        InPositionLoop = 11, // Param is an EmoteMode entry
        Performance = 16, // Unknown
    }
}
