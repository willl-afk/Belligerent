using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Tools.GemPickaxes
{
    public class AmethystPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 11;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 3f;
            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.White;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 45;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.Amethyst, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 4);

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}