using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Belligerite
{
    public class BelligeritePickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 4;
            Item.useAnimation = 6;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 7f;
            Item.value = Item.buyPrice(gold: 50);
            Item.rare = ItemRarityID.Red;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 265;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<BelligeriteBar>(),
                12
            );

            recipe.AddTile(TileID.AdamantiteForge);

            recipe.Register();
        }
    }
}