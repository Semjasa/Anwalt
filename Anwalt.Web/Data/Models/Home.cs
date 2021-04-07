// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/08
// ----------------------------------------------------------------------

using System.Collections.Generic;
using Anwalt.Web.Data.Models.Base;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Anwalt.Web.Data.Models
{
    public class Home : Entity
    {
        private readonly ILazyLoader _lazyLoader;

        private ICollection<Card> _cards;

        public Home()
        {

        }

        public Home(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int Id { get; set; }

        public string Headline { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Card> Cards
        {
            get => _lazyLoader.Load(this, ref _cards);
            set => _cards = value;
        }

        public bool IsActive { get; set; }
    }
}