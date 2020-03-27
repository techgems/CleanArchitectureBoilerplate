using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CleanArchitectureBoilerplate.DataAccess.Models;
using CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using CleanArchitectureBoilerplate.DataAccess.Utils;

namespace CleanArchitectureBoilerplate.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IConfiguration Configuration;

        public PersonRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string ConnectionString { 
            get { return Configuration.GetConnectionString("Default"); } 
        }

        public List<Person> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<Person>("SELECT * FROM Person").AsList();
            }
        }

        public PaginatedList<Person> GetPaginated(int pageNumber, int pageSize)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                var paginatedList = new PaginatedList<Person>();

                var sql = @"SELECT COUNT(id) FROM Person; 
                            SELECT * FROM Person ORDER BY id OFFSET @pageNumber ROWS FETCH NEXT @pageSize ROWS ONLY;";

                using (var multi = conn.QueryMultiple(sql))
                {
                    paginatedList.PageNumber = pageNumber;
                    paginatedList.PageSize = pageSize;
                    paginatedList.TotalCount = multi.Read<int>().Single();
                    paginatedList.EntityList = multi.Read<Person>().ToList();
                }    

                return paginatedList;
            }
        }

        public List<PersonAddress> GetPersonAdresses(int personId)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<PersonAddress>("SELECT * FROM PersonAddress WHERE PersonId = @personId", new { personId }).AsList();
            }
        }

        public Person GetPersonWithAddresses(int personId)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<Person, PersonAddress, Person>(@"SELECT * FROM Person
                                            INNER JOIN PersonAddress on Person.Id = PersonAddress.Id
                                            WHERE Person.Id = @personId", 
                                            (person, address) => { person.Adresses.Add(address); return person; },
                                            new { personId }).SingleOrDefault();
            }
        }

        public Person GetById(int personId)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.QuerySingleOrDefault<Person>(@"SELECT * FROM Person
                                                           WHERE PersonId = @personId", new { personId });
            }
        }

        public bool IsEmailUnique(string emailAddress)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                var email = conn.ExecuteScalar<string>(@"SELECT Email FROM Person
                                                         WHERE Email = @emailAddress", new { emailAddress });

                return string.IsNullOrWhiteSpace(email);
            }
        }

        public Person Create(Person person)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                person.Id = Convert.ToInt32(conn.Insert(person));

                return person;
            }
        }

        public Person Update(Person person)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Update(person);
                return person;
            }
        }

        public void Delete(int personId)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Delete(new Person { Id = personId });
            }
        }
    }
}
