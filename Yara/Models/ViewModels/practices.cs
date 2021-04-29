using System.Collections.Generic;
using Yara.Models.ViewModels;

namespace Yara.Models.ViewModels
{
    public class practices
    {
        public List<ContentItem> InScope { set; get; } = new List<ContentItem>();
        public List<ContentItem> Answered { set; get; } = new List<ContentItem>();
        public List<ContentItem> Lost { set; get; } = new List<ContentItem>();
    }
}