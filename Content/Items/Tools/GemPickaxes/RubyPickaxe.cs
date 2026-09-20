using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Tools.GemPickaxes
{
    public class RubyPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 10;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 3f;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.White;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 60;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.Ruby, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 4);

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}