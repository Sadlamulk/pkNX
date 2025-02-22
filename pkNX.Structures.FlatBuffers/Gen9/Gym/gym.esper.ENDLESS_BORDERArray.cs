using System.ComponentModel;
using FlatSharp.Attributes;
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedType.Global
#nullable disable

namespace pkNX.Structures.FlatBuffers;

// Generated by FlatSharp
// FileIdentifier: 
// FileExtension: 
// Object Count: 4
// Enum Count: 1
// Root Type: gym.esper.ENDLESS_BORDERArray

[FlatBufferTable, TypeConverter(typeof(ExpandableObjectConverter))]
public class ENDLESSBORDERArray : IFlatBufferArchive<ENDLESSBORDER>
{
    [FlatBufferItem(0)] public ENDLESSBORDER[] Table { get; set; }
}

[FlatBufferTable, TypeConverter(typeof(ExpandableObjectConverter))]
public class ENDLESSBORDER
{
    [FlatBufferItem(0)] public ExerciseSetting ExerciseSetting { get; set; }
}

[FlatBufferStruct, TypeConverter(typeof(ExpandableObjectConverter))]
public class ExerciseSetting
{
    [FlatBufferItem(0)] public int Variation { get; set; }
    [FlatBufferItem(1)] public float InputSeconds { get; set; }
    [FlatBufferItem(2)] public int InstructCount { get; set; }
    [FlatBufferItem(3)] public ExerciseRewardData FixedReward { get; set; }
    [FlatBufferItem(4)] public ExerciseRewardData[] Rewards { get; set; }
    [FlatBufferItem(5)] public int RewardsCount { get; set; }
}

[FlatBufferStruct, TypeConverter(typeof(ExpandableObjectConverter))]
public class ExerciseRewardData
{
    [FlatBufferItem(0)] public ItemID ItemId { get; set; }
    [FlatBufferItem(1)] public int ItemCount { get; set; }
}
