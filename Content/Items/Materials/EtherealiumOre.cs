using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Materials
{
    public class EtherealiumOre : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;

            Item.maxStack = 9999;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Cyan;

            Item.DefaultToPlaceableTile(
                ModContent.TileType<Content.Tiles.EtherealiumOreTile>()
            );
        }
    }
}