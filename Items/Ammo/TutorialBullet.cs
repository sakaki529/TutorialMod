using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;//これいれてやるとProjectileTypeとか使うときにModContentを省略できるよ。ModContent*いっぱい使うときは便利

namespace TutorialMod.Items.Ammo
{
	public class TutorialBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Tutorial Bullet");
        }
		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;//消費の可否
            Item.maxStack = 999;//最大スタック数
            Item.knockBack = 4f;
            Item.ammo = AmmoID.Bullet;//弾薬としてのID 弾丸と等しいアイテムとして設定 カスタム弾薬作る場合はアイテムのタイプを設定してやればよかったはず
            Item.shoot = ProjectileType<Projectiles.Ranged.TutorialBullet>();//弾丸として消費された場合に発射するprojectile
            Item.shootSpeed = 4f;
            Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 0, 0, 10);
		}
	}
}
