using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IntroductionToCSharp;
using System.Xml.Linq;
using MathComponenetProject;


    class Program
    {
        static void Main()
        {
            string[] words = { "hello", "world" , "Boxer" , "Tiger"};
            var l = words.Where(w => w.Length >= 5);
           // var lengthofwords = from w in words where w.Length >= 5 select w;
            foreach (var i in l)
            {
                Console.WriteLine(i);
            }


          //  Query Operators  are select ,  where and orderby  and it always starts with From

            int[] scores = new int[] { 12, 34, 56, 2, 38, 2, 56 };

            IEnumerable<int> scorequery = from score in scores where score >= 20 select score;

            foreach( int i in scorequery)
            {
                Console.WriteLine(i);
            }

            NORTHWNDEntities db = new NORTHWNDEntities();

            var employee = from emp in db.Employees where emp.Country == "USA" select emp;

            foreach ( var i in employee)
            {
                Console.WriteLine(i.EmployeeID.ToString());
            }

            // Substring
            string[] filteringWords = { "new", "Islam", "religion" , "Developer" };

            var le = from w in filteringWords where w.Length >= 3 select w.Substring(0,3);

            foreach (var i in le)
            {
                Console.WriteLine(i);
            }

            // Join
            var list = from e in db.Employees
                       join d in db.Orders on e.EmployeeID equals d.EmployeeID
                       select new
                       {
                           EmployeeName = e.FirstName,
                           OrdersName = d.Customer.Country
                       };

            foreach (var ab in list)
            {
                Console.WriteLine(ab.EmployeeName);
            }

            var lis = from c in db.Customers join d in db.Orders on c.CustomerID equals d.CustomerID select
                          new { 
                                                    customerName = c.CustomerID,
                                                    orderName = d.OrderID
                         };
            foreach (var abe in lis)
            {
                Console.WriteLine(abe);
            }

            // Split 

            List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };            var ldf = from phrase in phrases                      from word in phrase.Split(' ')                      select word;
            var emf = from el in ldf orderby el descending select el;
            foreach (var i in ldf)
            {
                Console.WriteLine(i);
            }

            // Order By
            int[] num = { -20, 12, 6, 10, 0, -3, 1 };            var ev = from number in num orderby number descending select number;
            foreach (var i in ev)
            {
                Console.WriteLine(i);
            }
            foreach (var i in emf)
            {
                Console.WriteLine(i);
            }

            List<int> numbers = new List<int>() { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };

            IEnumerable<IGrouping<int, int>> query = from q in numbers group q by q % 2;

            foreach (var group in query)
            {
                Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
                foreach (int i in group)
                    Console.WriteLine(i);
            }


            IEnumerable<string> names = (from s in db.Products select s.ProductName).Concat(from e in db.Employees select e.FirstName);

            foreach (string ls in names)
            {
                Console.WriteLine(ls);
            }


            int[] inl = new int[] { 1 , 2 , 3,  4};

            var aggre = inl.Aggregate((a, b) => b + a);

            var gree = inl.Aggregate((a, b) => a * b);
            var gree1 = inl.Count();
            var avg = inl.Average();
            var max = inl.Max();
            var min = inl.Min();
            Console.WriteLine(aggre);
            Console.WriteLine(gree);
            Console.WriteLine(gree1);
            Console.WriteLine(avg);
            Console.WriteLine(max);
            Console.WriteLine(min);

            //quantifiers ALL, ANY , CONTAINS

            int[] ind = new int[] {4,5,6,7,2,1 };
            bool eh = filteringWords.Contains("new");

            bool be = ind.All(e => e >= 2);
            bool eb = ind.All(e => e >= 1);

            bool findany = ind.Any(e=> e==7);

            Console.WriteLine(be);
            Console.WriteLine(eb);
            Console.WriteLine(findany);
            Console.WriteLine(eh);

            //Partition Operators SKIP , SKIPWHILE , TAKE , TAKEWHILE
            int[] array = { 1, 3, 5, 7, 9, 11 };
            var skip = array.Skip(3);
            foreach (var value in skip)
            {
                Console.WriteLine(value);
            }
            var skipall = array.SkipWhile(e => e < 7);
            foreach (var value1 in skipall)
            {
                Console.WriteLine(value1);
            }

            List<string> reverse = new List<string> { "Tiger", "Lion", "Cat", "Hen" };
            var rev = reverse.Reverse<string>().Take(2);
            foreach (string s in rev)
            {
                Console.WriteLine(s);
            }

            int[] val = { 1, 3, 5, 8, 10 };

            var rest = val.TakeWhile(item => item % 2 != 0);
            foreach(int vale in rest)
            {
                Console.WriteLine(vale);
            }

            //Generation Operations  DEFAULTIFEMPTY , EMPTY , RANGE , REPEAT

            // Empty list.
            List<int> liste = new List<int>();
            var result = liste.DefaultIfEmpty();

            // One element in collection with default(int) value.
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }

            result = liste.DefaultIfEmpty(-1);

            // One element in collection with -1 value.
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }


            IEnumerable<string> strings = Enumerable.Repeat("I like programming.", 3);

            foreach (String str in strings)
            {
                Console.WriteLine(str);
            }

            //Set Operations DISTINCT , INTERSECT , EXCEPT , UNION

            int[] array1 = { 1, 2, 2, 3, 4, 4 };
            // Invoke Distinct extension method.
            var result2= array1.Distinct();
            // Display results.
            foreach (int value in result2)
            {
                Console.WriteLine(value);
            }

            // Assign two arrays.
            int[] array12= { 1, 2, 3 };
            int[] array2 = { 2, 3, 4 };
            // Call Intersect extension method.
            var intersect = array12.Intersect(array2);
            // Write intersection to screen.
            foreach (int value in intersect)
            {
                Console.WriteLine(value);
            }

            int[] values1 = { 1, 2, 3, 4 };

            // Contains three values (1 and 2 also found in values1).
            int[] values2 = { 1, 2, 5 };

            // Remove all values2 from values1.
            var resulte = values1.Except(values2);

            // Show.
            foreach (var element in resulte)
            {
                Console.WriteLine(element);
            }

            int[] array3 = { 1, 2, 3 };
            int[] array4 = { 2, 3, 4 };
            // Union the two arrays.
            var resultr = array3.Union(array4);
            // Enumerate the union.
            foreach (int value in resultr)
            {
                Console.WriteLine(value);
            }


           // Element Operators ELEMENTAT , ELEMENTATORDEFAULT

            int[] array34 = { 4, 5, 6 };
            int k = array34.ElementAtOrDefault(1);
            int r = array34.ElementAtOrDefault(-1);
            Console.WriteLine(r);
            Console.WriteLine(k);


            string myXML = @"<Departments>
                             <Department>Account</Department>
                             <Department>Sales</Department>
                             <Department>Pre-Sales</Department>
                             <Department>Marketing</Department>
                             </Departments>";
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(myXML);
            var results = xdoc.Element("Departments").Descendants();
            foreach (XElement item in results)
            {
                Console.WriteLine("Department Name - " + item.Value);
            }

            //encapsulation
            Bike bike = new Bike();


            Console.WriteLine("Bike mileage is : " + bike.GetMileage()); //accessible outside "Bike"
            Console.WriteLine("Bike color is : " + bike.GetColor()); //accessible outside "Bike"
            //we can't call this method as it is inaccessible outside "Bike"
            //objBike.GetEngineMakeFormula(); //commented because we can't access it
            Console.WriteLine("Bike color is : " + bike.DisplayMakeFormula()); //accessible outside
            



            //Inheritance
            Child objChild = new Child();
            //Child class don't have DisplayMessage() method but we inherited from "Base" class
            objChild.DisplayMessage();
            Console.Read();


            //PolyMorphism Method Overloading - COmpile time polymorphism

            Base objBase = new Base();
            int values = 7;
            Console.WriteLine(objBase.Display(values));


            //PolyMorphism Method Overriding - Runtime Polymorphism

            Base objBase1 = new Child();
            Console.WriteLine(objBase1.BlogName());
            Console.Read();
           
        }
    }

