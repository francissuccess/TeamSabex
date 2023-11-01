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
    public class UsheringDbService
    {
        private readonly IDbConnection _connection;

        public UsheringDbService(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> CreateUshering(Ushering request)
        {
            try
            {
                var query = @"[InsertInto_Ushering]";
                var param = new
                {
                    Name = request.Name,
                    Address = request.Address,
                    City = request.City,
                    PhoneNumber = request.PhoneNumber,
                    CreatedBy = request.CreatedBy,
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<Ushering> SingleUshering(int Id)
        {
            Ushering usherings = new Ushering();
            try
            {
                var query = @"[GetUshering]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Ushering>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return usherings;
            }
            return null;
        }


        public async Task<APIListResponse3<Ushering>> GetUsherings(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Ushering>();
            try
            {
                var query = @"[GetAllUsherings]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Ushering>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Ushering>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdateUshering(Ushering request)
        {
            try
            {
                var query = @"[Update_Ushering]";
                var param = new
                {
                    Name = request.Name,
                    Address = request.Address,
                    City = request.City,
                    PhoneNumber = request.PhoneNumber,
                    CreatedBy = request.CreatedBy,
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
