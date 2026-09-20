using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.Accessories.Wings
{
    public class FrostWyvernWings : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Orange;

            Item.accessory = true;

            Item.wingSlot = 1;
        }

        public override void UpdateAccessory(
            Player player,
            bool hideVisual
        )
        {
            player.wingTimeMax = 480;
            player.wingRunAccelerationMult = 1f;
        }
    }
}