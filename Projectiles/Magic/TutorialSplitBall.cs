using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TutorialMod.Projectiles.Magic
{
    public class TutorialSplitBall : ModProjectile
    {
        //拡散する弾のチュートリアル
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Ball");
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 120;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
        }
        public override void AI()
        {
            Projectile.velocity *= 0.98f;//減速
            Projectile.rotation += Projectile.direction * 0.02f;
        }
        public override void Kill(int timeLeft)
        {
            //発射体が消滅する際に呼び出される。
            //Projectile.activeを弄るなどで強制的に消滅させられた場合は呼び出されない。
            if (Projectile.owner == Main.myPlayer)//マルチプレイ対応
            {
                //発射体から発射体を発生させる場合は、上の条件のネストからNewProjectileを実行しないとマルチの際に発射体が複数発生してしまう

                int splitProj = ModContent.ProjectileType<TutorialHomingBall>();//発射する弾のタイプ
                //この発射体はai[0]の値によって拡散方法が変化する
                if (Projectile.ai[0] == 0f)
                {
                    //全方位
                    int v = 8;//発射する弾の数
                    float exRad = Main.rand.NextFloat(MathHelper.Pi);//均等な角度間隔を保持したまま炸裂方向にランダム性を持たせたい場合は、forループ内のradにこのexRadを加算してみよう
                    for (int i = 0; i < v; i++)
                    {
                        float rad = MathHelper.TwoPi / v * i;//回転角(弧度法)。MathHelper.TwoPiは6.14...の数値を持っている。
                                                             //TwoPiを弾の数(v)で除算して弾一つ分の角度を求め、発射した回数(i)を乗算することで実際の回転角を算出する。
                        Vector2 vector = Vector2.UnitY.RotatedBy(rad);//UnitY(Y軸正方向の単位ベクトル)をrad分だけ回転させる

                        //radとvectorの算出部を、度数法を使って書くと以下のようになる
                        //float deg = 360 / v * i;//radと同義。360度をvで割ってiを掛けるだけ
                        //vector = vector = Vector2.UnitY.RotatedBy(MathHelper.ToRadians(deg));//MathHelper.ToRadiansで度数法表現をを弧度法表現に変換して回転させる

                        vector *= 12f;//回転させた単位ベクトルに、発射する速度を乗算する
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vector, splitProj, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
                    }
                }
                if (Projectile.ai[0] == 1f)
                {
                    //全方位ランダム
                    int v = 8;//発射する弾の数
                    for (int i = 0; i < v; i++)
                    {
                        Vector2 vector = Vector2.UnitY.RotatedByRandom(MathHelper.TwoPi);//UnitY(Y軸正方向の単位ベクトル)を、RotatedByRandomを用いて回転させる
                        //Vector2 vector = Vector2.UnitY.RotatedBy(Main.rand.NextFloat() * MathHelper.TwoPi);//RotatedByで同じようなものを書くとこうなる
                        vector *= 12f;//回転させた単位ベクトルに、発射する速度を乗算する
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vector, splitProj, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
                    }
                }
                if (Projectile.ai[0] == 2f)
                {
                    //前方3way
                    float deg = 15;//弾一つ毎の角度間隔。ここではイメージしやすい度数法を用いる。弧度法の方が楽なら書き変えてもらってもok
                    for (int i = -1; i <= 1; i++)//iが取りうる値は-1, 0, 1の三つ
                    {
                        Vector2 normalizedVel = Vector2.Normalize(Projectile.velocity);//発射体の速度を単位ベクトルにして格納
                        //Vector2 normalizedVel = Vector2.Normalize(-Projectile.velocity);//括弧の中のvelocityにマイナスを付与すれば後方3wayになる
                        Vector2 vector = normalizedVel.RotatedBy(MathHelper.ToRadians(deg) * i);//速度の単位ベクトルを、RotatedByRandomを用いて回転させる
                        vector *= 12f;//回転させた単位ベクトルに、発射する速度を乗算する
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vector, splitProj, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
                    }
                }
            }
        }
    }
}
