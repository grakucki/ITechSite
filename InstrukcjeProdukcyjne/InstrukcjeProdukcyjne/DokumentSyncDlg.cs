﻿using InstrukcjeProdukcyjne.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    public partial class DokumentSyncDlg : Form
    {
        public class ProgressState
        {
            public ProgressState(string msg, bool newLine = false)
            {
                Msg = msg;
                NewLine = newLine;
            }
            public string Msg { get; set; } 
            public bool NewLine { get; set; }
        }

        public DokumentSyncDlg()
        {
            InitializeComponent();
        }

        private void DokumentSyncDlg_Load(object sender, EventArgs e)
        {

        }

        public void Sync()
        {

            if (!backgroundWorker1.IsBusy)
            {
                textBoxLog.Clear();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        public void Stop()
        {
            backgroundWorker1.CancelAsync();
        }

        private void OutMessage(string msg)
        {
            OutMessage(new ProgressState(msg));
        }

        delegate  void OutMessageDelegate ( ProgressState msg ); 
        private void OutMessage(ProgressState msg)
        {

             if (this.textBoxLog.InvokeRequired)
             {
                 this.textBoxLog.Invoke(new OutMessageDelegate(OutMessage), new object[] { msg });
             }

            textBoxLog.AppendText(msg.Msg);
            if (msg.NewLine)
                textBoxLog.AppendText(Environment.NewLine);
        }



        private void Worker_DownloadFile(int? idr)
        {
            try
            {
                if (!idr.HasValue)
                {
                    backgroundWorker1.ReportProgress(0, new ProgressState("Nie podano identyfikatora stacji roboczej", true));
                    return;
                }

                //sprawdzić NetTcpBinding
                //https://petermeinl.wordpress.com/2012/02/20/managing-blobs-using-sql-server-filestream-via-ef-and-wcf-streaming/

                //System.ServiceModel.WebHttpBinding webhttpbinding = new WebHttpBinding();
                //EndpointAddress adr = new EndpointAddress("http://localhost:53854/ServiceDokument.svc");

                backgroundWorker1.ReportProgress(0, new ProgressState("Łączę z serwerem ..."));

                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    backgroundWorker1.ReportProgress(0, new ProgressState("ok.", true));
                    backgroundWorker1.ReportProgress(0, new ProgressState("Pobieram listę plików ..."));
                    var dokc = client.GetDokumentsList(Settings.Default.App.Stanowisko.Value);

                    backgroundWorker1.ReportProgress(0, new ProgressState("ok.", true));
                    using (var clientD = new ServiceDokument.ServiceDokumentClient())
                    {
                        // pobieramy listę wymaganych dokumentów

                        try
                        {
                            foreach (var item in dokc)
                            {
                                if (backgroundWorker1.CancellationPending)
                                {
                                    throw new Exception("Przerwano na życzenie użytkownika");
                                }
                                    backgroundWorker1.ReportProgress(0, new ProgressState(item.LocalFileName + "..."));
                                    if (!CompareVersion(item))
                                    {
                                        backgroundWorker1.ReportProgress(0, new ProgressState("pobieram ..."));
                                        DownloadFile(clientD, item);
                                    }
                                    backgroundWorker1.ReportProgress(0, new ProgressState("Ok", true));
                            }
                        }
                        catch (Exception ex)
                        {
                            backgroundWorker1.ReportProgress(0, new ProgressState(ex.Message));
                            backgroundWorker1.ReportProgress(0, new ProgressState(". Spróbuję puźniej."));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                backgroundWorker1.ReportProgress(0, new ProgressState("Błąd " + ex.Message, true));
            }

        }

        /// <summary>
        /// czy należy ponownie ściiągnąć dokument
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true = jeśli dokumenty są zgodnbe, false Jeśli są różne</returns>
        private bool CompareVersion(ServiceWorkstation.DokumentIdentity doc)
        {

            var tempfilename = DokumentFullFileName(doc.LocalFileName + ".tmp");

            // kasujemy plik tymczasowy jeśli nie odpowiada najnowszej wersji.
            // jeśłi jest zgodny z najnowszą wersją to nie będziemy go ponownie ściągać
            if (CompareVersion(tempfilename, doc))
                return false;
            else
            {
                if (File.Exists(tempfilename))
                    File.Delete(tempfilename);
            }

            var destfilename = DokumentFullFileName(doc.LocalFileName);
            return CompareVersion(destfilename, doc);
        }


        /// <summary>
        /// Czy dokumenty są zgodne
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true = jeśli są zgodnbe, false Jeśli są różne</returns>
        private bool CompareVersion(string localfullfilename, ServiceWorkstation.DokumentIdentity doc)
        {
            if (!File.Exists(localfullfilename))
                return false;

            var localfileinfo = new FileInfo(localfullfilename);
            if (localfileinfo.LastWriteTime != doc.LastWriteTime)
                return false;
            if (localfileinfo.Length != doc.Size)
                return false;

            return true;
        }

        private void DownloadFile(ServiceDokument.ServiceDokumentClient client, ServiceWorkstation.DokumentIdentity doc)
        {
            var tempfilename = DokumentFullFileName(doc.LocalFileName + ".tmp");
            var destfilename = DokumentFullFileName(doc.LocalFileName);


            if (!File.Exists(tempfilename))
            {
                SaveFile(tempfilename, client.DownloadDokument(doc.id));
                // ustawiamy datę ostatniej modyfikacji
                var f = new FileInfo(tempfilename);
                f.LastWriteTime = doc.LastWriteTime;
            }

            if (File.Exists(tempfilename))
            {
                if (File.Exists(destfilename))
                    File.Delete(destfilename);
                File.Move(tempfilename, destfilename);
            }

        }


        private string DokumentFullFileName(string FileName)
        {
            return Path.Combine(Settings.Default.App.LocalDoc, @"Dokuments\", FileName);
        }

        private void SaveFile(string downloadedFileSaveLocation, Stream fileStream)
        {
            var dir = Path.GetDirectoryName(downloadedFileSaveLocation);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (var file = File.Create(downloadedFileSaveLocation))
            {
                fileStream.CopyTo(file);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(0, new ProgressState(DateTime.Now.ToString()+" Rozpoczynam synchronizację", true));

            Worker_DownloadFile(Properties.Settings.Default.App.Stanowisko);
            backgroundWorker1.ReportProgress(0, new ProgressState("Zakończono."));
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                ProgressState ps = (ProgressState) e.UserState;
                OutMessage(ps);
            }
            catch (Exception ex)
            {
                OutMessage(ex.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sync();
        }  
    }
}