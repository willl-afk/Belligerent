using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Scorite
{
    public class ScoritePickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 15;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 4f;
            Item.value = Item.buyPrice(gold: 8);
            Item.rare = ItemRarityID.Orange;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 105;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<ScoriteBar>(),
                18
            );

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}