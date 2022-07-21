using Terraria;//Item.やMainなんかを使うときは必要
using Terraria.ID;//IDを使う場合は必要
using Terraria.ModLoader;

namespace TutorialMod.Items.Weapons.Melee//ファイルの場所を指定しておけば問題ない
{
	public class Sword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tutorial Sword");//アイテムの名前
			Tooltip.SetDefault("This is a sword.");//アイテムの説明文
		}
		public override void SetDefaults() 
		{
			Item.damage = 999;//ダメージ
			Item.DamageType = DamageClass.Melee;//近接
			Item.width = 40;//ワールド上のアイテムの横幅
			Item.height = 40;//ワールド上のアイテムの縦幅
            Item.useTime = 5;//アイテムの使用時間
			Item.useAnimation = 5;//アイテムの使用時間
            Item.useStyle = ItemUseStyleID.Swing;//アイテムの使用方法及びアニメーション
            Item.knockBack = 20;//アイテムのノックバックの強さ 20が最大らしい
			Item.value = 10000;//アイテムの価値 銅コインの枚数
            //item.value = Item.buyPrice(0, 1, 0, 0);//視覚的にわかりやすい価値の設定方法 プラチナ、金、銀、銅の枚数 買う時の値段基準
            //item.value = Item.sellPrice(0, 0, 20, 0);//視覚的にわかりやすい価値の設定方法2 売った時の金額基準(買値の1/5) item.valueへの代入は一回だけでいい
			Item.rare = ItemRarityID.Red;//レアリティ Red(10)だとPillarからムーンロードクラスのアイテム
			Item.UseSound = SoundID.Item1;//アイテム使用時の効果音
			Item.autoReuse = true;//自動使用
            Item.shoot = ProjectileID.HolyArrow;//shootで設定したProjectileが発射される速度
            //item.shoot = ProjectileID.StarWrath;//スターラースの流星
            //item.shoot = ProjectileID.TerraBeam;//テラブレードのビーム
            Item.shootSpeed = 24f;//shootで設定したProjectileが発射される速度
		}
		public override void AddRecipes() //このアイテムのレシピ
		{
			Recipe recipe = CreateRecipe();//アイテムが一つクラフトされる
			recipe.AddIngredient(ItemID.FallenStar);//ItemIDより 必要な素材を流れ星1個と
			recipe.AddIngredient(ItemID.PlatinumBar, 5);//プラチナインゴットを5個に設定
			recipe.AddTile(TileID.Anvils);//TileIDより Anvils(金床として認識されるタイル)を必要なタイルとして指定
			//recipe.SetResult(this, 2);//この場合はアイテムが2つクラフトされる SetResultは一つだけでいい
			recipe.Register();
		}
	}
}