using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Models
{
    public class gridDTO
    {
        //[Required]
  
        public int ID { get; set; }

    
        public string JSONString { get; set; }

        public DateTime date { get; set; }
        public int userID { get; set; }

        public gridDTO(int id, string JSONstring, DateTime Date, int userid)
        {
            ID = id;
            JSONString = JSONstring;
            date = Date;
            userID = userid;

        }
        public gridDTO()
        {
            ID = 1;
            JSONString = "{}";
            date = DateTime.Now;
            userID = 0;

        }

    }
}
