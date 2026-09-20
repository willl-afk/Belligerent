using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Tiles
{
    public class ScoriteOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            DustType = DustID.Torch;

            AddMapEntry(new Microsoft.Xna.Framework.Color(90, 60, 100));

            RegisterItemDrop(ModContent.ItemType<Content.Items.Materials.ScoriteOre>());
        }
    }
}