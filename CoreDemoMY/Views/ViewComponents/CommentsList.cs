using CoreDemoMY.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoMY.Views.ViewComponents
{
    public class CommentsList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    Username="Ali"
                },
                new UserComment
                {
                    ID=2,
                    Username="Kazım"
                },
                new UserComment {
                    ID=3,
                    Username="Şükrü"
                }
            };
            return View(commentValues);
        }
    }
}
