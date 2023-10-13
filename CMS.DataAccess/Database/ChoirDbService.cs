using CMS.Domain.Models;
using CMS.Domain.Utility;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DataAccess.Database
{
    public class ChoirDbService
    {
        private readonly IDbConnection _connection;

        public ChoirDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateChoir(Choir request)
        {
            try
            {
                var query = @"[InsertInto_Choir]";
                var param = new
                {
                    Name = request.Name,
                    Address = request.Address,
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<Choir> SingleChoir(int Id)
        {
            Choir choirs = new Choir();
            try
            {
                var query = @"[GetChoir]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Choir>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return choirs;
            }
            return null;
        }

        public async Task<APIListResponse3<Choir>> GetChoirs(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Choir>();
            try
            {
                var query = @"[GetAllChoir]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Choir>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Choir>.ToPagedList(result, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Sequence contatins no elements"))
                {
                    response.Code = "01";
                }
            }
            return response;
        }
        public async Task<int> UpdateChoir(Choir request)
        {
            try
            {
                var query = @"[Update_Choir]";
                var param = new
                {
                    Name = request.Name,
                    Address = request.Address,
                    Id = request.Id
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

    }
}







