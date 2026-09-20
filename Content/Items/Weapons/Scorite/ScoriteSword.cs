using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Weapons.Scorite
{
    public class ScoriteSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Melee;

            Item.width = 40;
            Item.height = 40;

            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 5f;
            Item.value = Item.buyPrice(gold: 6);
            Item.rare = ItemRarityID.Orange;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<ScoriteBar>(),
                12
            );

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}