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
            Tooltip.SetDefault("");//�Ȃɂ�����Ȃ��Ɛ����͕\������Ȃ�
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged; //�Ԑڕ���ɐݒ�
            Item.noMelee = true;//true�ɂ���ƃA�C�e�����g�p�����ۂ̓����蔻�肪���� �A�C�e���Œ��ڍU�����Ȃ��ꍇ�Ɏg��
            Item.autoReuse = false;//�����g�p�Ȃ�
			Item.useTime = 5;
            Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; 
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item5;
			Item.shoot = ProjectileID.WoodenArrowFriendly;//�� �e��n�͂�����Ɠ���@�ς��Ă݂�Ƃ킩�邩��
			Item.shootSpeed = 16f; 
			Item.useAmmo = AmmoID.Arrow;//��Ƃ��Đݒ肳��Ă���A�C�e���������
		}
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return player.statLife < player.statLifeMax2 / 10;//���C�t��10%��؂��Ă���Ԃ͒e�������Ȃ��Ȃ�
        }
        public override void AddRecipes() //���̃A�C�e���̃��V�s
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodenBow, 1);//ItemID��� �K�v�ȑf�ނ�؂̋|1��
            recipe.AddIngredient(ItemID.LifeCrystal);//���C�t�N���X�^����1�ɐݒ�
            recipe.AddTile(TileID.Furnaces);//TileID��� Furnaces(���܂ǂƂ��ĔF�������^�C��)��K�v�ȃ^�C���Ƃ��Ďw��
            recipe.Register();
        }
    }
}
