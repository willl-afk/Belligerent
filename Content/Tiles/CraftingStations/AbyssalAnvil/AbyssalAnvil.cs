using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Tiles.CraftingStations.AbyssalAnvil
{
    public class AbyssalAnvil : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            AddMapEntry(
                new Microsoft.Xna.Framework.Color(25, 15, 35),
                CreateMapEntryName()
            );

            DustType = DustID.Shadowflame;

            AdjTiles = new int[]
            {
                TileID.MythrilAnvil
            };
        }

        public override void NumDust(
            int i,
            int j,
            bool fail,
            ref int num
        )
        {
            num = fail ? 1 : 3;
        }
    }
}