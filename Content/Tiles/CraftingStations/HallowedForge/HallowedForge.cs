using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Tiles.CraftingStations.HallowedForge
{
    public class HallowedForge : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            AddMapEntry(
                new Microsoft.Xna.Framework.Color(220, 240, 255),
                CreateMapEntryName()
            );

            DustType = DustID.GemSapphire;

            AdjTiles = new int[]
            {
                TileID.AdamantiteForge
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