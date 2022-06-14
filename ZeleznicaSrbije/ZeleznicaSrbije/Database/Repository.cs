using System.Collections.Generic;
using ZeleznicaSrbije.API.CRUD;

namespace ZeleznicaSrbije.Database.Repositories {
    internal class Repository<T> {
        private int nextInd;
        private List<T> entities;


        public void AddEntity(T entity) { 
            nextInd++;
            entities.Add(entity); 
        }

        public int NextInd { get => nextInd; set => nextInd = value; }
        public List<T> Entities { get => entities; set => entities = value; }
    }
}
