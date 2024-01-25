using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Human
    {
        public string Name;
        public string SurName;
        public Gender Sex;
        public Human Father;
        public Human Mother;
        public Human WifeOrSpouse { get; set; }
        public DateTime DateOfBirth;
        public List<FamilyMember> family { get; set; }
        public List<Human> Children { get;private set; }
        public int Generation;
        public Human() 
        {
            Children = new List<Human>();
            family = new List<FamilyMember>();
        }
        public Human(string name,string surName,Gender sex,Human father,Human mother,DateTime DateOfBirth):base()
        {

            Name= name;
            Sex=sex;
            SurName=surName;
            Father=father;
            Mother=mother;
            this.DateOfBirth = DateOfBirth;
            Generation = father.Generation + 1;
        }
        public void add_Children(Human child)
        {
            Children.Add(child);
        }
        string GetMother()
        {
            try
            {
                return Mother.ToString();
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
        string GetFather()
        {
            try { 
                return Father.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public override string ToString()
        {
            var fm = (Sex == Gender.Male) ? SurName : SurName + "а";
            return $"Имя {Name}, " +
                $"Фамилия {fm}";
        }
    }
}
