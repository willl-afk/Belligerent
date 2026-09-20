using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Weapons.Etherealium
{
    public class EtherealiumSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 72;
            Item.DamageType = DamageClass.Melee;

            Item.width = 44;
            Item.height = 44;

            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 6.5f;
            Item.value = Item.buyPrice(gold: 35);
            Item.rare = ItemRarityID.Cyan;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
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