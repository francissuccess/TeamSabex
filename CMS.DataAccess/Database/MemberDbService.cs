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
    public class MemberDbService
    {
        private readonly IDbConnection _connection;

        public MemberDbService(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> CreateMember(Member request)
        {
            try
            {
                var query = @"[InsertInto_Member]";
                var param = new
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    City = request.City,
                    Occupation = request.Occupation,
                    CreatedBy = request.CreatedBy,
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<Member> SingleMember(int Id)
        {
            Member members = new Member();
            try
            {
                var query = @"[GetPastor]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Member>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return members;
            }
            return null;
        }


        public async Task<APIListResponse3<Member>> GetMembers(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Member>();
            try
            {
                var query = @"[GetAllMembers]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Member>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Member>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdateMember(Member request)
        {
            try
            {
                var query = @"[Update_Member]";
                var param = new
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    City = request.City,
                    Occupation = request.Occupation,
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
