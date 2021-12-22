using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_ASP.NET_Nhom7.Models;
using PagedList;

namespace BTL_ASP.NET_Nhom7.DAO
{
    public class UserDAO
    {
        WineStoreDB db = null;
        public UserDAO()
        {
            db = new WineStoreDB(); 
        }
        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.UserId;
        }
        public bool Update(User entity)
        {
            try
            {

                var user = db.User.Find(entity.UserId);
                user.UserName = entity.UserName;
                user.Password = entity.Password;    
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedDate = DateTime.Now;
                user.Status = entity.Status;
                user.Address = entity.Address;
                user.GroupId = entity.GroupId;
                db.SaveChanges();
                return true; 
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.User.ToPagedList(page , pageSize);
        }
        public User GetById(string Username)
        {
            return db.User.SingleOrDefault(x=>x.UserName == Username);
        }
        public User VieweDetails(int id)
        {
            return db.User.Find(id);

        }
        public int Login(string userName, string passWord)
        {
            var res = db.User.Count(x => x.UserName == userName && x.Password == passWord &&  x.GroupId == 1);
            if(res == 0)
            {
               return 0;

            }
            else
            {
                return 1;
                        //if (res.Password == passWord)
                        //    return 1;
                        //else
                        //    return -2;
            }    
        }
    }
}