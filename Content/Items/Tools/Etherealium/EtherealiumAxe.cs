using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Etherealium
{
    public class EtherealiumAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 58;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 6f;
            Item.value = Item.buyPrice(gold: 28);
            Item.rare = ItemRarityID.Cyan;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.axe = 30;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<EtherealiumBar>(),
                10
            );

            recipe.AddTile(TileID.AdamantiteForge);

            recipe.Register();
        }
    }
}