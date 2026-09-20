using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Weapons.Belligerite
{
    public class TheFinalArgument : ModItem
    {
        public override string Texture =>
            "Belligerent/Content/Items/Weapons/Belligerite/TheFinalArgument";

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = DamageClass.Melee;

            Item.width = 46;
            Item.height = 46;

            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 8f;
            Item.value = Item.buyPrice(gold: 70);
            Item.rare = ItemRarityID.Red;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<BelligeriteBar>(),
                15
            );

            recipe.AddTile(TileID.AdamantiteForge);

            recipe.Register();
        }
    }
}