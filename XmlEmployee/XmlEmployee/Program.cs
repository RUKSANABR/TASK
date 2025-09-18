using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

class Program
{
    static bool isValid = true; //to track xml is valid

    static void Main()
    {
        string xmlPath = "employees.xml";
        string xsdPath = "employees.xsd";

        // Validating XML
        XmlReaderSettings settings = new XmlReaderSettings(); //create setting for reader setting 
        settings.Schemas.Add(null, xsdPath);  //add schema to that settings
        settings.ValidationType = ValidationType.Schema; //use xml file
        settings.ValidationEventHandler += (_,e) =>     //attach eventhandler to event
        {
            isValid = false;
            Console.WriteLine("Validation Error: " + e.Message);
        };

        using (XmlReader reader = XmlReader.Create(xmlPath, settings))
        {
            while (reader.Read()) { } //read xml node by node
        }

        if (!isValid)
        {
            Console.WriteLine("\nXML validation failed. Stopping program.");
            return;
        }

        Console.WriteLine("XML validated successfully!\n");

        // Load XML for XPath
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlPath);
        XPathNavigator nav = doc.CreateNavigator();

        Console.WriteLine("Employees in IT Department:");
        foreach (XPathNavigator emp in nav.Select("//Employee[Department='IT']/Name"))
            Console.WriteLine(emp);

        Console.WriteLine("\nEmployees with Salary > 50000:");
        foreach (XPathNavigator emp in nav.Select("//Employee[Salary>50000]/Name"))
            Console.WriteLine(emp);


        XmlNode firstEmployee = doc.SelectSingleNode("//Employee");
        if (firstEmployee != null)
        {
            Console.WriteLine("Tags:");

            foreach (XmlNode child in firstEmployee.ChildNodes)
            {
                Console.WriteLine(child.Name);
            }
        }


        Console.WriteLine("\nEmployees who joined after 01-01-2020:");
        DateTime cutoff = new DateTime(2020, 1, 1);
        foreach (XPathNavigator emp in nav.Select("//Employee"))
        {
            string dateStr = emp.SelectSingleNode("JoiningDate")?.Value;
            if (DateTime.TryParse(dateStr, out DateTime joinDate) && joinDate > cutoff)
            {
                Console.WriteLine(emp.SelectSingleNode("Name").Value);
            }
        }
    }
}