using eAgendaMedica.Domain.AuthModule;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.Serialization;

namespace eAgendaMedica.Tests.Shared
{
    public static class BaseTest
    {
        public static DbUpdateException CreateDbUpdateException(string message)
        {
            var sqlException = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(sqlException, message);

            DbUpdateException dbUpdateException = (DbUpdateException)FormatterServices.GetUninitializedObject(typeof(DbUpdateException));
            FieldInfo innerExceptionField = typeof(Exception).GetField("_innerException", BindingFlags.Instance | BindingFlags.NonPublic);

            innerExceptionField?.SetValue(dbUpdateException, sqlException);
            return dbUpdateException;
        }

        public static Guid RegisterUser()
        {
            Guid userId = Guid.Parse("A8BC593B-5945-417B-3C2A-08DBE8775234");

            var sql =
                        @$"INSERT INTO ASPNETUSERS
				(
					ID,
					NAME,
					USERNAME,
					NORMALIZEDUSERNAME,
					EMAIL,
					NORMALIZEDEMAIL,
					EMAILCONFIRMED,
					PASSWORDHASH,
					SECURITYSTAMP,
					CONCURRENCYSTAMP,
					PHONENUMBER,
					PHONENUMBERCONFIRMED,
					TWOFACTORENABLED,
					LOCKOUTEND,
					LOCKOUTENABLED,
					ACCESSFAILEDCOUNT
				)
				VALUES
				(
					'{userId}',
					'TESTE TESTE',
					'TESTE@GMAIL.COM',
					'TESTE@GMAIL.COM',
					'TESTE@GMAIL.COM',
					'TESTE@GMAIL.COM',
					1,
					'AQAAAAEAACCQAAAAEL/NE00SPXPMU7SRDGSENWX7TKLQNMKI9AEYIDFGYKLGT1V6YFH+QEGZJMF5HVBN8G==',
					'FSNVOM5DIYV67KMJWQBDDIE3OSR57XTN',
					'CAB37435-2315-4C44-AB99-12EF2C7D91A4',
					NULL,
					0,
					0,
					NULL,
					1,
					0
				)";

            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=eAgendaMedicaDb-Tests;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
            return userId;
        }

        public static void DeleteData()
        {
            var sql = @$"DELETE FROM FK_TBDoctorActivity_TBDoctor;";

            sql = @$"DELETE FROM TBActivity;";

            sql += @$"DELETE FROM TBDoctor;";

            sql += @$"DELETE FROM ASPNETUSERS";

            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=eAgendaMedicaDb-Tests;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
