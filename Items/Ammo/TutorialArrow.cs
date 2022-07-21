using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Items.Ammo
{
    public class TutorialArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tutorial Arrow");
        }
		public override void SetDefaults()
		{
            Item.width = 10;
            Item.height = 28;
            Item.damage = 9;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;//消費の可否
            Item.maxStack = 999;//最大スタック数
            Item.knockBack = 3f;
            Item.ammo = AmmoID.Arrow;//弾薬としてのID 矢と等しいアイテムとして設定 カスタム弾薬作る場合はアイテムのタイプを設定してやればよかったはず
            //発射体の取得は、ModContent.ProjectileType<対象のnamespace>()で可能。アイテムの取得もProjectileTypeがItemTypeに変化するだけで同じ
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.TutorialArrow>();//矢として消費された場合に発射するprojectile
            Item.shootSpeed = 12.0f;
            Item.value = Item.sellPrice(0, 0, 0, 10);
			Item.rare = ItemRarityID.Blue;
        }
    }
}
