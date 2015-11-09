using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDo.Entities;

namespace ToDo.Repositories
{
  public class FakeTaskRepository : ITaskRepository
  {
    //ITaskRepository _faketasktrepository;
    static List<TaskEntity> _faketasktrepository = null;
    //new List<TaskEntity>();

    static FakeTaskRepository()
    {
      //TaskEntity taskentity1 = new TaskEntity() {Id=1, Title="title1", IsDone=true};
      _faketasktrepository = new List<TaskEntity>();

      _faketasktrepository.Add(new TaskEntity() { Id = 1, Title = "title 1", IsDone = true });
      _faketasktrepository.Add(new TaskEntity() { Id = 2, Title = "title 2", IsDone = false });
      _faketasktrepository.Add(new TaskEntity() { Id = 3, Title = "title 3", IsDone = true });
    }

    //public FakeTaskRepository( ITaskRepository faketasktrepository)
    //{
    //    _faketasktrepository = faketasktrepository;
    //}

    public List<TaskEntity> GetAll()
    {
      List<TaskEntity> list = new List<TaskEntity>();

      foreach (var item in _faketasktrepository)
      {
        list.Add(item);
      }

      return list;
    }

    public List<TaskEntity> Add(string title)
    {
      TaskEntity taskEntity1 = new TaskEntity();

      int maxIndex = 0;
      foreach (TaskEntity te in _faketasktrepository)
	    {
		    maxIndex = (te.Id > maxIndex)?te.Id : maxIndex;
	    }

      taskEntity1.Id = maxIndex + 1;
        //Count + 1;
      taskEntity1.Title = title;
      taskEntity1.IsDone = false;

      _faketasktrepository.Add(taskEntity1);
      taskEntity1 = null;
      title = "";

      return _faketasktrepository;
    }

    public List<TaskEntity> Add(TaskEntity taskEntity2)
    {
      _faketasktrepository.Add(taskEntity2);

      return _faketasktrepository;
    }

    public void Remove(int id)
    {
      TaskEntity taskEntity = null;

      taskEntity = _faketasktrepository.Find(r => r.Id == id);
      _faketasktrepository.Remove(taskEntity);
      //_faketasktrepository.RemoveAll(r => r.Id == id);
    }

    public TaskEntity Get(int id)
    {
      //TaskEntity taskentity = _faketasktrepository[id];

      foreach (TaskEntity taskentity in _faketasktrepository)
      {
        if (taskentity.Id == id)
        {
          return taskentity;
        }
      }
      throw new ArithmeticException("ERROR : TaskEntity wrong Id");
    }

  }
}
