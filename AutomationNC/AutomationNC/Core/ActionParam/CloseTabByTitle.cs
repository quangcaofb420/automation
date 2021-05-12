
using System;

namespace Core.ActionParam
{
    public class CloseTabByTitle
    {
        public String Title { get; set; }
        public CloseTabByTitle(String title)
        {
            Title = title;
        }
    }
}
