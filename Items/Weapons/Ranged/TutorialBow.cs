using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Items.Weapons.Ranged
{
    public class TutorialBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Bow");
            Tooltip.SetDefault("");//なにも入れないと説明は表示されない
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged; //間接武器に設定
            Item.noMelee = true;//trueにするとアイテムを使用した際の当たり判定が消失 アイテムで直接攻撃しない場合に使う
            Item.autoReuse = false;//自動使用なし
			Item.useTime = 5;
            Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; 
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item5;
			Item.shoot = ProjectileID.WoodenArrowFriendly;//矢 弾薬系はちょっと特殊　変えてみるとわかるかも
			Item.shootSpeed = 16f; 
			Item.useAmmo = AmmoID.Arrow;//矢として設定されているアイテムを消費する
		}
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return player.statLife < player.statLifeMax2 / 10;//ライフが10%を切っている間は弾薬を消費しなくなる
        }
        public override void AddRecipes() //このアイテムのレシピ
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodenBow, 1);//ItemIDより 必要な素材を木の弓1個と
            recipe.AddIngredient(ItemID.LifeCrystal);//ライフクリスタルを1個に設定
            recipe.AddTile(TileID.Furnaces);//TileIDより Furnaces(かまどとして認識されるタイル)を必要なタイルとして指定
            recipe.Register();
        }
    }
}
