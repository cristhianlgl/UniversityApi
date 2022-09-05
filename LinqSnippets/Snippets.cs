using System.Linq;
using System.Collections;

namespace LinqSnippets
{
    public class Snippets
    {
        public static void LinqBasic()
        {
            string[] cars = new string[]
            {
                "VM Golf",
                "VM California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            //1. Select * from Cars (All cars)
            var carsList = from car in cars select car;
            foreach (var car in carsList)
            {
                Console.WriteLine(car);
            }

            //1. Select where car is audi
            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }

        public static void LinqNumbers()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // each Number multipled by 3
            // take all numbers, but 9
            // order number by ascending value
            var processedNumberList = numbers
                    .Select(x => x * 3)
                    .Where(x => x != 9)
                    .OrderBy(x => x);
        }

        public static void SearchExamples()
        {
            List<string> textList = new List<string>()
            {
                "a", "bx", "c", "d", "e", "cj", "f", "c"
            };

            //1. Firts of all elements
            var firstElement = textList.First();

            //2. Firts elemente that is "c"
            var cFirstElement = textList.First(x => x.Equals("c"));

            //3. Firts elemente that contain "j"
            var jFirstElement = textList.First(x => x.Contains("j"));

            //4. Firts or Default elemente that contains "z"
            var zFirstOrDefaultElement = textList.FirstOrDefault(x => x.Contains("z"));

            //5. Last or Default elemente that contains "z"
            var zLastOrDefaultElement = textList.LastOrDefault(x => x.Contains("z"));

            //6. Single Values
            var uniqueElement = textList.Single();
            var uniqueOrDefaultElement = textList.SingleOrDefault();

            int[] evenNumbers = new int[] { 0, 2, 4, 6, 8 };
            int[] otherNumbers = new int[] { 0, 2, 6 };

            //obtain [ 4, 8 ]
            var myEvenNumbers = evenNumbers.Except(otherNumbers);

        }

        public static void MultipleSelects()
        {
            // select Many
            string[] myOpinions = new string[]
            { 
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionsSelection = myOpinions.SelectMany(x => x.Split(","));

            var enterprise = new List<Enterprise>()
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Empresa 1",
                    Employees = new Employee[]
                    {
                        new Employee()
                        { 
                            Id = 1,
                            Name = "Juan",
                            Salary = 1000,
                            Email = "Juan@example.com"
                        },
                        new Employee()
                        {
                            Id = 2,
                            Name = "Camilo",
                            Salary = 1500,
                            Email = "Camilo@example.com"
                        },
                        new Employee()
                        {
                            Id = 3,
                            Name = "Martin",
                            Salary = 2000,
                            Email = "Martin@example.com"
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Empresa 2",
                    Employees = new Employee[]
                    {
                        new Employee()
                        {
                            Id = 4,
                            Name = "Daniela",
                            Salary = 1700,
                            Email = "Daniela@example.com"
                        },
                        new Employee()
                        {
                            Id = 5,
                            Name = "Patricia",
                            Salary = 3500,
                            Email = "Patricia@example.com"
                        },
                        new Employee()
                        {
                            Id = 6,
                            Name = "Ana",
                            Salary = 2000,
                            Email = "Ana@example.com"
                        }
                    }

                }
            };

            // obtain all employees of all enterprises
            var employeesList = enterprise.SelectMany(x => x.Employees);

            // know if any list is empty
            bool hasEnterprise = enterprise.Any();

            bool hasEmployees = enterprise.Any(x => x.Employees.Any());

            // all enterprises at least has an employee with at least 1000 of salary
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 = enterprise
                    .Any(enterprise => enterprise.Employees
                        .Any(employee => employee.Salary >= 1000));

        }

        public static void LinqColletions()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // Inner Join
            var commonElements =  from firstElement in firstList
                                  join secondElement in secondList
                                  on firstElement equals secondElement
                                  select new {firstElement, secondElement };
            
            var commonElements2 = firstList.Join(
                    secondList,
                    firstElement => firstElement,
                    secondElement => secondElement,
                    (firstElement, secondElement) => new { firstElement, secondElement }
                );

            // Outer left join
            var outerLeftJoin = from firstElement in firstList
                                join secondElement in secondList
                                on firstElement equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where firstElement != temporalElement
                                select new { element = firstElement };

            // Outer Right join
            var outerRighttJoin = from secondElement in secondList
                                join firstElement in firstList
                                on secondElement equals firstElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { element = secondElement };

            // Union 
            var unionList = outerLeftJoin.Union(outerRighttJoin);



        }

        public static void SkipTakeLinq()
        {
            var myList = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var skipTwoFirstValues = myList.Skip(2);
            var skipTwoLastValues = myList.SkipLast(2);
            var skipWhile = myList.SkipWhile(x => x < 4);

            var takeTwoFirstValues = myList.Take(2);
            var takeTwoLastValues = myList.TakeLast(2);
            var takeWhile = myList.TakeWhile(x => x < 4);

        }
    }
}