namespace Repository
{
    using System.Collections.Generic;

    public class Repository
    {
        public Dictionary<int, Person> people;
        private int id;

        public Repository()
        {
            this.people = new Dictionary<int, Person>();
            this.id = 0;
        }

        public int Count => this.people.Count;

        public void Add(Person person)
        {
            this.people.Add(id++, person);
        }

        public Person Get(int id)
        {
            return this.people[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (this.people.ContainsKey(id))
            {
                this.people[id] = newPerson;
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.people.ContainsKey(id))
            {
                this.people.Remove(id);
                return true;
            }

            return false;
        }
    }
}
