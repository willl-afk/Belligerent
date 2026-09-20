using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Scorite
{
    public class ScoriteAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 5f;
            Item.value = Item.buyPrice(gold: 7);
            Item.rare = ItemRarityID.Orange;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.axe = 20;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<ScoriteBar>(),
                10
            );

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}