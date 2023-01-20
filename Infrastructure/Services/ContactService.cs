using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class ContactService
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Contactdb; User Id=postgres;Password=s.arda1717;";
    public ContactService()
    {
        
    }

    public List<ContactDto> GetContacts()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql ="Select * From contacts";
            var result = connection.Query<ContactDto>(sql);
            return result.ToList();
        }
    }
    public List<ContactDto> GetContactByName(string name)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql =$"Select * From contacts where name = '{name}' ";
            var result = connection.Query<ContactDto>(sql);
            return result.ToList();
        }
    }

    public bool AddContact(ContactDto contact)
    {
        try{
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Insert into contacts (name, address, telephone) values ('{contact.Name}', '{contact.Address}', {(Int32)contact.Telephone})";
            var added = connection.Execute(sql);
            if(added>0) return true;
            return false;
        }
        }
        catch(Exception ex )
        {
            return false;
        }
    }

    public bool UpdateContact(ContactDto contact)
    {
        try{
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update contacts set name = '{contact.Name}', address = '{contact.Address}', telephone = {(Int32)contact.Telephone} where id = {contact.Id}";
            var updated = connection.Execute(sql);
            if(updated>0) return true;
            return false;
        }
        }
        catch(Exception ex )
        {
            return false;
        }
    }
    
    public bool DeleteContact(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from contacts where id = {id}";
            var deleted = connection.Execute(sql);
            if(deleted>0) return true;
            return false;
        }
    }
}