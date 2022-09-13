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

        //paging with skip and take
        public static IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage )
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        //variables
        public static void LinqVariables()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Average: {0}", numbers.Average());
            foreach (var number in aboveAverage)
            {
                Console.WriteLine("Number: {0}, Squared: {1}",number, Math.Pow(number, 2));
            }
        }

        //Zip
        public static void ZipLinq()
        { 
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            var stringNumbers = new string[] { "one", "two", "three", "four", "five" };

            var resultZip = numbers.Zip(stringNumbers, (number, text) => $"{number}={text}");

            //{"1=one", "2=two", ...}
        }

        //Repeat and range
        public static void RepeatRangeLinq()
        {
            //generate collection from 1 - 1000
            var first1000 = Enumerable.Range(1, 1000);

            //repeat a value N times
            var repeatX = Enumerable.Repeat("X", 5); //{"X", "X", "X", "X", "X"}

        }

        public static List<Student> GetStudents()
        { 
            return new List<Student>()
            {
                new Student()
                {
                    Id= 1, Name = "Andres",Grade = 54, Certified = false
                },
                new Student()
                {
                    Id= 2, Name = "Camilo",Grade = 95, Certified = true
                },
                new Student()
                {
                    Id= 3, Name = "Marcos",Grade = 20, Certified = false
                },
                new Student()
                {
                    Id= 4, Name = "Ana",Grade = 80, Certified = true
                },
                new Student()
                {
                    Id= 5, Name = "Maria",Grade = 35, Certified = false
                },
                new Student()
                {
                    Id= 6, Name = "Pablo",Grade = 42, Certified = false
                },
            };
        }

        public static void StudentLinq()
        {
            List<Student> students = GetStudents();

            //obtain students that are certified
            var certifiedStudent = from student in students
                                   where student.Certified
                                   select student;

            var notCertifiedStudent = from student in students
                                   where !student.Certified
                                   select student;

            var approvedStudentName = from student in students
                                      where student.Grade >= 50 && student.Certified
                                      select student.Name;

        }

        //all
        public static void AllLinq()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            bool allAreSmallerThan10 = numbers.All(x => x < 10); //true
            bool allAreBiggerOrEqualsThan2 = numbers.All(x => x >= 2); //false

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = emptyList.All(x => x >= 0); //true
        }

        //aggregate
        public static void AggregateQueries()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //sum  all numbers 
            int sumNumbers = numbers.Aggregate((prevSum, current) => prevSum + current);

            string[] words = new string[] { "Hello", "my", "name", "is", "cristian" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);
        }

        // Distinct
        public static void DistinctLinq()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4 };
            IEnumerable<int> distinctValues = numbers.Distinct();

        }

        // Group by
        public static void GroupByLinq()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //obtain only even numbers  and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            foreach (var group in grouped)
            {
                foreach (var item in group)
                {
                    Console.WriteLine(item); // 1,3,5,7,9 ... 2,4,6,8,10 (first the odd numbers then the even numbers)
                }
            }

            List<Student> students = GetStudents();
            var certifiedGroups = students.GroupBy(x => x.Certified);
            //we obtain two group
            //1. non-certified students  
            //2. certified students 
            foreach (var group in certifiedGroups)
            {
                foreach (var item in group)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }


        public static void RelationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1 ,
                    Title = "First post",
                    Content= "Content",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        { Id = 1 , Title = "first comment", Content = "first comment content"},
                        new Comment()
                        { Id = 2 , Title = "second comment", Content = "second comment content"},
                    }
                },
                new Post()
                {
                    Id = 2 ,
                    Title = "Second post",
                    Content= "Content",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        { Id = 3 , Title = "other comment", Content = "other content"},
                        new Comment()
                        { Id = 4 , Title = "New comment", Content = "New content"},
                    }
                }
            };

            var commentWithContent = posts
                .SelectMany(post => post.Comments,
                    (post, comment) => new { postID = post.Id, ContentComment = comment.Content});
        }

    }
}