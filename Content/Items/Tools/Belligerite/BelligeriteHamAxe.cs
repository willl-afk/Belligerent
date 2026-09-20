using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Belligerite
{
    public class BelligeriteHamAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 85;
            Item.DamageType = DamageClass.Melee;

            Item.width = 40;
            Item.height = 40;

            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 8f;
            Item.value = Item.buyPrice(gold: 60);
            Item.rare = ItemRarityID.Red;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.axe = 35;
            Item.hammer = 100;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<BelligeriteBar>(),
                15
            );

            recipe.AddTile(TileID.AdamantiteForge);

            recipe.Register();
        }
    }
}