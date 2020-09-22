using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Interfaces
{
    public interface IRolesAndUsers<T> where T:class
    {
        IEnumerable<T> GetUsers();
        //IEnumerable<T> GetRoles();

        void save();
        void AddRole(string name);
        Task UpUserAsync(T users,string role);
        void downUser(int id);
  
    }
}
