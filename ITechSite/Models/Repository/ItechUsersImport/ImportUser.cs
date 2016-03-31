using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITechSite.Models.Repository.ItechUsersImport
{
    public class ImportUser
    {
        public int LineRead = 0;
        public int UserReadOk = 0;
        public int UserReadError = 0;
        public int UserAdd = 0;
        public int UserModified = 0;
        public int UserDisabled = 0;

        public List<string> ErrorList = new List<string>();
        public List<string> StatusList = new List<string>();
        public List<SitechUser> Users = new List<SitechUser>();

        private bool UserImportExist(string userid)
        {
            return Users.Where(m => m.Nr_identyfikacyjny == userid).Any();
        }

        public bool SaveChanges()
        {

            //if (UserReadError > 0)
            //{ 
            //    showErrorMessage("Lista nie została zapisana. Popraw błedy aby kontynuować!", 0);
            //    return false;
            //}

            try
            {
                using (var db = new ITechEntities(0))
                {
                    var userbd = db.ItechUsers;

                    // szukamy użytkowników których nie ma na liśie importowanej i ich wyłączamy
                    UserDisabled = 0;
                    foreach (var item in userbd)
                    {
                        if (!item.Frozen)
                            if (!UserImportExist(item.UserId))
                            {
                                if (item.Enabled)
                                {
                                    item.Enabled = false;
                                    UserDisabled++;
                                }
                            }
                    }

                    var pracownikRole = db.AspNetRoles.Where(m => m.Name == "pracownik").FirstOrDefault();
                    // aktualizujemy użytkowników z listy importowanej
                    foreach (var item in Users)
                    {
                        var u = db.ItechUsers.Where(m => m.UserId == item.Nr_identyfikacyjny).FirstOrDefault();
                        if (u == null)
                        {
                            u = new ItechUsers();
                            db.ItechUsers.Add(u);
                            u.UserId = item.Nr_identyfikacyjny;
                            u.Frozen = false;
                        }
                        u.Enabled = true;
                        u.CardNo = item.Nr_karty;
                        u.UserName = string.Format("{0} {1}", item.Nazwisko, item.Imię);
                        u.Desc = item.Opis;
                        u.AccessProfile = item.Profil_dostepu;

                        // dodaj role pracownik
                        if (pracownikRole != null)
                            if (!u.AspNetRoles.Any(m => m.Id == pracownikRole.Id))
                                u.AspNetRoles.Add(pracownikRole);


                    }

                    UserAdd = db.ChangeTracker.Entries().Where(m => m.State == System.Data.Entity.EntityState.Added).Count();
                    UserModified = db.ChangeTracker.Entries().Where(m => m.State == System.Data.Entity.EntityState.Modified).Count();
                    db.SaveChanges();

                    showStatusMessage("====================");
                    showStatusMessage("Zapis do bazy");
                    showStatusMessage("Operatorów dodano : " + UserAdd);
                    showStatusMessage("Operatorów zmodyfikowano: " + UserModified);
                    showStatusMessage("W tym operatorów wyłączono: " + UserDisabled);

                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message);
                return false;
            }

            return true;
        }

        public bool Prepare(string content)
        {
            LineRead = 0;
            UserReadOk = 0;
            UserReadError = 0;
            Users.Clear();
            ErrorList.Clear();

            using (var f = content.ToStreamReader())
            {
                // pierwszą linie ignorujemy
                string line = f.ReadLine();
                while (!f.EndOfStream)
                {
                    line = f.ReadLine();
                    LineRead++;
                    var user = LineToUser(line);
                    if (user != null)
                    {
                        if (CheckUser(user))
                            UserReadOk++;
                        else
                            UserReadError++;
                    }
                    else
                        UserReadError++;
                }
            }

            if (UserReadError != 0)
                showErrorMessage("Lista nie została zapisana. Popraw błedy aby kontynuować!", 0);

            showStatusMessage("Sprawdzam plik");
            showStatusMessage("Odczytanych linii : " + LineRead);
            showStatusMessage("Odczytanych użytkowników poprawnie: " + UserReadOk);
            showStatusMessage("Odczytanych użytkowników błędnie: " + UserReadError);

            return (UserReadError == 0);
        }


        private SitechUser LineToUser(string line)
        {
            line = line.TrimEnd();
            if (line.Length == 0)
                return null;

            string[] ss = line.Split(new Char[] { ';','\t' }, StringSplitOptions.None);
            if (ss.Count() < 4)
            {
                showErrorMessage("Linia " + LineRead.ToString() + ". Za mało parametrów - " + line);
                return null;
            }

            var user = new SitechUser();
            user.Nazwisko = ss[0].Trim();
            user.Imię = ss[1].TrimEnd();
            user.Nr_identyfikacyjny = ss[2].Trim();
            user.Nr_karty = ss[3].Trim();

            // na życzenie sitech odczytujemy tylko 6 ostatnich numerów karty
            if (user.Nr_karty.Length > 6)
                user.Nr_karty = user.Nr_karty.Substring(user.Nr_karty.Length-6, 6);
            if (ss.Count() > 4)
            {
                user.Profil_dostepu = ss[4].Trim();
                if (ss.Count() > 5)
                    user.Opis = ss[5].Trim();
            }

            if (string.IsNullOrEmpty(user.Nr_identyfikacyjny))
            {
                showErrorMessage("Linia " + LineRead.ToString() + ". Numer identyfikacyjny jest wymagany - " + line);
                return null;
            }

            if (string.IsNullOrEmpty(user.Nr_karty))
            {
                showErrorMessage("Linia " + LineRead.ToString() + ". Numer karty jest wymagany - " + line);
                return null;
            }

            return user;
        }

        private void showErrorMessage(string msg, int pos=-1)
        {
            if (pos>=0)
                ErrorList.Insert(pos,msg);
            else
                ErrorList.Add(msg);
        }
        
        private void showStatusMessage(string msg)
        {
            StatusList.Add(msg);
        }

        private bool CheckUser(SitechUser user)
        {
            // sprawdzamy czy user istnieje
            bool exist = Users.Where(m => m.Nr_identyfikacyjny == user.Nr_identyfikacyjny).Any();
            if (exist)
            {
                showErrorMessage("Linia " + LineRead.ToString() + ". Wielokrotne wystąpienie użytkownika o identyfikatorze  - " + user.Nr_identyfikacyjny);
                return false;
            }

            // sprawdzamy czy nr karty już isnieje
            if (user.Nr_karty != "0")
            {
                exist = Users.Where(m => m.Nr_karty == user.Nr_karty).Any();
                if (exist)
                {
                    showErrorMessage("Linia " + LineRead.ToString() + ". Wielokrotne wystąpienie nr karty  - " + user.Nr_karty);
                    return false;
                }
            }

            Users.Add(user);

            return true;


        }
    }

}