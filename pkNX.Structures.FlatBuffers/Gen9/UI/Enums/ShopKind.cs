using FlatSharp.Attributes;
// ReSharper disable UnusedMember.Global

namespace pkNX.Structures.FlatBuffers;

[FlatBufferEnum(typeof(int))]
public enum ShopKind
{
    NONE = 0,
    FRIENDLYSHOP = 1,
    RESTAURANT = 2,
    HAIRMAKE = 3,
    WAZAMACHINEMACHINE = 4,
    DRESSUP = 5,
    LUXURYRESTAURANT = 6,
    DELIBIRD = 7,
    DELICATESSEN = 8,
    DRUG_STORE = 9,
    KANZUME = 10,
    BAKERY = 11,
    SUPERMARKET = 12,
    KOUBAI = 13,
    PICNIC = 14,
}
