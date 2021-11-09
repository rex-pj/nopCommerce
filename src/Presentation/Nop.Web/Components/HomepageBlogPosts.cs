using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Blogs;

namespace Nop.Web.Components
{
    public class HomepageBlogPostsViewComponent : NopViewComponent
    {
        private readonly IBlogModelFactory _blogModelFactory;

        public HomepageBlogPostsViewComponent(IBlogModelFactory blogModelFactory)
        {
            _blogModelFactory = blogModelFactory;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _blogModelFactory.PrepareNewBlogPostListModelAsync(new BlogPagingFilteringModel
            {
                PageSize = 4
            });

            if (!model.BlogPosts.Any())
            {
                return Content("");
            }

            return View(model);
        }
    }
}
