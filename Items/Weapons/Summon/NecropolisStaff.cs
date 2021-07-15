using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Dimension.Projectiles.Summon;
using Dimension.Buff.Summon;

namespace Dimension.Items.Weapons.Summon
{
    class NecropolisStaff : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("耐克罗波利斯员工");
			Tooltip.SetDefault("召唤耐克罗波利斯员工为你而战");
		}
		public override void SetDefaults()
		{
			item.damage = 120;
			item.summon = true;
			item.mana = 10;
			item.width = 20;
			item.height = 20;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 50, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item44;
			item.shoot = ModContent.ProjectileType<NecropolisMinion>();
			item.buffType = ModContent.BuffType<Buff.Summon.NecropolisActive>(); 
		}
        public override bool CanUseItem(Player player)
        {
			return player.ownedProjectileCounts[ModContent.ProjectileType<NecropolisMinion>()] < 1;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
