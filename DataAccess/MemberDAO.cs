using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{   
    public class MemberDAO
    {

        private static MemberDAO instance=null;
        public static readonly object instanceLock = new object();

        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new MemberDAO();
                }
                return instance;
            }
        }
        public List<Member> GetMembers()
        {
            List<Member> members;
            try
            {
                var context = new FStoreContext();
                members = context.Members.ToList();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;
        }

        public Member GetMemByID(int memId)
        {
            Member member = null;
            try
            {
                var myStockDB = new FStoreContext();
                member = myStockDB.Members.SingleOrDefault(car => car.MemberId == memId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void Register(Member member)
        {
            try
            {
                Member m = GetMemByID(member.MemberId);
                if (m != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.Members.Add(member);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateMember(Member member)
        {
            try
            {
                Member m=GetMemByID(member.MemberId);
                if (m != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.Entry<Member>(m).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoveAcc(Member member)
        {
            try
            {
                Member m = GetMemByID(member.MemberId);
                if (m != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.Members.Remove(member);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Member Login(string acc,string pass)
        {
            Member member = null;
            try
            {
                var myStockDB = new FStoreContext();
                member = myStockDB.Members.Where(m => m.Email == acc && m.Password == pass).FirstOrDefault();
                if (member != null)
                {
                    return member;
                }
                else
                {
                    return null;
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
