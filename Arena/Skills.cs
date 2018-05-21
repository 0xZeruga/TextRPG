using System.Collections.Generic;

namespace Arena
{
    public class Skills
    {
        public Dictionary<string, int> skills = new Dictionary<string, int>();

        public Skills()
        {
            PopSkills();
        }

        public void PopSkills()
        {
            skills.Add("Smithing", 0);
            skills.Add("Alchemy", 0);
            skills.Add("Bargain", 0);
            skills.Add("Onehanded", 0);
            skills.Add("Twohanded", 0);
            skills.Add("Magic", 0);
        }
    }
}