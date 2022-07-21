using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Items.Weapons.Magic
{
	public class TutorialStaff : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Staff");//�A�C�e���̖��O
            Tooltip.SetDefault("This is beam staff.");//�A�C�e���̐�����
            Item.staff[Item.type] = true;//��Ƃ��ăA�C�e�������ꍇ�͕K�v
        }
		public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.damage = 20;
            Item.DamageType = DamageClass.Magic;// ���@����Ƃ��Đݒ�
            Item.noMelee = true;//true�ɂ���ƃA�C�e�����g�p�����ۂ̓����蔻�肪���� �A�C�e���Œ��ڍU�����Ȃ��ꍇ�Ɏg��
            Item.autoReuse = true;
            Item.mana = 12;//�g�p����}�i�̗�
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
            //item.shoot = ProjectileID.RubyBolt;//���r�[�X�^�b�t���甭�˂����Ԃ���
            Item.shoot = ModContent.ProjectileType<Projectiles.Magic.TutorialShadowBeam>();//�V���h�E�r�[��
			Item.shootSpeed = 24f;
		}
        public override void AddRecipes() //���̃A�C�e���̃��V�s
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 12);//ItemID��� �K�v�ȑf�ނ�؍�12��
            recipe.AddIngredient(ItemID.Ruby, 1);//���r�[��1�ɐݒ�
            recipe.AddTile(TileID.WorkBenches);//TileID��� WorkBenches(���[�N�x���`�Ƃ��ĔF�������^�C��)��K�v�ȃ^�C���Ƃ��Ďw��
            recipe.Register();
        }
    }
}