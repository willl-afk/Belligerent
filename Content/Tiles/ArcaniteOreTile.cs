using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Tiles
{
    public class ArcaniteOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            DustType = DustID.PinkTorch;

            AddMapEntry(
                new Microsoft.Xna.Framework.Color(150, 80, 180)
            );

            RegisterItemDrop(
                ModContent.ItemType<Content.Items.Materials.ArcaniteOre>()
            );
        }
    }
}