using System.Security.Cryptography;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FamilyMember family1= new FamilyMember();
            FamilyMember family2= new FamilyMember();

            family1.Name = "Угаров";
            family2.Name = "Кудряшов";

            Human grandfather1 = new Human() {Name= "Вадим" ,Generation=0,SurName=family1.Name,Sex=Gender.Male};
            grandfather1.family.Add(family1);
            family1.humans.Add(grandfather1);

            Human GrandMother = new Human() {Name = "Светлана", Generation = 0, SurName="Мизунова",Sex = Gender.Female,WifeOrSpouse = grandfather1 };
            GrandMother.family.Add(family1);
            family1.humans.Add(GrandMother);
            grandfather1.WifeOrSpouse = GrandMother;

            Human grandfather2 = new Human() { Name = "Владимир", SurName = family2.Name, Generation = 0,Sex=Gender.Male };
            grandfather2.family.Add(family2);
            family2.humans.Add(grandfather2);

            Human Aunt = new Human() { Name = "Лариса", SurName = family1.Name, Generation = 0 , Sex = Gender.Female };
            Aunt.family.Add(family1);
            family1.humans.Add(Aunt);
            


            Human Father = new Human() { Name = "Евгений", DateOfBirth = DateTime.Parse("05.09.1991"), Sex = Gender.Male, SurName = family1.Name, Father = grandfather1, Generation = grandfather1.Generation + 1};
            family1.humans.Add(Father);
            Father.family.Add(family1);
            grandfather1.add_Children(Father);


            Human Mother= new Human() { Name = "Анна", SurName = family2.Name, WifeOrSpouse = Father, Sex = Gender.Female, DateOfBirth = DateTime.Parse("16.06.1987"), Father = grandfather2, Generation = grandfather2.Generation + 1 };
            family2.humans.Add(Mother);
            Mother.family.Add (family2);
            grandfather2.add_Children(Mother);
            Father.WifeOrSpouse = Mother;
            family1.humans.Add(Mother);

            Human child = new Human() { Name = "Яна", Father = Father, Mother = Mother , Sex = Gender.Female, Generation = Father.Generation + 1,SurName= family2.Name };

            family1.humans.Add(child);
            child.family.Add(family1);

            Console.WriteLine("Вывод Древа");
            family1.Info();
            //Console.WriteLine($"Ребенок: {child}");
            //Console.WriteLine();

            //foreach (FamilyMember family in child.family)
            //{
            //    foreach(Human human in family.humans)
            //    {

            //        if (child.Father.SurName == family.Name && child.Father.Generation > human.Generation)
            //        {
            //            Console.WriteLine(human.ToString());
            //        }
            //        else if (child.Mother.SurName == family.Name && child.Mother.Generation > human.Generation)
            //        {
            //            Console.WriteLine(human.ToString());

            //        }
            //    }

            //}
        }


    }
}