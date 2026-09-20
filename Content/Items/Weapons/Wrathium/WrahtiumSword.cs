using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Weapons.Wrathium
{
    public class WrathiumSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 56;
            Item.DamageType = DamageClass.Melee;

            Item.width = 42;
            Item.height = 42;

            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 6f;
            Item.value = Item.buyPrice(gold: 26);
            Item.rare = ItemRarityID.Cyan;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
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