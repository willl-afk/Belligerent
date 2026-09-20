using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.NPCs.Bosses.DuneStalker
{
    public class DuneSandProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Hitbox
            Projectile.width = 18;
            Projectile.height = 18;

            // Hurts players
            Projectile.hostile = true;

            // Does not hurt enemies
            Projectile.friendly = false;

            // Collides with terrain
            Projectile.tileCollide = true;

            Projectile.ignoreWater = true;

            // Destroy after hitting something
            Projectile.penetrate = 1;

            // 5 second maximum lifetime
            Projectile.timeLeft = 300;
        }

        public override void AI()
        {
            // =====================================================
            // SPIN
            // =====================================================

            Projectile.rotation +=
                Projectile.velocity.X *
                0.04f;

            // =====================================================
            // SLIGHT GRAVITY
            // =====================================================

            Projectile.velocity.Y +=
                0.08f;

            if (Projectile.velocity.Y > 12f)
            {
                Projectile.velocity.Y = 12f;
            }

            // =====================================================
            // SAND TRAIL
            // =====================================================

            if (Main.rand.NextBool(2))
            {
                Dust dust =
                    Dust.NewDustDirect(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        DustID.Sand
                    );

                dust.velocity *= 0.25f;

                dust.noGravity = true;

                dust.scale = 0.9f;
            }
        }

        // =========================================================
        // HIT TERRAIN
        // =========================================================

        public override bool OnTileCollide(
            Vector2 oldVelocity)
        {
            // Returning true destroys
            // the projectile.
            return true;
        }

        // =========================================================
        // PROJECTILE DESTROYED
        // =========================================================

        public override void OnKill(
            int timeLeft)
        {
            CreateSandBurst();
        }

        // =========================================================
        // SAND BURST
        // =========================================================

        private void CreateSandBurst()
        {
            for (int i = 0;
                 i < 12;
                 i++)
            {
                Vector2 velocity =
                    new Vector2(
                        Main.rand.NextFloat(
                            -2.5f,
                            2.5f
                        ),
                        Main.rand.NextFloat(
                            -2.5f,
                            2.5f
                        )
                    );

                Dust.NewDustPerfect(
                    Projectile.Center,
                    DustID.Sand,
                    velocity
                );
            }
        }
    }
}