using System;
using System.Collections.Generic;
using System.Text;

namespace lsc
{
    struct Integer
    {
        private int value;

        public Integer(int input)
        {
            value = input;
        }

        public static implicit operator Integer(int input)
        {
            return new Integer(input);
        }

        public int Get()
        {
            return value;
        }

        public void Set(Integer integer)
        {
            value = integer.Get();
        }

        public StringChar toString()
        {
            return value.ToString();
        }
    }

    struct Character
    {
        private char value;

        public Character(char input)
        {
            value = input;
        }

        public static implicit operator Character(char input)
        {
            return new Character(input);
        }

        public char Get()
        {
            return value;
        }

        public void Set(Character character)
        {
            value = character.Get();
        }
    }

    struct StringChar
    {
        private string value;

        public StringChar(string input)
        {
            value = input;
        }

        public static implicit operator StringChar(string input)
        {
            return new StringChar(input);
        }

        public string Get()
        {
            return value;
        }

        public void Set(string characters)
        {
            value = characters;
        }

        public char[] Simplify()
        {
            return value.ToCharArray();
        }
    }

    struct Bool
    {
        private bool value;

        public Bool(bool input)
        {
            value = input;
        }

        public static implicit operator Bool(bool input)
        {
            return new Bool(input);
        }

        public bool Get()
        {
            return value;
        }

        public void Set(bool newvalue)
        {
            value = newvalue;
        }

        public StringChar toString()
        {
            return value.ToString();
        }
    }
}
