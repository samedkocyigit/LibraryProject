using LibraryApp.BLL.Services.Abstract;
using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services
{
    public class MemberService:IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetAll();
        }
        public Member GetMemberById(int id)
        {
            return _memberRepository.GetById(id);
        }
        public Member ValidateUser(string username,string password)
        {
            return _memberRepository.GetAll()
                                           .FirstOrDefault(m => m.Username == username && m.Password == password);
        }
        public void AddMember(Member member)
        {
            _memberRepository.Insert(member);
        }
        public void UpdateMember(Member member)
        {
            _memberRepository.Update(member);
        }
        public void DeleteMember(int id)
        {
            var member = _memberRepository.GetById(id);
            if (member!=null)
            {
                _memberRepository.Delete(member);
            }
        }
        public Member Authenticate(string username, string password)
        {
            var member = _memberRepository.GetAll().FirstOrDefault(m => m.Username == username && m.Password == password);
            return member;
        }
    }
}
