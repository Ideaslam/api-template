using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class BaseSearchResult
    {
        public int TotalCount { get; set; }
        public virtual string Message { get; set; }
        public virtual Exception Exception { get; set; }
        public virtual ResponseState State { get; set; }
    }
}
