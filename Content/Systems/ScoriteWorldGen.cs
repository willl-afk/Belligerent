using System.Collections.Generic;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;

namespace Belligerent.Common.Systems
{
    public class ScoriteWorldGen : ModSystem
    {
        public override void ModifyWorldGenTasks(
            List<GenPass> tasks,
            ref double totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(
                genpass => genpass.Name.Equals("Shinies")
            );

            if (shiniesIndex != -1)
            {
                tasks.Insert(
                    shiniesIndex + 1,
                    new PassLegacy(
                        "Scorite",
                        GenerateScorite
                    )
                );
            }
        }

        private void GenerateScorite(
            GenerationProgress progress,
            GameConfiguration configuration)
        {
            progress.Message = "Generating Scorite";

            int tileType = ModContent.TileType<
                Content.Tiles.ScoriteOreTile>();

            int veinCount = Main.maxTilesX / 150;

            int minY = (int)(Main.UnderworldLayer * 0.55f);
            int maxY = Main.UnderworldLayer - 100;

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

                WorldGen.TileRunner(
                    x,
                    y,
                    WorldGen.genRand.Next(3, 5),
                    WorldGen.genRand.Next(5, 10),
                    tileType
                );
            }
        }
    }
}