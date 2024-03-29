﻿using ITechInstrukcjeModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Protocols;
using System.Data.Entity;
using System.IO;
using System.Drawing;
using System.Threading;

namespace ITechService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceWorkstation : IServiceWorkstation
    {

        public string TestConnection(int value)
        {
            StringBuilder ret = new StringBuilder();
//            ret.AppendLine("Serwis ... v16.04.29 Ok");
            ret.AppendLine("Serwis ... v19.07.08 Ok");
            try
            {
                ret.Append("Baza danych ... ");
                ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities();
                if (!context.Database.Exists())
                {
                    ret.AppendLine("Brak bazy");
                    return ret.ToString();
                }
                else
                    ret.AppendLine("Ok");

                ret.Append("Zapytanie ... ");
                var query = context.News.Where(m => m.Resource.Id==value).Select(m => m.News1).FirstOrDefault();
                var s = query != null ? query.ToString() : "ok";
                ret.AppendLine(s);
             
            }
            catch (DbEntityValidationException vex)
            {
                ret.AppendLine("Błąd walidacji!!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(vex));
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd!!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
            }

            return ret.ToString();
        }

       
        public News GetNews(int idR)
        {
            StringBuilder ret = new StringBuilder();
            News o = null;
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    o = context.News.Where(m=>m.ValidEnd ==null || m.ValidEnd>DateTime.Now).Where(m => m.Resource.Id == idR).FirstOrDefault();
                    //Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }

        public News GetNewsUser(int idR, int IUserId)
        {
            StringBuilder ret = new StringBuilder();
            News o = null;
            try
            {

                        //.Include(m => m.InformationPlanWorkstation)
                        //.Include(m => m.InformationPlanWorkstation.Select(y => y.Dokument))

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    var d = context.News.Where(m => m.ValidEnd == null || m.ValidEnd > DateTime.Now).Where(m => m.Resource.Id == idR);
                    d = d.Include(n => n.NewsItems);
                    o = d.FirstOrDefault();

                    // informacja o przeczytanej wiadomości
                    if (o != null)
                    {
                        if (o.ItemId.HasValue)
                        {
                            var r = context.ItechUsersNewsRead.Where(m => m.UserId == IUserId && m.NewsItemId == o.ItemId).FirstOrDefault();
                            if (r!=null)
                                o.NewsItems.ItechUsersNewsRead.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }

        public List<string> GetSimaticCpuType()
        {
            StringBuilder ret = new StringBuilder();
            List<string> o = null;
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    o = context.SimaticCpuType.Where(m => m.Enabled).Select(m => m.CpuType).ToList();
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }

        public List<Resource> GetWorkstationList()
        {
            StringBuilder ret = new StringBuilder();
            List<Resource> o = null;
            int kp = 1100;// 11;
            try
            {
                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    o = context.Resource.Where(m=>m.Enabled==true & m.Type==1).Include(m=>m.Workstation).Take(kp*3).OrderBy(m=>m.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }

        /// <summary>
        /// pobiera plan informacyjny dla konkretnego stanowiska bez modeli
        /// </summary>
        /// <param name="idR"></param>
        /// <returns></returns>
        public Resource GetInformationPlain(int idR)
        {
            StringBuilder ret = new StringBuilder();
            Resource o = null;
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;

                    var q = context.Resource.Where(m => m.Id == idR)
                        .Include(m => m.InformationPlanWorkstation)
                        .Include(m => m.InformationPlanWorkstation.Select(y => y.Dokument))
                        .Include(m => m.InformationPlanWorkstation.Select(y => y.Dokument).Select(z => z.Kategorie))
                        .Include(m => m.Workstation)
                        .Include(m => m.News)
                        .Include(m => m.ModelsWorkstation);

                    o=q.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }


        /// <summary>
        /// pobiera listę zasobów z planami informacyjnymi dla stanowiska i wszystkich modeli przynależnych do stanowiska
        /// </summary>
        /// <param name="idR"></param>
        /// <returns></returns>
        public List<Resource> GetInformationPlainsList(int idR)
        {
            StringBuilder ret = new StringBuilder();
            List<Resource> o = null;
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;

                    var q = context.Resource.Where(m => m.Enabled && m.Id==idR)
                        .Include(m => m.Workstation)
                        .Include(m => m.InformationPlanWorkstation)
                        .Include(m => m.InformationPlanWorkstation.Select(y => y.Dokument))
                        .Include(m => m.InformationPlanWorkstation.Select(y => y.Dokument).Select(z => z.Kategorie))
                        .Include(m => m.News)
                        .Include(m => m.ModelsWorkstation)
                        ;

                    o = q.ToList();
                    q = context.Resource.Where(m=>m.ModelsWorkstationModel.Any(n=>n.idW==idR))
                        .Include(m => m.Workstation)
                        .Include(m => m.InformationPlanWorkstation)
                        .Include(m => m.InformationPlanWorkstation.Select(y => y.Dokument))
                        .Include(m => m.InformationPlanWorkstation.Select(y => y.Dokument).Select(z => z.Kategorie))
                        .Include(m => m.News)
                        .Include(m => m.ModelsWorkstation)
                        ;
                    o.AddRange(q.ToList());
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }
        
      

        public List<ItechUsers> GetITechUserList()
        {
            StringBuilder ret = new StringBuilder();
            List<ItechUsers> o = null;
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    o = context.ItechUsers.Where(m=>m.Enabled==true && m.Deleted==false).Include(m=>m.AspNetRoles).OrderBy(m=>m.CardNo).ToList();
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }
        
        
        public DateTime Ping()
        {
            return DateTime.Now;
        }




        /// <summary>
        /// lista dokumentów które są dostępne na stacji roboczej na potrzeby ściagania na stacje robocze
        /// </summary>
        /// <param name="idR"></param>
        /// <returns></returns>
        public List<DokumentIdentity> GetDokumentsList(int idR)
        {
            StringBuilder ret = new StringBuilder();
            List<DokumentIdentity> o = null;
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;

                    //// stacja robocza
                    var q = context.Dokument.Where(m => m.InformationPlan.Any(i => i.idR == idR && i.Enabled == true))
                        .Select(m=>new DokumentIdentity { id=m.Id, CodeName = m.CodeName, LastWriteTime=m.LastWriteTime, LocalFileName=m.LocalFileName, Size=m.Size ?? 0});


                    //// modele dorobić aby zwracała tylko potrzebne dokumenty dla wszystkich modeli produkowanych na stacji
                    //var q2 = context.Dokument.Where(m => m.InformationPlan.Any(i => i.Resource.Type == 2 && i.Enabled == true))
                    //    .Select(m => new DokumentIdentity { id = m.Id, CodeName = m.CodeName, LastWriteTime = m.LastWriteTime, LocalFileName = m.LocalFileName, Size = m.Size ?? 0 });
                    //q=q.Union(q2);
                    
                    if (q != null)
                        o = q.ToList();
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }



        public void UpdateWorkstation(Workstation workstation)
        {
            if (workstation==null)
                throw new FaultException("Nie podana porametrów sterownika");

            StringBuilder ret = new StringBuilder();
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    Workstation q = null;
                    q= context.Workstation.Find(workstation.Id);
                    if (q==null)
                    {
                        q = new Workstation();
                        q.idR = workstation.idR;
                        q.WorkstationGroup = "All";
                        q.Factory = string.Empty;
                        q.Area = string.Empty;
                        context.Workstation.Add(q);
                    }
                    q.Setrownik_DB = workstation.Setrownik_DB;
                    q.Sterownik_Ip = workstation.Sterownik_Ip;
                    q.Sterownik_Model = workstation.Sterownik_Model;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return;
        }




        public List<ModelWorkstationInfo> GetModelWorkstationInfo(int idR)
        {
            StringBuilder ret = new StringBuilder();
            List<ModelWorkstationInfo> o = null;
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    o = context.ModelsWorkstation.Where(m=>m.idW==idR).Select(
                        m=>new ModelWorkstationInfo
                        {
                             id = m.id,
                             idW = m.idW,
                             idM = m.idM,
                             SterownikIndex = m.index,
                             ModelName = m.Models==null ? "???" : m.Models.Name,
                             WorkstationName =m.Workstation==null ? "???" : m.Workstation.Name
                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }

        public List<Resource> GetModels()
        {
            StringBuilder ret = new StringBuilder();
            List<Resource> o = null;
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    //o = context.ResourceModel.OrderBy(m => m.Name).ToList();
                    //o = context.ResourceModelsOnly.OrderBy(m => m.Name).ToList();
                    o = context.ResourceModelsOnly.Include(m => m.Resource1).OrderBy(m => m.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return o;
        }

        public void UpdateModelWorkstationInfo(ModelWorkstationInfo modelWorkstationInfo, bool Remove = false)
        {
            StringBuilder ret = new StringBuilder();
            ModelsWorkstation o = null;
            try
            {

                using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
                {
                    if (Remove)
                    {
                        o = context.ModelsWorkstation.Find(modelWorkstationInfo.id);
                        if (o != null)
                        {
                            context.ModelsWorkstation.Remove(o);
                            context.SaveChanges();
                        }
                        return;
                    }


                    if (modelWorkstationInfo.id>0)
                        o = context.ModelsWorkstation.Find(modelWorkstationInfo.id);
                    if (o==null)
                    {
                        o = new ModelsWorkstation();
                        context.ModelsWorkstation.Add(o);
                    }
                    o.idW = modelWorkstationInfo.idW;
                    o.idM = modelWorkstationInfo.idM;
                    o.index = modelWorkstationInfo.SterownikIndex;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ret.AppendLine("Błąd !!!!!!");
                ret.AppendLine(ExceptionResolver.Resolve(ex));
                throw new FaultException(ret.ToString());
            }
            return;
        }

    
    public bool RunTestKompetencji(int UserId)
    {
        bool ret = false;
        try
        {
            using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
            {
                // czy globalna flaga jest właczona
                var set = context.TestSettings.FirstOrDefault();
                if (set==null)
                    return false;

                if (!set.Test_Run)
                    return false;

                var u = context.ItechUsers.Where(m => m.id == UserId).FirstOrDefault();
                if (u == null)
                    return false;

                // sprawdzamy czy user musi wykonać test
                if (u.ForceTestKompetencji)
                    return true;
                
                // sprawdzamy czy nadszedł czas na wykonaie testu
                if (!u.LastTestKompetencjiDtm.HasValue)
                    return true;

                if (u.LastTestKompetencjiDtm.Value.AddDays(set.Test_PeriodDay)<DateTime.Now)
                    return true;
            }
        }
        catch (Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Błąd !!!!!!");
            str.AppendLine(ExceptionResolver.Resolve(ex));
            throw new FaultException(str.ToString());
        }
        return false;
    }

    public void UpdateTestKompetencji(int  UserId, int? TestResult)
    {
        bool ret = false;
        try
        {
            using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
            {

                var u = context.ItechUsers.Where(m => m.id == UserId).FirstOrDefault();
                if (u == null)
                    return;
                int? SuccessTestResult = 1;
                u.ForceTestKompetencji=false;
                u.LastTestKompetencjiDtm=DateTime.Now;
                u.LastTestKompetencjiResult=TestResult;
                if (TestResult == SuccessTestResult)
                    u.LastTestKompetencjiDtmSucces = u.LastTestKompetencjiDtm;
                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Błąd !!!!!!");
            str.AppendLine(ExceptionResolver.Resolve(ex));
            throw new FaultException(str.ToString());
        }
    }

    public List<ItechUsersDokumentRead> GetUserReadDokList(int IUserId)
    {
        try
        {
            List<ItechUsersDokumentRead> l = null;
            using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                var u = context.ItechUsersDokumentRead.Where(m => m.UserId == IUserId && m.Dokument.Version==m.DokVersion);
                l = u.ToList();
            }
            return l;
        }
        catch (Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Błąd !!!!!!");
            str.AppendLine(ExceptionResolver.Resolve(ex));
            throw new FaultException(str.ToString());
        }

    }

    public void UserReadDok(int IUserId, int DokId, int DokVersion)
    {
        try
        {
            using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
            {
                var u = context.ItechUsersDokumentRead.Where(m => m.UserId == IUserId && m.DokId == DokId && m.DokVersion == DokVersion).FirstOrDefault();
                if (u == null)
                {
                    u = new ITechInstrukcjeModel.ItechUsersDokumentRead();
                    u.DokId = DokId;
                    u.UserId = IUserId;
                    u.DokVersion = DokVersion;
                    u.FirstReadAt = DateTime.Now;
                    context.ItechUsersDokumentRead.Add(u);
                }
                u.LastReadAt = DateTime.Now;
                u.ReadCount += 1;

                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Błąd !!!!!!");
            str.AppendLine(ExceptionResolver.Resolve(ex));
            throw new FaultException(str.ToString());
        }
    }

    public void UserReadMessage(int IUserId, int NewsItemId)
    {
        try
        {
            using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
            {

                var u = context.ItechUsersNewsRead.Where(m => m.UserId == IUserId && m.NewsItemId == NewsItemId).FirstOrDefault();
                if (u == null)
                {
                    u = new ITechInstrukcjeModel.ItechUsersNewsRead();
                    u.NewsItemId = NewsItemId;
                    u.UserId = IUserId;
                    u.FirstReadAt = DateTime.Now;
                    context.ItechUsersNewsRead.Add(u);
                }
                u.ReadCount += 1;
                u.LastReadAt = DateTime.Now;
                
                context.SaveChanges();
                //System.Threading.Thread.Sleep(3000);
            }
        }
        catch (Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Błąd !!!!!!");
            str.AppendLine(ExceptionResolver.Resolve(ex));
            throw new FaultException(str.ToString());
        }
    }

    public ItechUsers GetLoginUser(string cardno, string passowrd, bool OnlyCardNo)
    {
        StringBuilder ret = new StringBuilder();
        List<ItechUsers> o = null;
        try
        {

            using (ITechInstrukcjeModel.ITechEntities context = new ITechInstrukcjeModel.ITechEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                if (OnlyCardNo)
                    o = context.ItechUsers.Where(m => m.CardNo == cardno && m.Enabled==true && m.Deleted==false).Include(m => m.AspNetRoles).ToList();
                else
                    o = context.ItechUsers.Where(m => m.CardNo == cardno && m.Password == passowrd && m.Enabled == true && m.Deleted == false).Include(m => m.AspNetRoles).ToList();
            }
        }
        catch (Exception ex)
        {
            ret.AppendLine("Błąd !!!!!!");
            ret.AppendLine(ExceptionResolver.Resolve(ex));
            throw new FaultException(ret.ToString());
        }
        return o.FirstOrDefault();
    }

       
    }
}
