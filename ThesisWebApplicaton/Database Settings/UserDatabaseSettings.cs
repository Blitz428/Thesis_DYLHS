using System;
using System.Collections.Generic;
using System.Text;

namespace Thesis.Repository
{
    public class UserDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UsersCollectionName { get; set; } = null!;
    }
}
