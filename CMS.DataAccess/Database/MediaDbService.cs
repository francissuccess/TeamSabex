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
    public class MediaDbService
    {
        private readonly IDbConnection _connection;

        public MediaDbService(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> CreateMedia(Media request)
        {
            try
            {
                var query = @"[InsertInto_Media]";
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
        public async Task<Media> SingleMedia(int Id)
        {
            Media medias = new Media();
            try
            {
                var query = @"[GetMedia]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Media>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return medias;
            }
            return null;
        }


        public async Task<APIListResponse3<Media>> GetMedias(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Media>();
            try
            {
                var query = @"[GetAllMedias]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Media>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Media>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdateMedia(Media request)
        {
            try
            {
                var query = @"[Update_Media]";
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

