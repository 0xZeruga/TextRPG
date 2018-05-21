namespace Arena
{

    public class Item
    {
        public int weight;


        public Item()
        {

        }
    }

    public class Weapon : Item
    {
        private int m_damage;
        private string m_name;
        public string Name
        {
            get
            {
                return m_name;
            }
            
        }
        public int Damage()
        {
            return m_damage;
        }

        public Weapon(string name, int damage, int weight)
        {
            m_damage = damage;
            m_name = name;
        }
    }
    public class Armor : Item
    {
        private int m_absorb;
        public string m_name;
        public string Name
        {
            get
            {
                return m_name;
            }
  
        }
        public int Absorb()
        {
            return m_absorb;
        }

        public Armor(string name, int absorb, int weight)
        {
            m_name = name;
            m_absorb = absorb;
        }
    }
    public class Potion : Item
    {
        public Potion(string name, string attribute,int amount)
        {

        }
    }
    public class Spell : Item
    {
        public Spell(string name, int amount, bool requiresTurn)
        {

        }
    }
}