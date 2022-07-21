using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Projectiles.Ranged
{
    public class TutorialBullet : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Bullet");
        }
        public override void SetDefaults()
		{
            //projectile.CloneDefaults(ProjectileID.Bullet);//今回は使わないが、こいつをつかうと指定の発射体と同じパラメータを設定できる。処理の順番についてはもちろん理解してますよね？
			Projectile.width = 2;
			Projectile.height = 2;
            Projectile.aiStyle = 1;//aiテンプレートの番号。1なら矢。うまく使うと発射体を簡単に作れる。-1にすると一般的な発射体が行う方向の変化等の一部の動作が行われなくなる。その場合でも発射体としての支障はとくにない。
            AIType = ProjectileID.Bullet;//指定の発射体とほぼ同じ動きをするよう設定 
            //*実は弾丸もaistyleは1。ただaiTypeで弾丸と同じ動きをするように設定してやらないと一般的な矢みたく落ちてきちゃう。めんどくさい設定してんなおまえな
            Projectile.timeLeft = 180;//三秒で消える弾丸...
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
            Projectile.extraUpdates = 1;//こいつのおかげで実質的には1.5秒で消える弾丸になっちまった！弾丸は速いし発射される量も多分おおいのでこんくらいが丁度いい音とリズムが超気持ちいい(???
            Projectile.alpha = 255;
        }
		public override void AI()
		{
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 25;
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)//タイルにヒットした場合の処理。
        {
            Collision.HitTiles(Projectile.position, oldVelocity, Projectile.width, Projectile.height);
            return true;//falseにするとタイルに衝突しても消えない。ペットやミニオン、フレイルなんかもそうですよね。trueだとそのままKill()、消滅
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
        public override Color? GetAlpha(Color lightColor)//発射体に色をつけることができる。真っ暗なのに発射体だけくっきり見える現象が再現できる
        {
            //return Main.DiscoColor * (1f - projectile.alpha / 255f);//ゲーミング弾丸
            return Color.Red * (1f - Projectile.alpha / 255f);
        }
    }
}
