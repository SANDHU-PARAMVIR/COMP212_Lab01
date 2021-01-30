using System;

namespace Lab1
{
    class Student : IEquatable<int>, IEquatable<string>
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public bool Equals(int other)
        {
            return ID == other;
        }

        public bool Equals(string other)
        {
            return Name == other;
        }
    }
}
