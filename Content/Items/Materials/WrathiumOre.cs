using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Materials
{
    public class WrathiumOre : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;

            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Cyan;

            Item.DefaultToPlaceableTile(
                ModContent.TileType<Content.Tiles.WrathiumOreTile>()
            );
        }
    }
}