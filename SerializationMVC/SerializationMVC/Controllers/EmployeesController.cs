using Microsoft.AspNetCore.Mvc;
using SerializationMVC.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SerializationMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly string dataFolder; //stores full path to the App_Data.
        private readonly string xmlFilePath; //stores the full path to the XML file 

        public EmployeesController()
        {
            dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");  //Combines the current project root folder with App_Data 
            if (!Directory.Exists(dataFolder)) Directory.CreateDirectory(dataFolder);
            xmlFilePath = Path.Combine(dataFolder, "employees.xml");
        }

        public IActionResult Index()
        {
            var employees = new List<Employee>(); //if xml file exist then the list will be shown

            if (System.IO.File.Exists(xmlFilePath))
            {
                using (var fs = new FileStream(xmlFilePath, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(List<Employee>));
                    employees = (List<Employee>)serializer.Deserialize(fs);
                }
            }

            return View(employees);
        }

        [HttpPost]
        public IActionResult CreateAndSerialize()
        {
            var employees = new List<Employee>
            {
                new Employee{ Id=1, Name="Ruksana", Department="HR", Salary=50000 },
                new Employee{ Id=2, Name="Joel", Department="IT", Salary=60000 },
                new Employee{ Id=3, Name="Steffy", Department="Finance", Salary=55000 },
                new Employee{ Id=4, Name="Amala", Department="IT", Salary=40000 },
                new Employee{ Id=5, Name="Appu", Department="IT", Salary=35000 },
            };

            using (var fs = new FileStream(xmlFilePath, FileMode.Create))  // if file exist it be overwritten if not then create
            {
                var serializer = new XmlSerializer(typeof(List<Employee>));  //Creates an instance of the XmlSerializer class.
                serializer.Serialize(fs, employees);
            }

            TempData["Message"] = "Employees serialized to employees.xml successfully!";
            return View("Index", new List<Employee>()); // empty list
        }

        [HttpPost]
        public IActionResult DeserializeEmployees()
        {
            var employees = new List<Employee>();

            if (System.IO.File.Exists(xmlFilePath))
            {
                using (var fs = new FileStream(xmlFilePath, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(List<Employee>));
                    employees = (List<Employee>)serializer.Deserialize(fs);
                }

                TempData["Message"] = "Employees deserialized from XML successfully!";
            }
            else
            {
                TempData["Message"] = "No XML file found. Please serialize first.";
            }

            return View("Index", employees);
        }
    }
}
