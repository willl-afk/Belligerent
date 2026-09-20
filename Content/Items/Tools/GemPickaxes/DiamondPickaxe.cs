using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Tools.GemPickaxes
{
    public class DiamondPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 9;
            Item.useAnimation = 11;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 3.5f;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.White;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 63;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.Diamond, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 4);
            recipe.AddIngredient(ItemID.Sapphire, 5);

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}