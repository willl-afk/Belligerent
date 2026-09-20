using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Arcanite
{
    public class ArcanitePickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 10;
            Item.useAnimation = 13;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 5f;
            Item.value = Item.buyPrice(gold: 15);
            Item.rare = ItemRarityID.LightRed;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 195;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<ArcaniteBar>(),
                12
            );

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }
    }
}