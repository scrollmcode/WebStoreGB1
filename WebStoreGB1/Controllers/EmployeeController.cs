using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStoreGB1.ViewModels;
using WebStoreGB1.Infrastructure.Interfaces;

namespace WebStoreGB1.Controllers
{
    [Route("users")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService _employeesService;

        private readonly IConfiguration _configuration;

        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Employees)); ;
        }

        [Route("all")]
        public IActionResult Employees()
        {
            ViewData["Title"] = "Сотрудники";
            return View(_employeesService.GetAll());
        }

        [Route("{id}")]
        public IActionResult EmployeeDetails(int id)
        {
            //Получаем сотрудника по Id
            var employee = _employeesService.GetById(id);

            //Если такого не существует
            if (employee == null)
                return NotFound(); // возвращаем результат 404 Not Found

            //Иначе возвращаем сотрудника
            return View(employee);
        }

        /// <summary>
        /// Добавление или редактирование сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new EmployeeViewModel());

            var model = _employeesService.GetById(id.Value);
            if (model == null)
                return NotFound();// возвращаем результат 404 Not Found

            return View(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model.Id > 0) // если есть Id, то редактируем модель
            {
                var dbItem = _employeesService.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();// возвращаем результат 404 Not Found

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Position = model.Position;
            }
            else // иначе добавляем модель в список
            {
                _employeesService.AddNew(model);
            }
            _employeesService.Commit(); // станет актуальным позднее (когда добавим БД)

            return RedirectToAction(nameof(Employees));
        }


        [Route("delete/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
                _employeesService.Delete(id.Value);
            else
                return NotFound();

            return RedirectToAction(nameof(Employees));
        }

    }
}