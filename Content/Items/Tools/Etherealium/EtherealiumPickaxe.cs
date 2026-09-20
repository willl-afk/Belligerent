using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Tools.Etherealium
{
    public class EtherealiumPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 55;
            Item.DamageType = DamageClass.Melee;

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 6;
            Item.useAnimation = 9;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 6f;
            Item.value = Item.buyPrice(gold: 30);
            Item.rare = ItemRarityID.Cyan;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 215;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(
                ModContent.ItemType<EtherealiumBar>(),
                12
            );

            recipe.AddTile(TileID.AdamantiteForge);

            recipe.Register();
        }
    }
}