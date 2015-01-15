using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Basic
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<string> Comments { get; set; }

        public Post(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }
}
