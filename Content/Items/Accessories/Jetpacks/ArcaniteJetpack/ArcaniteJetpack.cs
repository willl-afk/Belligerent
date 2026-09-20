using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Belligerent.Content.Items.Materials;

namespace Belligerent.Content.Items.Accessories.Jetpacks.ArcaniteJetpack
{
    [AutoloadEquip(EquipType.Wings)]
    public class ArcaniteJetpack : ModItem
    {
        public override void SetStaticDefaults()
        {
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] =
                new WingStats(
                    180,
                    8.5f,
                    2.5f
                );
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.accessory = true;

            Item.value = Item.buyPrice(gold: 20);
            Item.rare = ItemRarityID.LightRed;
        }

        public override void VerticalWingSpeeds(
            Player player,
            ref float ascentWhenFalling,
            ref float ascentWhenRising,
            ref float maxCanAscendMultiplier,
            ref float maxAscentMultiplier,
            ref float constantAscend
        )
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.Jetpack);

            recipe.AddIngredient(
                ModContent.ItemType<ArcaniteBar>(),
                20
            );

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }
    }
}