using Umbraco.Cms.Core.Models.Blocks;

namespace Umb9.Core.Shared.Models
{
    /// <summary>
    /// View model used for the block list
    /// </summary>
    public class BlockListViewModel
    {
        public BlockListViewModel(){}

        public BlockListViewModel(BlockListItem blockListItem, int websiteId) {
            BlockListItem = blockListItem;
            WebsiteId = websiteId;
        }

        /// <summary>
        /// The block list item
        /// </summary>
        public BlockListItem BlockListItem { get; set; }

        /// <summary>
        /// Root node id
        /// </summary>
        public int WebsiteId { get; set; }
    }
}