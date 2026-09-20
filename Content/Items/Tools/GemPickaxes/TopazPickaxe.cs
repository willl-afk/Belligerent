using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Tools.GemPickaxes
{
    public class TopazPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 14;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 3f;
            Item.value = Item.buyPrice(silver: 75);
            Item.rare = ItemRarityID.White;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 40;
            Item.scale = 1.0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.Topaz, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 4);

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}