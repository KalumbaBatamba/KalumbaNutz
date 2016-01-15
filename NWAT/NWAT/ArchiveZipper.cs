using NWAT.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NWAT
{
    class ArchiveZipper : IDisposable
    {
        public void Dispose() { }

        /// <summary>
        /// Compresses the files to zip archive.
        /// </summary>
        /// <param name="zipArchivePath">The zip file path.</param>
        /// <param name="filesToZip">The files to zip.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 15.01.2016
        public bool CompressFilesToZipArchive(string zipArchivePath, List<string> filesToZip)
        {
            using (FileStream zipToOpen = new FileStream(zipArchivePath, FileMode.OpenOrCreate))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {

                    foreach (string exportFilePath in filesToZip)
                    {
                        if (File.Exists(exportFilePath))
                        {
                            string fileName = Path.GetFileName(exportFilePath);
                            archive.CreateEntryFromFile(exportFilePath, fileName, CompressionLevel.Optimal);
                        }
                        else
                        {
                            throw new NWATException(MessageZipProblemFileMissing(exportFilePath));
                        }
                    }
                }
            }
            return true;
        }



        /// <summary>
        /// Extracts the archive data to temporary dir.
        /// </summary>
        /// <param name="tempExtractDir">The temporary extract dir.</param>
        /// <param name="zipArchiveFilePath">The zip archive file path.</param>
        /// <returns>
        /// A list with all paths of extraced files
        /// </returns>
        /// Erstellt von Joshua Frey, am 15.01.2016
        public List<string> extractArchiveDataToTempDir(string tempExtractDir, string zipArchiveFilePath)
        {
            if (Directory.Exists(tempExtractDir))
            {
                Directory.Delete(tempExtractDir, true);
                // sleep is needed. If tempExtractDir is open in file explorer
                // it needs more time to delete tempExtractDir and handle the user interruption from gui
                // closing window so the create statement will not actually create a tempExtractDir
                Thread.Sleep(20);
            }
            Directory.CreateDirectory(tempExtractDir);

            List<string> extractedFilePaths = new List<string>();

            using (ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        string extractedFilePath = Path.Combine(tempExtractDir, entry.FullName);
                        extractedFilePaths.Add(extractedFilePath);
                        entry.ExtractToFile(extractedFilePath);
                    }
                }
            }
            return extractedFilePaths;
        }




        /*
         * Messages
         */
        private string MessageZipProblemFileMissing(string filePath)
        {
            return String.Format("Beim Komprimieren ist ein Fehler aufgetreten. Die erstellte Exportdatei kann nicht gefunden werden: {0}", filePath);
        }
    }
}
