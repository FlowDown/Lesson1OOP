using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class FamilyMember
    {
        public string Name { get; set; }
        public List<Human> humans { get; set; }
        private int maxGeneration;
        private int minGeneration;
        public FamilyMember()
        {
            humans= new List<Human>();
        }
        private Human[,] InfoGrand(int generation)
        {
                Human[,] hum= new Human[20,2];
                int k = 0;
            foreach (Human human in humans)
            {
                if (human.Generation == generation)
                {
                    if (human.WifeOrSpouse != null)
                    {
                        bool check = true;
                        for (int z = 0; z < k; z++)
                        {
                            if (hum[z, 0] == human.WifeOrSpouse)
                            {
                                hum[z, 1] = human;
                                check = false;
                                break;
                            }
                        }
                        if (check)
                        {
                            
                            hum[k, 0] = human;
                            k++;
                        }
                    }
                    else
                    {
                        hum[k, 0] = human;
                        k++;
                    }
                }
            }
            return hum;
            
        }

        public void Info() 
        {
            UpdateGeneration();
            

            for (int i = 0;i <= maxGeneration;i++)
            Console.WriteLine(CreateString(i));
        }
        public string CreateString(int gen)
        {
            string strFam = "";
            Human[,] fam1 = InfoGrand(gen);
            for (int i = 0; i <= fam1.Length; i++)
            {
                if (fam1[i, 0] == null) break;
                if (fam1[i, 1] == null)
                {
                    strFam = strFam + "     " + fam1[i, 0].ToString();
                }
                else
                {
                    strFam = strFam + "     " + fam1[i, 0].ToString() + "---" + fam1[i, 1].ToString();
                }
            }
            return strFam;
        }
        void UpdateGeneration()
        {
            minGeneration = 1000;
            maxGeneration = 0;
            foreach (Human human in humans)
            {
                if (minGeneration > human.Generation) minGeneration = human.Generation;
                if (maxGeneration < human.Generation) maxGeneration = human.Generation;
            }
        }
    }
}
