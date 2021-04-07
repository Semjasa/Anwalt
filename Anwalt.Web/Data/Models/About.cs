// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/11
// ----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using Anwalt.Web.Data.Models.Base;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Anwalt.Web.Data.Models
{
    public class About : Entity
    {
        private readonly ILazyLoader _lazyLoader;

        private ICollection<Link> _links;

        public About()
        {
            
        }

        public About(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int Id { get; set; }

        public string Headline { get; set; }

        public string Description { get; set; }

        public ICollection<Link> Links
        {
            get => _lazyLoader.Load(this, ref _links);
            set => _links = value;
        }
    }
}