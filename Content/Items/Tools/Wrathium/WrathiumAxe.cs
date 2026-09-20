using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Wrathium
{
    public class WrathiumAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 5.5f;
            Item.value = Item.buyPrice(gold: 22);
            Item.rare = ItemRarityID.Cyan;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.axe = 27;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<WrathiumBar>(),
                10
            );

            recipe.AddTile(TileID.AdamantiteForge);

            recipe.Register();
        }
    }
}