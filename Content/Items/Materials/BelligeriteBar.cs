using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Materials
{
    public class BelligeriteBar : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;

            Item.maxStack = 9999;
            Item.value = Item.buyPrice(gold: 8);
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<BelligeriteOre>(),
                4
            );

            recipe.AddTile(TileID.AdamantiteForge);

            recipe.Register();
        }
    }
}