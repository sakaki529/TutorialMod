using Terraria;//Item.��Main�Ȃ񂩂��g���Ƃ��͕K�v
using Terraria.ID;//ID���g���ꍇ�͕K�v
using Terraria.ModLoader;

namespace TutorialMod.Items.Weapons.Melee//�t�@�C���̏ꏊ���w�肵�Ă����Ζ��Ȃ�
{
	public class Sword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tutorial Sword");//�A�C�e���̖��O
			Tooltip.SetDefault("This is a sword.");//�A�C�e���̐�����
		}
		public override void SetDefaults() 
		{
			Item.damage = 999;//�_���[�W
			Item.DamageType = DamageClass.Melee;//�ߐ�
			Item.width = 40;//���[���h��̃A�C�e���̉���
			Item.height = 40;//���[���h��̃A�C�e���̏c��
            Item.useTime = 5;//�A�C�e���̎g�p����
			Item.useAnimation = 5;//�A�C�e���̎g�p����
            Item.useStyle = ItemUseStyleID.Swing;//�A�C�e���̎g�p���@�y�уA�j���[�V����
            Item.knockBack = 20;//�A�C�e���̃m�b�N�o�b�N�̋��� 20���ő�炵��
			Item.value = 10000;//�A�C�e���̉��l ���R�C���̖���
            //item.value = Item.buyPrice(0, 1, 0, 0);//���o�I�ɂ킩��₷�����l�̐ݒ���@ �v���`�i�A���A��A���̖��� �������̒l�i�
            //item.value = Item.sellPrice(0, 0, 20, 0);//���o�I�ɂ킩��₷�����l�̐ݒ���@2 ���������̋��z�(���l��1/5) item.value�ւ̑���͈�񂾂��ł���
			Item.rare = ItemRarityID.Red;//���A���e�B Red(10)����Pillar���烀�[�����[�h�N���X�̃A�C�e��
			Item.UseSound = SoundID.Item1;//�A�C�e���g�p���̌��ʉ�
			Item.autoReuse = true;//�����g�p
            Item.shoot = ProjectileID.HolyArrow;//shoot�Őݒ肵��Projectile�����˂���鑬�x
            //item.shoot = ProjectileID.StarWrath;//�X�^�[���[�X�̗���
            //item.shoot = ProjectileID.TerraBeam;//�e���u���[�h�̃r�[��
            Item.shootSpeed = 24f;//shoot�Őݒ肵��Projectile�����˂���鑬�x
		}
		public override void AddRecipes() //���̃A�C�e���̃��V�s
		{
			Recipe recipe = CreateRecipe();//�A�C�e������N���t�g�����
			recipe.AddIngredient(ItemID.FallenStar);//ItemID��� �K�v�ȑf�ނ𗬂ꐯ1��
			recipe.AddIngredient(ItemID.PlatinumBar, 5);//�v���`�i�C���S�b�g��5�ɐݒ�
			recipe.AddTile(TileID.Anvils);//TileID��� Anvils(�����Ƃ��ĔF�������^�C��)��K�v�ȃ^�C���Ƃ��Ďw��
			//recipe.SetResult(this, 2);//���̏ꍇ�̓A�C�e����2�N���t�g����� SetResult�͈�����ł���
			recipe.Register();
		}
	}
}