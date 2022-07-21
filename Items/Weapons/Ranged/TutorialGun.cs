using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Items.Weapons.Ranged
{
    public class TutorialGun : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Gun");
            Tooltip.SetDefault("Jungle" +
                "\nNONO");//改行
            //Tooltip.SetDefault("Jungle\nNONO");//こんな風に続けて書いても同じ結果になる
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged; //間接武器に設定
            Item.noMelee = true;//trueにするとアイテムを使用した際の当たり判定が消失 アイテムで直接攻撃しない場合に使う
            Item.autoReuse = true;
			Item.useTime = 20;
            Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; 
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item11;
			Item.shoot = ProjectileID.Bullet;//弾薬系はちょっと特殊 変えてみるとわかるかも
            Item.shootSpeed = 16f; 
			Item.useAmmo = AmmoID.Bullet;//弾丸として設定されているアイテムを消費する
		}
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return player.statLife < player.statLifeMax2 / 10;//ライフが10%を切っている間は弾薬を消費しなくなる
        }
        public override void AddRecipes() //このアイテムのレシピ
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 12);//ItemIDより 必要な素材を木材12個と
            recipe.AddIngredient(ItemID.Ruby, 1);//ルビーを1個に設定
            recipe.AddTile(TileID.Hellforge);//TileIDより Hellforge(地獄のかまどとして認識されるタイル)を必要なタイルとして指定
            recipe.Register();
        }
    }
}
