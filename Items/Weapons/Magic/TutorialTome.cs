using Terraria;
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
            Item.useTime = 10;//useTime:useAnimationが10:20場合、一回のクリックで2回発射される 9:20になると3回になる 詳しい説明は面倒なので使って覚えてください
            Item.useAnimation = 20;//1クリック毎の使用時間
            Item.UseSound = SoundID.Item8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.shootSpeed = 16f;
			Item.useAnimation = 20;
			Item.shoot = ProjectileID.Typhoon;//レーザーブレードタイフーン
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 8, 0, 0);
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
