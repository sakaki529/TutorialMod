using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Items.Weapons.Magic
{
    public class TutorialTome : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Tome");
            Tooltip.SetDefault("This is a tutorial.");
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.damage = 40;
            Item.DamageType = DamageClass.Magic;//魔法武器として設定
            Item.noMelee = true;//trueにするとアイテムを使用した際の当たり判定が消失 アイテムで直接攻撃しない場合に使う
            Item.mana = 5;//使用するマナの量
            Item.useTime = 20;//useTime:useAnimationが10:20場合、一回のクリックで2回発射される 9:20になると3回になる 詳しい説明は面倒なので使って覚えてください
            Item.useAnimation = 20;//1クリック毎の使用時間
            Item.UseSound = SoundID.Item8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.shootSpeed = 8f;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<Projectiles.Magic.TutorialSplitBall>();//炸裂弾
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 8, 0, 0);
		}
        //shootを使うことで発射方法などに多彩な変更を加えることが出来ます。空から降らせたりカーソルの位置に出現させたり...
        //NewProjectileを複数使って、複数の発射体を発生させることもできます
        //aiの数値を変更したり複数発生させたりしない場合で、速度に角度を持たせたいだけ、特殊な弓のように発射する物体の種類を変えたいだけならModifyShootStatsを推奨。
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            //TutorialSplitBallは発射体のai[0]の値によって拡散方法が変化します。NewProjectileでは発生させる際にShootからai[0]を変更して拡散の種類を決めることができます
            //ai[0]を設定できる引数にMain.rand.Next(3)を入れておきます。Main.rand.Next(3)は0~2のランダムな値です。
            //プロジェクトを開いていてかつそこに含まれるファイルを閲覧している場合、NewProjectileにカーソルを合わせると詳細が表示されます。
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, Main.rand.Next(3), 0f);
            return false;//上のNewProjectileで既に発射しているので、falseにすることで通常通りの発射はさせないようにしておきます。
        }
        public override void AddRecipes() //このアイテムのレシピ
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 8);//ItemIDより 必要な素材を布8個と
            recipe.AddIngredient(ItemID.WaterBolt);//ウォーターボルト1個に設定
            recipe.AddTile(TileID.Bookcases);//TileIDより Bookcases(本棚として認識されるタイル)を必要なタイルとして指定
            recipe.Register();
        }
    }
}
