using Microsoft.AspNetCore.Components.Forms;

namespace adoExmapleCRUD
{
    public static class ConnectionString
    {
        private static string cs = "server=SONU\\MSSQLSERVERNEW;database=CrudAdoDb;integrated security=True;";
        public static string dbcs { get => cs; }
    }
}
