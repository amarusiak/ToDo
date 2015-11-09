using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDo.Entities;

namespace ToDo.Repositories
{
    public interface ITaskRepository
    {
        List<TaskEntity> GetAll();
        List<TaskEntity> Add(string title);
        List<TaskEntity> Add(TaskEntity taskEntity);
        TaskEntity Get(int id);
        void Remove(int id);
    }
}
