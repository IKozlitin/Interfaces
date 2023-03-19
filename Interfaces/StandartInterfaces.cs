using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace InterfacesWPU221
{
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: {Series} {Number}\n";
        }
    }

    class Student : IComparable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string group { get; set; }
        public string magicSpeciality { get; set; }
        public string magicWand { get; set; }
        public StudentCard StudentCard { get; set; }

        public override string ToString()
        {
            return $"Имя: {firstName}\nФамилия: {lastName}\nДата рождения: {birthDate.ToLongDateString()}\nФакультет: {group}\nМагия: {magicSpeciality}\nВолщебная палочка: {magicWand}\n" + StudentCard.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return lastName.CompareTo((obj as Student).lastName);
            }
            throw new NotImplementedException();
        }
    }

    class Auditory : IEnumerable
    {
        Student[] students =
        {
            new Student
            {
                firstName="Harry",
                lastName="Potter",
                birthDate=new DateTime(1981,07,31),
                group="Gryffindor",
                magicSpeciality="Light",
                magicWand="Phoenix Feather",
                StudentCard=new StudentCard
                {
                    Number=19810731,
                    Series="HP"
                }
            },
            new Student
            {
                firstName="Drako",
                lastName="Malfoy",
                birthDate=new DateTime(1981,10,23),
                group="Slytherin",
                magicSpeciality="Poison",
                magicWand="Unicorn hair",
                StudentCard=new StudentCard
                {
                    Number=19811023,
                    Series="DM"
                }
            },
            new Student
            {
                firstName="Polumna",
                lastName="Lovegood",
                birthDate=new DateTime(1985,03,15),
                group="Hufflepuff",
                magicSpeciality="Earth",
                magicWand="Birch",
                StudentCard=new StudentCard
                {
                    Number=19850315,
                    Series="PL"
                }
            },
            new Student
            {
                firstName="Cedrick",
                lastName="Diggory",
                birthDate=new DateTime(1980,09,25),
                group="Ravenclaw",
                magicSpeciality="Fire",
                magicWand="Ash",
                StudentCard=new StudentCard
                {
                    Number=19800925,
                    Series="CD"
                }
            }, 
            new Student
            {
                firstName="Hannah",
                lastName="Abbot",
                birthDate=new DateTime(1981,12,22),
                group="Hufflepuff",
                magicSpeciality="Ice",
                magicWand="Oak",
                StudentCard=new StudentCard
                {
                    Number=19811222,
                    Series="HA"
                }
            }, 
            new Student
            {
                firstName="Lianna",
                lastName="Creeper",
                birthDate=new DateTime(1988,08,18),
                group="Hufflepuff",
                magicSpeciality="Earth",
                magicWand="Pine",
                StudentCard=new StudentCard
                {
                    Number=19880818,
                    Series="LC"
                }
            },
            new Student
            {
                firstName="Pansy",
                lastName="Parkinson",
                birthDate=new DateTime(1991,09,26),
                group="Slytherin",
                magicSpeciality="Water",
                magicWand="Walnut",
                StudentCard=new StudentCard
                {
                    Number=19910926,
                    Series="PP"
                }
            },
            new Student
            {
                firstName="Vincent",
                lastName="Crabb",
                birthDate=new DateTime(1989,05,13),
                group="Slytherin",
                magicSpeciality="Lightning",
                magicWand="Plum",
                StudentCard=new StudentCard
                {
                    Number=19890513,
                    Series="VC"
                }
            },
            new Student
            {
                firstName="Ron",
                lastName="Weasley",
                birthDate=new DateTime(1986,10,10),
                group="Gryffindor",
                magicSpeciality="Ice",
                magicWand="Willow",
                StudentCard=new StudentCard
                {
                    Number=19861010,
                    Series="RW"
                }
            },
            new Student
            {
                firstName="Hermiona",
                lastName="Grainger",
                birthDate=new DateTime(1987,06,16),
                group="Gryffindor",
                magicSpeciality="Spirit",
                magicWand="Vine",
                StudentCard=new StudentCard
                {
                    Number=19870616,
                    Series="HG"
                }
            }
        };

        public void Sort()
        {
            Array.Sort(students);
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(students, comparer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }

    class Data_Comparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).birthDate, (y as Student).birthDate);
            }
            throw new NotImplementedException();
        }
    }
    class FirstName_Comparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).firstName, (y as Student).firstName);
            }
            throw new NotImplementedException();
        }
    }
    class Group_Comparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).group, (y as Student).group);
            }
            throw new NotImplementedException();
        }
    }
    class MagicSpeciality_Comparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).magicSpeciality, (y as Student).magicSpeciality);
            }
            throw new NotImplementedException();
        }
    }
    class MagicWand_Comparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).magicWand, (y as Student).magicWand);
            }
            throw new NotImplementedException();
        }
    }
    class StudCardNumber_Comparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                int X = (x as Student).StudentCard.Number;
                int Y = (y as Student).StudentCard.Number;
                if (X > Y) return 1;
                else if (X < Y) return -1;
                else return 0;
            }
            throw new NotImplementedException();
        }
    }
    class StudCardSeries_Comparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).StudentCard.Series, (y as Student).StudentCard.Series);
            }
            throw new NotImplementedException();
        }
    }
    class InterfacesWPU221
    {
        static void Main(string[] args)
        {
            Auditory auditory = new Auditory();
            WriteLine("************Список студентов*****************");
            WriteLine();
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }


            WriteLine("***********Сортировка по фамилии************");
            WriteLine();
            auditory.Sort();
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("***********Сортировка по дате рождения************");
            WriteLine();
            auditory.Sort(new Data_Comparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }
            
            WriteLine("***********Сортировка по имени************");
            WriteLine();
            auditory.Sort(new FirstName_Comparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            } 
            
            WriteLine("***********Сортировка по факультету************");
            WriteLine();
            auditory.Sort(new Group_Comparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }
            
            WriteLine("***********Сортировка по магии************");
            WriteLine();
            auditory.Sort(new MagicSpeciality_Comparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("******Сортировка по волшебной палочке******");
            WriteLine();
            auditory.Sort(new MagicWand_Comparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            } 
            
            WriteLine("******Сортировка по номеру студ.билета******");
            WriteLine();
            auditory.Sort(new StudCardNumber_Comparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }
            
            WriteLine("******Сортировка по серии студ.билета******");
            WriteLine();
            auditory.Sort(new StudCardSeries_Comparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }
        }
    }
}