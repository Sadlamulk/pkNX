﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using pkNX.Containers;
using pkNX.Game;
using pkNX.Structures;
using pkNX.Structures.FlatBuffers;

namespace pkNX.WinForms.Subforms
{
    public partial class MapViewer8a : Form
    {
        private readonly GameManagerPLA ROM;
        private readonly GFPack Resident;
        private readonly AreaSettingsTable8a Settings;

        public readonly AreaInstance8a[] Areas;
        private readonly bool Loading = true;

        public MapViewer8a(GameManagerPLA rom, GFPack resident)
        {
            ROM = rom;
            Resident = resident;
            var bin_settings = resident.GetDataFullPath("bin/field/resident/AreaSettings.bin");
            Settings = FlatBufferConverter.DeserializeFrom<AreaSettingsTable8a>(bin_settings);

            InitializeComponent();

            Areas = ResidentAreaSet.AreaNames.Select(z => AreaInstance8a.Create(Resident, z, Settings)).ToArray();
            var speciesNames = ROM.GetStrings(TextName.SpeciesNames);
            CB_Map.Items.AddRange(Areas.Select(z => z.ParentArea?.AreaName ?? z.AreaName).ToArray());

            var pt = rom.Data.PersonalData;
            var nameList = new List<ComboItem>();
            foreach (var e in pt.Table.OfType<PersonalInfoLA>())
            {
                if (!e.IsPresentInGame)
                    continue;

                var species = e.Species;
                if (nameList.All(z => z.Value != species))
                    nameList.Add(new(speciesNames[species], species));
            }

            nameList.Insert(0, new("(Any)", -1));
            nameList.Sort((x, y) => string.Compare(x.Text, y.Text, StringComparison.InvariantCulture));

            CB_Species.DisplayMember = nameof(ComboItem.Text);
            CB_Species.ValueMember = nameof(ComboItem.Value);
            CB_Species.DataSource = new BindingSource(nameList, null);

            CB_Species.SelectedValue = 399;
            Loading = false;
            CB_Map.SelectedIndex = 0;
        }

        private class ComboItem
        {
            public ComboItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public string Text { get; }
            public int Value { get; }
        }

        private void CB_Map_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMap(CB_Map.SelectedIndex, (int)CB_Species.SelectedValue);
        }

        private void CB_Species_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMap(CB_Map.SelectedIndex, (int)CB_Species.SelectedValue);
        }

        private List<AreaDef> Defs = new();

        private void UpdateMap(int map, int species)
        {
            if (Loading)
                return;

            var mapfile = $"map_pla\\map_lmap_pic_l_{map-1:00}.png";
            if (!System.IO.File.Exists(mapfile))
            {
                pictureBox1.BackgroundImage = null;
                return;
            }

            var area = Areas[map];
            var coordinates = Defs = GetSpawnerInfo(species, area);

            var img = Image.FromFile(mapfile);
            using var gr = Graphics.FromImage(img);
            var r = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
            var g = new SolidBrush(Color.FromArgb(100, 20, 255, 10));
            var b = new SolidBrush(Color.FromArgb(100, 10, 0, 255));
            var c = new SolidBrush(Color.FromArgb(100, 0, 255, 255));

            var rs = new Pen(Color.FromArgb(255, 255, 0, 0)) { Width = 3 };
            var gs = new Pen(Color.FromArgb(255, 20, 255, 10)) { Width = 3 };
            var bs = new Pen(Color.FromArgb(255, 10, 0, 255)) { Width = 3 };
            var cs = new Pen(Color.FromArgb(255, 10, 255, 255)) { Width = 3 };
            foreach (var o in coordinates)
            {
                var pen = o.Type switch
                {
                    SpawnerType.Spawner => r,
                    SpawnerType.Wormhole => g,
                    SpawnerType.Landmark => b,
                    SpawnerType.Unown => c,
                    _ => throw new ArgumentOutOfRangeException(nameof(o.Type)),
                };
                var penS = o.Type switch
                {
                    SpawnerType.Spawner => rs,
                    SpawnerType.Wormhole => gs,
                    SpawnerType.Landmark => bs,
                    SpawnerType.Unown => cs,
                    _ => throw new ArgumentOutOfRangeException(nameof(o.Type)),
                };
                var p = o.Position;
                var s = o.Scale;
                var x = (p.X * 2) - (s / 2);
                var y = (p.Z * 2) - (s / 2);
                gr.FillEllipse(pen, x, y, s, s);
                gr.DrawEllipse(penS, x, y, s, s);
            }

            pictureBox1.BackgroundImage = img;
        }

        private static List<AreaDef> GetSpawnerInfo(int species, AreaInstance8a area)
        {
            var result = new List<AreaDef>();

            foreach (var s in area.Spawners.Concat(area.SubAreas.SelectMany(z => z.Spawners)))
            {
                var table = s.Field_20_Value.EncounterTableID;
                var slots = Array.Find(area.Encounters, z => z.TableID == table);
                if (slots == null)
                    continue;

                if (species != -1 && slots.Table.All(z => z.Species != species))
                    continue;

                result.Add(new(s.MinSpawnCount, s.MaxSpawnCount, s.Parameters.Coordinates, SpawnerType.Spawner, slots.Table, s.Scalar * 4));
            }

            foreach (var s in area.Wormholes.Concat(area.SubAreas.SelectMany(z => z.Wormholes)))
            {
                var table = s.Field_20_Value.EncounterTableID;
                var slots = Array.Find(area.Encounters, z => z.TableID == table);
                if (slots == null)
                    continue;

                if (species != -1 && slots.Table.All(z => z.Species != species))
                    continue;

                result.Add(new(s.MinSpawnCount, s.MaxSpawnCount, s.Parameters.Coordinates, SpawnerType.Wormhole, slots.Table, Math.Max(s.Scalar * 4, 50)));
            }

            foreach (var a in area.LandMarks.Concat(area.SubAreas.SelectMany(z => z.LandMarks)))
            {
                var table = a.LandmarkItemSpawnTableID;
                foreach (var l in area.LandItems.Concat(area.SubAreas.SelectMany(z => z.LandItems)))
                {
                    if (l.LandmarkItemSpawnTableID != table)
                        continue;
                    var st = l.EncounterTableID;
                    var slots = Array.Find(area.Encounters, z => z.TableID == st);
                    if (slots == null)
                        continue;

                    if (species != -1 && slots.Table.All(z => z.Species != species))
                        continue;

                    result.Add(new(1, 1, a.Parameters.Coordinates, SpawnerType.Landmark, slots.Table, Math.Max(a.Scalar, 1) * 4));
                }
            }

            if (species is not 201)
                return result;

            foreach (var u in area.Unown.Concat(area.SubAreas.SelectMany(z => z.Unown)))
            {
                var slots = Unown;
                result.Add(new(1, 1, u.Parameters.Coordinates, SpawnerType.Unown, slots, u.Number * 2));
            }

            return result;
        }

        private static readonly EncounterSlot8a[] Unown = { new() { Species = 201 } };

        private void MapViewer8a_MouseMove(object sender, MouseEventArgs e)
        {
            LatestCoordinates = (e.X * 2, e.Y * 2);
            L_CoordinateMouse.Text = $"{LatestCoordinates.X}, {LatestCoordinates.Y}";

            var dist = NUD_Tolerance.Value;
            var (x, z) = (LatestCoordinates.X, LatestCoordinates.Y);
            var spawners = Defs
                .Select(s => (Spawner: s, Distance: s.Position.DistanceTo(x, s.Position.Y, z)))
                .Where(s=> s.Distance <= (float)dist)
                .OrderByDescending(s => s.Distance).ToArray();
            if (spawners.Length == 0)
            {
                L_SpawnDump.Text = "";
                return;
            }

            L_SpawnDump.Text = string.Join(Environment.NewLine, spawners.Select(s => s.Spawner.GetLine()));
        }

        private (int X, int Y) LatestCoordinates;
    }

    public class AreaDef
    {
        public readonly int Min;
        public readonly int Max;
        public readonly PlacementV3f8a Position;
        public readonly SpawnerType Type;
        public readonly EncounterSlot8a[] Slots;
        public readonly float Scale;

        public AreaDef(int min, int max, PlacementV3f8a position, SpawnerType type, EncounterSlot8a[] slots, float scale)
        {
            Min = min;
            Max = max;
            Position = position;
            Type = type;
            Slots = slots;
            Scale = scale;
        }

        public string GetLine()
        {
            var species = string.Join(",", Slots.Select(x => (Species)x.Species));
            return $"{Position.ToTriple()} {Min}-{Max}: {species}";
        }
    }
}
