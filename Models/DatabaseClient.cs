using System;
using DocumentManager.Models.DocumentsModels;
using DocumentManager.Models.Filters;
using DocumentManager.Properties;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DocumentManager.Models
{
    public class DatabaseClient : IDisposable
    {
        private readonly SqlConnection _connection = new SqlConnection(Resources.ConnectionString);

        public DatabaseClient()
        {
            _connection.Open();
        }

        #region Select

        public IEnumerable<BaseDocument> GetAllBaseDocuments(BaseDocumentFilter filter = null)
        {
            var query = $@"
                    SELECT Discriminator, BaseDocumentTable.Name, DocumentKindTable.DocumentKind, DocumentKindTable.Id, Subject, CreationDate, DocumentNumber
                    FROM [dbo].[BaseDocument] AS BaseDocumentTable
                    JOIN [dbo].[DocumentKind] AS DocumentKindTable
                    ON (BaseDocumentTable.DocumentKind = DocumentKindTable.Id)
                    {GetSqlWhere(filter)}";
            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();
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
            reader.Close();
        }

        public IEnumerable<IncomingDocument> GetAllIncomingDocuments(IncomingDocumentFilter filter = null)
        {
            var query = $@"
                    SELECT BaseDocumentTable.Id, BaseDocumentTable.Discriminator, BaseDocumentTable.Name, DocumentKindTable.Id, DocumentKindTable.DocumentKind, BaseDocumentTable.Subject,
                    BaseDocumentTable.CreationDate, BaseDocumentTable.DocumentNumber, AddresseeTable.Id, AddresseeTable.Surname, AddresseeTable.Name, AddresseeTable.Patronimyc,
                    CounterpartyTable.Id, CounterpartyTable.OrganizationName, DeliveryMethodTable.Id, DeliveryMethodTable.MethodName, CameFromTable.Id, CameFromTable.OrganizationName
                    FROM [dbo].[IncomingDocument] AS IncomingDocumentTable
                    JOIN [dbo].[BaseDocument] AS BaseDocumentTable
                    ON (BaseDocumentTable.Id = IncomingDocumentTable.BaseDocument)
                    JOIN [dbo].[DocumentKind] AS DocumentKindTable
                    ON (BaseDocumentTable.DocumentKind = DocumentKindTable.Id)
                    JOIN [dbo].[Addressee] AS AddresseeTable
                    ON ((AddresseeTable.Id = IncomingDocumentTable.Addressee))
                    JOIN [dbo].[Counterparty] AS CounterpartyTable
                    ON ((CounterpartyTable.Id = IncomingDocumentTable.Counterparty))
                    JOIN [dbo].[DeliveryMethod] AS DeliveryMethodTable
                    ON ((DeliveryMethodTable.Id = IncomingDocumentTable.DeliveryMethod))
                    JOIN [dbo].[Counterparty] AS CameFromTable
                    ON ((CameFromTable.Id = IncomingDocumentTable.CameFrom))
                    {GetSqlWhere(filter)}";
            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();
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
            reader.Close();
        }

        private int GetIdFrom(string tableName, string columnName, string parameter)
        {
            var result = 0;
            var query = $@"SELECT [Table].Id FROM [dbo].[{tableName}] AS [Table] WHERE ([Table].{columnName} = @Parameter);";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Parameter", parameter);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }
            reader.Close();
            return result;
        }

        #endregion

        #region Insert

        public void AddBaseDocument(BaseDocument baseDocument)
        {
            var documentKindId = GetIdFrom("DocumentKind", "DocumentKind", baseDocument.DocumentKind.Name);
            var command = _connection.CreateCommand();
            command.CommandText = 
                  @"INSERT INTO [dbo].[BaseDocument] 
                    (Discriminator, Name, DocumentKind, Subject, CreationDate, DocumentNumber) 
                    VALUES 
                    (@Discriminator, @Name, @DocumentKind, @Subject, @CreationDate, @DocumentNumber)";
            command.Parameters.AddWithValue("@Discriminator", baseDocument.Discriminator);
            command.Parameters.AddWithValue("@Name", baseDocument.Name);
            command.Parameters.AddWithValue("@DocumentKind", documentKindId);
            command.Parameters.AddWithValue("@Subject", baseDocument.Subject);
            command.Parameters.AddWithValue("@CreationDate", baseDocument.CreatedDate);
            command.Parameters.AddWithValue("@DocumentNumber", baseDocument.DocumentNumber);
            command.ExecuteNonQuery();
        }

        public void AddIncomingDocument(IncomingDocument incomingDocument)
        {
            AddBaseDocument(incomingDocument.BaseDocument);
            var baseDocumentId = GetIdFrom("BaseDocument", "DocumentNumber", incomingDocument.BaseDocument.DocumentNumber);
            var addresseeId = GetIdFrom("Addressee", "Surname", incomingDocument.Addresses.Surname);
            var counterpartyId = GetIdFrom("Counterparty", "OrganizationName", incomingDocument.Counterparty.OrganizationName);
            var deliveryMethodId = GetIdFrom("DeliveryMethod", "MethodName", incomingDocument.DeliveryMethod.MethodName);
            var cameFromId = GetIdFrom("Counterparty", "OrganizationName", incomingDocument.CameFrom.OrganizationName);
            var command = _connection.CreateCommand();
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

        #endregion

        #region Update

        public void UpdateBaseDocument(BaseDocument newBaseDocument)
        {
            var documentKind = GetIdFrom("DocumentKind", "DocumentKind", newBaseDocument.DocumentKind.Name);
            var command = _connection.CreateCommand();
            command.CommandText =
                  @"UPDATE [dbo].[BaseDocument] SET
                    Discriminator = @Discriminator, 
                    Name = @Name, 
                    DocumentKind = @DocumentKind, 
                    Subject = @Subject, 
                    CreationDate = @CreationDate, 
                    DocumentNumber = @DocumentNumber 
                    WHERE DocumentNumber = @DocumentNumber";
            command.Parameters.AddWithValue("@Discriminator", newBaseDocument.Discriminator);
            command.Parameters.AddWithValue("@Name", newBaseDocument.Name);
            command.Parameters.AddWithValue("@DocumentKind", documentKind);
            command.Parameters.AddWithValue("@Subject", newBaseDocument.Subject);
            command.Parameters.AddWithValue("@CreationDate", newBaseDocument.CreatedDate);
            command.Parameters.AddWithValue("@DocumentNumber", newBaseDocument.DocumentNumber);
            command.ExecuteNonQuery();
        }

        public void UpdateIncomingDocument(IncomingDocument newIncomingDocument)
        {
            UpdateBaseDocument(newIncomingDocument.BaseDocument);
            var baseDocumentId = GetIdFrom("BaseDocument", "DocumentNumber", newIncomingDocument.BaseDocument.DocumentNumber);
            var addresseeId = GetIdFrom("Addressee", "Surname", newIncomingDocument.Addresses.Surname);
            var counterpartyId = GetIdFrom("Counterparty", "OrganizationName", newIncomingDocument.Counterparty.OrganizationName);
            var deliveryMethodId = GetIdFrom("DeliveryMethod", "MethodName", newIncomingDocument.DeliveryMethod.MethodName);
            var cameFromId = GetIdFrom("Counterparty", "OrganizationName", newIncomingDocument.CameFrom.OrganizationName);
            var command = _connection.CreateCommand();
            command.CommandText =
                  @"UPDATE [dbo].[IncomingDocument] SET
                    Addressee = @Addressee, 
                    Counterparty = @Counterparty, 
                    DeliveryMethod = @DeliveryMethod, 
                    CameFrom = @CameFrom
                    WHERE BaseDocument = @BaseDocument";
            command.Parameters.AddWithValue("@Addressee", addresseeId);
            command.Parameters.AddWithValue("@Counterparty", counterpartyId);
            command.Parameters.AddWithValue("@DeliveryMethod", deliveryMethodId);
            command.Parameters.AddWithValue("@CameFrom", cameFromId);
            command.Parameters.AddWithValue("@BaseDocument", baseDocumentId);
            command.ExecuteNonQuery();
        }

        #endregion

        #region Util

        private string GetSqlWhere(BaseDocumentFilter filter)
        {
            var sqlFilter = "WHERE ";
            if (!string.IsNullOrEmpty(filter.DocumentKind)) sqlFilter += $"DocumentKindTable.DocumentKind = '{filter.DocumentKind}'";
            if (!string.IsNullOrEmpty(filter.DocumentNumber)) sqlFilter += $" AND DocumentNumber = '{filter.DocumentNumber}'";
            if (!string.IsNullOrEmpty(filter.ByName)) sqlFilter += $" AND BaseDocumentTable.Name = '{filter.ByName}'";
            if (filter.FromDate.Year > 1) sqlFilter += $" AND CreationDate >= '{filter.FromDate:yyyy-MM-dd}'";
            if (filter.ToDate.Year > 1) sqlFilter += $" AND CreationDate <= '{filter.ToDate:yyyy-MM-dd}'";
            return sqlFilter;
        }

        private string GetSqlWhere(IncomingDocumentFilter filter)
        {
            var sqlFilter = GetSqlWhere(filter.BaseDocumentFilter);
            if (!string.IsNullOrEmpty(filter.ByDeliveryMethod.MethodName)) sqlFilter += $" AND DeliveryMethodTable.MethodName = '{filter.ByDeliveryMethod.MethodName}'";
            if (!string.IsNullOrEmpty(filter.ByCounterparty.OrganizationName)) sqlFilter += $" AND CounterpartyTable.OrganizationName = '{filter.ByCounterparty.OrganizationName}'";
            return sqlFilter;
        }

        #endregion

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
