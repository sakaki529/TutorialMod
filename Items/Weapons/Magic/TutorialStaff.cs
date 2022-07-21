using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Items.Weapons.Magic
{
	public class TutorialStaff : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Staff");//アイテムの名前
            Tooltip.SetDefault("This is beam staff.");//アイテムの説明文
            Item.staff[Item.type] = true;//杖としてアイテムを作る場合は必要
        }
		public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.damage = 20;
            Item.DamageType = DamageClass.Magic;// 魔法武器として設定
            Item.noMelee = true;//trueにするとアイテムを使用した際の当たり判定が消失 アイテムで直接攻撃しない場合に使う
            Item.autoReuse = true;
            Item.mana = 12;//使用するマナの量
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
            //item.shoot = ProjectileID.RubyBolt;//ルビースタッフから発射される赤い玉
            Item.shoot = ModContent.ProjectileType<Projectiles.Magic.TutorialShadowBeam>();//シャドウビーム
			Item.shootSpeed = 24f;
		}
        public override void AddRecipes() //このアイテムのレシピ
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 12);//ItemIDより 必要な素材を木材12個と
            recipe.AddIngredient(ItemID.Ruby, 1);//ルビーを1個に設定
            recipe.AddTile(TileID.WorkBenches);//TileIDより WorkBenches(ワークベンチとして認識されるタイル)を必要なタイルとして指定
            recipe.Register();
        }
    }
}