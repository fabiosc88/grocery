using System.Collections.Generic;

namespace Application.Models.Shop
{
    /// <summary>
    /// Model of Basket
    /// </summary>
    public sealed class ListShopModel : BaseModel
    {
        public IList<ShopModel> BasketList { get; set; }
        public IList<ShopModel> AvailableProductList { get; set; }
    }
}
