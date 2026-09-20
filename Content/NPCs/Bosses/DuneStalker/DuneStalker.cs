using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Belligerent.Content.NPCs.Bosses.DuneStalker
{
    public class DuneStalker : ModNPC
    {
        // =========================================================
        // ATTACK STATES
        // =========================================================

        private const int StateNormal = 0;
        private const int StateStompRise = 1;
        private const int StateStompHover = 2;
        private const int StateStompSlam = 3;
        private const int StatePhaseTwoPause = 4;

        private int attackState = StateNormal;


        // =========================================================
        // TIMERS
        // =========================================================

        // Phase 1 = 5 seconds
        private const int PhaseOneStompCooldown = 300;

        // Short delay between Phase 2 stomps
        private const int PhaseTwoStompDelay = 30;

        // 15 ticks = 0.25 seconds
        private const int StompHoverTime = 15;

        // Normal jump about every 2 seconds
        private const int NormalJumpCooldownTime = 120;

        private int stompCooldown = 0;
        private int normalJumpCooldown = 0;
        private int hoverTimer = 0;


        // =========================================================
        // PHASE TWO TRANSITION
        // =========================================================

        // 5 seconds
        private const int PhaseTwoTransitionTime = 300;

        private int phaseTwoTransitionTimer = 0;
        private bool phaseTwoTransitionStarted = false;
        private bool phaseTwoTransitionFinished = false;


        // =========================================================
        // PHASE TWO ATTACK PATTERN
        // =========================================================

        // Phase 2:
        // STOMP -> STOMP -> STOMP -> SAND ATTACK -> repeat

        private int phaseTwoStompCount = 0;

        // Temporary placeholder until we create the sand attack.
        // 2 seconds on the ground.
        private const int PhaseTwoGroundPauseTime = 120;

        private int phaseTwoGroundPauseTimer = 0;


        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 1;
        }


        public override void SetDefaults()
        {
            NPC.width = 80;
            NPC.height = 80;

            NPC.damage = 80;
            NPC.defense = 8;
            NPC.lifeMax = 1800;

            NPC.knockBackResist = 0f;

            NPC.value = Item.buyPrice(gold: 1);

            NPC.aiStyle = -1;

            NPC.noGravity = false;
            NPC.noTileCollide = false;

            NPC.boss = true;
            NPC.npcSlots = 10f;

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.netAlways = true;

            Music = MusicID.Boss1;
        }


        public override void AI()
        {
            // =====================================================
            // FIND PLAYER
            // =====================================================

            if (NPC.target < 0 ||
                NPC.target >= Main.maxPlayers ||
                !Main.player[NPC.target].active ||
                Main.player[NPC.target].dead)
            {
                NPC.TargetClosest(false);
            }


            // =====================================================
            // DESPAWN IF PLAYER IS DEAD
            // =====================================================

            if (NPC.target < 0 ||
                NPC.target >= Main.maxPlayers ||
                !Main.player[NPC.target].active ||
                Main.player[NPC.target].dead)
            {
                NPC.active = false;
                NPC.netUpdate = true;
                return;
            }

            Player player = Main.player[NPC.target];


            // Keep boss alive during fight
            if (NPC.timeLeft < 1800)
            {
                NPC.timeLeft = 1800;
            }


            // =====================================================
            // START PHASE TWO TRANSITION
            // =====================================================

            if (!phaseTwoTransitionStarted &&
                NPC.life <= NPC.lifeMax / 2)
            {
                phaseTwoTransitionStarted = true;
                phaseTwoTransitionTimer = 0;

                // Cancel whatever attack was happening
                attackState = StateNormal;

                hoverTimer = 0;
                stompCooldown = 0;

                // Completely stop
                NPC.velocity = Vector2.Zero;

                // Freeze
                NPC.noGravity = true;
                NPC.noTileCollide = false;

                // Invincible
                NPC.dontTakeDamage = true;

                // First dialogue line
                if (Main.netMode != NetmodeID.Server)
                {
                    Main.NewText(
                        "Dune Stalker: \"You have tested my patience for long enough..\"",
                        255,
                        180,
                        60
                    );
                }

                NPC.netUpdate = true;
            }


            // =====================================================
            // HANDLE PHASE TWO TRANSITION
            // =====================================================

            if (phaseTwoTransitionStarted &&
                !phaseTwoTransitionFinished)
            {
                phaseTwoTransitionTimer++;

                // Keep completely frozen
                NPC.velocity = Vector2.Zero;
                NPC.noGravity = true;
                NPC.dontTakeDamage = true;


                // Sand particles while enraging
                if (Main.rand.NextBool(3))
                {
                    Vector2 dustPosition =
                        NPC.Center +
                        new Vector2(
                            Main.rand.NextFloat(
                                -NPC.width / 2f,
                                NPC.width / 2f
                            ),
                            Main.rand.NextFloat(
                                -NPC.height / 2f,
                                NPC.height / 2f
                            )
                        );

                    Dust dust = Dust.NewDustPerfect(
                        dustPosition,
                        DustID.Sand,
                        new Vector2(
                            Main.rand.NextFloat(-2f, 2f),
                            Main.rand.NextFloat(-4f, -1f)
                        )
                    );

                    dust.noGravity = true;
                }


                // Second dialogue line after 2 seconds
                if (phaseTwoTransitionTimer == 120)
                {
                    if (Main.netMode != NetmodeID.Server)
                    {
                        Main.NewText(
                            "Dune Stalker: \"Now.. DIE!\"",
                            255,
                            180,
                            60
                        );
                    }
                }


                // After 5 seconds, Phase 2 begins
                if (phaseTwoTransitionTimer >=
                    PhaseTwoTransitionTime)
                {
                    phaseTwoTransitionFinished = true;

                    NPC.dontTakeDamage = false;
                    NPC.noGravity = false;

                    attackState = StateNormal;

                    phaseTwoStompCount = 0;
                    phaseTwoGroundPauseTimer = 0;

                    // Make first Phase 2 stomp happen almost immediately
                    stompCooldown = PhaseTwoStompDelay;

                    hoverTimer = 0;

                    NPC.netUpdate = true;
                }

                // Do not run normal AI during transformation
                return;
            }


            // =====================================================
            // PHASE TWO SPECIAL PATTERN
            // =====================================================

            if (IsPhaseTwo())
            {
                DoPhaseTwo(player);
                return;
            }


            // =====================================================
            // PHASE ONE ATTACK STATES
            // =====================================================

            switch (attackState)
            {
                case StateStompRise:
                    DoStompRise(player);
                    return;

                case StateStompHover:
                    DoStompHover();
                    return;

                case StateStompSlam:
                    DoStompSlam(player);
                    return;

                default:
                    DoNormalMovement(player);
                    return;
            }
        }


        // =========================================================
        // PHASE TWO CHECK
        // =========================================================

        private bool IsPhaseTwo()
        {
            return phaseTwoTransitionFinished;
        }


        // =========================================================
        // PHASE TWO
        // =========================================================

        private void DoPhaseTwo(Player player)
        {
            switch (attackState)
            {
                case StateStompRise:
                    DoStompRise(player);
                    return;

                case StateStompHover:
                    DoStompHover();
                    return;

                case StateStompSlam:
                    DoStompSlam(player);
                    return;

                case StatePhaseTwoPause:
                    DoPhaseTwoGroundPause(player);
                    return;
            }


            // =====================================================
            // PHASE TWO NORMAL STATE
            //
            // NO normal running.
            // NO normal jumping.
            // ONLY stomps.
            // =====================================================

            NPC.noGravity = false;
            NPC.noTileCollide = false;

            bool onGround =
                NPC.collideY ||
                NPC.velocity.Y == 0f;


            // Face player while waiting
            if (player.Center.X > NPC.Center.X)
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }


            // Stay where he landed
            NPC.velocity.X = 0f;


            // Count up to the next stomp
            stompCooldown++;


            if (onGround &&
                stompCooldown >= PhaseTwoStompDelay)
            {
                stompCooldown = 0;

                StartStomp(player);
                return;
            }
        }


        // =========================================================
        // PHASE TWO GROUND PAUSE
        //
        // This is where the future sand attack will go.
        // =========================================================

        private void DoPhaseTwoGroundPause(Player player)
        {
            NPC.noGravity = false;
            NPC.noTileCollide = false;

            NPC.velocity.X = 0f;

            phaseTwoGroundPauseTimer++;


            // Face player
            if (player.Center.X > NPC.Center.X)
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }


            // =====================================================
            // FUTURE SAND ATTACK GOES HERE
            // =====================================================

            // For now he simply remains grounded for 2 seconds.


            if (phaseTwoGroundPauseTimer >=
                PhaseTwoGroundPauseTime)
            {
                phaseTwoGroundPauseTimer = 0;
                phaseTwoStompCount = 0;

                attackState = StateNormal;

                // Small delay before beginning the next triple stomp
                stompCooldown = 0;

                NPC.netUpdate = true;
            }
        }


        // =========================================================
        // PHASE ONE NORMAL MOVEMENT
        // =========================================================

        private void DoNormalMovement(Player player)
        {
            NPC.noGravity = false;
            NPC.noTileCollide = false;

            bool onGround =
                NPC.collideY ||
                NPC.velocity.Y == 0f;

            float directionToPlayer =
                player.Center.X > NPC.Center.X
                    ? 1f
                    : -1f;

            NPC.direction = (int)directionToPlayer;
            NPC.spriteDirection = NPC.direction;


            // =====================================================
            // TIMERS
            // =====================================================

            stompCooldown++;

            if (normalJumpCooldown > 0)
            {
                normalJumpCooldown--;
            }


            // =====================================================
            // START GIANT STOMP
            // =====================================================

            if (stompCooldown >=
                PhaseOneStompCooldown &&
                onGround)
            {
                StartStomp(player);
                return;
            }


            // =====================================================
            // AGGRESSIVE CHASE
            // =====================================================

            const float moveSpeed = 3.5f;
            const float acceleration = 0.15f;

            float targetVelocityX =
                directionToPlayer *
                moveSpeed;

            if (NPC.velocity.X < targetVelocityX)
            {
                NPC.velocity.X += acceleration;

                if (NPC.velocity.X > targetVelocityX)
                {
                    NPC.velocity.X = targetVelocityX;
                }
            }
            else if (NPC.velocity.X > targetVelocityX)
            {
                NPC.velocity.X -= acceleration;

                if (NPC.velocity.X < targetVelocityX)
                {
                    NPC.velocity.X = targetVelocityX;
                }
            }


            // =====================================================
            // NORMAL LARGE JUMP
            // =====================================================

            if (onGround &&
                normalJumpCooldown <= 0)
            {
                StartNormalJump(directionToPlayer);

                normalJumpCooldown =
                    NormalJumpCooldownTime;

                return;
            }


            // =====================================================
            // SMALL OBSTACLE HOP
            // =====================================================

            if (onGround)
            {
                TryObstacleHop(directionToPlayer);
            }
        }


        // =========================================================
        // NORMAL JUMP
        // =========================================================

        private void StartNormalJump(
            float directionToPlayer)
        {
            NPC.velocity.Y = -11.5f;

            NPC.velocity.X =
                directionToPlayer * 5f;

            NPC.netUpdate = true;
        }


        // =========================================================
        // BEGIN GIANT STOMP
        // =========================================================

        private void StartStomp(Player player)
        {
            attackState = StateStompRise;

            hoverTimer = 0;

            // High launch
            NPC.velocity.Y = -16f;

            float directionToPlayer =
                player.Center.X > NPC.Center.X
                    ? 1f
                    : -1f;

            // Immediately launch toward player
            NPC.velocity.X =
                directionToPlayer * 14f;

            NPC.netUpdate = true;
        }


        // =========================================================
        // STOMP - RISE AND TRACK PLAYER
        // =========================================================

        private void DoStompRise(Player player)
        {
            NPC.noGravity = false;

            float differenceX =
                player.Center.X -
                NPC.Center.X;


            // Very aggressive air tracking
            const float maxHorizontalSpeed = 20f;
            const float horizontalAcceleration = 3f;

            float desiredVelocityX;

            if (differenceX > 0f)
            {
                desiredVelocityX =
                    maxHorizontalSpeed;
            }
            else
            {
                desiredVelocityX =
                    -maxHorizontalSpeed;
            }


            // Slow down when nearly directly above player
            if (System.Math.Abs(differenceX) < 100f)
            {
                desiredVelocityX =
                    differenceX * 0.18f;
            }


            if (NPC.velocity.X < desiredVelocityX)
            {
                NPC.velocity.X +=
                    horizontalAcceleration;

                if (NPC.velocity.X > desiredVelocityX)
                {
                    NPC.velocity.X =
                        desiredVelocityX;
                }
            }
            else if (NPC.velocity.X > desiredVelocityX)
            {
                NPC.velocity.X -=
                    horizontalAcceleration;

                if (NPC.velocity.X < desiredVelocityX)
                {
                    NPC.velocity.X =
                        desiredVelocityX;
                }
            }


            // Face player
            if (differenceX > 0f)
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }


            // =====================================================
            // REACHED PEAK
            // =====================================================

            if (NPC.velocity.Y >= -0.5f)
            {
                attackState =
                    StateStompHover;

                NPC.velocity =
                    Vector2.Zero;

                NPC.noGravity = true;

                hoverTimer = 0;

                NPC.netUpdate = true;
            }
        }


        // =========================================================
        // STOMP - SHORT HOVER
        // =========================================================

        private void DoStompHover()
        {
            NPC.noGravity = true;

            NPC.velocity =
                Vector2.Zero;

            hoverTimer++;


            // Warning sand particles
            if (hoverTimer % 3 == 0)
            {
                Vector2 dustPosition =
                    NPC.Bottom +
                    new Vector2(
                        Main.rand.NextFloat(
                            -NPC.width / 2f,
                            NPC.width / 2f
                        ),
                        0f
                    );

                Dust.NewDustPerfect(
                    dustPosition,
                    DustID.Sand,
                    new Vector2(
                        Main.rand.NextFloat(-1f, 1f),
                        Main.rand.NextFloat(3f, 6f)
                    )
                );
            }


            // =====================================================
            // BEGIN SLAM
            // =====================================================

            if (hoverTimer >= StompHoverTime)
            {
                attackState =
                    StateStompSlam;

                NPC.noGravity = false;

                // Straight down
                NPC.velocity.X = 0f;

                // Almost instant slam
                NPC.velocity.Y = 24f;

                NPC.netUpdate = true;
            }
        }


        // =========================================================
        // STOMP - SLAM
        // =========================================================

        private void DoStompSlam(Player player)
        {
            NPC.noGravity = false;
            NPC.noTileCollide = false;

            bool landed =
                NPC.collideY ||
                NPC.velocity.Y == 0f;


            if (landed)
            {
                DoStompImpact(player);


                // Existing Phase 2 sand balls still fire
                // from every stomp.
                if (IsPhaseTwo())
                {
                    ShootSandProjectiles();
                }


                EndStomp(player);
                return;
            }


            NPC.velocity.X = 0f;

            NPC.velocity.Y =
                MathHelper.Min(
                    NPC.velocity.Y + 3f,
                    36f
                );
        }


        // =========================================================
        // PHASE TWO SAND PROJECTILES
        // =========================================================

        private void ShootSandProjectiles()
        {
            // Only spawn once in multiplayer
            if (Main.netMode ==
                NetmodeID.MultiplayerClient)
            {
                return;
            }


            Vector2 spawnPosition =
                NPC.Bottom +
                new Vector2(
                    0f,
                    -16f
                );


            // Four sand balls:
            //
            //     ↖  ←   →  ↗
            //

            Vector2[] velocities =
            {
                new Vector2(-9f, -5f),
                new Vector2(-11f, -2f),
                new Vector2(11f, -2f),
                new Vector2(9f, -5f)
            };


            foreach (Vector2 velocity in velocities)
            {
                Projectile.NewProjectile(
                    NPC.GetSource_FromAI(),
                    spawnPosition,
                    velocity,

                    ModContent.ProjectileType
                        <DuneSandProjectile>(),

                    // Damage
                    25,

                    // Knockback
                    2f,

                    Main.myPlayer
                );
            }
        }


        // =========================================================
        // FINISH STOMP
        // =========================================================

        private void EndStomp(Player player)
        {
            hoverTimer = 0;

            NPC.noGravity = false;
            NPC.noTileCollide = false;


            // =====================================================
            // PHASE TWO
            // =====================================================

            if (IsPhaseTwo())
            {
                phaseTwoStompCount++;

                NPC.velocity =
                    Vector2.Zero;


                // After stomp #3, stay grounded.
                if (phaseTwoStompCount >= 3)
                {
                    attackState =
                        StatePhaseTwoPause;

                    phaseTwoGroundPauseTimer = 0;

                    NPC.netUpdate = true;
                    return;
                }


                // Otherwise prepare the next stomp.
                attackState =
                    StateNormal;

                stompCooldown = 0;

                NPC.netUpdate = true;
                return;
            }


            // =====================================================
            // PHASE ONE
            // =====================================================

            attackState = StateNormal;

            stompCooldown = 0;

            // Prevent immediate normal jump
            normalJumpCooldown = 45;


            // Immediately resume chasing
            float directionToPlayer =
                player.Center.X > NPC.Center.X
                    ? 1f
                    : -1f;

            NPC.direction =
                (int)directionToPlayer;

            NPC.spriteDirection =
                NPC.direction;

            NPC.velocity.X =
                directionToPlayer * 3.5f;

            NPC.velocity.Y = 0f;

            NPC.netUpdate = true;
        }


        // =========================================================
        // SMALL OBSTACLE HOP
        // =========================================================

        private void TryObstacleHop(
            float directionToPlayer)
        {
            int frontX;

            if (NPC.direction == 1)
            {
                frontX =
                    (int)(
                        (
                            NPC.position.X +
                            NPC.width +
                            8f
                        ) / 16f
                    );
            }
            else
            {
                frontX =
                    (int)(
                        (
                            NPC.position.X -
                            8f
                        ) / 16f
                    );
            }


            int feetY =
                (int)(
                    (
                        NPC.position.Y +
                        NPC.height -
                        8f
                    ) / 16f
                );


            Tile obstacleTile =
                Framing.GetTileSafely(
                    frontX,
                    feetY
                );


            Tile tileAbove =
                Framing.GetTileSafely(
                    frontX,
                    feetY - 1
                );


            bool obstacleInFront =
                obstacleTile.HasTile &&
                Main.tileSolid[
                    obstacleTile.TileType
                ] &&
                !Main.tileSolidTop[
                    obstacleTile.TileType
                ];


            bool spaceAboveObstacle =
                !tileAbove.HasTile ||
                !Main.tileSolid[
                    tileAbove.TileType
                ] ||
                Main.tileSolidTop[
                    tileAbove.TileType
                ];


            if (obstacleInFront &&
                spaceAboveObstacle)
            {
                NPC.velocity.Y = -5f;

                NPC.velocity.X =
                    directionToPlayer * 3.5f;

                NPC.netUpdate = true;
            }
        }


        // =========================================================
        // STOMP IMPACT
        // =========================================================

        private void DoStompImpact(Player player)
        {
            // 4 tiles = 64 pixels
            const int stompWidth = 64;

            const int stompHeight = 32;


            Rectangle stompHitbox =
                new Rectangle(
                    (int)NPC.Bottom.X -
                    stompWidth / 2,

                    (int)NPC.Bottom.Y -
                    stompHeight / 2,

                    stompWidth,
                    stompHeight
                );


            // =====================================================
            // STOMP DAMAGE
            // =====================================================

            if (player.active &&
                !player.dead &&
                player.Hitbox.Intersects(
                    stompHitbox
                ))
            {
                int hitDirection =
                    player.Center.X <
                    NPC.Center.X
                        ? -1
                        : 1;


                player.Hurt(
                    PlayerDeathReason
                        .ByCustomReason(
                            player.name +
                            " was crushed by the Dune Stalker."
                        ),

                    40,

                    hitDirection
                );
            }


            // =====================================================
            // BIG SAND IMPACT
            // =====================================================

            for (int i = 0; i < 50; i++)
            {
                Vector2 dustPosition =
                    NPC.Bottom +
                    new Vector2(
                        Main.rand.NextFloat(
                            -32f,
                            32f
                        ),

                        Main.rand.NextFloat(
                            -8f,
                            4f
                        )
                    );


                Dust.NewDustPerfect(
                    dustPosition,
                    DustID.Sand,
                    new Vector2(
                        Main.rand.NextFloat(
                            -6f,
                            6f
                        ),

                        Main.rand.NextFloat(
                            -7f,
                            -1f
                        )
                    )
                );
            }
        }
    }
}