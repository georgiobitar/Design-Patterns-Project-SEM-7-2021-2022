using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBaseFactory
{
    public class DataBaseFactory 
    {
        public string ChooseDbContext()
        {
            var db = Reader.ReadContextChoice();

            if (db == 1)
                return "Name=DesignDatabase";

            else
                return "Name=DesignDatabase2";
        }
    }

}
