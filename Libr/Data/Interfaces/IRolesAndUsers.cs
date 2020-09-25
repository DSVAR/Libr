using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Interfaces
{
    public interface IRolesAndUsers<T> where T:class
    {
        //IEnumerable<T> GetUsers();
       // IEnumerable<T> GetRoles();

        void save();
        void AddRole(string name);
        Task UpUserAsync(string id,string role);
        Task downUser(string id);
        IEnumerable<T> allGetUser();
        Task<bool> GetRole(string id, string role);
  
    }
}
