using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Tiles.CraftingStations.HallowedAnvil
{
    public class HallowedAnvil : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            AddMapEntry(
                new Microsoft.Xna.Framework.Color(255, 230, 255),
                CreateMapEntryName()
            );

            DustType = DustID.PinkTorch;

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