using System.ComponentModel;
using FlatSharp.Attributes;
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedType.Global
#nullable disable

namespace pkNX.Structures.FlatBuffers;

[FlatBufferTable, TypeConverter(typeof(ExpandableObjectConverter))]
public class DressupShopDataArray : IFlatBufferArchive<DressupShopData>
{
    [FlatBufferItem(0)] public DressupShopData[] Table { get; set; }
}

[FlatBufferTable, TypeConverter(typeof(ExpandableObjectConverter))]
public class DressupShopData
{
    [FlatBufferItem(000)] public string ShopId { get; set; }
    [FlatBufferItem(001)] public int DressupItemid1 { get; set; }
    [FlatBufferItem(002)] public int DressupItemid2 { get; set; }
    [FlatBufferItem(003)] public int DressupItemid3 { get; set; }
    [FlatBufferItem(004)] public int DressupItemid4 { get; set; }
    [FlatBufferItem(005)] public int DressupItemid5 { get; set; }
    [FlatBufferItem(006)] public int DressupItemid6 { get; set; }
    [FlatBufferItem(007)] public int DressupItemid7 { get; set; }
    [FlatBufferItem(008)] public int DressupItemid8 { get; set; }
    [FlatBufferItem(009)] public int DressupItemid9 { get; set; }
    [FlatBufferItem(010)] public int DressupItemid10 { get; set; }
    [FlatBufferItem(011)] public int DressupItemid11 { get; set; }
    [FlatBufferItem(012)] public int DressupItemid12 { get; set; }
    [FlatBufferItem(013)] public int DressupItemid13 { get; set; }
    [FlatBufferItem(014)] public int DressupItemid14 { get; set; }
    [FlatBufferItem(015)] public int DressupItemid15 { get; set; }
    [FlatBufferItem(016)] public int DressupItemid16 { get; set; }
    [FlatBufferItem(017)] public int DressupItemid17 { get; set; }
    [FlatBufferItem(018)] public int DressupItemid18 { get; set; }
    [FlatBufferItem(019)] public int DressupItemid19 { get; set; }
    [FlatBufferItem(020)] public int DressupItemid20 { get; set; }
    [FlatBufferItem(021)] public int DressupItemid21 { get; set; }
    [FlatBufferItem(022)] public int DressupItemid22 { get; set; }
    [FlatBufferItem(023)] public int DressupItemid23 { get; set; }
    [FlatBufferItem(024)] public int DressupItemid24 { get; set; }
    [FlatBufferItem(025)] public int DressupItemid25 { get; set; }
    [FlatBufferItem(026)] public int DressupItemid26 { get; set; }
    [FlatBufferItem(027)] public int DressupItemid27 { get; set; }
    [FlatBufferItem(028)] public int DressupItemid28 { get; set; }
    [FlatBufferItem(029)] public int DressupItemid29 { get; set; }
    [FlatBufferItem(030)] public int DressupItemid30 { get; set; }
    [FlatBufferItem(031)] public int DressupItemid31 { get; set; }
    [FlatBufferItem(032)] public int DressupItemid32 { get; set; }
    [FlatBufferItem(033)] public int DressupItemid33 { get; set; }
    [FlatBufferItem(034)] public int DressupItemid34 { get; set; }
    [FlatBufferItem(035)] public int DressupItemid35 { get; set; }
    [FlatBufferItem(036)] public int DressupItemid36 { get; set; }
    [FlatBufferItem(037)] public int DressupItemid37 { get; set; }
    [FlatBufferItem(038)] public int DressupItemid38 { get; set; }
    [FlatBufferItem(039)] public int DressupItemid39 { get; set; }
    [FlatBufferItem(040)] public int DressupItemid40 { get; set; }
    [FlatBufferItem(041)] public int DressupItemid41 { get; set; }
    [FlatBufferItem(042)] public int DressupItemid42 { get; set; }
    [FlatBufferItem(043)] public int DressupItemid43 { get; set; }
    [FlatBufferItem(044)] public int DressupItemid44 { get; set; }
    [FlatBufferItem(045)] public int DressupItemid45 { get; set; }
    [FlatBufferItem(046)] public int DressupItemid46 { get; set; }
    [FlatBufferItem(047)] public int DressupItemid47 { get; set; }
    [FlatBufferItem(048)] public int DressupItemid48 { get; set; }
    [FlatBufferItem(049)] public int DressupItemid49 { get; set; }
    [FlatBufferItem(050)] public int DressupItemid50 { get; set; }
    [FlatBufferItem(051)] public int DressupItemid51 { get; set; }
    [FlatBufferItem(052)] public int DressupItemid52 { get; set; }
    [FlatBufferItem(053)] public int DressupItemid53 { get; set; }
    [FlatBufferItem(054)] public int DressupItemid54 { get; set; }
    [FlatBufferItem(055)] public int DressupItemid55 { get; set; }
    [FlatBufferItem(056)] public int DressupItemid56 { get; set; }
    [FlatBufferItem(057)] public int DressupItemid57 { get; set; }
    [FlatBufferItem(058)] public int DressupItemid58 { get; set; }
    [FlatBufferItem(059)] public int DressupItemid59 { get; set; }
    [FlatBufferItem(060)] public int DressupItemid60 { get; set; }
    [FlatBufferItem(061)] public int DressupItemid61 { get; set; }
    [FlatBufferItem(062)] public int DressupItemid62 { get; set; }
    [FlatBufferItem(063)] public int DressupItemid63 { get; set; }
    [FlatBufferItem(064)] public int DressupItemid64 { get; set; }
    [FlatBufferItem(065)] public int DressupItemid65 { get; set; }
    [FlatBufferItem(066)] public int DressupItemid66 { get; set; }
    [FlatBufferItem(067)] public int DressupItemid67 { get; set; }
    [FlatBufferItem(068)] public int DressupItemid68 { get; set; }
    [FlatBufferItem(069)] public int DressupItemid69 { get; set; }
    [FlatBufferItem(070)] public int DressupItemid70 { get; set; }
    [FlatBufferItem(071)] public int DressupItemid71 { get; set; }
    [FlatBufferItem(072)] public int DressupItemid72 { get; set; }
    [FlatBufferItem(073)] public int DressupItemid73 { get; set; }
    [FlatBufferItem(074)] public int DressupItemid74 { get; set; }
    [FlatBufferItem(075)] public int DressupItemid75 { get; set; }
    [FlatBufferItem(076)] public int DressupItemid76 { get; set; }
    [FlatBufferItem(077)] public int DressupItemid77 { get; set; }
    [FlatBufferItem(078)] public int DressupItemid78 { get; set; }
    [FlatBufferItem(079)] public int DressupItemid79 { get; set; }
    [FlatBufferItem(080)] public int DressupItemid80 { get; set; }
    [FlatBufferItem(081)] public int DressupItemid81 { get; set; }
    [FlatBufferItem(082)] public int DressupItemid82 { get; set; }
    [FlatBufferItem(083)] public int DressupItemid83 { get; set; }
    [FlatBufferItem(084)] public int DressupItemid84 { get; set; }
    [FlatBufferItem(085)] public int DressupItemid85 { get; set; }
    [FlatBufferItem(086)] public int DressupItemid86 { get; set; }
    [FlatBufferItem(087)] public int DressupItemid87 { get; set; }
    [FlatBufferItem(088)] public int DressupItemid88 { get; set; }
    [FlatBufferItem(089)] public int DressupItemid89 { get; set; }
    [FlatBufferItem(090)] public int DressupItemid90 { get; set; }
    [FlatBufferItem(091)] public int DressupItemid91 { get; set; }
    [FlatBufferItem(092)] public int DressupItemid92 { get; set; }
    [FlatBufferItem(093)] public int DressupItemid93 { get; set; }
    [FlatBufferItem(094)] public int DressupItemid94 { get; set; }
    [FlatBufferItem(095)] public int DressupItemid95 { get; set; }
    [FlatBufferItem(096)] public int DressupItemid96 { get; set; }
    [FlatBufferItem(097)] public int DressupItemid97 { get; set; }
    [FlatBufferItem(098)] public int DressupItemid98 { get; set; }
    [FlatBufferItem(099)] public int DressupItemid99 { get; set; }
    [FlatBufferItem(100)] public int DressupItemid100 { get; set; }
    [FlatBufferItem(101)] public int DressupItemid101 { get; set; }
    [FlatBufferItem(102)] public int DressupItemid102 { get; set; }
    [FlatBufferItem(103)] public int DressupItemid103 { get; set; }
    [FlatBufferItem(104)] public int DressupItemid104 { get; set; }
    [FlatBufferItem(105)] public int DressupItemid105 { get; set; }
    [FlatBufferItem(106)] public int DressupItemid106 { get; set; }
    [FlatBufferItem(107)] public int DressupItemid107 { get; set; }
    [FlatBufferItem(108)] public int DressupItemid108 { get; set; }
    [FlatBufferItem(109)] public int DressupItemid109 { get; set; }
    [FlatBufferItem(110)] public int DressupItemid110 { get; set; }
    [FlatBufferItem(111)] public int DressupItemid111 { get; set; }
    [FlatBufferItem(112)] public int DressupItemid112 { get; set; }
    [FlatBufferItem(113)] public int DressupItemid113 { get; set; }
    [FlatBufferItem(114)] public int DressupItemid114 { get; set; }
    [FlatBufferItem(115)] public int DressupItemid115 { get; set; }
    [FlatBufferItem(116)] public int DressupItemid116 { get; set; }
    [FlatBufferItem(117)] public int DressupItemid117 { get; set; }
    [FlatBufferItem(118)] public int DressupItemid118 { get; set; }
    [FlatBufferItem(119)] public int DressupItemid119 { get; set; }
    [FlatBufferItem(120)] public int DressupItemid120 { get; set; }
    [FlatBufferItem(121)] public int DressupItemid121 { get; set; }
    [FlatBufferItem(122)] public int DressupItemid122 { get; set; }
    [FlatBufferItem(123)] public int DressupItemid123 { get; set; }
    [FlatBufferItem(124)] public int DressupItemid124 { get; set; }
    [FlatBufferItem(125)] public int DressupItemid125 { get; set; }
    [FlatBufferItem(126)] public int DressupItemid126 { get; set; }
    [FlatBufferItem(127)] public int DressupItemid127 { get; set; }
    [FlatBufferItem(128)] public int DressupItemid128 { get; set; }
    [FlatBufferItem(129)] public int DressupItemid129 { get; set; }
    [FlatBufferItem(130)] public int DressupItemid130 { get; set; }
    [FlatBufferItem(131)] public int DressupItemid131 { get; set; }
    [FlatBufferItem(132)] public int DressupItemid132 { get; set; }
    [FlatBufferItem(133)] public int DressupItemid133 { get; set; }
    [FlatBufferItem(134)] public int DressupItemid134 { get; set; }
    [FlatBufferItem(135)] public int DressupItemid135 { get; set; }
    [FlatBufferItem(136)] public int DressupItemid136 { get; set; }
    [FlatBufferItem(137)] public int DressupItemid137 { get; set; }
    [FlatBufferItem(138)] public int DressupItemid138 { get; set; }
    [FlatBufferItem(139)] public int DressupItemid139 { get; set; }
    [FlatBufferItem(140)] public int DressupItemid140 { get; set; }
    [FlatBufferItem(141)] public int DressupItemid141 { get; set; }
    [FlatBufferItem(142)] public int DressupItemid142 { get; set; }
    [FlatBufferItem(143)] public int DressupItemid143 { get; set; }
    [FlatBufferItem(144)] public int DressupItemid144 { get; set; }
    [FlatBufferItem(145)] public int DressupItemid145 { get; set; }
    [FlatBufferItem(146)] public int DressupItemid146 { get; set; }
    [FlatBufferItem(147)] public int DressupItemid147 { get; set; }
    [FlatBufferItem(148)] public int DressupItemid148 { get; set; }
    [FlatBufferItem(149)] public int DressupItemid149 { get; set; }
    [FlatBufferItem(150)] public int DressupItemid150 { get; set; }
    [FlatBufferItem(151)] public int DressupItemid151 { get; set; }
    [FlatBufferItem(152)] public int DressupItemid152 { get; set; }
    [FlatBufferItem(153)] public int DressupItemid153 { get; set; }
    [FlatBufferItem(154)] public int DressupItemid154 { get; set; }
    [FlatBufferItem(155)] public int DressupItemid155 { get; set; }
    [FlatBufferItem(156)] public int DressupItemid156 { get; set; }
    [FlatBufferItem(157)] public int DressupItemid157 { get; set; }
    [FlatBufferItem(158)] public int DressupItemid158 { get; set; }
    [FlatBufferItem(159)] public int DressupItemid159 { get; set; }
    [FlatBufferItem(160)] public int DressupItemid160 { get; set; }
    [FlatBufferItem(161)] public int DressupItemid161 { get; set; }
    [FlatBufferItem(162)] public int DressupItemid162 { get; set; }
    [FlatBufferItem(163)] public int DressupItemid163 { get; set; }
    [FlatBufferItem(164)] public int DressupItemid164 { get; set; }
    [FlatBufferItem(165)] public int DressupItemid165 { get; set; }
    [FlatBufferItem(166)] public int DressupItemid166 { get; set; }
    [FlatBufferItem(167)] public int DressupItemid167 { get; set; }
    [FlatBufferItem(168)] public int DressupItemid168 { get; set; }
    [FlatBufferItem(169)] public int DressupItemid169 { get; set; }
    [FlatBufferItem(170)] public int DressupItemid170 { get; set; }
    [FlatBufferItem(171)] public int DressupItemid171 { get; set; }
    [FlatBufferItem(172)] public int DressupItemid172 { get; set; }
    [FlatBufferItem(173)] public int DressupItemid173 { get; set; }
    [FlatBufferItem(174)] public int DressupItemid174 { get; set; }
    [FlatBufferItem(175)] public int DressupItemid175 { get; set; }
}
