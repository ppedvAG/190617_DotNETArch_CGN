using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektorientiertesProgrammieren_Demo
{
    class LoggingRepository<T> : IRepository<T> // wie IComponent
    {
        public LoggingRepository(IRepository<T> parentRepo)
        {
            this.parentRepo = parentRepo;
        }
        private readonly IRepository<T> parentRepo;

        private void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: {message}");
            Console.ResetColor();
        }

        public void Add(T item)
        {
            Log("Logger: Vor dem Add()");
            parentRepo.Add(item);
            Log("Logger: Nach dem Add()");
        }
        public void Delete(T item)
        {
            Log("Logger: Vor dem Delete()");
            parentRepo.Delete(item);
            Log("Logger: Nach dem Delete()");
        }
        public IEnumerable<T> GetAll()
        {
            Log("Logger: Vor dem GetAll()");
            var result = parentRepo.GetAll();
            Log("Logger: Nach dem GetAll()");
            return result;
        }
        public T GetByID(int id)
        {
            Log("Logger: Vor dem GetByID()");
            var result = parentRepo.GetByID(id);
            Log("Logger: Nach dem GetByID()");
            return result;
        }
        public void Save()
        {
            Log("Logger: Vor dem Save()");
            parentRepo.Save();
            Log("Logger: Nach dem Save()");
        }
        public void Update(T item)
        {
            Log("Logger: Vor dem Update()");
            parentRepo.Update(item);
            Log("Logger: Nach dem Update()");
        }
    }
}
