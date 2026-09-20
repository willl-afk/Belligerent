using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Arcanite
{
    public class ArcaniteHammer : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 29;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 6f;
            Item.value = Item.buyPrice(gold: 16);
            Item.rare = ItemRarityID.LightRed;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.hammer = 75;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<ArcaniteBar>(),
                10
            );

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }
    }
}