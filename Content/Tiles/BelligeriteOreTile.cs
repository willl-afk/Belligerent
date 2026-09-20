using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Tiles
{
    public class BelligeriteOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            DustType = DustID.Shadowflame;

            AddMapEntry(
                new Microsoft.Xna.Framework.Color(45, 25, 55)
            );

            RegisterItemDrop(
                ModContent.ItemType<Content.Items.Materials.BelligeriteOre>()
            );
        }
    }
}