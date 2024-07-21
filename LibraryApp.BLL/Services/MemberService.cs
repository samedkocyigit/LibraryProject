using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services
{
    public class MemberService
    {
        private readonly IGenericRepository<Member> _memberRepository;
        public MemberService(IGenericRepository<Member> memberRepository)
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


    }
}
