using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Tools.GemPickaxes
{
    public class SapphirePickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 15;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 3f;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.White;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 59;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.Sapphire, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 4);

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}