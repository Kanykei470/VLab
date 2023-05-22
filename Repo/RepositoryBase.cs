using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VLab.Repo
{
    public abstract class RepositoryBase
    {
        private readonly string _con;
        public RepositoryBase()
        {
            _con = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_con);
        }
    }
}
