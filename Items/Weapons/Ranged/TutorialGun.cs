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
                "\nNONO");//���s
            //Tooltip.SetDefault("Jungle\nNONO");//����ȕ��ɑ����ď����Ă��������ʂɂȂ�
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged; //�Ԑڕ���ɐݒ�
            Item.noMelee = true;//true�ɂ���ƃA�C�e�����g�p�����ۂ̓����蔻�肪���� �A�C�e���Œ��ڍU�����Ȃ��ꍇ�Ɏg��
            Item.autoReuse = true;
			Item.useTime = 20;
            Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; 
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item11;
			Item.shoot = ProjectileID.Bullet;//�e��n�͂�����Ɠ��� �ς��Ă݂�Ƃ킩�邩��
            Item.shootSpeed = 16f; 
			Item.useAmmo = AmmoID.Bullet;//�e�ۂƂ��Đݒ肳��Ă���A�C�e���������
		}
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return player.statLife < player.statLifeMax2 / 10;//���C�t��10%��؂��Ă���Ԃ͒e�������Ȃ��Ȃ�
        }
        public override void AddRecipes() //���̃A�C�e���̃��V�s
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 12);//ItemID��� �K�v�ȑf�ނ�؍�12��
            recipe.AddIngredient(ItemID.Ruby, 1);//���r�[��1�ɐݒ�
            recipe.AddTile(TileID.Hellforge);//TileID��� Hellforge(�n���̂��܂ǂƂ��ĔF�������^�C��)��K�v�ȃ^�C���Ƃ��Ďw��
            recipe.Register();
        }
    }
}
