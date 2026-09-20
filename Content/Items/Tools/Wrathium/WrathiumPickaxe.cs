using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Wrathium
{
    public class WrathiumPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 42;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 5;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 5.5f;
            Item.value = Item.buyPrice(gold: 20);
            Item.rare = ItemRarityID.Cyan;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 230;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<WrathiumBar>(),
                12
            );

            recipe.AddTile(TileID.AdamantiteForge);

            recipe.Register();
        }
    }
}