using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Model
{
    public class catalog
    {
        public string author { get; }
        public string title { get; }

        public catalog(string author, string title)
        {
            this.author = author;
            this.title = title;
        }
    }
}
