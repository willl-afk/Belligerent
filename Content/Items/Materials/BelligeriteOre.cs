using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Materials
{
    public class BelligeriteOre : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;

            Item.maxStack = 9999;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.Red;

            Item.DefaultToPlaceableTile(
                ModContent.TileType<Content.Tiles.BelligeriteOreTile>()
            );
        }
    }
}