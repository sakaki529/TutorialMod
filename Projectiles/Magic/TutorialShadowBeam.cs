using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Projectiles.Magic
{
    public class TutorialShadowBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Beam");
        }
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.DamageType = DamageClass.Magic;//魔法
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;//無限貫通
            Projectile.timeLeft = 120;
            Projectile.tileCollide = true;//地形貫通させない
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 100;//これが重要
        }
        public override void AI()
        {
            if (++Projectile.localAI[0] > 1f)
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector2 vector = Projectile.position;
                    vector -= Projectile.velocity * (i * 0.25f);
                    Projectile.alpha = 255;
                    int num2 = Dust.NewDust(vector, 1, 1, DustID.ShadowbeamStaff, 0f, 0f, 0, default(Color), 0.9f);//紫色のモヤモヤが発生する。発生させるものを変更させたい場合はDustID.ShadowbeamStaffの部分を変えてみよう
                                                                                                                   //DustIDの後ろに「.」を打つと使用できるDustの候補を出してくれるよ
                    Main.dust[num2].position = vector;
                    Main.dust[num2].noGravity = true;
                    Dust dust = Main.dust[num2];
                    dust.velocity *= 0.2f;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 120);//シャドウフレイムを二秒付与
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 120);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 120);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //以下のコードはタイルにぶつかった際に反射させるコードです
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;//タイルに衝突しても発射体は消えないように
        }
    }
}
