using Game2048;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game2048
{
    public class AccountMenager
    {
        private List<Account> _users;

        static private string _filename = "users.txt";

        public AccountMenager()
        {
            _users = _LoadUsersFromFile();
        }

        static private List<Account> _LoadUsersFromFile()
        {
            if (!File.Exists(_filename))
                return new List<Account>();

            string newList = File.ReadAllText(_filename);

            if (newList == "")
                return new List<Account>();

            return JsonSerializer.Deserialize<List<Account>>(newList);
        }

        static private void _SaveUsersToFile(List<Account> users)
        {
            using (FileStream fs = new FileStream(_filename, FileMode.Create))
                JsonSerializer.SerializeAsync<List<Account>>(fs, users);
        }

        public Account LogInOrRegistration(string username, string password)
        {
            foreach (Account user in _users)
                if (user.Username == username)
                {
                    return user.LogIn(password) ? user : null;
                }

            Account newUser = new Account()
            {
                Username = username,
                Password = password
            };

            _users.Add(newUser);

            return newUser;
        }

        static public void RememberUser(Account account, int hightScore)
        {
            string filename = "lastUser.txt";

            File.Delete(filename);

            account.HightScore = hightScore;

            using (FileStream fs = new FileStream(filename, FileMode.Create))
                JsonSerializer.SerializeAsync<Account>(fs, account);
        }

        private void _UpdeteAccount(Account account, int hightScore)
        {
            for(int i = 0; i < _users.Count; i++)
                if(_users[i].Username == account.Username)
                {
                    _users[i].HightScore = hightScore;
                }
        }

        public void Save(Account account, int hightScore)
        {
            _UpdeteAccount(account, hightScore);

            _SaveUsersToFile(_users);

            if (File.Exists("lastUser.txt"))
                RememberUser(account, hightScore);
        }

    }
}