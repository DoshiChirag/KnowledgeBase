using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;


    public class CLRFunction
    {
        [SqlFunction(IsDeterministic = true, IsPrecise = true)]
        public static string Hello(string UserName)
        {
            string strResponse = $"Hello {UserName}";
            return strResponse;
        }
    }

