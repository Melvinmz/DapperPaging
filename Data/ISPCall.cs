using System;
using System.Collections.Generic;
using Dapper;
namespace DapperPaging.Data
{
    public interface ISPCall : IDisposable
        {
            IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null);          
        }    
}
