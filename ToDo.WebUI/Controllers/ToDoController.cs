using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ToDo.Entities;
using ToDo.Repositories;
using ToDo.WebUI.Models;

namespace ToDo.WebUI.Controllers
{
  public class ToDoController : Controller
  {
    private ITaskRepository _taskRepository;

    #region Constructors
    public ToDoController()
    {
      //  reference to 1 ! static FakeRepository
      this._taskRepository = new FakeTaskRepository();
    }
    #endregion

    //
    // GET: /ToDo/
    [HttpGet]
    public ActionResult Index()
    {
      FakeTaskRepository repository = new FakeTaskRepository();

      ViewBag.tasks = repository.GetAll();

      //return View(repository);
      return View();
    }

    //public ViewResult Index()
    //{
    //    int hour = DateTime.Now.Hour;
    //    ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
    //    return View();
    //}

    [HttpPost]
    //public ViewResult Index(string txtTitle="")
    public ActionResult Index(string txtTitle="")
    {

      #region Model Usage
      //if (ModelState.IsValid)
      //{
      //    // TODO: Email response to the party organizer
      //    return View("Thanks", taskModifier);
      //}
      //else
      //{
      //    // there is a validation error
      //    return View();
      //}
      #endregion

      //FakeTaskRepository repository = new FakeTaskRepository();

      #region Validation
      if (String.IsNullOrWhiteSpace(txtTitle) || String.IsNullOrEmpty(txtTitle))
      {
        ViewBag.Error = "ERROR : The task title can not be empty!";
        txtTitle = null;
      }
      else if (txtTitle.Length > 10)
      {
        ViewBag.Error = "ERROR : The task title can not be more 10 symbols!";
        txtTitle = null;
      }
      else if (!String.IsNullOrEmpty(txtTitle))
      {
        _taskRepository.Add(txtTitle);
        txtTitle = "";
      }
      #endregion

      #region Old validation
      //if (!String.IsNullOrEmpty(txtTitle))
      //{
      //  _taskRepository.Add(txtTitle);
      //} 
      #endregion

      ViewBag.Tasks = this._taskRepository.GetAll();

      //return View();
      return RedirectToAction("Index");
    }

    // -------------------------------------------------------
    [HttpPost]
    public ActionResult Delete(int taskId)
    {
      _taskRepository.Remove(taskId);

      //    Add(txtTitle);
      ViewBag.Tasks = this._taskRepository.GetAll();

      return RedirectToAction("Index");
    }
    // ------------------------------------------------------

    [HttpGet]
    public ActionResult Edit(int id)
    {
      FakeTaskRepository repository = new FakeTaskRepository();
      TaskEntity taskEntity = repository.Get(id);

      //return View(repository);
      return View(taskEntity);
    }

    [HttpPost]
    public ActionResult Edit(TaskModel taskModel)
    {
        if (ModelState.IsValid)
        {
            TaskEntity taskEntity3 = new TaskEntity();
            taskEntity3.Id = taskModel.Id;
            taskEntity3.Title = taskModel.Title;
            taskEntity3.IsDone = (bool)taskModel.IsDone;

            _taskRepository.Add(taskEntity3);

            //_taskRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(taskModel);
        
        //if (editFinish == "Cancel")
        //{
        //    return RedirectToAction("Index");
        //}

        //return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Save(TaskModel taskModel)
    {
      if (ModelState.IsValid)
      {
        //this._taskRepository.Add(
        //_taskRepository.Add(taskModel);


        //_taskRepository.SaveChanges();
        return RedirectToAction("Index", new { id = taskModel.Id });
      }
      return View(taskModel);
    }


    [HttpPost]
    public ActionResult Cancel()
    {
      //if (editFinish == "Cancel")
      //{
      //    return RedirectToAction("Index");
      //}
      return RedirectToAction("Index");
    }

    public ActionResult ChangeStatus(int taskId, bool isDone)
    {
        //  execute repository
        //throw new Exception("FAILED !");

        return new EmptyResult();
    }

    [HttpPost]
    public ActionResult TasksPartial(string taskStatus)
    {
        List<TaskEntity> tasks2 = _taskRepository.GetAll().Where(m => m.IsDone).ToList();

        return PartialView("TasksPartial", tasks2);
    }
  }
}
