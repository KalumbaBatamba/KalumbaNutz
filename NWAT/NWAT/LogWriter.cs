using NWAT.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT
{
    public class LogWriter
    {

        private string _logFilePath;

        public string LogFilePath
        {
            get { return _logFilePath; }
            set { _logFilePath = value; }
        }

        private StreamWriter _logFileWriter;

        public StreamWriter LogFileWriter
        {
            get { return _logFileWriter; }
            set { _logFileWriter = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogWriter"/> class.
        /// </summary>
        /// <param name="logFilePath">The log file path.</param>
        /// <param name="logHeader">The log header.</param>
        /// Erstellt von Joshua Frey, am 15.01.2016
        public LogWriter(string logFilePath, string logHeader)
        {
            this.LogFilePath = logFilePath;

            // Create Logfile
            if (!File.Exists(this.LogFilePath))
            {
                File.Create(this.LogFilePath).Close();
            }
            else
            {
                throw new NWATException(MessageLogFileAlreadyExists(this.LogFilePath));
            }

            // Write Header
            WriteHeaderToLog(logHeader);
        }

        public void Log(string logMessage)
        {
            this.LogFileWriter = File.AppendText(this.LogFilePath);
            this.LogFileWriter.WriteLine("\r\n{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());

            this.LogFileWriter.WriteLine("---------------------------------");
            this.LogFileWriter.WriteLine("{0}", logMessage);
            this.LogFileWriter.Close();
        }


        /// <summary>
        /// Writes the header to log.
        /// </summary>
        /// <param name="header">The header.</param>
        /// Erstellt von Joshua Frey, am 15.01.2016
        private void WriteHeaderToLog(string header)
        {
            this.LogFileWriter = File.AppendText(this.LogFilePath);
            this.LogFileWriter.WriteLine(header);
            this.LogFileWriter.WriteLine("-------------------------------");
            this.LogFileWriter.WriteLine();
            //this.LogFileWriter.WriteLine();
            this.LogFileWriter.Close();
        }

        private string MessageLogFileAlreadyExists(string logFilePath)
        {
            return String.Format("Es wurde versucht die Logdatei {0} zu erstellen.\n"+
                                 "Hierbei ist ein Fehler aufgetreten, da die Datei bereits existierte.\n" + 
                                 "Bitte benennen Sie die Datei um oder löschen Sie sie.", logFilePath);
        }
        
    }
}
