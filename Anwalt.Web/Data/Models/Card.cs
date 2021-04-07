// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/08
// ----------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Anwalt.Web.Data.Models.Base;

namespace Anwalt.Web.Data.Models
{
    public class Card : Entity, ICollection
    {
        public int Id { get; set; }

        [Required]
        public int HomeId { get; set; }

        public string Headline { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}