using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Projectiles.Ranged
{
    public class TutorialArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Arrow");
        }
        public override void SetDefaults()
        {
            Projectile.width = 14;//横幅
            Projectile.height = 14;//縦幅
            Projectile.aiStyle = 1;//aiテンプレートの番号。1なら矢。うまく使うと発射体を簡単に作れる。-1にすると一般的な発射体が行う方向の変化等の一部の動作が行われなくなる。その場合でも発射体としての支障はとくにない。
            Projectile.DamageType = DamageClass.Ranged;//間接攻撃として扱う。
            //アイテムのものとほぼ同じ。発射体のクリティカル率は持っている属性のクリティカル率を参照する。そのため、属性を持たない場合クリティカルは発生しない
            Projectile.arrow = true;//発射体を矢として設定。矢ではない場合この行はなくてもかまわない
            Projectile.penetrate = 1;//何体の敵にヒットできるか。二回貫通させたいなら3を設定。-1にすると無限貫通になる
            Projectile.timeLeft = 300;//発射体が消えるまでの時間。1フレームごとに1減る。timeleftが0になると消滅する。AIから一定の値にし続けると自然消滅しない発射体ができるが、動作が重くなったり弊害があるのでしないように
            //主にミニオンやペットなどの一定の条件がクリアされている間は消えない発射体に対しては使うことがある
            Projectile.friendly = true;//発射体が敵にヒットするかどうか
            Projectile.hostile = false;//発射体がプレイヤーや町のnpcにヒットするか
            Projectile.tileCollide = true;//発射体がタイルにヒットするか。falseにすると地形貫通
            Projectile.ignoreWater = true;//発射体が水の中で遅くならないかどうか。trueだと遅くならない
            Projectile.extraUpdates = 1;//発射体が一フレームの間に追加で行う処理の回数。発射体は速くしすぎると敵をすり抜けてしまうが、こいつを使うことで速いように見せかけることができる。シャドウビームはこの数値が100である
            //extraUpdatesで追加された処理の回数分。追加処理分だけtimeleftも減少する
            Projectile.alpha = 255;//projectileのアルファ値...だがこれが初見だと厄介である。**255に近いほど** 透明になる。ややこしいね
            Projectile.scale = 1.0f;//発射体の大きさの倍率。これを変えたところで見かけのサイズが変わるだけでヒットボックスには影響しない。ヒットボックスのサイズも変えたい場合はこのスケールを基に縦横幅を調整してやる必要がある

            //projectile.rotation = 0;//発射体の回転(radian) 3.141592...(Math.PIを使うと3.14とか入力しなくていいので楽)で半回転。三角関数の基礎ってやつだよ
            //projectile.knockBack = 0;//発射体のノックバックの強さ
            //projectile.damage = 0;//発射体のダメージ。時間経過でダメージを増加させたりヒットごとに減少させたりするときに触る
            //projectile.owner = 0;//発射体の所有者であるプレイヤーを示す番号。基本触らない
        }
        public override void AI()//AIだ!
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
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)//npcにヒットした際、ダメージ処理の前に呼び出される
        {
            //このメソッドからであればnpcに与えるダメージが操作できる
            if (target.type == NPCID.KingSlime)//king slimeには４倍ダメージを与えてみたり
            {
                damage *= 4;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)//npcにヒットした際、ダメージ処理の後に呼び出される
        {
            //ここで与えられたダメージを変更してもtargetに与えられるダメージは変化しない
            target.AddBuff(BuffID.ShadowFlame, 120);//シャドウフレイムを二秒付与
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 120);//シャドウフレイムを二秒付与
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 120);//シャドウフレイムを二秒付与
        }
        public override void Kill(int timeLeft)//projectileが非active化されずにkillされた場合(貫通しきった、timeleftが0になった、Killが実行された場合)に呼び出される
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);//矢が壊れる音を鳴らす
            if (!Projectile.noDropItem && Main.rand.Next(2) == 0)//アイテムを落とすように設定されている場合、1/2の確率でベースの矢をアイテムとして発生させる あってもなくてもいい
            {
                //Main.rand.NextBool(2)は。中の数字を4にすると0~3から、(2, 5)とすると2~4からランダムな値が得られる
                //この場合は、0~1のランダムな値を取得、それが0だった場合にアイテムを発生させる。簡単に言うと、(カッコ内の数字)分の1の確率
                Item.NewItem(Projectile.GetSource_DropAsItem(),Projectile.position, Projectile.width, Projectile.height, ModContent.ItemType<Items.Ammo.TutorialArrow>(), 1);
            }
        }
    }
}
