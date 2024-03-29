﻿using CMS.Domain.Models;
using CMS.Domain.Utility;
using Dapper;
using System.Data;

namespace CMS.DataAccess.Database
{
    public class PastorDbService
    {
        private readonly IDbConnection _connection;

        public PastorDbService(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> CreatePastor(Pastor request)
        {
            try
            {
                var query = @"[InsertInto_Pastor]";
                var param = new
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    Rank = request.Rank,
                    Description = request.Description,
                    CreatedBy = request.CreatedBy,
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<Pastor> SinglePastor(int Id)
        {
            Pastor pastors = new Pastor();
            try
            {
                var query = @"[GetPastor]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Pastor>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return pastors;
            }
            return null;
        }


        public async Task<APIListResponse3<Pastor>> GetPastors(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Pastor>();
            try
            {
                var query = @"[GetAllPastors]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Pastor>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Pastor>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdatePastor(Pastor request)
        {
            try
            {
                var query = @"[Update_Pastor]";
                var param = new
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    Rank = request.Rank,
                    Description = request.Description,
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
