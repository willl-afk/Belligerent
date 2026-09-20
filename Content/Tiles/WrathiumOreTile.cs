using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Tiles
{
    public class WrathiumOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            DustType = DustID.Electric;

            AddMapEntry(
                new Microsoft.Xna.Framework.Color(80, 180, 255)
            );

            RegisterItemDrop(
                ModContent.ItemType<Content.Items.Materials.WrathiumOre>()
            );
        }
    }
}