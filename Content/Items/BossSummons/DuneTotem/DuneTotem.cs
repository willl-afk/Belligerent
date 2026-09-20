using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.Items.BossSummons.DuneTotem
{
    public class DuneTotem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;

            Item.maxStack = 20;
            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.rare = ItemRarityID.Blue;
        }

        public override bool CanUseItem(Player player)
        {
            int bossType = Mod.Find<ModNPC>(
                "DuneStalker"
            ).Type;

            return !NPC.AnyNPCs(bossType);
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int bossType = Mod.Find<ModNPC>(
                    "DuneStalker"
                ).Type;

                Vector2 spawnPosition =
                    player.Center +
                    new Vector2(500f, -100f);

                int npcIndex = NPC.NewNPC(
                    player.GetSource_ItemUse(Item),
                    (int)spawnPosition.X,
                    (int)spawnPosition.Y,
                    bossType
                );

                if (npcIndex >= 0 &&
                    npcIndex < Main.maxNPCs)
                {
                    Main.npc[npcIndex].TargetClosest();

                    Main.npc[npcIndex].netUpdate = true;
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(
                    ItemID.SandBlock,
                    5
                )
                .AddTile(
                    TileID.WorkBenches
                )
                .Register();
        }
    }
}