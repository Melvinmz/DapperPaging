using Dapper;
using DapperPaging.Data;
using DapperPaging.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPaging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISPCall _SPCall;
        private readonly ApplicationDBContext _context;
        public PagingData PagingData { get; set; }
        [BindProperty]
        public IList<Employee> Employees { get; set; }
        private const int PageSize = 10;

        public IndexModel(ILogger<IndexModel> logger, ISPCall SPCall, ApplicationDBContext context)
        {
            _logger = logger;
            _SPCall = SPCall;
            _context = context;
        }

        public void OnGet(int PageNum = 1)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@PageNum", PageNum, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@pageSize", PageSize, DbType.Int32, ParameterDirection.Input);           

            Employees = _SPCall.ReturnList<Employee>("DapperPaging_Employee_GetAll", parameter).ToList<Employee>();

           
            StringBuilder QParam = new StringBuilder();
            if (PageNum != 0)
            {
                QParam.Append($"/Index?PageNum=-");

            }
            if (Employees.Count > 0)
            {
                PagingData = new PagingData
                {
                    CurrentPage = PageNum,
                    RecordsPerPage = PageSize,
                    TotalRecords = Employees[0].TotalRows,
                    UrlParams = QParam.ToString(),
                    LinksPerPage = 5
                };               
            }
        }
    }
}
