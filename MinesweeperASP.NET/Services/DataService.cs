using MinesweeperASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Services
{
    public class DataService
    {
        DataDAO dao = new DataDAO();

        public List<gridDTO> retrieveData()
        {
            // return true if found in the list
            return dao.retrieveData();
        }
        public bool Save(gridDTO dto)
        {
            //serialize board and save to database

            return dao.save(dto);
        }
        public gridDTO Load()
        {
            //serialize board and save to database

            return dao.load();
        }
        /*public bool AddAccountToDatabase(userModel user)
        {
            // If true send user details to the database
            return usersDAO.AddAccountToDatabase(user);
        }*/
    }
}
