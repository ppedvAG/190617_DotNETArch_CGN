using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektorientiertesProgrammieren_Demo
{
    enum User
    {
        ReadOnlyUser,
        RegualUser,
        Admin,
    }
    class AuthRepositoriy<T> : IRepository<T>
    {
        public AuthRepositoriy(IRepository<T> parentRepo, User currentUser)
        {
            this.currentUser = currentUser;
            this.parentRepo = parentRepo;
        }
        private readonly IRepository<T> parentRepo;
        private readonly User currentUser;

        private void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: {message}");
            Console.ResetColor();
        }

        public void Add(T item)
        {
            if (currentUser == User.ReadOnlyUser)
            {
                Log($"Add-Operation for user {currentUser.ToString()} not allowed");
                return;
            }
            else
                parentRepo.Add(item);
        }

        public void Delete(T item)
        {
            if (currentUser == User.ReadOnlyUser || currentUser == User.RegualUser)
            {
                Log($"Delete-Operation for user {currentUser.ToString()} not allowed");
                return;
            }
            else
                parentRepo.Delete(item);
        }

        public IEnumerable<T> GetAll()
        {
            return parentRepo.GetAll();
        }

        public T GetByID(int id)
        {
            return parentRepo.GetByID(id);
        }

        public void Save()
        {
            if (currentUser == User.ReadOnlyUser)
            {
                Log($"Save-Operation for user {currentUser.ToString()} not allowed");
                return;
            }
            else
                parentRepo.Save();
        }

        public void Update(T item)
        {
            if (currentUser == User.ReadOnlyUser)
            {
                Log($"Update-Operation for user {currentUser.ToString()} not allowed");
                return;
            }
            else
                parentRepo.Update(item);
        }
    }
}
