using System;

namespace Assignment
{
    internal class Instructor
    {
        public float avgFeedback;
        public int experience;
        public string instructorName;
        public string[] instructorSkill;
        public string technology;
        public string instech;

        public Instructor(string instructorName, float avgFeedback, int experience, string[] instructorSkill)
        {
            this.instructorName = instructorName;
            this.instructorSkill = instructorSkill;
            this.experience = experience;
            this.avgFeedback = avgFeedback;
        }

        public bool ValidateEligibility()
        {
            if (experience > 3 && avgFeedback >= 4.5f)
            {
                return true;
            }
            if (experience <= 3 && avgFeedback >= 4.0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckSkill(string technology)
        {
            for (int i = 0; i < instructorSkill.Length; i++)
            {
                if (ValidateEligibility() && (instructorSkill[i] == technology))
                {
                    instech = technology;
                }
                else
                {
                    instech = "Instructor does not possess required skill";
                }
            }
        }
        static void Main()
        {
            Console.WriteLine("Enter the values");
            string instructorName = Console.ReadLine();
            string technology = Console.ReadLine();
            float avgFeedback = float.Parse(Console.ReadLine());
            int experience = Convert.ToInt32(Console.ReadLine());
            //float avgFeedback = float.Parse(Console.ReadLine());
            string[] instructorSkill = new string[2];
            for (int i = 0; i < 2; i++)
            {
                instructorSkill[i] = Console.ReadLine();
            }
            Console.ReadLine();
            Instructor instructor = new Instructor(instructorName, avgFeedback, experience, instructorSkill);
            instructor.ValidateEligibility();
            instructor.CheckSkill(technology);
            Console.WriteLine($"instructorName = {instructor.instructorName}\navgFeedback = {instructor.avgFeedback}\nexperience = {instructor.experience}\ninstructorSkill = {instructor.instech}");
        }
    }
}