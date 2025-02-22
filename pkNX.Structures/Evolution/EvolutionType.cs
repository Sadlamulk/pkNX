using System;
using static pkNX.Structures.EvolutionType;
using static pkNX.Structures.EvolutionTypeArgumentType;
using System.Collections.Generic;

namespace pkNX.Structures;

public enum EvolutionType : byte
{
    None = 0,
    LevelUpFriendship = 1,
    LevelUpFriendshipMorning = 2,
    LevelUpFriendshipNight = 3,
    LevelUp = 4,
    Trade = 5,
    TradeHeldItem = 6,
    TradeShelmetKarrablast = 7,
    UseItem = 8,
    LevelUpATK = 9,
    LevelUpAeqD = 10,
    LevelUpDEF = 11,
    LevelUpECl5 = 12,
    LevelUpECgeq5 = 13,
    LevelUpNinjask = 14,
    LevelUpShedinja = 15,
    LevelUpBeauty = 16,
    UseItemMale = 17,
    UseItemFemale = 18,
    LevelUpHeldItemDay = 19,
    LevelUpHeldItemNight = 20,
    LevelUpKnowMove = 21,
    LevelUpWithTeammate = 22,
    LevelUpMale = 23,
    LevelUpFemale = 24,
    LevelUpElectric = 25,
    LevelUpForest = 26,
    LevelUpCold = 27,
    LevelUpInverted = 28,
    LevelUpAffection50MoveType = 29,
    LevelUpMoveType = 30,
    LevelUpWeather = 31,
    LevelUpMorning = 32,
    LevelUpNight = 33,
    LevelUpFormFemale1 = 34,
    UNUSED = 35,
    LevelUpVersion = 36,
    LevelUpVersionDay = 37,
    LevelUpVersionNight = 38,
    LevelUpSummit = 39,
    LevelUpDusk = 40,
    LevelUpWormhole = 41,
    UseItemWormhole = 42,
    CriticalHitsInBattle = 43, // Sirfetch'd
    HitPointsLostInBattle = 44, // Runerigus
    Spin = 45, // Alcremie
    LevelUpNatureAmped = 46, // Toxtricity
    LevelUpNatureLowKey = 47, // Toxtricity
    TowerOfDarkness = 48, // Urshifu
    TowerOfWaters = 49, // Urshifu

    LevelUpWalkStepsWith = 50,
    LevelUpUnionCircle = 51, // Palafin
    LevelUpInBattleEC25 = 52, // Maushold-0
    LevelUpInBattleECElse = 53, // Maushold-1
    LevelUpCollect999 = 54, // Gimmighoul formarg 999
    LevelUpDefeatEquals = 55, // Kingambit
    LevelUpUseMoveSpecial = 56, // Annihilape
    LevelUpKnowMoveECElse = 57, // Dudunsparce-0
    LevelUpKnowMoveEC25 = 58, // Dudunsparce-1

    LevelUpRecoilDamageMale = 59, // Basculegion-0
    LevelUpRecoilDamageFemale = 60, // Basculegion-1

    Hisui = 61,

    UseItemFullMoon = 90, // Ursaluna
    UseMoveAgileStyle = 91, // Wyrdeer
    UseMoveStrongStyle = 92, // Overqwil
}

public enum EvolutionTypeArgumentType
{
    NoArg,
    Level,
    Items,
    Moves,
    Species,
    Stat,
    Type,
    Version,
}

public static class EvolutionTypeExtensions
{
    public static bool IsTrade(this EvolutionType t) => t is Trade or TradeHeldItem or TradeShelmetKarrablast;

    public static bool IsLevelUpRequired(this EvolutionType type) => type switch
    {
        None => false,
        LevelUpFriendship => true,
        LevelUpFriendshipMorning => true,
        LevelUpFriendshipNight => true,
        LevelUp => true,
        Trade => false,
        TradeHeldItem => false,
        TradeShelmetKarrablast => false,
        UseItem => false,
        LevelUpATK => true,
        LevelUpAeqD => true,
        LevelUpDEF => true,
        LevelUpECl5 => true,
        LevelUpECgeq5 => true,
        LevelUpNinjask => true,
        LevelUpShedinja => true,
        LevelUpBeauty => true,
        UseItemMale => false,
        UseItemFemale => false,
        LevelUpHeldItemDay => true,
        LevelUpHeldItemNight => true,
        LevelUpKnowMove => true,
        LevelUpWithTeammate => true,
        LevelUpMale => true,
        LevelUpFemale => true,
        LevelUpElectric => true,
        LevelUpForest => true,
        LevelUpCold => true,
        LevelUpInverted => true,
        LevelUpAffection50MoveType => true,
        LevelUpMoveType => true,
        LevelUpWeather => true,
        LevelUpMorning => true,
        LevelUpNight => true,
        LevelUpFormFemale1 => true,
        UNUSED => false,
        LevelUpVersion => true,
        LevelUpVersionDay => true,
        LevelUpVersionNight => true,
        LevelUpSummit => true,
        LevelUpDusk => true,
        LevelUpWormhole => true,
        UseItemWormhole => false,
        CriticalHitsInBattle => false,
        HitPointsLostInBattle => false,
        Spin => false,
        LevelUpNatureAmped => true,
        LevelUpNatureLowKey => true,
        TowerOfDarkness => false,
        TowerOfWaters => false,
        LevelUpWalkStepsWith => true,
        LevelUpUnionCircle => true,
        LevelUpInBattleEC25 => true,
        LevelUpInBattleECElse => true,
        LevelUpCollect999 => true,
        LevelUpDefeatEquals => true,
        LevelUpUseMoveSpecial => true,
        LevelUpKnowMoveECElse => true,
        LevelUpKnowMoveEC25 => true,
        LevelUpRecoilDamageMale => true,
        LevelUpRecoilDamageFemale => true,
        Hisui => false, // todo sv

        UseItemFullMoon => false,
        UseMoveAgileStyle => false,
        UseMoveStrongStyle => false,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
    };

    private static readonly Dictionary<EvolutionType, EvolutionTypeArgumentType> ArgType = new()
    {
        [None] = NoArg,
        [LevelUpFriendship] = NoArg,
        [LevelUpFriendshipMorning] = NoArg,
        [LevelUpFriendshipNight] = NoArg,
        [LevelUp] = Level,
        [Trade] = NoArg,
        [TradeHeldItem] = Items,
        [TradeShelmetKarrablast] = NoArg,
        [UseItem] = Items,

        [LevelUpATK] = Level,
        [LevelUpAeqD] = Level,
        [LevelUpDEF] = Level,
        [LevelUpECl5] = Level,
        [LevelUpECgeq5] = Level,
        [LevelUpNinjask] = Level,
        [LevelUpShedinja] = Level,
        [LevelUpBeauty] = Stat,

        [UseItemMale] = Items,
        [UseItemFemale] = Items,
        [LevelUpHeldItemDay] = Items,
        [LevelUpHeldItemNight] = Items,
        [LevelUpKnowMove] = Moves,
        [LevelUpWithTeammate] = EvolutionTypeArgumentType.Species,
        [LevelUpMale] = Level,
        [LevelUpFemale] = Level,
        [LevelUpElectric] = NoArg,
        [LevelUpForest] = NoArg,
        [LevelUpCold] = NoArg,
        [LevelUpInverted] = NoArg,
        [LevelUpAffection50MoveType] = EvolutionTypeArgumentType.Type,

        [LevelUpMoveType] = EvolutionTypeArgumentType.Type,
        [LevelUpWeather] = Level,
        [LevelUpMorning] = Level,
        [LevelUpNight] = Level,
        [LevelUpFormFemale1] = Level,
        [UNUSED] = NoArg,
        [LevelUpVersion] = EvolutionTypeArgumentType.Version,
        [LevelUpVersionDay] = EvolutionTypeArgumentType.Version,
        [LevelUpVersionNight] = EvolutionTypeArgumentType.Version,
        [LevelUpSummit] = Level,
        [LevelUpDusk] = Level,
        [LevelUpWormhole] = Level,
        [UseItemWormhole] = Items,

        [CriticalHitsInBattle] = EvolutionTypeArgumentType.Version,
        [HitPointsLostInBattle] = EvolutionTypeArgumentType.Version,
        [Spin] = NoArg,
        [LevelUpNatureAmped] = NoArg,
        [LevelUpNatureLowKey] = NoArg,
        [TowerOfDarkness] = NoArg,
        [TowerOfWaters] = NoArg,
        [UseItemFullMoon] = Items, // Ursaluna
        [UseMoveAgileStyle] = NoArg, // Wyrdeer
        [UseMoveStrongStyle] = NoArg, // Overqwil
        [LevelUpRecoilDamageMale] = NoArg, // Basculegion-0
        [LevelUpRecoilDamageFemale] = NoArg, // Basculegion-1

        [LevelUpWalkStepsWith] = NoArg,
        [LevelUpUnionCircle] = NoArg,
        [LevelUpInBattleEC25] = NoArg, // Maushold-0
        [LevelUpInBattleECElse] = NoArg, // Maushold-1
        [LevelUpCollect999] = NoArg, // Ghimmighoul formarg 999
        [LevelUpDefeatEquals] = NoArg, // Kingambit
        [LevelUpUseMoveSpecial] = NoArg, // Annihilape
        [LevelUpKnowMoveECElse] = Moves, // Dudunsparce 0
        [LevelUpKnowMoveEC25] = Moves, // Dudunsparce 1
        [Hisui] = NoArg,
    };

    public static EvolutionTypeArgumentType GetArgType(this EvolutionType t) => ArgType[t];
    public static bool IsUseItem(this EvolutionType type) => GetArgType(type) == Items;
}
