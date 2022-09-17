using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DocumentManager.Models.DocumentsModels;
using DocumentManager.Models.Filters;
using DocumentManager.Properties;

namespace DocumentManager.Models
{
    public class DatabaseClient
    {
        private readonly string _connectionString = Resources.ConnectionString;

        #region Select

        public IEnumerable<BaseDocument> GetAllBaseDocuments(BaseDocumentFilter filter = null)
        {
            var connection = new SqlConnection(_connectionString);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                var query = $@"
                    SELECT 
                    Discriminator, 
                    Base.Name,
                    DK.DocumentKind,
                    DK.Id,
                    Subject,
                    CreationDate,
                    DocumentNumber
                    FROM [dbo].[BaseDocument] AS Base
                    JOIN [dbo].[DocumentKind] AS DK
                    ON (Base.DocumentKind = DK.Id)
                    {FilterToSql(filter)}
                    ";
                var command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return new BaseDocumentBuilder()
                            .AddDiscriminator(reader.GetGuid(0))
                            .AddName(reader.GetString(1))
                            .AddDocumentKind(reader.GetInt32(3), reader.GetString(2))
                            .AddSubject(reader.GetString(4))
                            .AddCreationDate(reader.GetDateTime(5))
                            .AddDocumentNumber(reader.GetString(6))
                            .Build();
                    }
                }
            }
            finally
            {
                reader?.Close();
                connection.Close();
                connection.Dispose();
            }
        }

        public IEnumerable<IncomingDocument> GetAllIncomingDocuments(IncomingDocumentsFilter filter = null)
        {
            var connection = new SqlConnection(_connectionString);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                var query =
                    $@"
                    SELECT
                    Base.Id,
                    Base.Discriminator,
                    Base.Name,
                    DK.Id,
                    DK.DocumentKind,
                    Base.Subject,
                    Base.CreationDate,
                    Base.DocumentNumber,
                    Addr.Id,
                    Addr.Surname,
                    Addr.Name,
                    Addr.Patronimyc,
                    Count.Id,
                    Count.OrganizationName,
                    Del.Id,
                    Del.MethodName,
                    Came.Id,
                    Came.OrganizationName
                    FROM [dbo].[IncomingDocument] AS Incoming
                    JOIN [dbo].[BaseDocument] AS Base
                    ON (Base.Id = Incoming.BaseDocument)
                    JOIN [dbo].[DocumentKind] AS DK
                    ON (Base.DocumentKind = DK.Id)
                    JOIN [dbo].[Addressee] AS Addr
                    ON ((Addr.Id = Incoming.Addressee))
                    JOIN [dbo].[Counterparty] AS Count
                    ON ((Count.Id = Incoming.Counterparty))
                    JOIN [dbo].[DeliveryMethod] AS Del
                    ON ((Del.Id = Incoming.DeliveryMethod))
                    JOIN [dbo].[Counterparty] AS Came
                    ON ((Came.Id = Incoming.CameFrom))
                    {FilterToSql(filter)}
                    ";
                var command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var baseDocument = new BaseDocumentBuilder()
                            .AddId(reader.GetInt32(0))
                            .AddDiscriminator(reader.GetGuid(1))
                            .AddName(reader.GetString(2))
                            .AddDocumentKind(reader.GetInt32(3), reader.GetString(4))
                            .AddSubject(reader.GetString(5))
                            .AddCreationDate(reader.GetDateTime(6))
                            .AddDocumentNumber(reader.GetString(7))
                            .Build();
                        yield return new IncomingDocumentBuilder()
                            .AddBaseDocument(baseDocument)
                            .AddAddressee(reader.GetInt32(8), reader.GetString(9), reader.GetString(10), reader.GetString(11))
                            .AddCounterparty(reader.GetInt32(12), reader.GetString(13))
                            .AddDeliveryMethod(reader.GetInt32(14), reader.GetString(15))
                            .AddCameFrom(reader.GetInt32(16), reader.GetString(17))
                            .Build();
                    }
                }
            }
            finally
            {
                reader?.Close();
                connection.Close();
                connection.Dispose();
            }
        }

        private int GetIdFrom(string tableName, string columnName, string parameter)
        {
            var connection = new SqlConnection(_connectionString);
            var result = 0;
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                var query = $@"SELECT [Table].Id FROM [dbo].[{tableName}] AS [Table] WHERE ([Table].{columnName} = @Parameter);";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Parameter", parameter);

                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetInt32(0);
                    }
                }
            }
            finally
            {
                reader?.Close();
                connection.Close();
                connection.Dispose();
            }
            return result;
        }

        #endregion

        #region Insert

        public void AddBaseDocument(BaseDocument baseDocument)
        {
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();

                var documentKind = GetIdFrom("DocumentKind", "DocumentKind", baseDocument.DocumentKind.Name);
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                    INSERT INTO [dbo].[BaseDocument] 
                    (Discriminator, Name, DocumentKind, Subject, CreationDate, DocumentNumber) 
                    VALUES 
                    (@Discriminator, @Name, @DocumentKind, @Subject, @CreationDate, @DocumentNumber)
                    ";
                command.Parameters.AddWithValue("@Discriminator", baseDocument.Discriminator);
                command.Parameters.AddWithValue("@Name", baseDocument.Name);
                command.Parameters.AddWithValue("@DocumentKind", documentKind);
                command.Parameters.AddWithValue("@Subject", baseDocument.Subject);
                command.Parameters.AddWithValue("@CreationDate", baseDocument.CreatedDate);
                command.Parameters.AddWithValue("@DocumentNumber", baseDocument.DocumentNumber);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public void AddIncomingDocument(IncomingDocument incomingDocument)
        {
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                AddBaseDocument(incomingDocument.BaseDocument);
                var baseDocumentId = GetIdFrom("BaseDocument", "DocumentNumber", incomingDocument.BaseDocument.DocumentNumber);
                var addresseeId = GetIdFrom("Addressee", "Surname", incomingDocument.Addresses.Surname);
                var counterpartyId = GetIdFrom("Counterparty", "OrganizationName", incomingDocument.Counterparty.OrganizationName);
                var deliveryMethodId = GetIdFrom("DeliveryMethod", "MethodName", incomingDocument.DeliveryMethod.MethodName);
                var cameFromId = GetIdFrom("Counterparty", "OrganizationName", incomingDocument.CameFrom.OrganizationName);

                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO [dbo].[IncomingDocument] 
                    (BaseDocument, Addressee, Counterparty, DeliveryMethod, CameFrom) 
                    VALUES 
                    (@BaseDocument, @Addressee, @Counterparty, @DeliveryMethod, @CameFrom)";
                command.Parameters.AddWithValue("@BaseDocument", baseDocumentId);
                command.Parameters.AddWithValue("@Addressee", addresseeId);
                command.Parameters.AddWithValue("@Counterparty", counterpartyId);
                command.Parameters.AddWithValue("@DeliveryMethod", deliveryMethodId);
                command.Parameters.AddWithValue("@CameFrom", cameFromId);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        #endregion

        #region Update

        public void UpdateBaseDocument(BaseDocument newBaseDocument)
        {
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();

                var documentKind = GetIdFrom("DocumentKind", "DocumentKind", newBaseDocument.DocumentKind.Name);
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                    UPDATE [dbo].[BaseDocument] SET
                    Discriminator = @Discriminator, 
                    Name = @Name, 
                    DocumentKind = @DocumentKind, 
                    Subject = @Subject, 
                    CreationDate = @CreationDate, 
                    DocumentNumber = @DocumentNumber 
                    WHERE DocumentNumber = @DocumentNumber
                    ";
                command.Parameters.AddWithValue("@Discriminator", newBaseDocument.Discriminator);
                command.Parameters.AddWithValue("@Name", newBaseDocument.Name);
                command.Parameters.AddWithValue("@DocumentKind", documentKind);
                command.Parameters.AddWithValue("@Subject", newBaseDocument.Subject);
                command.Parameters.AddWithValue("@CreationDate", newBaseDocument.CreatedDate);
                command.Parameters.AddWithValue("@DocumentNumber", newBaseDocument.DocumentNumber);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public void UpdateIncomingDocument(IncomingDocument newIncomingDocument)
        {
            var connection = new SqlConnection(_connectionString);
            try
            {
                UpdateBaseDocument(newIncomingDocument.BaseDocument);
                var baseDocumentId = GetIdFrom("BaseDocument", "DocumentNumber", newIncomingDocument.BaseDocument.DocumentNumber);
                var addresseeId = GetIdFrom("Addressee", "Surname", newIncomingDocument.Addresses.Surname);
                var counterpartyId = GetIdFrom("Counterparty", "OrganizationName", newIncomingDocument.Counterparty.OrganizationName);
                var deliveryMethodId = GetIdFrom("DeliveryMethod", "MethodName", newIncomingDocument.DeliveryMethod.MethodName);
                var cameFromId = GetIdFrom("Counterparty", "OrganizationName", newIncomingDocument.CameFrom.OrganizationName);

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                    UPDATE [dbo].[IncomingDocument] SET
                    Addressee = @Addressee, 
                    Counterparty = @Counterparty, 
                    DeliveryMethod = @DeliveryMethod, 
                    CameFrom = @CameFrom
                    WHERE BaseDocument = @BaseDocument
                    ";
                command.Parameters.AddWithValue("@Addressee", addresseeId);
                command.Parameters.AddWithValue("@Counterparty", counterpartyId);
                command.Parameters.AddWithValue("@DeliveryMethod", deliveryMethodId);
                command.Parameters.AddWithValue("@CameFrom", cameFromId);
                command.Parameters.AddWithValue("@BaseDocument", baseDocumentId);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        #endregion

        #region Util

        private string FilterToSql(BaseDocumentFilter filter)
        {
            var sqlFilter = "WHERE ";
            if (!string.IsNullOrEmpty(filter.DocumentKind)) sqlFilter += $"DK.DocumentKind = '{filter.DocumentKind}'";
            if (!string.IsNullOrEmpty(filter.DocumentNumber)) sqlFilter += $" AND DocumentNumber = '{filter.DocumentNumber}'";
            if (!string.IsNullOrEmpty(filter.ByName)) sqlFilter += $" AND Base.Name = '{filter.ByName}'";
            if (filter.FromDate.Year > 1) sqlFilter += $" AND CreationDate >= '{filter.FromDate:yyyy-MM-dd}'";
            if (filter.ToDate.Year > 1) sqlFilter += $" AND CreationDate <= '{filter.ToDate:yyyy-MM-dd}'";
            return sqlFilter;
        }

        private string FilterToSql(IncomingDocumentsFilter filter)
        {
            var sqlFilter = FilterToSql(filter.BaseDocumentFilter);
            if (!string.IsNullOrEmpty(filter.ByDeliveryMethod.MethodName)) sqlFilter += $" AND Del.MethodName = '{filter.ByDeliveryMethod.MethodName}'";
            if (!string.IsNullOrEmpty(filter.ByCounterparty.OrganizationName)) sqlFilter += $" AND Count.OrganizationName = '{filter.ByCounterparty.OrganizationName}'";
            return sqlFilter;
        }

        #endregion
    }
}
