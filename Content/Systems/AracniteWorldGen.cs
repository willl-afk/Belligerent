using System.Collections.Generic;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;

namespace Belligerent.Common.Systems
{
    public class ArcaniteWorldGen : ModSystem
    {
        public override void ModifyHardmodeTasks(List<GenPass> tasks)
        {
            int announcementIndex = tasks.FindIndex(
                genpass => genpass.Name.Equals("Hardmode Announcement")
            );

            if (announcementIndex != -1)
            {
                tasks.Insert(
                    announcementIndex,
                    new PassLegacy(
                        "Arcanite",
                        GenerateArcanite
                    )
                );
            }
        }

        private void GenerateArcanite(
            GenerationProgress progress,
            GameConfiguration configuration)
        {
            progress.Message = "Generating Arcanite";

            int tileType = ModContent.TileType<
                Content.Tiles.ArcaniteOreTile>();

            int veinCount = Main.maxTilesX / 120;

            int minY = (int)(Main.maxTilesY * 0.35f);
            int maxY = (int)(Main.maxTilesY * 0.75f);

            for (int i = 0; i < veinCount; i++)
            {
                int x = WorldGen.genRand.Next(
                    100,
                    Main.maxTilesX - 100
                );

                int y = WorldGen.genRand.Next(
                    minY,
                    maxY
                );

                WorldGen.OreRunner(
                    x,
                    y,
                    WorldGen.genRand.Next(4, 7),
                    WorldGen.genRand.Next(6, 12),
                    (ushort)tileType
                );
            }
        }
    }
}