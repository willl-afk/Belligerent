using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Materials
{
    public class ArcaniteOre : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;

            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 25);
            Item.rare = ItemRarityID.LightRed;

            Item.DefaultToPlaceableTile(ModContent.TileType<Content.Tiles.ArcaniteOreTile>());
        }
    }
}