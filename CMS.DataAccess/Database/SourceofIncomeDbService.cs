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
    public class SourceofIncomeDbService
    {
        private readonly IDbConnection _connection;

        public SourceofIncomeDbService(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> CreateSourceofIncome(SourceofIncome request)
        {
            try
            {
                var query = @"[InsertInto_SourceofIncome]";
                var param = new
                {
                    Offering = request.Offering,
                    Tithe = request.Tithe,
                    Vow = request.Vow,
                    SalesofChurchItems = request.SalesofChurchItems,
                    donation = request.donation

                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<SourceofIncome> SingleSourceofIncome(int Id)
        {
            SourceofIncome sourceofIncomes = new SourceofIncome();
            try
            {
                var query = @"[GetSourceofIncome]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<SourceofIncome>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return sourceofIncomes;
            }
            return null;
        }

        public async Task<APIListResponse3<SourceofIncome>> GetSourceofIncomes(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<SourceofIncome>();
            try
            {
                var query = @"[GetAllSourceofIncome]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<SourceofIncome>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<SourceofIncome>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdateSourceofIncome(SourceofIncome request)
        {
            try
            {
                var query = @"[Update_SourceofIncome]";
                var param = new
                {
                    Offering = request.Offering,
                    Tithe = request.Tithe,
                    Vow = request.Vow,
                    SalesofChurchItems = request.SalesofChurchItems,
                    donation = request.donation
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
