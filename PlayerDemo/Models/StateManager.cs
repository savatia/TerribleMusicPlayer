using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayerDemo.Models
{
    public class StateManager
    {
        private readonly string _stateFile;
        private Database _db;

        public StateManager()
        {
            _stateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PlayerDemo.state");
            Deserialize();
        }

        public Database SongDB
        {
            get
            {
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        private void Deserialize()
        {
            if (File.Exists(_stateFile))
            {
                try
                {
                    FileStream stream = File.Open(_stateFile, FileMode.Open);

                    BinaryFormatter formatter = new BinaryFormatter();
                    _db = (Database)formatter.Deserialize(stream);
                }
               catch(Exception e)
                {
                    MessageBox.Show(e.Message, "Could not read database!");
                }

            }
            else _db = new Database();
        }

        private void Serialize()
        {
            try
            {
                FileStream stream = File.Open(_stateFile, FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _db);
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Could not serialize database!");
                File.Delete(_stateFile);
            }

        }

        public void SaveDatabase()
        {
            Serialize();
        }
    }
}
