using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Projectiles.Magic
{
    public class TutorialHomingBall : ModProjectile
    {
        //追尾弾のチュートリアル
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Ball");
            ProjectileID.Sets.TrailingMode[Type] = 3;//軌跡を描画する場所の保存に関わる設定: 2と3の違いを実際に変更して確かめてみてもいいかもしれない
            ProjectileID.Sets.TrailCacheLength[Type] = 20;//軌跡の長さ
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 240;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            //発射体本体を描画する前に軌跡を描画する
            default(RainbowRodDrawer).Draw(Projectile);//レインボーロッド
            //default(MagicMissileDrawer).Draw(Projectile);//マジックミサイル
            //default(FlameLashDrawer).Draw(Projectile);//フレイムラッシュ
            return base.PreDraw(ref lightColor);
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            TutorialProjAI.HomingToNPC(Projectile, 420f, 16, 20);//追尾用AIメソッドの実行。引数の説明はTutorialProjAIをご覧ください
        }
    }
}
