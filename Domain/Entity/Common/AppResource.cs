using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity.Common
{
   public  class AppResource :BaseEntity
    {
        #region common
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets the english value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the arabic value
        /// </summary>
        public string ValueAr { get; set; }


        #endregion




    }
}
