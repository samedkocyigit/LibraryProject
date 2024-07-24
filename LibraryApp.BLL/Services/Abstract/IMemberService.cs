using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services.Abstract
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAllMembers();
        Member GetMemberById(int id);
        Member ValidateUser(string username, string password);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
    }
}
