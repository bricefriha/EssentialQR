using EssentialQR.Models;
using SQLite;

namespace EssentialQR
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();

            }
            catch (System.IO.FileNotFoundException)
            {

                //throw;
            }

            MainPage = new AppShell();

            // Set the db up
            StartDb();
            SqLiteConn.CreateTable<CodeRecord>();
        }

        public SQLiteConnection SqLiteConn { get; private set; }

        /// <summary>
        /// Function to start the data base
        /// </summary>
        public async void StartDb()
        {
            const SQLite.SQLiteOpenFlags Flags =
                    // open the database in read/write mode
                    SQLite.SQLiteOpenFlags.ReadWrite |
                    // create the database if it doesn't exist
                    SQLite.SQLiteOpenFlags.Create |
                    // enable multi-threaded database access
                    SQLite.SQLiteOpenFlags.SharedCache;
            // Just use whatever directory SpecialFolder.Personal returns
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            var path = Path.Combine(libraryPath, "ess_qr.db3");

            // Verify if a data base already exist
            if (!File.Exists(path))
                // Create the folder path.
                File.Create(path);

            // Sqlite connection
            SqLiteConn = new SQLiteConnection(path);



        }
    }
}