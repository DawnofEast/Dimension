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
    class AwaBag:ModItem
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
            base.item.width = 56;
            base.item.height = 32;
            base.item.rare = 10;
            base.item.expert = true;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    player.QuickSpawnItem(ModContent.ItemType<Bunkachou>(), 1);
                    break;
                case 1:
                    player.QuickSpawnItem(ModContent.ItemType<DarkCrow>(), 1);
                    break;
                case 2:
                    player.QuickSpawnItem(ModContent.ItemType<Tenki>(), 1);
                    break;
            }
        }
    }
}
