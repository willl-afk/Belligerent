using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Tiles.CraftingStations.VoidForge
{
    public class VoidForge : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            AddMapEntry(
                new Microsoft.Xna.Framework.Color(35, 20, 45),
                CreateMapEntryName()
            );

            DustType = DustID.Shadowflame;

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