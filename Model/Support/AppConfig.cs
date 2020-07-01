using Model.Services.Firebase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Support
{
   public class AppConfig
    {

        /// <summary>
        /// Gets or sets the <see cref="JwtConfig"/>
        /// </summary>
        public JwtConfig Jwt { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Cors"/>
        /// </summary>
        public CorsConfig Cors { get; set; }
        /// <summary>
        /// Gets or sets the upload folder path
        /// </summary>
        public string UploadFolderPath { get; set; }
       
        /// <summary>
        /// Gets or sets the <see cref="FirebaseConfig"/>
        /// </summary>
        public FirebaseConfig Firebase { get; set; }
    }

    public class JwtConfig
    {
        /// <summary>
        /// Gets or sets the secret key
        /// </summary>
        public string  SecretKey { get; set; }

    }

    public class CorsConfig
    {
        public string[] AllowedCorsDomains { get; set; }
        public string CorsPolicy { get; set; }

    }
}

