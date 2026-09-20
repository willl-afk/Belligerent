using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Weapons.Arcanite
{
    public class ArcaniteSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 34;
            Item.DamageType = DamageClass.Melee;

            Item.width = 40;
            Item.height = 40;

            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 5.5f;
            Item.value = Item.buyPrice(gold: 14);
            Item.rare = ItemRarityID.LightRed;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
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