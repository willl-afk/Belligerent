using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Tiles
{
    public class EtherealiumOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            DustType = DustID.Ice;

            AddMapEntry(
                new Microsoft.Xna.Framework.Color(180, 240, 255)
            );

            RegisterItemDrop(
                ModContent.ItemType<Content.Items.Materials.EtherealiumOre>()
            );
        }
    }
}