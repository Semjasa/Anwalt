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
    public class Link : Entity, ICollection
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int Position { get; set; }

        public string ViewName { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsSynchronized { get; }
        public object SyncRoot { get; }
    }
}