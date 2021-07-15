using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dimension.Items.Weapons;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Dimension.Items.Sundry
{
	public class MuBloodBag : ModItem
	{
        public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault(Language.GetTextValue("ItemName.CultistBossBag"));
			base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }
		public override void SetDefaults()
		{
			base.item.maxStack = 999;
			base.item.consumable = true;
			base.item.width = 24;
			base.item.height = 24;
			base.item.rare = 10;
			base.item.expert = true;
        }
        public override bool CanRightClick()
		{
			return true;
		}
		public override void RightClick(Player player)
		{
			player.TryGettingDevArmor();
			player.QuickSpawnItem(ModContent.ItemType<StarrySky>(),1);
		}
    }
}
